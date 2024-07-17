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

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create measurement options which are used to create a measurement. We need the measurement options object to create a measurement.
  /// </summary>
  /// <example>
  /// This sample uses the <see cref="MeasurementOptionsFactory"/>, to show how you can start a line measurement in a cyclorama.
  /// <code>
  /// using System.Collections.Generic;
  /// using StreetSmart.Common.Factories;
  /// using StreetSmart.Common.Interfaces;
  ///
  /// namespace Demo
  /// {
  ///   public class Example
  ///   {
  ///     private IStreetSmartAPI _api;
  ///     // Todo: Add a function to initialize the api.
  ///
  ///     private async void OpenImageAndStartMeasurement()
  ///     {
  ///       // The open viewer options for open a new panorama viewer in EPSG:28992.
  ///       IViewerOptions viewerOpt = ViewerOptionsFactory.Create(new List&lt;ViewerType&gt; { ViewerType.Panorama }, "EPSG:28992");
  ///
  ///       // open a panorama viewer
  ///       IList&lt;IViewer&gt; viewers = await _api.Open("Boschdijk 7, Eindhoven", viewerOpt);
  ///
  ///       if (viewers.Count == 1)
  ///       {
  ///         // Get the panorama viewer object
  ///         IPanoramaViewer viewer = (IPanoramaViewer)viewers[0];
  ///
  ///         // The geometry type of the measurement
  ///         MeasurementGeometryType geometryType = MeasurementGeometryType.LineString;
  ///
  ///         // Create a measurement options object
  ///         IMeasurementOptions measurementOptions = MeasurementOptionsFactory.Create(geometryType);
  ///
  ///         // Start line measurement in the opened viewer
  ///         _api.StartMeasurementMode(viewer, measurementOptions);
  ///       }
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public static class MeasurementOptionsFactory
  {
    /// <summary>
    /// Create a default measurement options object.
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="Create()"/> method.
    /// <code>
    /// // Create a measurement options object
    /// IMeasurementOptions measurementOptions = MeasurementOptionsFactory.Create();
    /// </code>
    /// </example>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create() => new MeasurementOptions();

    /// <summary>
    /// Create a measurement options object with a specific geometry type.
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="Create(MeasurementGeometryType)"/> method.
    /// <code>
    /// // Create a measurement options object which can be used for start a surface measurement
    /// MeasurementGeometryType geometryType = MeasurementGeometryType.Polygon;
    /// IMeasurementOptions measurementOptions = MeasurementOptionsFactory.Create(geometryType);
    /// </code>
    /// </example>
    /// <param name="geometryType">The <c>MeasurementGeometryType</c> of the measurement</param>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create(MeasurementGeometryType geometryType) =>
      new MeasurementOptions(geometryType, null, null);

    /// <summary>
    /// Create a measurement options object with a specific measure method.
    /// </summary>
    /// <param name="measureMethods">The <c>measureMethod</c> of the measurement</param>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create(MeasureMethods measureMethods) =>
      new MeasurementOptions(null, measureMethods, null);

    /// <summary>
    /// Create a measurement object and show the save measurement button during the measurement.
    /// </summary>
    /// <param name="showSaveMeasurementButton">>Show the measurement button while taking a measurement</param>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create(bool showSaveMeasurementButton) =>
      new MeasurementOptions(null, null, showSaveMeasurementButton);

    /// <summary>
    /// Create a measurement options object with a specific geometry type and a specific measure method
    /// </summary>
    /// <param name="geometryType">The <c>MeasurementGeometryType</c> of the measurement</param>
    /// <param name="measureMethods">The <c>measureMethod</c> of the measurement</param>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create(MeasurementGeometryType geometryType, MeasureMethods measureMethods) =>
      new MeasurementOptions(geometryType, measureMethods, null);

    /// <summary>
    /// Create a measurement options object with a specific geometry type and a specific measure method
    /// </summary>
    /// <param name="geometryType">The <c>MeasurementGeometryType</c> of the measurement</param>
    /// <param name="measureMethods">The <c>measureMethod</c> of the measurement</param>
    /// <param name="showSaveMeasurementButton">Show the measurement button while taking a measurement</param>
    /// <returns>The measurement options object that is needed to make a measurement</returns>
    public static IMeasurementOptions Create(MeasurementGeometryType geometryType, MeasureMethods measureMethods,
      bool? showSaveMeasurementButton) =>
      new MeasurementOptions(geometryType, measureMethods, showSaveMeasurementButton);
  }
}
