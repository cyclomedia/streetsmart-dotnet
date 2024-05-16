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

using CefSharp.WinForms;
using StreetSmart.Common;
using System.Windows.Forms;

namespace StreetSmart.WinForms
{
  /// <inheritdoc />
  /// <summary>
  /// The <c>StreetSmartGUI</c> class is the <c>UserControl</c> within Street Smart runs.
  /// This class can be added to a <c>Panel</c> within your application.
  /// </summary>
  /// <example> 
  /// This sample shows how to use the <see cref="StreetSmartGUI"/> UserControl.
  /// <code>
  /// using System;
  /// using StreetSmart.WinForms;
  /// using StreetSmart.WinForms.Factories;
  /// using StreetSmart.WinForms.Interfaces;
  ///
  /// namespace Demo
  /// {
  ///   public class Example
  ///   {
  ///     private IStreetSmartAPI _api;
  ///     private System.Windows.Forms.Panel _plStreetSmart = new System.Windows.Forms.Panel();
  ///
  ///     public void StartAPI()
  ///     {
  ///       _api = StreetSmartAPIFactory.Create();
  ///       _api.APIReady += OnAPIReady;
  ///
  ///       // _api.GUI is the StreetSmartGUI UserControl
  ///       StreetSmartGUI gui = _api.GUI;
  ///       _plStreetSmart.Controls.Add(gui);
  ///     }
  ///
  ///     private void OnAPIReady(object sender, EventArgs args)
  ///     {
  ///       // API ready
  ///       // Todo: add functionality
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  // ReSharper disable once InconsistentNaming
  public sealed partial class StreetSmartGUI : UserControl
  {
    internal StreetSmartGUI(IStreetSmartBrowser browser)
    {
      InitializeComponent();
      Dock = browser.Dock;
      Controls.Add(browser.Control());      
    }
  }
}
