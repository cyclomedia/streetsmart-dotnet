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

using System.Collections.Generic;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Derived data which contains the calculated data of a line measurement
  /// </summary>
  public interface IDerivedDataLineString : IDerivedData
  {
    /// <summary>
    /// Standard deviations of the points
    /// </summary>
    IList<IStdev> CoordinateStdev { get; }

    /// <summary>
    /// The total lenght
    /// </summary>
    IProperty TotalLength { get; }

    /// <summary>
    /// Segment lengths
    /// </summary>
    IList<IProperty> SegmentLengths { get; }

    /// <summary>
    /// Segments delta XY
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IList<IProperty> SegmentsDeltaXY { get; }

    /// <summary>
    /// Segments delta Z
    /// </summary>
    IList<IProperty> SegmentsDeltaZ { get; }

    /// <summary>
    /// Segments slope percentage
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IList<IProperty> SegmentsSlopePercentage { get; }

    /// <summary>
    /// Segments slope angle
    /// </summary>
    IList<IProperty> SegmentsSlopeAngle { get; }

    /// <summary>
    /// Delta XY
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IProperty DeltaXY { get; }

    /// <summary>
    /// Delta Z
    /// </summary>
    IProperty DeltaZ { get; }
  }
}
