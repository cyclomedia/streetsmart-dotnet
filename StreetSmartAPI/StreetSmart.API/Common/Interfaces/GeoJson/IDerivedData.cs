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

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Derived data which contains the calculated data from the measurement
  /// </summary>
  public interface IDerivedData
  {
    /// <summary>
    /// The unit of the measurement
    /// </summary>
    Unit Unit { get; }

    /// <summary>
    /// Precision
    /// </summary>
    int Precision { get; }
  }
}
