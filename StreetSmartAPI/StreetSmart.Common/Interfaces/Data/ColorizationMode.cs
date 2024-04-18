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
  /// Definition of PointStyles
  /// </summary>
  public enum ColorizationMode
  {
    /// <summary>
    /// RGB
    /// </summary>
    [Description("RGB")]
    Rgb = 1,

    /// <summary>
    /// Height
    /// </summary>
    [Description("Height")]
    Height = 2,

    /// <summary>
    /// Intensity
    /// </summary>
    [Description("Intensity")]
    Intensity = 3,

    /// <summary>
    /// Classification
    /// </summary>
    [Description("Classification")]
    Classification = 4
  }
}
