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

using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Common.API
{
  internal class ObliqueViewerList : ViewerList
  {
    #region Properties

    public static string Type => "@@ViewerType/OBLIQUE";

    #endregion

    #region Callback definitions

    public string JsSwitchViewingDirection => $"{nameof(OnSwitchViewingDirection).FirstCharacterToLower()}";

    public string JsFeatureClick => $"{nameof(OnFeatureClick).FirstCharacterToLower()}";

    public string JsFeatureSelectionChange => $"{nameof(OnFeatureSelectionChange).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

    #endregion

    #region Functions

    public override IViewer AddViewer(string name)
    {
      return RegisterViewer(new ObliqueViewer(Browser, this, name));
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnSwitchViewingDirection(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnSwitchViewingDirection(args);
      }
    }

    public void OnFeatureClick(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnFeatureClick(args);
      }
    }

    public void OnFeatureSelectionChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnFeatureSelectionChange(args);
      }
    }

    public void OnImageChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnImageChange(args);
      }
    }

    public void OnViewChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnViewChange(args);
      }
    }

    public void OnViewLoadEnd(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnViewLoadEnd(args);
      }
    }

    public void OnTimeTravelChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnTimeTravelChange(args);
      }
    }

    #endregion
  }
}
