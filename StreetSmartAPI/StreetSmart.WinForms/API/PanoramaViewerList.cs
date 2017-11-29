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

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewerList : ViewerList
  {
    #region Properties

    public static string Type => "@@ViewerType/PANORAMA";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsRecClick => $"{nameof(OnRecordingClick).FirstCharacterToLower()}";

    public string JsTileLoadError => $"{nameof(OnTileLoadError).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsViewLoadStart => $"{nameof(OnViewLoadStart).FirstCharacterToLower()}";

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

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

    public void OnImageNotFoundException(string name, string message)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnImageNotFoundException(message);
      }
    }

    #endregion
  }
}
