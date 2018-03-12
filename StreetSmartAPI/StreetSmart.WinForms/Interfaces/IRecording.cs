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

using System;

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Information about the Recording
  /// </summary>
  public interface IRecording
  {
    /// <summary>
    /// Ground level offset
    /// </summary>
    double? GroundLevelOffset { get; set; }

    /// <summary>
    /// Recorder direction
    /// </summary>
    double? RecorderDirection { get; set; }

    /// <summary>
    /// Orientation
    /// </summary>
    double? Orientation { get; set; }

    /// <summary>
    /// RecordedAt
    /// </summary>
    DateTime? RecordedAt { get; set; }

    /// <summary>
    /// ImageId
    /// </summary>
    string Id { get; set; }

    // ReSharper disable InconsistentNaming

    /// <summary>
    /// xyz coordinate
    /// </summary>
    ICoordinate XYZ { get; set; }

    /// <summary>
    /// Coordinate system
    /// </summary>
    string SRS { get; set; }

    // ReSharper restore InconsistentNaming

    /// <summary>
    /// Orientation precision
    /// </summary>
    double? OrientationPrecision { get; set; }

    /// <summary>
    /// Tile schema
    /// </summary>
    TileSchema TileSchema { get; set; }

    /// <summary>
    /// Longitude precision
    /// </summary>
    double? LongitudePrecision { get; set; }

    /// <summary>
    /// Latitiude precision
    /// </summary>
    double? LatitudePrecision { get; set; }

    /// <summary>
    /// Height precision
    /// </summary>
    double? HeightPrecision { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    ProductType ProductType { get; set; }

    /// <summary>
    /// Height coordiate system
    /// </summary>
    string HeightSystem { get; set; }

    /// <summary>
    /// Expired at date
    /// </summary>
    DateTime? ExpiredAt { get; set; }
  }
}
