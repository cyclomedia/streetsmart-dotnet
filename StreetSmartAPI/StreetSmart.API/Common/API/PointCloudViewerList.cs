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
  internal sealed class PointCloudViewerList : ViewerList
  {
    #region Properties

    public static string Type => "@@ViewerType/POINTCLOUD";

    #endregion

    #region Callback definitions

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsEdgesChanged => $"{nameof(OnEdgesChanged).FirstCharacterToLower()}";

    public string JsPointSizeChanged => $"{nameof(OnPointSizeChanged).FirstCharacterToLower()}";

    public string JsPointStyleChanged => $"{nameof(OnPointStyleChanged).FirstCharacterToLower()}";

    public string JsPointBudgetChanged => $"{nameof(OnPointBudgedChanged).FirstCharacterToLower()}";

    public string JsBackGroundChanged => $"{nameof(OnBackGroundChanged).FirstCharacterToLower()}";

    #endregion

    #region Functions

    public override IViewer AddViewer(string name)
    {
      return RegisterViewer(new PointCloudViewer(Browser, this, name));
    }

    #endregion

    #region Events from StreetSmartAPI

#if NETCOREAPP
    public void OnViewChange(string name, ExpandoObject args)
#else
    public void OnViewChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnViewChange(args);
      }
    }

#if NETCOREAPP
    public void OnEdgesChanged(string name, ExpandoObject args)
#else
    public void OnEdgesChanged(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnEdgesChanged(args);
      }
    }

#if NETCOREAPP
    public void OnPointSizeChanged(string name, ExpandoObject args)
#else
    public void OnPointSizeChanged(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointSizeChanged(args);
      }
    }

#if NETCOREAPP
    public void OnPointStyleChanged(string name, ExpandoObject args)
#else
    public void OnPointStyleChanged(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointStyleChanged(args);
      }
    }

#if NETCOREAPP
    public void OnPointBudgedChanged(string name, ExpandoObject args)
#else
    public void OnPointBudgedChanged(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointBudgedChanged(args);
      }
    }

#if NETCOREAPP
    public void OnBackGroundChanged(string name, ExpandoObject args)
#else
    public void OnBackGroundChanged(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnBackGroundChanged(args);
      }
    }

    #endregion
  }
}
