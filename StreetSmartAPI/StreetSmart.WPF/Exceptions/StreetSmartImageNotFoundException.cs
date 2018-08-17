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

using System;

namespace StreetSmart.Wpf.Exceptions
{
  /// <inheritdoc />
  /// <summary>
  /// This exception is thrown when no images can be found.
  /// </summary>
  /// <example>
  /// This sample shows how to use the <see cref="StreetSmartImageNotFoundException"/> Exception.
  /// <code>
  /// using System;
  /// using System.Collections.Generic;
  /// using StreetSmart.Wpf.Exceptions;
  /// using StreetSmart.Wpf.Factories;
  /// using StreetSmart.Wpf.Interfaces;
  ///
  /// namespace Demo
  /// {
  ///   public class Example
  ///   {
  ///     private IStreetSmartAPI _api;
  ///     private System.Windows.Forms.Panel plStreetSmart = new System.Windows.Forms.Panel();
  ///
  ///     public void StartAPI()
  ///     {
  ///       _api = StreetSmartAPIFactory.Create();
  ///       _api.APIReady += OnAPIReady;
  ///       plStreetSmart.Controls.Add(_api.GUI);
  ///     }
  ///
  ///     private async void OnAPIReady(object sender, EventArgs args)
  ///     {
  ///       // The dom element within the api must be rendered.
  ///       IDomElement element = DomElementFactory.Create();
  ///
  ///       // The initialisation options of the api
  ///       IOptions options = OptionsFactory.Create("myUsername", "myPassword", "myAPIKey", "EPSG:28992", element);
  ///
  ///       // Initialize the api.
  ///       await _api.Init(options);
  /// 
  ///       // The open viewer options for open a new panorama viewer in EPSG:28992.
  ///       IViewerOptions viewerOpt = ViewerOptionsFactory.Create(new List&lt;ViewerType&gt; {ViewerType.Panorama}, "EPSG:28992");
  ///
  ///       try
  ///       {
  ///         IList&lt;IViewer&gt; viewers = await _api.Open("Lange Haven 145, Schiedam", viewerOpt);
  ///         // Todo: add functionality
  ///       }
  ///       catch (StreetSmartImageNotFoundException ex)
  ///       {
  ///         // image not found exception (ex)
  ///       }
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public class StreetSmartImageNotFoundException : Exception
  {
    internal StreetSmartImageNotFoundException(string message) : base(message)
    {
    }

    internal StreetSmartImageNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
