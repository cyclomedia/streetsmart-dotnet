/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using CefSharp;

#if WINFORMS
using System.Windows.Forms;

using CefSharp.WinForms;

using StreetSmart.WinForms;
using StreetSmart.WinForms.Properties;
#else
using CefSharp.Wpf;

using StreetSmart.Wpf.Properties;
#endif

using StreetSmart.Common.API.Events;
using StreetSmart.Common.Data;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Events;
using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Handlers;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal class StreetSmartAPI : IStreetSmartAPI
  {
    #region Members

    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private ChromiumWebBrowser _browser;
    private int _processId;

    private ApiEventList _apiMeasurementEventList;
    private ApiEventList _apiViewerEventList;

    #endregion

    #region Tasks

    private readonly Dictionary<string, TaskCompletionSource<object>> _resultTask;

    #endregion

    #region Events

    public event EventHandler APIReady;

    public event EventHandler<IEventArgs<IFeatureCollection>> MeasurementChanged;

    public event EventHandler<IEventArgs<IViewer>> ViewerAdded;

    public event EventHandler<IEventArgs<IViewer>> ViewerRemoved;

    #endregion

    #if WINFORMS
    #region GUI

    public StreetSmartGUI GUI { get; }

    #endregion
    #endif

    #region Properties

    public string StreetSmartLocation { get; set; }

    public string JsThis => $"{GetType().Name}Events";

    public string JsApi => Resources.JsApi;

    public string ApiId { get; }

    private string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    private string JsLoginSuccess => $"{nameof(OnLoginSuccess).FirstCharacterToLower()}";

    private string JsLoginFailed => $"{nameof(OnLoginFailedException).FirstCharacterToLower()}";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsCloseViewerException => $"{nameof(OnViewerCloseException).FirstCharacterToLower()}";

    public string JsOnMeasurementChanged => $"{nameof(OnMeasurementChanged).FirstCharacterToLower()}";

    public string JsOnViewerAdded => $"{nameof(OnViewerAdded).FirstCharacterToLower()}";

    public string JsOnViewerRemoved => $"{nameof(OnViewerRemoved).FirstCharacterToLower()}";

    public int GetProcessId => _processId = (_processId + 1) % 10000;

    #endregion

    #region Constructor
    #if WINFORMS
    public StreetSmartAPI(string streetSmartLocation)
    {
      ApiId = $"{Guid.NewGuid():N}";
      StreetSmartLocation = streetSmartLocation;
      _resultTask = new Dictionary<string, TaskCompletionSource<object>>();
      _browser = new ChromiumWebBrowser(streetSmartLocation) { Dock = DockStyle.Fill };
      _browser.RegisterJsObject(JsThis, this);
      ViewerList.CreateViewerList(ApiId);
      ViewerList.RegisterJsObjects(ApiId, _browser);
      _browser.FrameLoadEnd += OnFrameLoadEnd;
      _browser.DownloadHandler = new DownloadHandler();
      GUI = new StreetSmartGUI(_browser);
      _processId = 0;
    }
    #else
    public StreetSmartAPI(string streetSmartLocation)
    {
      ApiId = $"{Guid.NewGuid():N}";
      StreetSmartLocation = streetSmartLocation;
      _resultTask = new Dictionary<string, TaskCompletionSource<object>>();
      _processId = 0;
    }

    public void InitBrowser(ChromiumWebBrowser browser)
    {
      _browser = browser;
      _browser.Address = StreetSmartLocation;
      _browser.RegisterJsObject(JsThis, this);
      ViewerList.CreateViewerList(ApiId);
      ViewerList.RegisterJsObjects(ApiId, _browser);
      _browser.FrameLoadEnd += OnFrameLoadEnd;
      _browser.DownloadHandler = new DownloadHandler();
    }
    #endif

    ~StreetSmartAPI()
    {
      ViewerList.DeleteViewerList(ApiId);
    }

    #endregion

    #region CefSharp Functions

    public void ShowDevTools()
    {
      if (_browser.IsBrowserInitialized)
      {
        _browser?.ShowDevTools();
      }
    }

    public void CloseDevTools()
    {
      if (_browser.IsBrowserInitialized)
      {
        _browser?.CloseDevTools();
      }
    }

    #endregion

    #region Interface Functions
    #if WPF
    public void RestartStreetSmart()
    {
      RestartStreetSmart(Resources.StreetSmartLocation);
    }

    public void RestartStreetSmart(string streetSmartLocation)
    {
      StreetSmartLocation = streetSmartLocation;
      _browser.Address = streetSmartLocation;
    }

    #endif
    public async Task<IOverlay> AddOverlay(IOverlay overlay)
    {
      int processId = GetProcessId;
      string script = GetScript($"addOverlay({overlay})", processId);
      ((Overlay) overlay)?.FillInParameters((Dictionary<string, object>) await CallJsAsync(script, processId));
      return overlay;
    }

    public async Task<IList<IViewer>> CloseViewer(string viewerId)
    {
      string resultType = "resultCloseViewer";
      int processId = GetProcessId;
      string funcName = $"{nameof(CloseViewer)}{processId}".ToQuote();

      string script = $@"var {resultType};{JsApi}.closeViewer({viewerId.ToQuote()}).catch
                      (function(e){{{JsThis}.{JsCloseViewerException}(e.message,{funcName})}}).then
                      (function(r){{{resultType}=r;{JsThis}.{JsResult}('{resultType}',{funcName});}});";

      object result = await CallJsAsync(script, processId);

      if (result is Exception exception)
      {
        throw exception;
      }

      IList<IViewer> viewerList = await ViewerList.ToViewersFromJsValue
        (ApiId, new List<ViewerType> {ViewerType.Panorama, ViewerType.Oblique}, (string) result);
      IViewer removedViewer = null;

      foreach (var viewer in viewerList)
      {
        if (await viewer.GetId() == viewerId)
        {
          removedViewer = viewer;
        }
      }

      if (removedViewer != null)
      {
        viewerList.Remove(removedViewer);
      }

      return viewerList;
    }

    public async Task<IList<IViewer>> GetViewers()
    {
      string resultType = "resultGetViewers";
      int processId = GetProcessId;
      string funcId = $"{nameof(GetViewers)}{processId}".ToQuote();
      string script = $@"var {resultType}={JsApi}.getViewers();{JsThis}.{JsResult}('{resultType}',{funcId});";
      object result = await CallJsAsync(script, processId);

      return await ViewerList.ToViewersFromJsValue(ApiId, new List<ViewerType> {ViewerType.Panorama, ViewerType.Oblique},
        (string) result);
    }

    public async Task RemoveOverlay(string layerId)
    {
      await CallJsGetScriptAsync($"removeOverlay({layerId.ToQuote()})");
    }

    public async Task Destroy(IOptions options)
    {
      RemoveMeasurementEvents();
      RemoveViewerEvents();
      await CallJsGetScriptAsync($"destroy({options})");
      ViewerList.ClearViewers(ApiId);
    }

    public async Task<IFeatureCollection> GetActiveMeasurement()
    {
      return new FeatureCollection(
        (Dictionary<string, object>) await CallJsGetScriptAsync("getActiveMeasurement()"), true);
    }

    public async Task<IAddressSettings> GetAddressSettings()
    {
      return new AddressSettings((Dictionary<string, object>) await CallJsGetScriptAsync("getAddressSettings()"));
    }

    public async Task<bool> GetApiReadyState()
    {
      return _browser != null && ((bool?) await CallJsGetScriptAsync("getApiReadyState()") ?? false);
    }

    public async Task<string> GetApplicationName()
    {
      return (string) await CallJsGetScriptAsync("getApplicationName()");
    }

    public async Task<string> GetApplicationVersion()
    {
      return (string) await CallJsGetScriptAsync("getApplicationVersion()");
    }

    public async Task<string[]> GetDebugLogs()
    {
      return ((object[]) await CallJsGetScriptAsync("getDebugLogs()")).Cast<string>().ToArray();
    }

    public async Task<string[]> GetPermissions()
    {
      return ((object[]) await CallJsGetScriptAsync("getPermissions()")).Cast<string>().ToArray();
    }

    public async Task Init(IOptions options)
    {
      int processId = GetProcessId;
      string funcId = $"{nameof(Init)}{processId}".ToQuote();
      string script = $@"{options.Element}{JsApi}.init({options}).then(function(){{{JsThis}.{JsLoginSuccess}({funcId})}},
                      function(e){{{JsThis}.{JsLoginFailed}(e.message,{funcId})}});";
      object result = await CallJsAsync(script, processId);

      if (result is Exception exception)
      {
        throw exception;
      }

      AddViewerEvents();
    }

    public async Task<IList<IViewer>> Open(string query, IViewerOptions options)
    {
      int processId = GetProcessId;
      string resultType = "resultOpenByQuery";
      string funcId = $"{nameof(Open)}{processId}".ToQuote();

      string script = $@"var {resultType};{JsApi}.open({query.ToQuote()}{options}).catch
                      (function(e){{{JsThis}.{JsImNotFound}(e.message,{funcId})}}).then
                      (function(r){{{resultType}=r;{JsThis}.{JsResult}('{resultType}',{funcId});}});";

      object result = await CallJsAsync(script, processId);

      if (result is Exception exception)
      {
        throw exception;
      }

      return await ViewerList.ToViewersFromJsValue(ApiId, options.ViewerTypes.GetTypes(), (string) result);
    }

    public void SetActiveMeasurement(string measurement)
    {
      _browser.ExecuteScriptAsync(GetScript($"setActiveMeasurement({measurement})"));
    }

    public void SetOverlayDrawDistance(int distance)
    {
      _browser.ExecuteScriptAsync(GetScript($"setOverlayDrawDistance({distance})"));
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

    public void OnResult(object result, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(result);
    }

    public void OnLoginSuccess(string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(true);
    }

    public void OnLoginFailedException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartLoginFailedException(message));
    }

    public void OnImageNotFoundException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartImageNotFoundException(message));
    }

    public void OnViewerCloseException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartCloseViewerException(message));
    }

    public void OnMeasurementChanged(Dictionary<string, object> args)
    {
      MeasurementChanged?.Invoke(this, new EventArgs<IFeatureCollection>(new FeatureCollection(args, true)));
    }

    public void OnViewerAdded(string name, string type)
    {
      string jsName = $"type{Guid.NewGuid():N}";
      _browser.ExecuteScriptAsync($"var {jsName}={name};");
      IViewer viewer = ViewerList.ToViewer(ApiId, type, jsName);
      ViewerAdded?.Invoke(this, new EventArgs<IViewer>(viewer));

      if (viewer is PanoramaViewer)
      {
        ReAssignMeasurementEvents();
      }
    }

    public async void OnViewerRemoved(string name, string type)
    {
      IViewer viewer = await ViewerList.RemoveViewerFromJsValue(ApiId, type, name);
      ViewerRemoved?.Invoke(this, new EventArgs<IViewer>(viewer));
    }

    #endregion

    #region Functions

    private bool CheckResultTask(string funcName)
    {
      bool result = true;

      if (!_resultTask.ContainsKey(funcName))
      {
        _resultTask.Add(funcName, new TaskCompletionSource<object>());
        result = false;
      }

      return result;
    }

    private async Task<object> CallJsGetScriptAsync(string script, [CallerMemberName] string memberName = "")
    {
      int processId = GetProcessId;
      return await CallJsAsync(GetScript(script, processId, memberName), processId, memberName);
    }

    private async Task<object> CallJsAsync(string script, int processId, [CallerMemberName] string memberName = "")
    {
      string funcName = $"{memberName}{processId}";

      if (CheckResultTask(funcName))
      {
        _resultTask[funcName] = new TaskCompletionSource<object>();
      }

      _browser.ExecuteScriptAsync(script);
      await _resultTask[funcName].Task;
      TaskCompletionSource<object> result = _resultTask[funcName];
      _resultTask.Remove(funcName);
      return result.Task.Result;
    }

    private string GetScript(string funcName, int processId = 0, [CallerMemberName] string memberName = "")
    {
      string memberId = $"{memberName}{processId}";
      return $"{JsThis}.{JsResult}({JsApi}.{funcName},{memberId.ToQuote()});";
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
