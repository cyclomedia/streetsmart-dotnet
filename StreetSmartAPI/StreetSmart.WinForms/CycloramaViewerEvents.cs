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

using System.Collections.Generic;
using CefSharp;
using CefSharp.WinForms;

namespace StreetSmart.WinForms
{
  class CycloramaViewerEvents
  {
    private readonly List<CycloramaViewer> _listeners;
    private readonly ChromiumWebBrowser _browser;

    public CycloramaViewerEvents(ChromiumWebBrowser browser)
    {
      _browser = browser;
      _listeners = new List<CycloramaViewer>();
      // it is only possible for register a cycloramaviewer object before the initialisation of the browser is finished
      browser.RegisterJsObject("cycloramaViewerEvents", this);
    }

    public void RegisterEventHandlers()
    {
      _browser.ExecuteScriptAsync(
        @"window.addEventListener(StreetSmartApi.Events.panoramaViewer.RECORDING_CLICK, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onRecordingClick(e.detail);
            });
          window.addEventListener(StreetSmartApi.Events.panoramaViewer.IMAGE_CHANGED, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onImageChanged(e.detail);
            });
          window.addEventListener(StreetSmartApi.Events.panoramaViewer.VIEW_CHANGED, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onViewChanged(e.detail);
            });
          window.addEventListener(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_STARTED, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onViewLoadStarted(e.detail);
            });
          window.addEventListener(StreetSmartApi.Events.panoramaViewer.VIEW_LOADED, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onViewLoaded(e.detail);
            });
          window.addEventListener(StreetSmartApi.Events.panoramaViewer.TILE_LOAD_ERROR, function(e)
            {
              delete e.detail.recording.thumbs;
              cycloramaViewerEvents.onTileLoadError(e.detail);
            });");
    }

    public void AddListner(CycloramaViewer cycloramaViewer)
    {
      if (!_listeners.Contains(cycloramaViewer))
      {
        _listeners.Add(cycloramaViewer);
      }
    }

    public void RemoveListener(CycloramaViewer cycloramaViewer)
    {
      if (_listeners.Contains(cycloramaViewer))
      {
        _listeners.Remove(cycloramaViewer);
      }
    }

    public void OnRecordingClick(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnRecordingClick();
      }
    }

    public void OnImageChanged(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnImageChanged();
      }
    }

    public void OnViewChanged(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnViewChanged();
      }
    }

    public void OnViewLoadStarted(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnViewLoadStarted();
      }
    }

    public void OnViewLoaded(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnViewLoaded();
      }
    }

    public void OnTileLoadError(Dictionary<string, object> args)
    {
      foreach (var listener in _listeners)
      {
        // todo: find the cycloramaViewer
        listener.OnTileLoadError();
      }
    }
  }
}
