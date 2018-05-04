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
  public interface IProperties
  {
    /// <summary>
    /// Id
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    string Group { get; set; }

    /// <summary>
    /// Measure details
    /// </summary>
    IList<IMeasureDetails> MeasureDetails { get; set; }

    /// <summary>
    /// Dimension
    /// </summary>
    int Dimension { get; set; }

    /// <summary>
    /// Custom geometry type
    /// </summary>
    CustomGeometryType CustomGeometryType { get; set; }

    /// <summary>
    /// Derived data
    /// </summary>
    // DerivedData { get; set; }

    /// <summary>
    /// Measure reliability
    /// </summary>
    Reliability MeasureReliability { get; set; }

    /// <summary>
    /// Points with errors
    /// </summary>
    IList<int> PointsWithErrors { get; set; }

    /// <summary>
    /// Valid Geometry
    /// </summary>
    bool ValidGeometry { get; set; }

    /// <summary>
    /// Observation lines
    /// </summary>
    IObservationLines ObservationLines { get; set; }
  }
}
