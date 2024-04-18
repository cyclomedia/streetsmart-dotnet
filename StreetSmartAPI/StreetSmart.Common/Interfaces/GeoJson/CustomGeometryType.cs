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
  /// Custom geometry type
  /// </summary>
  public enum CustomGeometryType
  {
    /// <summary>
    /// Not defined
    /// </summary>
    [Description("")]
    NotDefined = 0,

    /// <summary>
    /// Circle
    /// </summary>
    [Description("Circle")]
    Circle = 1,

    /// <summary>
    /// Orthogonal
    /// </summary>
    [Description("Orthogonal")]
    Orthogonal = 2,

    /// <summary>
    /// Height
    /// </summary>
    [Description("Height")]
    Height = 3,

    /// <summary>
    /// Rectangle
    /// </summary>
    [Description("Rectangle")]
    Rectangle = 4,

    /// <summary>
    /// Redline
    /// </summary>
    [Description("Redline")]
    Redline = 5
  }
}
