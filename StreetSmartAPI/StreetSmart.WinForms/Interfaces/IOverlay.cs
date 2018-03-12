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

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Information about the overlay
  /// </summary>
  public interface IOverlay
  {
    /// <summary>
    /// Id of the overlay
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Name of the layer
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// GeoJSON object containing the layer data
    /// </summary>
    // ReSharper disable once InconsistentNaming
    string GeoJson { get; set; }

    /// <summary>
    /// Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.
    /// </summary>
    string Srs { get; set; }

    /// <summary>
    /// Optional XML string for Styled Layer Descriptor.
    /// </summary>
    string Sld { get; set; }
  }
}
