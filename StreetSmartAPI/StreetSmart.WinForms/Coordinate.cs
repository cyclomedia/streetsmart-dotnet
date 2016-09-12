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

// ReSharper disable InconsistentNaming

namespace StreetSmart.WinForms
{
  /// <summary>
  /// Coordinate information.
  /// </summary>
  public class Coordinate
  {
    /// <summary>
    /// X value of the coordinate.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y value of the coordinate.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Z value of the coordinate.
    /// </summary>
    public double? Z { get; set; }
  }
}

// ReSharper restore InconsistentNaming
