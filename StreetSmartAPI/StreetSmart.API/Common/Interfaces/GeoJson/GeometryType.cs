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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Defines the geometryType of a GeoJson
  /// </summary>
  public enum GeometryType
  {
    /// <summary>
    /// anything else
    /// </summary>
    [Description("")]
    Unknown = -1,

    /// <summary>
    /// positions
    /// </summary>
    [Description("Positions")]
    Positions = 1,

    /// <summary>
    /// geometry point
    /// </summary>
    [Description("Point")]
    Point = 2,

    /// <summary>
    /// geometry multipoint
    /// </summary>
    [Description("MultiPoint")]
    MultiPoint = 3,

    /// <summary>
    /// geometry lineString
    /// </summary>
    [Description("LineString")]
    LineString = 4,

    /// <summary>
    /// geometry multiLineString
    /// </summary>
    [Description("MultiLineString")]
    MultiLineString = 5,

    /// <summary>
    /// geometry polygon
    /// </summary>
    [Description("Polygon")]
    Polygon = 6,

    /// <summary>
    /// geometry multipolygon
    /// </summary>
    [Description("MultiPolygon")]
    MultiPolygon = 7,

    /// <summary>
    /// geometry geometrycollection
    /// </summary>
    [Description("GeometryCollection")]
    GeometryCollection = 8,
  }
}
