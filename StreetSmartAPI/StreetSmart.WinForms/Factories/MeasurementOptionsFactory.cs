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
  /// Factory for create measurement options to use for create a measurement
  /// </summary>
  public static class MeasurementOptionsFactory
  {
    /// <summary>
    /// Create measurement options to use for create a measurement
    /// </summary>
    /// <returns>The measurement options to use for create a measurement</returns>
    public static IMeasurementOptions Create() => new MeasurementOptions();

    /// <summary>
    /// Create measurement options to use for create a measurement
    /// </summary>
    /// <param name="geometryType">The geometryType of the measurement</param>
    /// <returns>The measurement options to use for create a measurement</returns>
    public static IMeasurementOptions Create(MeasurementGeometryType geometryType) => new MeasurementOptions(geometryType);
  }
}
