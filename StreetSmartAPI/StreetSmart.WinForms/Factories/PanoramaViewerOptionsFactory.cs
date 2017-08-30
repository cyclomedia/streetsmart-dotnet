/*
 * Street Smart .NET integration
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// Factory for create Options which are used to initialize the panorama viewer
  /// </summary>
  public static class PanoramaViewerOptionsFactory
  {
    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="recordingsVisible">If recordings should be visible</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateRecordingsVisible(bool recordingsVisible)
      => new PanoramaViewerOptions(recordingsVisible, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateTimeTravelVisible(bool timeTravelVisible)
      => new PanoramaViewerOptions(null, timeTravelVisible, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="navBarVisible">If navbar is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateNavBarVisible(bool navBarVisible)
      => new PanoramaViewerOptions(null, null, navBarVisible);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions Create() => new PanoramaViewerOptions(null, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="recordingsVisible">If recordings should be visible</param>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <param name="navBarVisible">If nav bar is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions Create(bool recordingsVisible, bool timeTravelVisible, bool navBarVisible)
      => new PanoramaViewerOptions(recordingsVisible, timeTravelVisible, navBarVisible);
  }
}
