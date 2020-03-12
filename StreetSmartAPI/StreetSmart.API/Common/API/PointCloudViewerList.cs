/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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
  internal class PointCloudViewerList : ViewerList
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

    #endregion

    #region Functions

    public override IViewer AddViewer(string name)
    {
      return RegisterViewer(new PointCloudViewer(Browser, this, name));
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnViewChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnViewChange(args);
      }
    }

    public void OnEdgesChanged(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnEdgesChanged(args);
      }
    }

    public void OnPointSizeChanged(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointSizeChanged(args);
      }
    }

    public void OnPointStyleChanged(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointStyleChanged(args);
      }
    }

    public void OnPointBudgedChanged(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as PointCloudViewer)?.OnPointBudgedChanged(args);
      }
    }

    #endregion
  }
}
