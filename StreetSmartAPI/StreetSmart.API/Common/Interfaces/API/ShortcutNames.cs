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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// Object containing a list of available shortcut names
  /// </summary>
  public enum ShortcutNames
  {
    /// <summary>
    /// Copy coordinate to clipboard
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.CopyCoordinateToClipboard")]
    CopyCoordinateToClipboard = 1,

    /// <summary>
    /// Close all panoramas
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.closeAllPanoramas")]
    CloseAllPanoramas = 2,

    /// <summary>
    /// Move to panorama position
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.moveToPanoramaPosition")]
    MoveToPanoramaPosition = 3,

    /// <summary>
    /// Move panorama with arrow keys
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.movePanoramaWithArrowKeys")]
    MovePanoramaWithArrowKeys = 4,

    /// <summary>
    /// Start measurement from panorama
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.startMeasurementFromPanorama")]
    StartMeasurementFromPanorama = 5,

    /// <summary>
    /// Close panorama
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.closePanorama")]
    ClosePanorama = 6,

    /// <summary>
    /// Close other panorama
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.closeOtherPanorama")]
    CloseOtherPanorama = 7,

    /// <summary>
    /// Start measrement from map
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.startMeasurementFromMap")]
    StartMeasurementFromMap = 8,

    /// <summary>
    /// Start measurement from oblique
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.startMeasurementFromOblique")]
    StartMeasurementFromOblique = 9,

    /// <summary>
    /// Close oblique
    /// </summary>
    [Description("StreetSmartApi.ShortCuts.ShortcutNames.closeOblique")]
    CloseOblique = 10
  }
}
