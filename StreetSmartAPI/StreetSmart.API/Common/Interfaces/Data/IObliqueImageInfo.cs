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

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Oblique image info
  /// </summary>
  public interface IObliqueImageInfo
  {
    /// <summary>
    /// The footprint of the oblique image
    /// </summary>
    IPolygon Footprint { get; set; }

    /// <summary>
    /// The center of the footprint
    /// </summary>
    ICoordinate FootprintCentre { get; set; }

    /// <summary>
    /// The rotation of the oblique image
    /// </summary>
    double Rotation { get; set; }

    /// <summary>
    /// The SRS of the oblique image
    /// </summary>
    string Srs { get; set; }
  }
}
