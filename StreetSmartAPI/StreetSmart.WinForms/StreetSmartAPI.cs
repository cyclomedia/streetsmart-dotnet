/*
 * Integration in ArcMap for Cycloramas
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

using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Interfaces;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming

  internal class StreetSmartAPI : IStreetSmartAPI
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private readonly PanoramaViewerEvents _cycloramaViewerEvents;

    #endregion

    #region Tasks

    private TaskCompletionSource<bool> _apiReadyStateTask;
    private TaskCompletionSource<string> _applicationNameTask;
    private TaskCompletionSource<string> _applicationVersionTask;
    private TaskCompletionSource<object[]> _permissionsTask;

    #endregion

    #region Events

    public event EventHandler FrameLoaded;
    public event EventHandler<EventInitArgs> InitComplete;

    #endregion

    #region GUI

    public StreetSmartGUI GUI { get; }

    #endregion

    #region Constructor

    public StreetSmartAPI(string streetSmartLocation)
    {
      _browser = new ChromiumWebBrowser(streetSmartLocation) {Dock = DockStyle.Fill};
      _browser.RegisterJsObject("streetSmartAPIEvents", this);
      _cycloramaViewerEvents = new PanoramaViewerEvents(_browser);
      _browser.FrameLoadEnd += OnFrameLoadEnd;
      _browser.DownloadHandler = new DownloadHandler();
      GUI = new StreetSmartGUI(_browser);
    }

    #endregion

    #region Functions

    public void Init(string username, string password, string apiKey, string srs)
    {
      string script =
        $@"StreetSmartApi.init({{username:'{username}', password:'{password}', apiKey:'{apiKey}',
           srs:'{srs}'}}).then(function() {{streetSmartAPIEvents.onSuccess()}},
           function(e) {{streetSmartAPIEvents.onFailed(e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void Init(string username, string password, string apiKey, string srs, string locale)
    {
      string script =
        $@"StreetSmartApi.init({{username:'{username}', password:'{password}', apiKey:'{apiKey}',
           srs:'{srs}', locale:'{locale}'}}).then(function() {{streetSmartAPIEvents.onInitSuccess()}},
           function(e) {{streetSmartAPIEvents.onInitFailed(e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void Init(string username, string password, string apiKey, string srs, string locale, string configurationUrl)
    {
      string script =
        $@"StreetSmartApi.init({{username:'{username}', password:'{password}', apiKey:'{apiKey}',
           srs:'{srs}', locale:'{locale}', configurationUrl:'{configurationUrl}'}}).then(function() {{streetSmartAPIEvents.onInitSuccess()}},
           function(e) {{streetSmartAPIEvents.onInitFailed(e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public IPanoramaViewer AddPanoramaViewer(string viewerObjectName)
    {
      PanoramaViewer viewer = new PanoramaViewer(_browser, viewerObjectName);
      _cycloramaViewerEvents.AddListener(viewer);
      return viewer;
    }

    public IPanoramaViewer AddPanoramaViewer(string viewerObjectName, string domElementName, string domElementScript)
    {
      PanoramaViewer viewer = new PanoramaViewer(_browser, viewerObjectName, domElementName, domElementScript);
      _cycloramaViewerEvents.AddListener(viewer);
      return viewer;
    }

    public IPanoramaViewer AddPanoramaViewer(string viewerObjectName, bool recordingsVisible,
      bool timeTravelEnabled)
    {
      PanoramaViewer viewer = new PanoramaViewer(_browser, viewerObjectName, recordingsVisible, timeTravelEnabled);
      _cycloramaViewerEvents.AddListener(viewer);
      return viewer;
    }

    public IPanoramaViewer AddPanoramaViewer(string viewerObjectName, bool recordingsVisible,
      bool timeTravelEnabled, string domElementName, string domElementScript)
    {
      PanoramaViewer viewer = new PanoramaViewer(_browser, viewerObjectName, recordingsVisible, timeTravelEnabled,
        domElementName, domElementScript);
      _cycloramaViewerEvents.AddListener(viewer);
      return viewer;
    }

    public void DestroyPanoramaViewer(IPanoramaViewer panoramaViewer)
    {
      PanoramaViewer viewer = (PanoramaViewer) panoramaViewer;
      _cycloramaViewerEvents.RemoveListener(viewer);
      string objectName = viewer.ViewerObjectName;
      string domElementName = viewer.DomElementName;
      string script = $@"StreetSmartApi.destroyPanoramaViewer({objectName},{domElementName});";
      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Async Functions

    public async Task<bool> getAPIReadyStateAsync()
    {
     _apiReadyStateTask = new TaskCompletionSource<bool>();
      string script = "streetSmartAPIEvents.onAPIReadyState(StreetSmartApi.getAPIReadyState());";
      _browser.ExecuteScriptAsync(script);
      await _apiReadyStateTask.Task;
      return _apiReadyStateTask.Task.Result;
    }

    public async Task<string> getApplicationNameAsync()
    {
      _applicationNameTask = new TaskCompletionSource<string>();
      string script = "streetSmartAPIEvents.onApplicationName(StreetSmartApi.getApplicationName());";
      _browser.ExecuteScriptAsync(script);
      await _applicationNameTask.Task;
      return _applicationNameTask.Task.Result;
    }

    public async Task<string> getApplicationVersionAsync()
    {
      _applicationVersionTask = new TaskCompletionSource<string>();
      string script = "streetSmartAPIEvents.onApplicationVersion(StreetSmartApi.getApplicationVersion());";
      _browser.ExecuteScriptAsync(script);
      await _applicationVersionTask.Task;
      return _applicationVersionTask.Task.Result;
    }

    public async Task<string[]> getPermissionsAsync()
    {
      _permissionsTask = new TaskCompletionSource<object[]>();
      string script = "streetSmartAPIEvents.onPermissions(StreetSmartApi.getPermissions());";
      _browser.ExecuteScriptAsync(script);
      await _permissionsTask.Task;
      object[] permissions = _permissionsTask.Task.Result;
      return permissions.Cast<string>().ToArray();
    }

    #endregion

    #region events ChromiumWebBrowser

    public void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
    {
      if (e.Frame.IsMain)
      {
        FrameLoaded?.Invoke(this, EventArgs.Empty);
      }
    }

    #endregion

    #region Callbacks StreetSmartAPI

    public void OnInitSuccess()
    {
      EventInitArgs initArgs = new EventInitArgs {Success = true, ErrorMessage = string.Empty};
      InitComplete?.Invoke(this, initArgs);
    }

    public void OnInitFailed(string message)
    {
      EventInitArgs initArgs = new EventInitArgs {Success = false, ErrorMessage = message};
      InitComplete?.Invoke(this, initArgs);
    }

    public void OnAPIReadyState(bool state)
    {
      _apiReadyStateTask.TrySetResult(state);
    }

    public void OnApplicationName(string name)
    {
      _applicationNameTask.TrySetResult(name);
    }

    public void OnApplicationVersion(string version)
    {
      _applicationVersionTask.TrySetResult(version);
    }

    public void OnPermissions(object[] permissions)
    {
      _permissionsTask.TrySetResult(permissions);
    }

    #endregion
  }

  // ReSharper restore InconsistentNaming
}
