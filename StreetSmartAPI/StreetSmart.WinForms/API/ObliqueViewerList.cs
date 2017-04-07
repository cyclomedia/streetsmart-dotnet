/*
 * Integration in ArcMap for Cycloramas
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

using System.Collections.Generic;

using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class ObliqueViewerList: ViewerList
  {
    #region Members

    private ChromiumWebBrowser _browser;
    private readonly Dictionary<string, ObliqueViewer> _viewers;

    #endregion

    #region Properties

    public static string Type => "@@ViewerType/OBLIQUE";

    public string JsThis => $"{GetType().Name}Events";

    #endregion

    #region Constructor

    public ObliqueViewerList()
    {
      _viewers = new Dictionary<string, ObliqueViewer>();
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
      ObliqueViewer viewer = new ObliqueViewer(_browser, this, name);

      if (!_viewers.ContainsKey(name))
      {
        _viewers.Add(name, viewer);
      }

      return viewer;
    }

    public override void DestroyViewer(IViewer viewer)
    {
      ObliqueViewer obliqueViewer = viewer as ObliqueViewer;

      if (_viewers.ContainsKey(obliqueViewer?.Name ?? string.Empty))
      {
        _viewers.Remove(obliqueViewer?.Name ?? string.Empty);
      }
    }

    #endregion
  }
}
