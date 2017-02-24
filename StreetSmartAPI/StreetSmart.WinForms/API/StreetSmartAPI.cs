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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Exceptions;
using StreetSmart.WinForms.Handlers;
using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Properties;

namespace StreetSmart.WinForms.API
{
  // ReSharper disable once InconsistentNaming
  internal class StreetSmartAPI : IStreetSmartAPI
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private readonly PanoramaViewerList _cycloramaViewerList;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Events

    public event EventHandler APIReady;

    #endregion

    #region GUI

    public StreetSmartGUI GUI { get; }

    #endregion

    #region Properties

    private string JsThis => $"{GetType().Name}Events";

    private string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    private string JsSuccess => $"{nameof(OnSuccess).FirstCharacterToLower()}";

    private string JsError => $"{nameof(OnError).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public StreetSmartAPI(string streetSmartLocation)
    {
      _browser = new ChromiumWebBrowser(streetSmartLocation) {Dock = DockStyle.Fill};
      _browser.RegisterJsObject(JsThis, this);
      _cycloramaViewerList = new PanoramaViewerList(_browser);
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

    #region Functions

    public IPanoramaViewer AddPanoramaViewer(IDomElement domElement, IPanoramaViewerOptions viewerOptions)
    {
      return _cycloramaViewerList.AddViewer(domElement, viewerOptions);
    }

    public void DestroyPanoramaViewer(IPanoramaViewer panoramaViewer)
    {
      _cycloramaViewerList.DestroyViewer((PanoramaViewer) panoramaViewer);
    }

    public async Task<IAddressSettings> GetAddressSettingsAsync()
    {
      return new AddressSettings((Dictionary<string, object>) await CallJsAsync(GetScript("getAddressSettings()")));
    }

    public async Task<bool> GetAPIReadyStateAsync()
    {
      return (bool) await CallJsAsync(GetScript("getAPIReadyState()"));
    }

    public async Task<string> GetApplicationNameAsync()
    {
      return (string) await CallJsAsync(GetScript("getApplicationName()"));
    }

    public async Task<string> GetApplicationVersionAsync()
    {
      return (string) await CallJsAsync(GetScript("getApplicationVersion()"));
    }

    public async Task<string[]> GetPermissionsAsync()
    {
      return ((object[]) await CallJsAsync(GetScript("getPermissions()"))).Cast<string>().ToArray();
    }

    public async Task InitAsync(IOptions options)
    {
      string script = $@"{Resources.JsApi}.init({options}).then(function(){{{JsThis}.{JsSuccess}()}},
                      function(e){{{JsThis}.{JsError}(e.message)}});";
      object result = await CallJsAsync(script);

      if (result is Exception)
      {
        throw (Exception) result;
      }
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

    public void OnSuccess()
    {
      _resultTask.TrySetResult(true);
    }

    public void OnError(string message)
    {
      _resultTask.TrySetResult(new StreetSmartLoginFailedException(message));
    }

    #endregion

    #region Functions no interface

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    private string GetScript(string funcName)
    {
      return $"{JsThis}.{JsResult}({Resources.JsApi}.{funcName});";
    }

    #endregion
  }
}
