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

using StreetSmart.Common.Data;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create a overlay
  /// </summary>
  public static class OverlayFactory
  {
    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <returns>Overlay object</returns>
    public static IOverlay Create(string geoJson, string name)
      => Create(geoJson, name, null, null);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">EPSG code (srs) for the source GeoJSON</param>
    /// <returns>Overlay object</returns>
    public static IOverlay Create(string geoJson, string name, string srs)
      => Create(geoJson, name, srs, null);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="sld">Optional XML string for Styled Layer Descriptor</param>
    /// <returns>Overlay object</returns>
    public static IOverlay Create(string geoJson, string name, string srs, string sld)
      => new Overlay(geoJson, name, srs, sld);
  }
}
