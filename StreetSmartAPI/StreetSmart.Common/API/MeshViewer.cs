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
using System.Threading.Tasks;

using CefSharp;
using StreetSmart.Common.Interfaces.API;
using System.Globalization;


namespace StreetSmart.Common.API
{
  internal sealed class BaseMeshViewer : Viewer, IMeshViewer
  {
    #region Members

    private readonly CultureInfo _ci;

    #endregion

    #region Constructors

    public MeshViewer(IChromiumWebBrowserBase browser, MeshViewerList meshViewerList, string name)
      : base(browser, meshViewerList, name)
    {
      _ci = CultureInfo.InvariantCulture;
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetMapDesaturated()
    {
      return ToBool(await CallJsGetScriptAsync("getMapDesaturated()"));
    }

    public void SetDesaturatedTexture(bool desaturated)
    {
      Browser.ExecuteScriptAsync($"{Name}.setDesaturatedTexture({desaturated.ToJsBool()});");
    }

    public void SetLOSEyeHeight(double eyeHeight)
    {
      Browser.ExecuteScriptAsync($"{Name}.setLOSEyeHeight({eyeHeight.ToString(_ci)});");
    }

    public void SetNavigationState(bool enabled)
    {
      Browser.ExecuteScriptAsync($"{Name}.setNavigationState({enabled.ToJsBool()});");
    }

    public void SetOverlayVisibility(string layerId, bool visibility)
    {
      Browser.ExecuteScriptAsync($"{Name}.setOverlayVisibility({layerId.ToQuote()}, {visibility.ToJsBool()});");
    }

    public void SetTime(DateTime? time)
    {
      Browser.ExecuteScriptAsync($"{Name}.setTime({time?.ToShortDateString() ?? string.Empty});");
    }

    #endregion
  }
}
