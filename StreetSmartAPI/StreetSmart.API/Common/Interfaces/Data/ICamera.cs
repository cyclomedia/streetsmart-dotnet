/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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
  /// Camera definition
  /// </summary>
  public interface ICamera
  {
    /// <summary>
    /// Current position of the camera
    /// </summary>
    ICoordinate Position { get; set; }

    /// <summary>
    /// Current position of target the camera is looking at
    /// </summary>
    ICoordinate Target { get; set; }
  }
}
