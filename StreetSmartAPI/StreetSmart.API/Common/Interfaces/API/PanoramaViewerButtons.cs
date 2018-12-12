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
    /// open pointcloud
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.OPEN_POINTCLOUD")]
    OpenPointCloud = 4,

    /// <summary>
    /// report blurring
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.REPORT_BLURRING")]
    ReportBlurring = 5,

    /// <summary>
    /// measure
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.MEASURE")]
    Measure = 6,

    /// <summary>
    /// play list
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.PLAYLIST")]
    PlayList = 7,

    /// <summary>
    /// center map
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.CENTER_MAP")]
    CenterMap = 8,

    /// <summary>
    /// image information
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.IMAGE_INFORMATION")]
    ImageInformation = 9,

    /// <summary>
    /// save image
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.SAVE_IMAGE")]
    SaveImage = 10,

    /// <summary>
    /// zoom in
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ZOOM_IN")]
    ZoomIn = 11,

    /// <summary>
    /// zoom out
    /// </summary>
    [Description("StreetSmartApi.PanoramaViewerUi.buttons.ZOOM_OUT")]
    ZoomOut = 12
  }
}
