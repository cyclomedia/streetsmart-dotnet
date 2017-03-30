/*
 * Integration in ArcMap for Cycloramas
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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
  /// Factory for create coordinates
  /// </summary>
  public static class CoordinateFactory
  {
    /// <summary>
    /// Create coordinates
    /// </summary>
    /// <param name="x">X value of the coordinate</param>
    /// <param name="y">Y value of the coordinate</param>
    /// <returns>Coordinate definition</returns>
    public static ICoordinate Create(double x, double y) => new Coordinate(x, y);

    /// <summary>
    /// Create coordinates
    /// </summary>
    /// <param name="x">X value of the coordinate</param>
    /// <param name="y">Y value of the coordinate</param>
    /// <param name="z">Z value of the coordinate</param>
    /// <returns>Coordinate definition</returns>
    public static ICoordinate Create(double x, double y, double z) => new Coordinate(x, y, z);
  }
}
