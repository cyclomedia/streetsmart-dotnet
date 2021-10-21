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
  /// Defines the viewerTypes of the API
  /// </summary>
  public enum ViewerType
  {
    /// <summary>
    /// Panoramic image
    /// </summary>
    [Description("ViewerType.PANORAMA")]
    Panorama = 1,

    /// <summary>
    /// Oblique image
    /// </summary>
    [Description("ViewerType.OBLIQUE")]
    Oblique = 2,

    /// <summary>
    /// Point cloud viewer
    /// </summary>
    [Description("ViewerType.POINTCLOUD")]
    PointCloud = 3
  }
}
