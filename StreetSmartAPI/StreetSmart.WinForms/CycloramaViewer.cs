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
using CefSharp;
using CefSharp.WinForms;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms
{
  internal class CycloramaViewer : ICycloramaViewer
  {
    private readonly ChromiumWebBrowser _browser;
    private readonly string _viewerObjectName;

    public event EventHandler RecordingClick;
    public event EventHandler ImageChanged;
    public event EventHandler ViewChanged;
    public event EventHandler ViewLoadStarted;
    public event EventHandler ViewLoaded;
    public event EventHandler TileLoadError;

    public CycloramaViewer(ChromiumWebBrowser browser, CycloramaViewerEvents cycloramaViewerEvents, string viewerObjectName)
    {
      _browser = browser;
      _viewerObjectName = viewerObjectName;
      cycloramaViewerEvents.AddListner(this);
      string script =
        $@"var domElement = document.createElement('div');
          document.body.appendChild(domElement);
          var {_viewerObjectName} = StreetSmartApi.addPanoramaViewer(domElement);";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByImageId(string imageId, string srsName)
    {
      string script = $@"{_viewerObjectName}.openByImageId('{imageId}', '{srsName}');";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateLeft(double deltaYaw)
    {
      var script = $"{_viewerObjectName}.rotateLeft({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateRight(double deltaYaw)
    {
      var script = $"{_viewerObjectName}.rotateRight({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void GetRecording()
    {
      var script = $"rec = {_viewerObjectName}.getRecording();";
      _browser.ExecuteScriptAsync(script);
    }

    // todo: add the other functions of the panorama viewer

    #region events

    public void OnRecordingClick()
    {
      RecordingClick?.Invoke(this, EventArgs.Empty);
    }

    public void OnImageChanged()
    {
      ImageChanged?.Invoke(this, EventArgs.Empty);
    }

    public void OnViewChanged()
    {
      ViewChanged?.Invoke(this, EventArgs.Empty);
    }

    public void OnViewLoadStarted()
    {
      ViewLoadStarted?.Invoke(this, EventArgs.Empty);
    }

    public void OnViewLoaded()
    {
      ViewLoaded?.Invoke(this, EventArgs.Empty);
    }

    public void OnTileLoadError()
    {
      TileLoadError?.Invoke(this, EventArgs.Empty);
    }

    #endregion
  }
}
