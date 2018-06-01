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

namespace StreetSmart.WinForms.Interfaces.GeoJson
{
  /// <summary>
  /// Custom geometry type
  /// </summary>
  public enum CustomGeometryType
  {
    /// <summary>
    /// Not defined
    /// </summary>
    NotDefined = 0,

    /// <summary>
    /// Circle
    /// </summary>
    Circle = 1,

    /// <summary>
    /// Orthogonal
    /// </summary>
    Orthogonal = 2,

    /// <summary>
    /// Height
    /// </summary>
    Height = 3,

    /// <summary>
    /// Rectangle
    /// </summary>
    Rectangle = 4,
  }
}
