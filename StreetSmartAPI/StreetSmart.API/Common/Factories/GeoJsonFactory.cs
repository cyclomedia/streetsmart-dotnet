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

using System.Collections.Generic;

using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create GeoJson objects
  /// </summary>
  public static class GeoJsonFactory
  {
    /// <summary>
    /// Returns GeoJson featureCollection object
    /// </summary>
    /// <param name="wkid">wkid of the feature collection</param>
    /// <returns>GeoJson feature collection</returns>
    public static IFeatureCollection CreateFeatureCollection(int wkid) => new FeatureCollection(wkid);

    /// <summary>
    /// Returns a clone of a GeoJSon featureCollection object
    /// </summary>
    /// <param name="featureCollection">feature collection</param>
    /// <returns>GeoJson feature collection</returns>
    public static IFeatureCollection CloneFeatureCollection(IFeatureCollection featureCollection) =>
      new FeatureCollection(featureCollection);

    /// <summary>
    /// Create measure details
    /// </summary>
    public static IMeasureDetails CreateMeasureDetails() => new MeasureDetails();

    /// <summary>
    /// Returns GeoJson point feature object
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <param name="z">z coordinate</param>
    /// <returns>Point feature</returns>
    public static IFeature CreatePointFeature(double x, double y, double z) => new Feature(new Point(x, y, z));

    /// <summary>
    /// Returns GeoJson point feature object
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <returns>Point feature</returns>
    public static IFeature CreatePointFeature(double x, double y) => new Feature(new Point(x, y));

    /// <summary>
    /// Returns GeoJson point feature object
    /// </summary>
    /// <param name="coordinate">Coordinate object</param>
    /// <returns>Point feature</returns>
    public static IFeature CreatePointFeature(ICoordinate coordinate) => new Feature(new Point(coordinate));

    /// <summary>
    /// Returns GeoJson line string feature object
    /// </summary>
    /// <param name="coordinates">Array of coordinates of a line</param>
    /// <returns>Line feature</returns>
    public static IFeature CreateLineFeature(IList<ICoordinate> coordinates) =>
      new Feature(new LineString(coordinates));

    /// <summary>
    /// Returns GeoJson polygon feature object
    /// </summary>
    /// <param name="coordinates">Double array of the coordinates of a polygon</param>
    /// <returns>Polygon feature</returns>
    public static IFeature CreatePolygonFeature(IList<IList<ICoordinate>> coordinates) =>
      new Feature(new Polygon(coordinates));

    /// <summary>
    /// Returns GeoJson point geometry object
    /// </summary>
    /// <param name="coordinate">Coordinate object</param>
    /// <returns>Point feature</returns>
    public static IGeometry CreatePointGeometry(ICoordinate coordinate) => new Point(coordinate);

    /// <summary>
    /// Returns GeoJson line string geometry object
    /// </summary>
    /// <param name="coordinates">Array of coordinates of a line</param>
    /// <returns>Line feature</returns>
    public static IGeometry CreateLineGeometry(IList<ICoordinate> coordinates) => new LineString(coordinates);

    /// <summary>
    /// Returns GeoJson polygon geometry object
    /// </summary>
    /// <param name="coordinates">Double array of the coordinates of a polygon</param>
    /// <returns>Polygon feature</returns>
    public static IGeometry CreatePolygonGeometry(IList<IList<ICoordinate>> coordinates) => new Polygon(coordinates);
  }
}
