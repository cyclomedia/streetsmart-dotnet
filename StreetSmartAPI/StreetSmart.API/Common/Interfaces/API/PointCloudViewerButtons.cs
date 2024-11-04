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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// Defines the oblique viewer buttons
  /// </summary>
  public enum PointCloudViewerButtons
  {
    /// <summary>
    /// measure
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.MEASURE")]
    Measure = 1,

    /// <summary>
    /// image information
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.IMAGE_INFORMATION")]
    ImageInformation = 2,

    /// <summary>
    /// overlays
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.OVERLAYS")]
    Overlays = 3,

    /// <summary>
    /// sections
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.SECTIONS")]
    Sections = 4,

    /// <summary>
    /// display
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.DISPLAY")]
    Display = 5,

    /// <summary>
    /// download
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.DOWNLOAD")]
    Download = 6,

    /// <summary>
    /// toggle aerial street
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.buttons.TOGGLE_AERIAL_STREET")]
    ToggleAerialStreet = 7,

    /// <summary>
    /// save measurement button
    /// </summary>
    [Description("StreetSmartApi.PointCloudViewerUi.SAVE_MEASUREMENT")]
    SaveMeasurement = 8
  }
}
