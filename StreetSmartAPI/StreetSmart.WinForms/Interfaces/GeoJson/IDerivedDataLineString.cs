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

using System.Collections.Generic;

namespace StreetSmart.WinForms.Interfaces.GeoJson
{
  /// <summary>
  /// Derived data which contains the calculated data of a line measurement
  /// </summary>
  public interface IDerivedDataLineString: IDerivedData
  {
    /// <summary>
    /// The total lenght
    /// </summary>
    IValue TotalLength { get; set; }

    /// <summary>
    /// Segment lengths
    /// </summary>
    List<IValue> SegmentLengths { get; set; }

    /// <summary>
    /// Segments delta XY
    /// </summary>
    // ReSharper disable once InconsistentNaming
    List<IValue> SegmentsDeltaXY { get; set; }

    /// <summary>
    /// Segments delta Z
    /// </summary>
    List<IValue> SegmentsDeltaZ { get; set; }

    /// <summary>
    /// Segments slope percentage
    /// </summary>
    // ReSharper disable once InconsistentNaming
    List<IValue> SegmentSlopePercentage { get; set; }

    /// <summary>
    /// Segments slope angle
    /// </summary>
    List<IValue> SegmentsSlopeAngle { get; set; }

    /// <summary>
    /// Delta XY
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IValue DeltaXY { get; set; }

    /// <summary>
    /// Delta Z
    /// </summary>
    IValue DeltaZ { get; set; }
  }
}
