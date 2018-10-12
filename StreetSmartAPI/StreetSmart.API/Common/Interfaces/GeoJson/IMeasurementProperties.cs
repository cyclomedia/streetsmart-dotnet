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

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// GeoJson Feature
  /// </summary>
  public interface IMeasurementProperties : IProperties
  {
    /// <summary>
    /// Id
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Name
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Group
    /// </summary>
    string Group { get; }

    /// <summary>
    /// Measure details
    /// </summary>
    IList<IMeasureDetails> MeasureDetails { get; }

    /// <summary>
    /// Dimension
    /// </summary>
    int Dimension { get; }

    /// <summary>
    /// Custom geometry type
    /// </summary>
    CustomGeometryType CustomGeometryType { get; }

    /// <summary>
    /// Derived data which contains the calculated data from the measurement
    /// </summary>
    IDerivedData DerivedData { get; }

    /// <summary>
    /// Measure reliability
    /// </summary>
    Reliability MeasureReliability { get; }

    /// <summary>
    /// Points with errors
    /// </summary>
    IList<int> PointsWithErrors { get; }

    /// <summary>
    /// Valid Geometry
    /// </summary>
    bool ValidGeometry { get; }

    /// <summary>
    /// Observation lines
    /// </summary>
    IObservationLines ObservationLines { get; }
  }
}
