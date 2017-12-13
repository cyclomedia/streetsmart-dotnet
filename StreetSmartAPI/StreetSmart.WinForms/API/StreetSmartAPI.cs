/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

using Newtonsoft.Json.Linq;

using StreetSmart.WinForms.API.Events;
using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Exceptions;
using StreetSmart.WinForms.Handlers;
using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Properties;
using StreetSmart.WinForms.Utils;

namespace StreetSmart.WinForms.API
{
  // ReSharper disable once InconsistentNaming
  internal class StreetSmartAPI : IStreetSmartAPI
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private ApiEventList _apiMeasurementEventList;
    private ApiEventList _apiViewerEventList;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Events

    public event EventHandler APIReady;

    public event EventHandler<IEventArgs<IDictionary<string, object>>> MeasurementChanged;

    public event EventHandler<IEventArgs<IViewer>> ViewerAdded;

    public event EventHandler<IEventArgs<IViewer>> ViewerRemoved;

    #endregion

    #region GUI

    public StreetSmartGUI GUI { get; }

    #endregion

    #region Properties

    public string JsThis => $"{GetType().Name}Events";

    public string JsApi => Resources.JsApi;

    private string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    private string JsLoginSuccess => $"{nameof(OnLoginSuccess).FirstCharacterToLower()}";

    private string JsLoginFailed => $"{nameof(OnLoginFailedException).FirstCharacterToLower()}";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsOnMeasurementChanged => $"{nameof(OnMeasurementChanged).FirstCharacterToLower()}";

    public string JsOnViewerAdded => $"{nameof(OnViewerAdded).FirstCharacterToLower()}";

    public string JsOnViewerRemoved => $"{nameof(OnViewerRemoved).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public StreetSmartAPI(string streetSmartLocation)
    {
      _browser = new ChromiumWebBrowser(streetSmartLocation) {Dock = DockStyle.Fill};
      _browser.RegisterJsObject(JsThis, this);
      ViewerList.RegisterJsObjects(_browser);
      _browser.FrameLoadEnd += OnFrameLoadEnd;
      _browser.DownloadHandler = new DownloadHandler();
      GUI = new StreetSmartGUI(_browser);
    }

    #endregion

    #region CefSharp Functions

    public void ShowDefTools()
    {
      if (_browser.Created)
      {
        _browser?.ShowDevTools();
      }
    }

    public void CloseDefTools()
    {
      if (_browser.Created)
      {
        _browser?.CloseDevTools();
      }
    }

    #endregion

    #region Interface Functions

    public async Task<IOverlay> AddOverlay(IOverlay overlay)
    {
      string script = GetScript($"addOverlay({overlay})");
      ((Overlay) overlay)?.FillInParameters((Dictionary<string, object>) await CallJsAsync(script));
      return overlay;
    }

    public void RemoveOverlay(string layerId)
    {
      _browser.ExecuteScriptAsync(GetScript($"removeOverlay({layerId.ToQuote()})"));
    }

    [Obsolete("Obsolete. Use StreetSmartApi.open instead.", true)]
    public IPanoramaViewer AddPanoramaViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return null;
    }

    public void Destroy(IOptions options)
    {
      RemoveMeasurementEvents();
      RemoveViewerEvents();
      _browser.ExecuteScriptAsync(GetScript($"destroy({options})"));
      ViewerList.ClearViewers();
    }

    [Obsolete("", true)]
    public void DestroyPanoramaViewer(IPanoramaViewer viewer)
    {
    }

    public async Task<dynamic> GetActiveMeasurement()
    {
      var script = GetScriptStringify("getActiveMeasurement()");
      var measurement = (string)await CallJsAsync(script);
      return JObject.Parse(measurement);
    }

    public async Task<IAddressSettings> GetAddressSettings()
    {
      return new AddressSettings((Dictionary<string, object>) await CallJsAsync(GetScript("getAddressSettings()")));
    }

    public async Task<bool> GetApiReadyState()
    {
      return (bool) await CallJsAsync(GetScript("getApiReadyState()"));
    }

    public async Task<string> GetApplicationName()
    {
      return (string) await CallJsAsync(GetScript("getApplicationName()"));
    }

    public async Task<string> GetApplicationVersion()
    {
      return (string) await CallJsAsync(GetScript("getApplicationVersion()"));
    }

    public async Task<string[]> GetDebugLogs()
    {
      return ((object[]) await CallJsAsync(GetScript("getDebugLogs()"))).Cast<string>().ToArray();
    }

    public async Task<string[]> GetPermissions()
    {
      return ((object[]) await CallJsAsync(GetScript("getPermissions()"))).Cast<string>().ToArray();
    }

    public async Task Init(IOptions options)
    {
      string script = $@"{options.Element}{JsApi}.init({options}).then(function(){{{JsThis}.{JsLoginSuccess}()}},
                      function(e){{{JsThis}.{JsLoginFailed}(e.message)}});";
      object result = await CallJsAsync(script);

      if (result is Exception)
      {
        throw (Exception) result;
      }

      AddViewerEvents();
    }

    public async Task<IList<IViewer>> Open(string query, IViewerOptions options)
    {
      string typeResult = "r";      
      string resultType = "resultOpenByQuery";

      string script = $@"var {resultType};{JsApi}.open({query.ToQuote()}{options}).catch
                      (function(e){{{JsThis}.{JsImNotFound}(e.message)}}).then
                      (function({typeResult}){{{resultType}={typeResult};{JsThis}.{JsResult}('{resultType}');}});";

      object result = await CallJsAsync(script);

      if (result is Exception)
      {
        throw (Exception) result;
      }

      return await ViewerList.ToViewersFromJsValue(options.ViewerTypes.GetTypes(), (string) result);
    }

    public void StartMeasurementMode(IPanoramaViewer viewer, IMeasurementOptions options)
    {
      _browser.ExecuteScriptAsync(GetScript($"startMeasurementMode({((PanoramaViewer) viewer).Name}{options})"));
    }

    public void StopMeasurementMode()
    {
      _browser.ExecuteScriptAsync(GetScript("stopMeasurementMode()"));
    }

    #endregion

    #region events ChromiumWebBrowser

    public void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
    {
      if (e.Frame.IsMain)
      {
        APIReady?.Invoke(this, EventArgs.Empty);
      }
    }

    #endregion

    #region Callbacks StreetSmartAPI

    public void OnResult(object result)
    {
      _resultTask.TrySetResult(result);
    }

    public void OnLoginSuccess()
    {
      _resultTask.TrySetResult(true);
    }

    public void OnLoginFailedException(string message)
    {
      _resultTask.TrySetResult(new StreetSmartLoginFailedException(message));
    }

    public void OnImageNotFoundException(string message)
    {
      _resultTask.TrySetResult(new StreetSmartImageNotFoundException(message));
    }

    public void OnMeasurementChanged(Dictionary<string, object> args)
    {
      MeasurementChanged?.Invoke(this, new EventArgs<Dictionary<string, object>>(args));
    }

    public void OnViewerAdded(string name, string type)
    {
      string jsName = new JsNameGenerator(1)[0];
      _browser.ExecuteScriptAsync($"var {jsName}={name};");
      IViewer viewer = ViewerList.ToViewer(type, jsName);
      ViewerAdded?.Invoke(this, new EventArgs<IViewer>(viewer));

      if (viewer is PanoramaViewer)
      {
        ReAssignMeasurementEvents();
      }
    }

    public async void OnViewerRemoved(string name, string type)
    {
      IViewer viewer = await ViewerList.RemoveViewerFromJsValue(type, name);
      ViewerRemoved?.Invoke(this, new EventArgs<IViewer>(viewer));
    }

    #endregion

    #region Functions

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    private string GetScript(string funcName)
    {
      return $"{JsThis}.{JsResult}({JsApi}.{funcName});";
    }

    private string GetScriptStringify(string funcName)
    {
      return $"{JsThis}.{JsResult}(JSON.stringify({JsApi}.{funcName}));";
    }

    private void ReAssignMeasurementEvents()
    {
      RemoveMeasurementEvents();
      AddMeasurementEvents();
    }

    private void AddViewerEvents()
    {
      if (_apiViewerEventList == null)
      {
        _apiViewerEventList = new ApiEventList
        {
          new ViewerEvent(this, "VIEWER_ADDED", JsOnViewerAdded),
          new ViewerEvent(this, "VIEWER_REMOVED", JsOnViewerRemoved)
        };

        _browser.ExecuteScriptAsync($"{_apiViewerEventList}");
      }
    }

    public void AddMeasurementEvents()
    {
      if (_apiMeasurementEventList == null)
      {
        _apiMeasurementEventList = new ApiEventList
        {
          new MeasurementEvent(this, "MEASUREMENT_CHANGED", JsOnMeasurementChanged)
        };

        _browser.ExecuteScriptAsync($"{_apiMeasurementEventList}");
      }
    }

    public void RemoveViewerEvents()
    {
      if (_apiViewerEventList != null)
      {
        _browser.ExecuteScriptAsync(_apiViewerEventList.Destroy);
        _apiViewerEventList = null;
      }
    }

    public void RemoveMeasurementEvents()
    {
      if (_apiMeasurementEventList != null)
      {
        _browser.ExecuteScriptAsync(_apiMeasurementEventList.Destroy);
        _apiMeasurementEventList = null;
      }
    }

    #endregion
  }
}
