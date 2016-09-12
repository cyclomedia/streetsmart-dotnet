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

using System.Collections.Generic;

namespace StreetSmart.WinForms
{
  internal class PanoramaViewerEvents
  {
    #region Members

    private readonly Dictionary<string, PanoramaViewer> _listeners;
    private readonly ChromiumWebBrowser _browser;

    #endregion

    #region Constructor

    public PanoramaViewerEvents(ChromiumWebBrowser browser)
    {
      _browser = browser;
      _listeners = new Dictionary<string, PanoramaViewer>();
      browser.RegisterJsObject("panoramaViewerEvents", this);
    }

    #endregion

    #region Functions

    public void AddListener(PanoramaViewer cycloramaViewer)
    {
      string viewerObjectName = cycloramaViewer.ViewerObjectName;

      if (!_listeners.ContainsKey(viewerObjectName))
      {
        _listeners.Add(viewerObjectName, cycloramaViewer);

        string script =
          $@"{viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.RECORDING_CLICK, onRecordingClick{viewerObjectName} = function(e)
             {{
               delete e.detail.recording.thumbs;
               panoramaViewerEvents.onRecordingClick('{viewerObjectName}', e.detail);
             }});
             {viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.IMAGE_CHANGE, onImageChange{viewerObjectName} = function(e)
             {{
               panoramaViewerEvents.onImageChange('{viewerObjectName}', e);
             }});
             {viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.VIEW_CHANGE, onViewChange{viewerObjectName} = function(e)
             {{
               panoramaViewerEvents.onViewChange('{viewerObjectName}', e.detail);
             }});
             {viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_START, onViewLoadStart{viewerObjectName} = function(e)
             {{
               panoramaViewerEvents.onViewLoadStart('{viewerObjectName}', e);
             }});
             {viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_END, onViewLoadEnd{viewerObjectName} = function(e)
             {{
               panoramaViewerEvents.onViewLoadEnd('{viewerObjectName}', e);
             }});
             {viewerObjectName}.on(StreetSmartApi.Events.panoramaViewer.TILE_LOAD_ERROR, onTileLoadError{viewerObjectName} = function(e)
             {{
               panoramaViewerEvents.onTileLoadError('{viewerObjectName}', e.detail);
             }});";

        _browser.ExecuteScriptAsync(script);
      }
      else
      {
        throw new StreetSmartAPIException("Viewer is added already");
      }
    }

    public void RemoveListener(PanoramaViewer cycloramaViewer)
    {
      string viewerObjectName = cycloramaViewer.ViewerObjectName;

      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners.Remove(viewerObjectName);

        string script =
          $@"{viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.RECORDING_CLICK, onRecordingClick{viewerObjectName});
             {viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.IMAGE_CHANGE, onImageChange{viewerObjectName});
             {viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.VIEW_CHANGE, onViewChange{viewerObjectName});
             {viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_START, onViewLoadStart{viewerObjectName});
             {viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_END, onViewLoadEnd{viewerObjectName});
             {viewerObjectName}.off(StreetSmartApi.Events.panoramaViewer.TILE_LOAD_ERROR, onTileLoadError{viewerObjectName});";
        _browser.ExecuteScriptAsync(script);
      }
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnRecordingClick(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnRecordingClick(args);
      }
    }

    public void OnImageChange(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnImageChange(args);
      }
    }

    public void OnViewChange(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnViewChange(args);
      }
    }

    public void OnViewLoadStart(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnViewLoadStart(args);
      }
    }

    public void OnViewLoadEnd(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnViewLoadEnd(args);
      }
    }

    public void OnTileLoadError(string viewerObjectName, Dictionary<string, object> args)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnTileLoadError(args);
      }
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnOpenImageError(string viewerObjectName, string message)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnOpenImageError(message);
      }
    }

    public void OnViewerColor(string viewerObjectName, object[] color)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnViewerColor(color);
      }
    }

    public void OnOrientation(string viewerObjectName, Dictionary<string, object> orientation)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnOrientation(orientation);
      }
    }

    public void OnRecording(string viewerObjectName, Dictionary<string, object> recording)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnRecording(recording);
      }
    }

    public void OnRecordingsVisible(string viewerObjectName, bool visible)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnRecordingsVisible(visible);
      }
    }

    public void OnNavbarVisible(string viewerObjectName, bool visible)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnNavbarVisible(visible);
      }
    }

    public void OnNavbarExpanded(string viewerObjectName, bool visible)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnNavbarExpanded(visible);
      }
    }

    public void OnTimeTravelVisible(string viewerObjectName, bool visible)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnTimeTravelVisible(visible);
      }
    }

    public void OnTimeTravelExpanded(string viewerObjectName, bool expanded)
    {
      if (_listeners.ContainsKey(viewerObjectName))
      {
        _listeners[viewerObjectName].OnTimeTravelExpanded(expanded);
      }
    }

    #endregion
  }
}
