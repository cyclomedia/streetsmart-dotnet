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

using System.ComponentModel;

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Defines the geometryTypes of the API
  /// </summary>
  public enum MeasurementGeometryType
  {
    /// <summary>
    /// geometry point
    /// </summary>
    [Description("MeasurementGeometryType.POINT")]
    Point = 1,

    /// <summary>
    /// geometry linestring
    /// </summary>
    [Description("MeasurementGeometryType.LINESTRING")]
    LineString = 2,

    /// <summary>
    /// geometry polygon
    /// </summary>
    [Description("MeasurementGeometryType.POLYGON")]
    Polygon = 3
  }
}
