/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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

using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Common.API
{
  internal class PanoramaViewerList : ViewerList
  {
    #region Properties

    public static string Type => "@@ViewerType/PANORAMA";

    #endregion

    #region Callback definitions

    public string JsElevationChange => $"{nameof(OnElevationChange).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsSurfaceCursorChange => $"{nameof(OnSurfaceCursorChange).FirstCharacterToLower()}";

    public string JsRecClick => $"{nameof(OnRecordingClick).FirstCharacterToLower()}";

    public string JsFeatureClick => $"{nameof(OnFeatureClick).FirstCharacterToLower()}";

    public string JsTileLoadError => $"{nameof(OnTileLoadError).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsViewLoadStart => $"{nameof(OnViewLoadStart).FirstCharacterToLower()}";

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

    #endregion

    #region Callback definitions PanoramaViewer

    public override string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    #endregion

    #region Functions

    public override IViewer AddViewer(string name)
    {
      return RegisterViewer(new PanoramaViewer(Browser, this, name));
    }

    public string ReAssignPanoramaViewer(string newViewer)
    {
      return Viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.Name}={newViewer};");
    }

    public string DisconnectEvents()
    {
      return Viewers.Aggregate(string.Empty,
        (current, viewer) => $"{current}{(viewer.Value as PanoramaViewer)?.DisconnectEventsScript}");
    }

    public string ConnectEvents()
    {
      return Viewers.Aggregate(string.Empty,
        (current, viewer) => $"{current}{(viewer.Value as PanoramaViewer)?.ConnectEventsScript}");
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnElevationChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnElevationChange(args);
      }
    }

    public void OnImageChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnImageChange(args);
      }
    }

    public void OnRecordingClick(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnRecordingClick(args);
      }
    }

    public void OnFeatureClick(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnFeatureClick(args);
      }
    }

    public void OnTileLoadError(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnTileLoadError(args);
      }
    }

    public void OnViewChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnViewChange(args);
      }
    }

    public void OnSurfaceCursorChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnSurfaceCursorChange(args);
      }
    }

    public void OnViewLoadEnd(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnViewLoadEnd(args);
      }
    }

    public void OnViewLoadStart(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnViewLoadStart(args);
      }
    }

    public void OnTimeTravelChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnTimeTravelChange(args);
      }
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnImageNotFoundException(string name, string message, string funcName)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnImageNotFoundException(message, funcName);
      }
    }

    #endregion
  }
}
