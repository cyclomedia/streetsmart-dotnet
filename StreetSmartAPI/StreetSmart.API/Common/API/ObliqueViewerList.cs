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
using StreetSmart.Common.Interfaces.API;

#if NETCOREAPP
  using System.Dynamic;
#else
  using System.Collections.Generic;
#endif

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

#if NETCOREAPP
    public void OnSwitchViewingDirection(string name, ExpandoObject args)
#else
    public void OnSwitchViewingDirection(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnSwitchViewingDirection(args);
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
        (Viewers[name] as ObliqueViewer)?.OnFeatureClick(args);
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
        (Viewers[name] as ObliqueViewer)?.OnFeatureSelectionChange(args);
      }
    }

#if NETCOREAPP
    public void OnImageChange(string name, ExpandoObject args)
#else
    public void OnImageChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnImageChange(args);
      }
    }

#if NETCOREAPP
    public void OnViewChange(string name, ExpandoObject args)
#else
    public void OnViewChange(string name,Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ObliqueViewer)?.OnViewChange(args);
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
        (Viewers[name] as ObliqueViewer)?.OnViewLoadEnd(args);
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
        (Viewers[name] as ObliqueViewer)?.OnTimeTravelChange(args);
      }
    }

    #endregion
  }
}
