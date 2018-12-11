/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

using System;
using System.Threading.Tasks;

using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// The vewer interface
  /// </summary>
  public interface IViewer
  {
    #region Interface functions

    /// <summary>
    /// Triggers when the elevation is changed
    /// </summary>
    event EventHandler<IEventArgs<ILayerInfo>> LayerVisibilityChange;

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
    /// Returns whether the timetravel component is visible or hidden.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>Whether the timetravel component is visible or hidden.</returns>
    Task<bool> GetTimeTravelExpanded();

    /// <summary>
    /// Returns whether timetravel is enabled for the viewer.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>Whether timetravel is enabled for the viewer.</returns>
    Task<bool> GetTimeTravelVisible();

    /// <summary>
    /// Returns the type of this viewer.
    /// </summary>
    /// <returns>The type of this viewer..</returns>
    Task<ViewerType> GetType();

    /// <summary>
    /// Downloads the image
    /// </summary>
    void SaveImage();

    /// <summary>
    /// Set the brightness of the viewer.
    /// </summary>
    /// <param name="value">Set brightness to a positive number</param>
    void SetBrightness(double value);

    /// <summary>
    /// Set the contrast of the viewer.
    /// </summary>
    /// <param name="value">Set contrast to a positive number</param>
    void SetContrast(double value);

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

    /// <summary>
    /// Toggles the visibility of an overlay.
    /// </summary>
    /// <param name="overlay">Sets the visibility of the layer to this value.</param>
    void ToggleOverlay(IOverlay overlay);

    /// <summary>
    /// Expands or hides the timetravel components.
    /// </summary>
    /// <param name="expanded">Value for expanding or hiding time travel.</param>
    void ToggleTimeTravelExpanded(bool expanded);

    /// <summary>
    /// Enables or disables timeTravel in the viewer.
    /// </summary>
    /// <param name="visible">Value for enabling or disablingtoggles time travel.</param>
    void ToggleTimeTravelVisible(bool visible);

    /// <summary>
    /// Zoom in in the Panorama. This will alter the hFov.
    /// </summary>
    void ZoomIn();

    /// <summary>
    /// Zoom out in the Panorama. This will alter the hFov.
    /// </summary>
    void ZoomOut();

    #endregion
  }
}
