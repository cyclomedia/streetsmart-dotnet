/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2021, CycloMedia, All rights reserved.
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
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

using CefSharp;

#if WINFORMS
using System.Windows.Forms;

using CefSharp.WinForms;

using StreetSmart.WinForms;
using StreetSmart.WinForms.Properties;
#else
using System.Threading;

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
  internal class StreetSmartAPI : APIBase, IStreetSmartAPI
  {
    #region Members

    private ApiEventList _apiMeasurementEventList;
    private ApiEventList _apiViewerEventList;
    private string _streetSmartLocation;

    #endregion

    #region Events

    public event EventHandler APIReady;

    public event EventHandler<IEventArgs<IFeatureCollection>> MeasurementChanged;

    public event EventHandler<IEventArgs<IViewer>> ViewerAdded;

    public event EventHandler<IEventArgs<IViewer>> ViewerRemoved;

    #endregion

    #region Settings / Shortcuts

    public ISettings Settings { get; private set; }

    public IShortcuts Shortcuts { get; private set; }

    #endregion

    #if WINFORMS
    #region GUI

    public StreetSmartGUI GUI { get; }

    #endregion
    #endif

    #region Properties

    private string JsApi => Resources.JsApi;

    public string ApiId { get; private set; }

    protected override string CallFunctionBase => $"{JsApi}";

    #endregion

    #region Callback definitions

    public string JsOnMeasurementChanged => $"{nameof(OnMeasurementChanged).FirstCharacterToLower()}";

    public string JsOnViewerAdded => $"{nameof(OnViewerAdded).FirstCharacterToLower()}";

    public string JsOnViewerRemoved => $"{nameof(OnViewerRemoved).FirstCharacterToLower()}";

    public string JsOnViewerUpdated => $"{nameof(OnViewerUpdated).FirstCharacterToLower()}";

    #endregion

    #region Constructor
    #if WINFORMS
    public StreetSmartAPI(string streetSmartLocation)
    {
      InitApi(streetSmartLocation);
      Browser = new ChromiumWebBrowser(streetSmartLocation) { Dock = DockStyle.Fill };
      RegisterBrowser();
      GUI = new StreetSmartGUI(Browser);
    }
    #else
    public StreetSmartAPI(string streetSmartLocation)
    {
      InitApi(streetSmartLocation);
    }

    public void InitBrowser(ChromiumWebBrowser browser)
    {
      Browser = browser;
      Browser.Address = _streetSmartLocation;
      RegisterBrowser();
    }
    #endif

    ~StreetSmartAPI()
    {
      ViewerList.DeleteViewerList(ApiId);
    }

    #endregion

    #region CefSharp Functions
    #if WINFORMS
    public void ShowDevTools()
    {
      ShowDeveloperTools();
    }

    public void CloseDevTools()
    {
      CloseDeveloperTools();
    }
    #else
    public void ShowDevTools()
    {
      Browser?.Dispatcher?.BeginInvoke(new ThreadStart(ShowDeveloperTools));
    }

    public void CloseDevTools()
    {
      Browser?.Dispatcher?.BeginInvoke(new ThreadStart(CloseDeveloperTools));
    }

    public void RestartStreetSmart()
    {
      RestartStreetSmart(Resources.StreetSmartLocation);
    }

    public void RestartStreetSmart(string streetSmartLocation)
    {
      _streetSmartLocation = streetSmartLocation;
      Browser.Address = streetSmartLocation;
    }

    #endif
    #endregion

    #region Interface Functions

    public async Task<IGeoJsonOverlay> AddOverlay(IGeoJsonOverlay overlay)
    {
      if (!overlay?.GeoJson?.IsValidJson() ?? true)
      {
        throw new StreetSmartJsonException("Json is not valid");
      }

      ((Overlay) overlay).FillInParameters(ToDictionary(await CallJsGetScriptAsync($"addOverlay({overlay})")));
      return overlay;
    }

    public async Task<IWFSOverlay> AddWFSLayer(IWFSOverlay overlay)
    {
      int processId = GetProcessId;
      string script = GetScript($"addWFSLayer({overlay})", processId);
      ((Overlay) overlay)?.FillInParameters(ToDictionary(await CallJsAsync(script, processId)));
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
        (ApiId, new List<ViewerType> {ViewerType.Panorama, ViewerType.Oblique, ViewerType.PointCloud}, ToString(result));
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

      return await ViewerList.ToViewersFromJsValue(ApiId,
        new List<ViewerType> {ViewerType.Panorama, ViewerType.Oblique, ViewerType.PointCloud}, ToString(result));
    }

    public async Task RemoveOverlay(string layerId)
    {
      await CallJsGetScriptAsync($"removeOverlay({layerId.ToQuote()})");
    }

    public async Task Destroy(IOptions options)
    {
      if (Browser.GetBrowser() != null)
      {
        RemoveMeasurementEvents();
        RemoveViewerEvents();
        await CallJsGetScriptAsync($"destroy({options})");
        ViewerList.ClearViewers(ApiId);
      }
    }

    public async Task<IFeatureCollection> GetActiveMeasurement()
    {
      return new FeatureCollection(ToDictionary(await CallJsGetScriptAsync("getActiveMeasurement()")), true);
    }

    public async Task<IAddressSettings> GetAddressSettings()
    {
      return new AddressSettings(ToDictionary(await CallJsGetScriptAsync("getAddressSettings()")));
    }

    public async Task<bool> GetApiReadyState()
    {
      return Browser != null && ToBool(await CallJsGetScriptAsync("getApiReadyState()"));
    }

    public async Task<string> GetApplicationName()
    {
      return ToString(await CallJsGetScriptAsync("getApplicationName()"));
    }

    public async Task<string> GetApplicationVersion()
    {
      return ToString(await CallJsGetScriptAsync("getApplicationVersion()"));
    }

    public async Task<string[]> GetDebugLogs()
    {
      return ToArray(await CallJsGetScriptAsync("getDebugLogs()")).Cast<string>().ToArray();
    }

    public async Task<string[]> GetPermissions()
    {
      return ToArray(await CallJsGetScriptAsync("getPermissions()")).Cast<string>().ToArray();
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

      return await ViewerList.ToViewersFromJsValue(ApiId, options.ViewerTypes.GetTypes(), ToString(result));
    }

    public void SetActiveMeasurement(IFeatureCollection measurement)
    {
      Browser.ExecuteScriptAsync(GetScript($"setActiveMeasurement({measurement})"));
    }

    public void SetOverlayDrawDistance(int distance)
    {
      Browser.ExecuteScriptAsync(GetScript($"setOverlayDrawDistance({distance})"));
    }

    public async Task StartMeasurementMode(IViewer viewer, IMeasurementOptions options)
    {
      int processId = GetProcessId;
      string funcId = $"{nameof(StartMeasurementMode)}{processId}".ToQuote();
      string startMeasurement = GetScript($"startMeasurementMode({((Viewer) viewer).Name}{options})", processId);
      string script = $@"try{{{startMeasurement}}}catch(e){{{JsThis}.{JsMeasurementFailed}(e.message,{funcId})}}";
      object result = await CallJsAsync(script, processId);

      if (result is Exception exception)
      {
        throw exception;
      }
    }

    public void StopMeasurementMode()
    {
      Browser.ExecuteScriptAsync(GetScript("stopMeasurementMode()"));
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

    public void OnMeasurementChanged(ExpandoObject args)
    {
      MeasurementChanged?.Invoke(this, new EventArgs<IFeatureCollection>(new FeatureCollection(args, true)));
    }

    public void OnViewerAdded(string id, string type, string name)
    {
      string jsName = $"type{Guid.NewGuid():N}";
      Browser.ExecuteScriptAsync($"var {jsName}={name}['{id}'];");
      IViewer viewer = ViewerList.ToViewer(ApiId, type, jsName);
      ((Viewer) viewer).JsObjectCollection = name;
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

    public async void OnViewerUpdated(string oldName, string name, string type)
    {
      string jsName = $"type{Guid.NewGuid():N}";
      Browser.ExecuteScriptAsync($"var {jsName}={name};");
      IViewer iViewer = await ViewerList.ToViewerFromJsValue(ApiId, type, oldName);
      Viewer viewer = (Viewer) iViewer;

      if (viewer != null)
      {
        viewer.DisConnectEvents();
        string removedName = viewer.Name;
        viewer.Name = jsName;
        ViewerList.ReRegisterViewer(ApiId, type, removedName, viewer);
        viewer.ReConnectEvents();

        if (viewer is PanoramaViewer)
        {
          ReAssignMeasurementEvents();
        }
      }
    }

    #endregion

    #region Functions

    public void InitApi(string streetSmartLocation)
    {
      ApiId = $"{Guid.NewGuid():N}";
      _streetSmartLocation = streetSmartLocation;
    }

    public void RegisterBrowser()
    {
      Settings = new Settings(Browser);
      Shortcuts = new Shortcuts(Browser);
      RegisterThisJsObject();
      ViewerList.CreateViewerList(ApiId);
      ViewerList.RegisterJsObjects(ApiId, Browser);
      Browser.FrameLoadEnd += OnFrameLoadEnd;
      Browser.DownloadHandler = new DownloadHandler();
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
          new ViewerAddedEvent(this, "VIEWER_ADDED", JsOnViewerAdded),
          new ViewerRemovedEvent(this, "VIEWER_REMOVED", JsOnViewerRemoved),
          new ViewerUpdateEvent(this, "VIEWER_UPDATED", JsOnViewerUpdated)
        };

        Browser?.ExecuteScriptAsync($"{_apiViewerEventList}");
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

        Browser?.ExecuteScriptAsync($"{_apiMeasurementEventList}");
      }
    }

    public void RemoveViewerEvents()
    {
      if (_apiViewerEventList != null)
      {
        Browser?.ExecuteScriptAsync(_apiViewerEventList.Destroy);
        _apiViewerEventList = null;
      }
    }

    public void RemoveMeasurementEvents()
    {
      if (_apiMeasurementEventList != null)
      {
        Browser?.ExecuteScriptAsync(_apiMeasurementEventList.Destroy);
        _apiMeasurementEventList = null;
      }
    }

    private void ShowDeveloperTools()
    {
      if (Browser.IsBrowserInitialized)
      {
        Browser?.ShowDevTools();
      }
    }

    private void CloseDeveloperTools()
    {
      if (Browser.IsBrowserInitialized)
      {
        Browser?.CloseDevTools();
      }
    }

    #endregion
  }
}
