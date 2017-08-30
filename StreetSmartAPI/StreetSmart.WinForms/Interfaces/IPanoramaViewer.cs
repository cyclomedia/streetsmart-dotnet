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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// PanoramaViewer component. Gets created by the StreetSmartAPI.
  /// </summary>
  public interface IPanoramaViewer : IViewer
  {
    /// <summary>
    /// Triggers when the loaded panorama is altered.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> ImageChange;

    /// <summary>
    /// Triggers when a recording is clicked inside the PanoramaViewer.
    /// </summary>
    event EventHandler<IEventArgs<IRecordingClickInfo>> RecordingClick;

    /// <summary>
    /// Triggers when one or more tiles could not be loaded.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> TileLoadError;

    /// <summary>
    /// Triggers when the view (pitch, hFov or yaw) of the panorama is altered.
    /// </summary>
    event EventHandler<IEventArgs<IOrientation>> ViewChange;

    /// <summary>
    /// Triggers when everything that is needed for the view to dislay correctly is loaded.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadEnd;

    /// <summary>
    /// Triggers when the view is altered and needs to be (partly) reloaded.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadStart;

    /// <summary>
    /// Triggers when time travel date is changed
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> TimeTravelChange;

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
    /// Returns the orientation in degrees (yaw, pitch, hFov) for this CycloramaViewer.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The orientation in degrees (yaw, pitch, hFov) for this CycloramaViewer.</returns>
    Task<IOrientation> GetOrientation();

    /// <summary>
    /// Gets the current active recording of the PanoramaViewer.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The current active recording of the PanoramaViewer.</returns>
    Task<IRecording> GetRecording();

    /// <summary>
    /// Returns whether recordings are visible.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>Whether recordings are visible.</returns>
    Task<bool> GetRecordingsVisible();

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
    /// Gets the viewer color.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The current viewer color.</returns>
    Task<Color> GetViewerColor();

    /// <summary>
    /// Sets the orientation of the PanoramaViewer to look at a certain coordinate.
    /// </summary>
    /// <param name="coordinate">Coordinate to look to.</param>
    /// <param name="srs">(optional) Will use to convert coordinate to viewer srs.</param>
    void LookAtCoordinate(ICoordinate coordinate, string srs = null);

    /// <summary>
    /// Opens a panorama closest to the given address.
    /// </summary>
    /// <param name="query">Address you want to search.</param>
    /// <param name="srs">(optional) Coordinate system in which the panorama will be opened.</param>
    Task<IRecording> OpenByAddress(string query, string srs = null);

    /// <summary>
    /// Opens an image by coordinates and accompanying coordinate system.
    /// </summary>
    /// <param name="coordinate">Coordinate of location to open a panorama.</param>
    /// <param name="srs">(optional) Will use to convert coordinate to viewer srs.</param>
    Task<IRecording> OpenByCoordinate(ICoordinate coordinate, string srs = null);

    /// <summary>
    /// Opens an image by imageId.
    /// </summary>
    /// <param name="imageId">ID of the image that needs to be opened.</param>
    /// <param name="srs">(optional) Coordinate system in which the panorama will be opened.</param>
    Task<IRecording> OpenByImageId(string imageId, string srs = null);

    /// <summary>
    /// Rotates the panorama vertically by a certain amount, as if the camera is turning to the ground.
    /// </summary>
    /// <param name="deltaPitch">Amount to rotate the image, in degrees.</param>
    void RotateDown(double deltaPitch);

    /// <summary>
    /// Rotates the panorama horizontally by a certain amount, as if the camera is turning to the left.
    /// </summary>
    /// <param name="deltaYaw">Amount to rotate the image, in degrees.</param>
    void RotateLeft(double deltaYaw);

    /// <summary>
    /// Rotates the panorama horizontally by a certain amount, as if the camera is turning to the right.
    /// </summary>
    /// <param name="deltaYaw">Amount to rotate the image, in degrees.</param>
    void RotateRight(double deltaYaw);

    /// <summary>
    /// Rotates the panorama vertically by a certain amount, as if the camera is turning to the sky.
    /// </summary>
    /// <param name="deltaPitch">Amount to rotate the image, in degrees.</param>
    void RotateUp(double deltaPitch);

    /// <summary>
    /// Sets the orientation {yaw, pitch, hFov} of the PanoramaViewer to specific values all at once.
    /// </summary>
    /// <param name="orientation">Orientation object that contains values to change.</param>
    void SetOrientation(IOrientation orientation);

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
    /// Toggles the visibility of the recording features in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleRecordingsVisible(bool visible);

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
  }
}
