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
    /// returns GeoJSon featureCollection object
    /// </summary>
    public static IFeatureCollection CreateFeatureCollection(int wkid) => new FeatureCollection(wkid);

    /// <summary>
    /// returns GeoJson point feature object
    /// </summary>
    public static IFeature CreatePointFeature(double x, double y, double z) => new Feature(new Point(x, y, z));

    /// <summary>
    /// returns GeoJson point feature object
    /// </summary>
    public static IFeature CreatePointFeature(double x, double y) => new Feature(new Point(x, y));

    /// <summary>
    /// returns GeoJson point feature object
    /// </summary>
    public static IFeature CreatePointFeature(ICoordinate coordinate) => new Feature(new Point(coordinate));

    /// <summary>
    /// returns GeoJson line string feature object
    /// </summary>
    public static IFeature CreateLineFeature(IList<ICoordinate> coordinates) =>
      new Feature(new LineString(coordinates));

    /// <summary>
    /// returns GeoJson polygon feature object
    /// </summary>
    public static IFeature CreatePolygonFeature(IList<IList<ICoordinate>> coordinates) =>
      new Feature(new Polygon(coordinates));
  }
}
