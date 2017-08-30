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

using CefSharp.WinForms;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewerList: ViewerList
  {
    #region Members

    private ChromiumWebBrowser _browser;
    private readonly Dictionary<string, PanoramaViewer> _viewers;

    #endregion

    #region Properties

    public static string Type => "@@ViewerType/PANORAMA";

    public string JsThis => $"{GetType().Name}Events";

    public string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsRecClick => $"{nameof(OnRecordingClick).FirstCharacterToLower()}";

    public string JsTileLoadError => $"{nameof(OnTileLoadError).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsViewLoadStart => $"{nameof(OnViewLoadStart).FirstCharacterToLower()}";

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public PanoramaViewerList()
    {
      _viewers = new Dictionary<string, PanoramaViewer>();
    }

    #endregion

    #region Functions

    public override void RegisterJsObject(ChromiumWebBrowser browser)
    {
      _browser = browser;
      browser.RegisterJsObject(JsThis, this);
    }

    public override IViewer AddViewer(string name)
    {
      return RegisterViewer(new PanoramaViewer(_browser, this, name));
    }

    public override IViewer AddViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return RegisterViewer(new PanoramaViewer(_browser, this, element, options));
    }

    public string ReAssignPanoramaViewer(string newViewer)
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.Name}={newViewer};");
    }

    public string DisconnectEvents()
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.DisconnectEventsScript}");
    }

    public string ConnectEvents()
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.ConnectEventsScript}");
    }

    public IViewer RegisterViewer(PanoramaViewer viewer)
    {
      if (!_viewers.ContainsKey(viewer.Name))
      {
        _viewers.Add(viewer.Name, viewer);
      }

      return viewer;
    }

    public override void DestroyViewer(IViewer viewer)
    {
      PanoramaViewer panoramaViewer = (PanoramaViewer) viewer;

      if (_viewers.ContainsKey(panoramaViewer?.Name ?? string.Empty))
      {
        _viewers.Remove(panoramaViewer?.Name ?? string.Empty);
        panoramaViewer?.DestroyViewer();
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

    public void OnTimeTravelChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnTimeTravelChange(args);
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
