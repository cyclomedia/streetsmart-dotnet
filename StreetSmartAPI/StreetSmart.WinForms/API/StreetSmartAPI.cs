/*
 * Street Smart .NET integration
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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
    private ApiEventList _apiEventList;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Events

    public event EventHandler APIReady;

    public event EventHandler<IEventArgs<IDictionary<string, object>>> MeasurementChanged;

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

    public IPanoramaViewer AddPanoramaViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      IPanoramaViewer panoramaViewer = ViewerList.AddPanoramaViewer(element, options);
      AddMeasurementEvents();
      return panoramaViewer;
    }

    public void Destroy(IOptions options)
    {
      RemoveMeasurementEvents();
      _browser.ExecuteScriptAsync(GetScript($"destroy({options})"));
      ViewerList.ClearViewers();
    }

    public void DestroyPanoramaViewer(IPanoramaViewer viewer)
    {
      ViewerList.DestroyPanoramaViewer(viewer);
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
    }

    public async Task<IList<IViewer>> OpenByQuery(string query, IViewerOptions options)
    {
      string typeResult = "r";      
      string resultType = "result";
      JsNameGenerator names = new JsNameGenerator(options.ViewerTypes.GetTypes().Count);

      string script = $@"{names.JsGetTypeDef()}{JsApi}.open({query.ToQuote()}{options}).catch
                      (function(e){{{JsThis}.{JsImNotFound}(e.message)}}).then
                      (function({typeResult}){{{names.JsAssignToNames(typeResult)}
                      {names.JsToResultTypes(resultType)}{JsThis}.{JsResult}({resultType});}});";
      object result = await CallJsAsync(script);

      if (result is Exception)
      {
        throw (Exception) result;
      }

      IList<IViewer> viewers = ViewerList.ToViewerList((Dictionary<string, object>) result);
      AddMeasurementEvents();
      return viewers;
    }

    public void StartMeasurementMode(IPanoramaViewer viewer, IMeasurementOptions options)
    {
      _browser.ExecuteScriptAsync(GetScript($"startMeasurementMode({((PanoramaViewer) viewer).Name}{options})"));
    }

    public void StopMeasurementMode()
    {
      _browser.ExecuteScriptAsync(GetScript("stopMeasurementMode()"));
    }

    public async Task<dynamic> GetMeasurementInfo()
    {
      var script = GetScriptStringify("getActiveMeasurement()");
      var measurement = (string) await CallJsAsync(script);
      return JObject.Parse(measurement);
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

    public void AddOverlay(string name, string geoJson, string sourceSrs)
    {
      var script = GetScript($"addOverlay({name.ToQuote()}, {geoJson.ToQuote()}, {sourceSrs.ToQuote()})");
      _browser.ExecuteScriptAsync(script);
    }

    public void AddOverlay(string name, string geoJson)
    {
      var json = JObject.Parse(geoJson);
      var script = GetScript($"addOverlay({name.ToQuote()}, {json})");
      _browser.ExecuteScriptAsync(script);
    }

    public void OnMeasurementChanged(Dictionary<string, object> args)
    {
      MeasurementChanged?.Invoke(this, new EventArgs<Dictionary<string, object>>(args));
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

    public void AddMeasurementEvents()
    {
      if (_apiEventList == null)
      {
        _apiEventList = new ApiEventList
        {
          new MeasurementEvent(this, "MEASUREMENT_CHANGED", JsOnMeasurementChanged)
        };

        _browser.ExecuteScriptAsync($"{_apiEventList}");
      }
    }

    public void RemoveMeasurementEvents()
    {
      if (_apiEventList != null)
      {
        _browser.ExecuteScriptAsync($"{_apiEventList.Destroy}");
        _apiEventList = null;
      }
    }

    #endregion
  }
}
