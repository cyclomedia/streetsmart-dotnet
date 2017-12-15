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

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Coordinate definition
  /// </summary>
  public interface ICoordinate
  {
    /// <summary>
    ///  X value of the coordinate
    /// </summary>
    double X { get; set; }

    /// <summary>
    /// Y value of the coordinate
    /// </summary>
    double Y { get; set; }

    /// <summary>
    /// Z value of the coordinate
    /// </summary>
    double? Z { get; set; }
  }
}
