/*
 * Street Smart .NET integration
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

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Options to initialize the panorama viewer with
  /// </summary>
  public interface IPanoramaViewerOptions
  {
    /// <summary>
    /// If recordings should be visible
    /// </summary>
    bool? RecordingsVisible { get; set; }

    /// <summary>
    /// If time travel is enabled
    /// </summary>
    bool? TimeTravelVisible { get; set; }

    /// <summary>
    /// If navbar is enabled
    /// </summary>
    bool? NavbarVisible { get; set; }
  }
}
