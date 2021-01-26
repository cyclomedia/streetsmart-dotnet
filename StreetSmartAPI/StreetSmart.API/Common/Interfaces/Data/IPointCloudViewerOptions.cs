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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Options to initialize the point cloud viewer with
  /// </summary>
  public interface IPointCloudViewerOptions : IBaseViewerOptions
  {
    /// <summary>
    /// The point cloud type of the viewer
    /// </summary>
    PointCloudType PointCloudType { get; set; }
  }
}
