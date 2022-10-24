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
  /// Defines the panorama viewer buttons
  /// </summary>
  public enum PanoramaViewerButtons
  {
    /// <summary>
    /// elevation
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ELEVATION")]
    Elevation = 1,

    /// <summary>
    /// overlays
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.OVERLAYS")]
    Overlays = 2,

    /// <summary>
    /// open oblique
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.OPEN_OBLIQUE")]
    OpenOblique = 3,

    /// <summary>
    /// report blurring
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.REPORT_BLURRING")]
    ReportBlurring = 4,

    /// <summary>
    /// measure
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.MEASURE")]
    Measure = 5,

    /// <summary>
    /// image information
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.IMAGE_INFORMATION")]
    ImageInformation = 6,

    /// <summary>
    /// save image
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.SAVE_IMAGE")]
    SaveImage = 7,

    /// <summary>
    /// zoom window
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ZOOM_WINDOW")]
    ZoomWindow = 8,

    /// <summary>
    /// zoom in
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ZOOM_IN")]
    ZoomIn = 9,

    /// <summary>
    /// zoom out
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ZOOM_OUT")]
    ZoomOut = 10,
      
    /// <summary>
    /// save measurement button
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.SAVE_MEASUREMENT")]
    SaveMeasurement = 11
  }
}
