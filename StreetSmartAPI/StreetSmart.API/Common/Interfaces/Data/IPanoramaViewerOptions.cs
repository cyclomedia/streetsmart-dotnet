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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Options to initialize the panorama viewer with
  /// </summary>
  public interface IPanoramaViewerOptions : IBaseViewerOptions
  {
    /// <summary>
    /// Whether the panorama viewer window should be replace.
    /// </summary>
    bool? Replace { get; set; }

    /// <summary>
    /// If recordings should be visible
    /// </summary>
    bool? RecordingsVisible { get; set; }

    /// <summary>
    /// Show measurement type button in measurement the navigation bar. Default is true.
    /// </summary>
    bool? MeasureTypeButtonVisible { get; set; }

    /// <summary>
    /// Allow toggle of measurement type in measurement the navigation bar. Default is true.
    /// </summary>
    bool? MeasureTypeButtonToggle { get; set; }

    /// <summary>
    /// Start new measurement when clicking on measurement type button in measurement the navigation bar. Default is true.
    /// </summary>
    bool? MeasureTypeButtonStart { get; set; }
  }
}
