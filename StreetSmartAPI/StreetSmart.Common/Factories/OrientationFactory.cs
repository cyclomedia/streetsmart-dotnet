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

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create a orientation object
  /// </summary>
  public static class OrientationFactory
  {
    /// <summary>
    /// Create the orientation Object
    /// </summary>
    /// <param name="hFov">Value of the hFov.</param>
    /// <returns>Orientation Object that contains values.</returns>
    public static IOrientation CreatehFov(double hFov) => new Orientation(null, null, hFov);

    /// <summary>
    /// Create the orientation Object
    /// </summary>
    /// <param name="pitch">Value of the pitch.</param>
    /// <returns>Orientation Object that contains values.</returns>
    public static IOrientation CreatePitch(double pitch) => new Orientation(null, pitch, null);

    /// <summary>
    /// Create the orientation Object
    /// </summary>
    /// <param name="yaw">Value of the yaw.</param>
    /// <returns>Orientation Object that contains values.</returns>
    public static IOrientation CreateYaw(double yaw) => new Orientation(yaw, null, null);

    /// <summary>
    /// Create the orientation Object
    /// </summary>
    /// <param name="yaw">Value of the yaw.</param>
    /// <param name="pitch">Value of the pitch.</param>
    /// <param name="hFov">Value of the hFov.</param>
    /// <returns>Orientation Object that contains values.</returns>
    public static IOrientation Create(double? yaw, double? pitch, double? hFov) => new Orientation(yaw, pitch, hFov);
  }
}
