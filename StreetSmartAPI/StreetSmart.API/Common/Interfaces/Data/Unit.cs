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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Units of measurements / elevation
  /// </summary>
  public enum Unit
  {
    /// <summary>
    /// anything else
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Meters
    /// </summary>
    Meters = 1,

    /// <summary>
    /// Feet
    /// </summary>
    Feet = 2,

    /// <summary>
    /// UsFeet
    /// </summary>
    UsFeet = 3,

    /// <summary>
    /// Degrees
    /// </summary>
    Degrees = 4,
  }
}
