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

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create Options which are used to initialize the panorama viewer
  /// </summary>
  public static class PanoramaViewerOptionsFactory
  {
    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="closable">If the panorama viewer should be closable</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateClosable(bool closable)
      => new PanoramaViewerOptions(closable, null, null, null, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="maximizable">If the panorama viewer should be maximizable</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateMaximizable(bool maximizable)
      => new PanoramaViewerOptions(null, maximizable, null, null, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateTimeTravelVisible(bool timeTravelVisible)
      => new PanoramaViewerOptions(null, null, timeTravelVisible, null, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="navBarVisible">If navbar is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateNavBarVisible(bool navBarVisible)
      => new PanoramaViewerOptions(null, null, null, navBarVisible, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="replace">Replace the panorama viewer</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateReplace(bool replace)
      => new PanoramaViewerOptions(null, null, null, null, replace, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="recordingsVisible">If recordings should be visible</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions CreateRecordingsVisible(bool recordingsVisible)
      => new PanoramaViewerOptions(null, null, null, null, null, recordingsVisible);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions Create() => new PanoramaViewerOptions(null, null, null, null, null, null);

    /// <summary>
    /// Create options to initialize the panorama viewer with
    /// </summary>
    /// <param name="closable">If the panorama viewer is closable</param>
    /// <param name="maximizable">If the panorama viewer is maximizable</param>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <param name="navBarVisible">If nav bar is enabled</param>
    /// <param name="replace">Replace the panorama viewer</param>
    /// <param name="recordingsVisible">If recordings should be visible</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IPanoramaViewerOptions Create(bool closable, bool maximizable, bool timeTravelVisible,
      bool navBarVisible, bool replace, bool recordingsVisible)
      => new PanoramaViewerOptions(closable, maximizable, timeTravelVisible, navBarVisible, replace, recordingsVisible);
  }
}
