/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
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

using System.Collections.Generic;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// Factory for create address settings to use for address searches
  /// </summary>
  public static class ViewerOptionsFactory
  {
    /// <summary>
    /// Creates a viewer options object
    /// </summary>
    /// <param name="viewerType">An collection of viewerTypes</param>
    /// <param name="srs">The SRS of the viewer</param>
    /// <returns>The viewer options used for open viewers</returns>
    public static IViewerOptions Create(IList<ViewerType> viewerType, string srs) => Create(viewerType, srs, true);

    /// <summary>
    /// Creates a viewer options object
    /// </summary>
    /// <param name="viewerType">An collection of viewerTypes</param>
    /// <param name="srs">The SRS of the viewer</param>
    /// <param name="replace">Whether the panorama viewer window should be replace</param>
    /// <returns>The viewer options used for open viewers</returns>
    public static IViewerOptions Create(IList<ViewerType> viewerType, string srs, bool replace) =>
      new ViewerOptions(viewerType, srs, replace);
  }
}
