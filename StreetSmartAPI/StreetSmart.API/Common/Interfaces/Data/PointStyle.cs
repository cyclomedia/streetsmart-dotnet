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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Definition of PointStyles
  /// </summary>
  public enum PointStyle
  {
    /// <summary>
    /// RGB
    /// </summary>
    [Description("0")]
    Rgb = 0,

    /// <summary>
    /// Height
    /// </summary>
    [Description("3")]
    Height = 3,

    /// <summary>
    /// Elevation
    /// </summary>
    [Description("3")]
    Elevation = 3,

    /// <summary>
    /// Intensity
    /// </summary>
    [Description("4")]
    Intensity = 4
  }
}
