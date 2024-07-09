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
using System.Linq;
using StreetSmart.Common.Interfaces.API;

#if NETCOREAPP
  using System.Dynamic;
#else
  using System.Collections.Generic;
#endif

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

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

    public string JsFeatureSelectionChange => $"{nameof(OnFeatureSelectionChange).FirstCharacterToLower()}";

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

#if NETCOREAPP
    public void OnElevationChange(string name, ExpandoObject args)
#else
    public void OnElevationChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnElevationChange(args);
      }
    }

#if NETCOREAPP
    public void OnImageChange(string name, ExpandoObject args)
#else
    public void OnImageChange(string name,Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnImageChange(args);
      }
    }

#if NETCOREAPP
    public void OnRecordingClick(string name, ExpandoObject args)
#else
    public void OnRecordingClick(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnRecordingClick(args);
      }
    }

#if NETCOREAPP
    public void OnFeatureClick(string name, ExpandoObject args)
#else
    public void OnFeatureClick(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnFeatureClick(args);
      }
    }

#if NETCOREAPP
    public void OnTileLoadError(string name, ExpandoObject args)
#else
    public void OnTileLoadError(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnTileLoadError(args);
      }
    }

#if NETCOREAPP
    public void OnViewChange(string name, ExpandoObject args)
#else
    public void OnViewChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnViewChange(args);
      }
    }

#if NETCOREAPP
    public void OnSurfaceCursorChange(string name, ExpandoObject args)
#else
    public void OnSurfaceCursorChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnSurfaceCursorChange(args);
      }
    }

#if NETCOREAPP
    public void OnViewLoadEnd(string name, ExpandoObject args)
#else
    public void OnViewLoadEnd(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnViewLoadEnd(args);
      }
    }

#if NETCOREAPP
    public void OnTimeTravelChange(string name, ExpandoObject args)
#else
    public void OnTimeTravelChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnTimeTravelChange(args);
      }
    }

#if NETCOREAPP
    public void OnFeatureSelectionChange(string name, ExpandoObject args)
#else
    public void OnFeatureSelectionChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PanoramaViewer)?.OnFeatureSelectionChange(args);
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
