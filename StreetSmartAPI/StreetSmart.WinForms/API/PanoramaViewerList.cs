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

using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewerList
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private readonly Dictionary<string, PanoramaViewer> _viewers;

    #endregion

    #region Properties

    public string JsThis => $"{GetType().Name}Events";

    public string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsRecClick => $"{nameof(OnRecordingClick).FirstCharacterToLower()}";

    public string JsTileLoadError => $"{nameof(OnTileLoadError).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsViewLoadStart => $"{nameof(OnViewLoadStart).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public PanoramaViewerList(ChromiumWebBrowser browser)
    {
      _browser = browser;
      _viewers = new Dictionary<string, PanoramaViewer>();
      browser.RegisterJsObject(JsThis, this);
    }

    #endregion

    #region Functions

    public PanoramaViewer AddViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      PanoramaViewer viewer = new PanoramaViewer(_browser, element, options, this);

      if (!_viewers.ContainsKey(viewer.Name))
      {
        _viewers.Add(viewer.Name, viewer);
      }

      return viewer;
    }

    public void DestroyViewer(PanoramaViewer viewer)
    {
      if (_viewers.ContainsKey(viewer.Name))
      {
        _viewers.Remove(viewer.Name);
        viewer.DestroyPanoramaViewer();
      }
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnImageChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnImageChange(args);
      }
    }

    public void OnRecordingClick(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnRecordingClick(args);
      }
    }

    public void OnTileLoadError(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnTileLoadError(args);
      }
    }

    public void OnViewChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewChange(args);
      }
    }

    public void OnViewLoadEnd(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewLoadEnd(args);
      }
    }

    public void OnViewLoadStart(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewLoadStart(args);
      }
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnResult(string name, object result)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnResult(result);
      }
    }

    public void OnImageNotFoundException(string name, string message)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnImageNotFoundException(message);
      }
    }

    #endregion
  }
}
