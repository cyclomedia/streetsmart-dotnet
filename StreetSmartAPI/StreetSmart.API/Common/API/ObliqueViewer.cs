/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

using System.Threading.Tasks;

using CefSharp;

using StreetSmart.Common.Interfaces.API;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

namespace StreetSmart.Common.API
{
  internal sealed class ObliqueViewer : Viewer, IObliqueViewer
  {
    #region Constructors

    public ObliqueViewer(ChromiumWebBrowser browser, ObliqueViewerList obliqueViewerList, string name)
      : base(browser, obliqueViewerList, name)
    {
      ConnectEvents();
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetButtonEnabled(ObliqueViewerButtons buttonId)
    {
      return await base.GetButtonEnabled(buttonId);
    }

    public void SwitchViewingDirection(double deltaDegrees)
    {
      Browser.ExecuteScriptAsync($"{Name}.switchViewingDirection({deltaDegrees});");
    }

    public void ToggleButtonEnabled(ObliqueViewerButtons buttonId, bool enabled)
    {
      base.ToggleButtonEnabled(buttonId, enabled);
    }

    #endregion
  }
}
