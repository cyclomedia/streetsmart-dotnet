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
  /// Recording info
  /// </summary>
  public interface IRecordingInfo
  {
    /// <summary>
    /// ImageId
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Position
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IPosition Position { get; set; }

    /// <summary>
    /// Coordinate system
    /// </summary>
    // ReSharper disable once InconsistentNaming
    string SRS { get; set; }

    /// <summary>
    /// Yaw
    /// </summary>
    IValue Yaw { get; set; }

    /// <summary>
    /// Depth std dev
    /// </summary>
    double DepthStdev { get; set; }
  }
}
