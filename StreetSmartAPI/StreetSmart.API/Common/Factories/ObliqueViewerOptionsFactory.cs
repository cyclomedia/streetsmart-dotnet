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
  /// Factory for create Options which are used to initialize the oblique viewer
  /// </summary>
  public static class ObliqueViewerOptionsFactory
  {
    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="closable">If the oblique viewer should be closable</param>
    /// <returns>Options to initialize the oblique viewer with</returns>
    public static IObliqueViewerOptions CreateClosable(bool closable)
      => new ObliqueViewerOptions(closable, null, null, null);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="maximizable">If the oblique viewer should be maximizable</param>
    /// <returns>Options to initialize the oblique viewer with</returns>
    public static IObliqueViewerOptions CreateMaximizable(bool maximizable)
      => new ObliqueViewerOptions(null, maximizable, null, null);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <returns>Options to initialize the oblique viewer with</returns>
    public static IObliqueViewerOptions CreateTimeTravelVisible(bool timeTravelVisible)
      => new ObliqueViewerOptions(null, null, timeTravelVisible, null);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="navBarVisible">If navbar is enabled</param>
    /// <returns>Options to initialize the oblique viewer with</returns>
    public static IObliqueViewerOptions CreateNavBarVisible(bool navBarVisible)
      => new ObliqueViewerOptions(null, null, null, navBarVisible);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <returns>Options to initialize the oblique viewer with</returns>
    public static IObliqueViewerOptions Create() => new ObliqueViewerOptions(null, null, null, null);

    /// <summary>
    /// Create options to initialize the oblique viewer with
    /// </summary>
    /// <param name="closable">If the panorama viewer is closable</param>
    /// <param name="maximizable">If the panorama viewer is maximizable</param>
    /// <param name="timeTravelVisible">If time travel is enabled</param>
    /// <param name="navBarVisible">If nav bar is enabled</param>
    /// <returns>Options to initialize the panorama viewer with</returns>
    public static IObliqueViewerOptions Create(bool closable, bool maximizable, bool timeTravelVisible,
      bool navBarVisible)
      => new ObliqueViewerOptions(closable, maximizable, timeTravelVisible, navBarVisible);
  }
}
