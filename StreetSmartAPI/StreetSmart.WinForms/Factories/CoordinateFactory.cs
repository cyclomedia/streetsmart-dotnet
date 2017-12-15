/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
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

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// Factory for create coordinate objects which are used in the api
  /// </summary>
  /// <example>
  /// This sample shows how to use the <see cref="CoordinateFactory"/>.
  /// <code>
  /// using System;
  /// using System.Collections.Generic;
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
  ///       plStreetSmart.Controls.Add(_api.GUI);
  ///     }
  ///
  ///     private void OnAPIReady(object sender, EventArgs args)
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
  ///       IViewerOptions viewerOpt = ViewerOptionsFactory.Create(new List&lt;ViewerType&gt; { ViewerType.Panorama }, "EPSG:28992");
  /// 
  ///       // open a panorama viewer
  ///       IList&lt;IViewer&gt; viewers = await _api.Open("Boschdijk 7, Eindhoven", viewerOpt);
  ///
  ///       if (viewers.Count == 1)
  ///       {
  ///         // Get the panorama viewer object
  ///         IPanoramaViewer viewer = (IPanoramaViewer) viewers[0];
  ///
  ///         // The look at coordinate
  ///         double x = 160850.585;
  ///         double y = 383923.326;
  ///         ICoordinate coordinate = CoordinateFactory.Create(x, y);
  ///
  ///         // let the viewer know where to look at
  ///         viewer.LookAtCoordinate(coordinate);
  ///       }
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public static class CoordinateFactory
  {
    /// <summary>
    /// Create coordinates based on x and y
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="CoordinateFactory.Create(double, double)"/> method.
    /// <code>
    /// // Create a x and y coordinate
    /// double x = 160850.585;
    /// double y = 383923.326;
    /// ICoordinate coordinate = CoordinateFactory.Create(x, y);
    /// </code>
    /// </example>
    /// <param name="x">X value of the coordinate</param>
    /// <param name="y">Y value of the coordinate</param>
    /// <returns>Coordinate definition</returns>
    public static ICoordinate Create(double x, double y) => new Coordinate(x, y);

    /// <summary>
    /// Create coordinates based on x, y and z
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="CoordinateFactory.Create(double, double, double)"/> method.
    /// <code>
    /// // Create a x, y and z coordinate
    /// double x = 160850.585;
    /// double y = 383923.326;
    /// double z = 2.5;
    /// ICoordinate coordinate = CoordinateFactory.Create(x, y, z);
    /// </code>
    /// </example>
    /// <param name="x">X value of the coordinate</param>
    /// <param name="y">Y value of the coordinate</param>
    /// <param name="z">Z value of the coordinate</param>
    /// <returns>Coordinate definition</returns>
    public static ICoordinate Create(double x, double y, double z) => new Coordinate(x, y, z);
  }
}
