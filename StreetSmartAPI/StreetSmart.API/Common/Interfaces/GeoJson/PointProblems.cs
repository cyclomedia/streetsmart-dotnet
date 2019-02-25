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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Point problems
  /// </summary>
  public enum PointProblems
  {
    /// <summary>
    /// oneObservation
    /// </summary>
    [Description("ONE_OBSERVATION")]
    OneObservation = 1,

    /// <summary>
    /// Too few recordings
    /// </summary>
    [Description("TOO_FEW_RECORDINGS")]
    TooFewRecordings = 2,

    /// <summary>
    /// Invalid angle
    /// </summary>
    [Description("INVALID_ANGLE")]
    InvalidAngle = 3,

    /// <summary>
    /// Point too far
    /// </summary>
    [Description("POINT_TOO_FAR")]
    PointTooFar = 4,

    /// <summary>
    /// Standard deviation
    /// </summary>
    [Description("STANDARD_DEVIATION")]
    StandardDeviation = 5
  }
}
