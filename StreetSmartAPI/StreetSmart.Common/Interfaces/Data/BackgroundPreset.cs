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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Defines the Background
  /// </summary>
  public enum BackgroundPreset
  {
    /// <summary>
    /// Skybox
    /// </summary>
    [Description("Skybox")]
    Skybox = 1,

    /// <summary>
    /// Darkblue
    /// </summary>
    [Description("DarkBlue")]
    DarkBlue = 2,

    /// <summary>
    /// LightBlue
    /// </summary>
    [Description("LightBlue")]
    LightBlue = 3,

    /// <summary>
    /// Black
    /// </summary>
    [Description("Black")]
    Black = 4,

    /// <summary>
    /// DarkGray
    /// </summary>
    [Description("DarkGray")]
    DarkGray = 5,

    /// <summary>
    /// Gray
    /// </summary>
    [Description("Gray")]
    Gray = 6,

    /// <summary>
    /// LightGray
    /// </summary>
    [Description("LightGray")]
    LightGray = 7,

    /// <summary>
    /// White
    /// </summary>
    [Description("White")]
    White = 8,
  }
}
