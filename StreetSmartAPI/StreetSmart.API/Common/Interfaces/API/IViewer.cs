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

using System.Threading.Tasks;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// The vewer interface
  /// </summary>
  public interface IViewer
  {
    #region Interface functions

    /// <summary>
    /// Returns the viewerId of the viewer
    /// </summary>
    /// <returns> The viewerId.</returns>
    Task<string> GetId();

    /// <summary>
    /// Returns the navbarExpanded state.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns> The navbarExpanded state.</returns>
    Task<bool> GetNavbarExpanded();

    /// <summary>
    /// Returns the visibility state of the navbar.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The visibility state of the navbar.</returns>
    Task<bool> GetNavbarVisible();

    /// <summary>
    /// Returns the type of this viewer.
    /// </summary>
    /// <returns>The type of this viewer..</returns>
    Task<ViewerType> GetType();

    /// <summary>
    /// Modify the state of navbar expanded in the panorama viewer store.
    /// </summary>
    /// <param name="expanded">Sets expanded to this value.</param>
    void ToggleNavbarExpanded(bool expanded);

    /// <summary>
    /// Toggles the visibility of the navbar in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleNavbarVisible(bool visible);

    #endregion
  }
}
