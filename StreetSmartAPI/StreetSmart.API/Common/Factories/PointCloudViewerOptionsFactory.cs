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

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create Options which are used to initialize the oblique viewer
  /// </summary>
  public static class PointCloudViewerOptionsFactory
  {
    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="pointCloudType">The type of the point cloud</param>
    /// <returns>Options to initialize the point cloud viewer with</returns>
    public static IPointCloudViewerOptions Create(PointCloudType pointCloudType)
      => new PointCloudViewerOptions(null, null, null, pointCloudType);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="closable">If the panorama viewer is closable</param>
    /// <param name="maximizable">If the panorama viewer is maximizable</param>
    /// <param name="navBarVisible">If nav bar is enabled</param>
    /// <param name="pointCloudType">The type of the point cloud</param>
    /// <returns>Options to initialize the point cloud viewer with</returns>
    public static IPointCloudViewerOptions Create(bool closable, bool maximizable, bool navBarVisible,
      PointCloudType pointCloudType)
      => new PointCloudViewerOptions(closable, maximizable, navBarVisible, pointCloudType);
  }
}
