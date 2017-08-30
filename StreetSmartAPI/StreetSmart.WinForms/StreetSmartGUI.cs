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

using CefSharp.WinForms;

using System.Windows.Forms;

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// The GUI of StreetSmart
  /// </summary>
  public sealed partial class StreetSmartGUI : UserControl
  {
    /// <summary>
    /// Create the GUI of StreetSmart
    /// </summary>
    /// <param name="browser">The browser</param>
    public StreetSmartGUI(ChromiumWebBrowser browser)
    {
      InitializeComponent();
      Dock = browser.Dock;
      Controls.Add(browser);      
    }
  }

  // ReSharper restore InconsistentNaming
}
