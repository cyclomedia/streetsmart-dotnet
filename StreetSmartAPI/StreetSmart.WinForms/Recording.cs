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

using System;
using System.Collections.Generic;

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// TileSchema of the recording.
  /// </summary>
  public enum TileSchema
  {
    /// <summary>
    /// No tiling
    /// </summary>
    NoTiling = 1,

    /// <summary>
    /// DCR9 Tiling.
    /// </summary>
    Dcr9Tiling = 2,

    /// <summary>
    /// DCR10 Tiling
    /// </summary>
    Dcr10Tiling = 3
  }

  /// <summary>
  /// ProductType of the recording.
  /// </summary>
  public enum ProductType
  {
    /// <summary>
    /// Cyclorama
    /// </summary>
    Cyclorama = 1,

    /// <summary>
    /// Aquarama
    /// </summary>
    Aquarama = 2,

    /// <summary>
    /// Aerial
    /// </summary>
    Aerial = 3,

    /// <summary>
    /// Aerorama
    /// </summary>
    Aerorama = 4
  }

  /// <summary>
  /// Recording information
  /// </summary>
  public class Recording
  {
    public Recording(Dictionary<string, object> recording)
    {
      Dictionary<string, object> xyz = (Dictionary<string, object>) recording["xyz"];

      XYZ = new Coordinate
      {
        X = (double) xyz["0"],
        Y = (double) xyz["1"],
        Z = (double) xyz["2"]
      };

      GroundLevelOffset = (double?) recording["groundLevelOffset"];
      RecorderDirection = (double?) recording["recorderDirection"];
      Orientation = (double?) recording["orientation"];
      RecordedAt = (DateTime?) recording["recordedAt"];
      Id = (string) recording["id"];
      SRS = (string) recording["srs"];
      OrientationPrecision = (double?) recording["orientationPrecision"];
      TileSchema = (TileSchema) Enum.Parse(typeof (TileSchema), (string) recording["tileSchema"]);
      LongitudePrecision = (double?) recording["longitudePrecision"];
      LatitudePrecision = (double?) recording["latitudePrecision"];
      HeightPrecision = (double?) recording["heightPrecision"];
      ProductType = (ProductType) Enum.Parse(typeof (ProductType), (string) recording["productType"]);
      HeightSystem = (string) recording["heightSystem"];
      ExpiredAt = (DateTime?) recording["expiredAt"];
    }

    /// <summary>
    /// Ground level offset
    /// </summary>
    public double? GroundLevelOffset { get; set; }

    /// <summary>
    /// Recorder direction
    /// </summary>
    public double? RecorderDirection { get; set; }

    /// <summary>
    /// Orientation
    /// </summary>
    public double? Orientation { get; set; }

    /// <summary>
    /// RecordedAt
    /// </summary>
    public DateTime? RecordedAt { get; set; }

    /// <summary>
    /// ImageId
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// xyz coordinate
    /// </summary>
    public Coordinate XYZ { get; set; }

    /// <summary>
    /// Coordinate system
    /// </summary>
    public string SRS { get; set; }

    /// <summary>
    /// Orientation precision
    /// </summary>
    public double? OrientationPrecision { get; set; }

    /// <summary>
    /// Tile schema
    /// </summary>
    public TileSchema TileSchema { get; set; }

    /// <summary>
    /// Longitude precision
    /// </summary>
    public double? LongitudePrecision { get; set; }

    /// <summary>
    /// Latitiude precision
    /// </summary>
    public double? LatitudePrecision { get; set; }

    /// <summary>
    /// Height precision
    /// </summary>
    public double? HeightPrecision { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Height coordiate system
    /// </summary>
    public string HeightSystem { get; set; }

    /// <summary>
    /// Expired at date
    /// </summary>
    public DateTime? ExpiredAt { get; set; }
  }

  // ReSharper restore InconsistentNaming
}
