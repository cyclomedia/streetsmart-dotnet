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
  /// GeoJson Feature
  /// </summary>
  public interface IMeasureDetails
  {
    /// <summary>
    /// Measure method
    /// </summary>
    MeasureMethod MeasureMethod { get; set; }

    /// <summary>
    /// Details
    /// </summary>
    IDetails Details { get; set; }

    /// <summary>
    /// Point problems
    /// </summary>
    IList<PointProblems> PointProblems { get; set; }

    /// <summary>
    /// Point reliability
    /// </summary>
    Reliability PointReliability { get; set; }
  }
}
