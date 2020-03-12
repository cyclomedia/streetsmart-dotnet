/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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
  public enum ObliqueViewerButtons
  {
    /// <summary>
    /// overlays
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.OVERLAYS")]
    Overlays = 1,

    /// <summary>
    /// image information
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.IMAGE_INFORMATION")]
    ImageInformation = 2,

    /// <summary>
    /// measure
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.MEASURE")]
    Measure = 3,

    /// <summary>
    /// zoom in
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.ZOOM_IN")]
    ZoomIn = 4,

    /// <summary>
    /// zoom out
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.ZOOM_OUT")]
    ZoomOut = 5,

    /// <summary>
    /// switch direction
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.SWITCH_DIRECTION")]
    SwitchDirection = 6,

    /// <summary>
    /// save image
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.SAVE_IMAGE")]
    SaveImage = 7,

    /// <summary>
    /// toggle nadir
    /// </summary>
    [Description("StreetSmartApi.ObliqueViewerUi.buttons.TOGGLE_NADIR")]
    ToggleNadir = 8
  }
}
