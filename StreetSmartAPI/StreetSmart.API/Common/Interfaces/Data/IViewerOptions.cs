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
  /// The address settings to use for address searches
  /// </summary>
  public interface IViewerOptions
  {
    /// <summary>
    /// The viewerType
    /// </summary>
    IViewerTypes ViewerTypes { get; set; }

    /// <summary>
    /// The Srs of the open viewer
    /// </summary>
    string Srs { get; set; }

    /// <summary>
    /// Options to initialize the panorama viewer with
    /// </summary>
    IPanoramaViewerOptions PanoramaViewer { get; set; }

    /// <summary>
    /// Options to initialize the oblique viewer with
    /// </summary>
    IObliqueViewerOptions ObliqueViewer { get; set; }

    /// <summary>
    /// Options to initialize the point cloud viewer with
    /// </summary>
    IPointCloudViewerOptions PointCloudViewer { get; set; }
  }
}
