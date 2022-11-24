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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

namespace StreetSmart.Common.Interfaces.API
{
  /// <inheritdoc />
  /// <summary>
  /// PanoramaViewer component. Gets created by the StreetSmartAPI.
  /// </summary>
  public interface IPanoramaViewer : IImageViewer
  {
    #region Interface events

    /// <summary>
    /// Triggers when the elevation is changed
    /// </summary>
    event EventHandler<IEventArgs<IElevationInfo>> ElevationChange;

    /// <summary>
    /// Triggers when the loaded panorama is altered.
    /// </summary>
    event EventHandler<EventArgs> ImageChange;

    /// <summary>
    /// Triggers when a recording is clicked inside the PanoramaViewer.
    /// </summary>
    event EventHandler<IEventArgs<IRecordingClickInfo>> RecordingClick;

    /// <summary>
    /// Triggers when a feature is clicked inside the PanoramaViewer.
    /// </summary>
    event EventHandler<IEventArgs<IFeatureInfo>> FeatureClick;

    /// <summary>
    /// Triggers when a feature is selected / deselected inside the PanoramaViewer.
    /// </summary>
    event EventHandler<IEventArgs<IFeatureInfo>> FeatureSelectionChange;

    /// <summary>
    /// Triggers when the surface cursor is changed
    /// </summary>
    event EventHandler<IEventArgs<IDepthInfo>> SurfaceCursorChange;

    /// <summary>
    /// Triggers when one or more tiles could not be loaded.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> TileLoadError;

    /// <summary>
    /// Triggers when time travel date is changed
    /// </summary>
    event EventHandler<IEventArgs<ITimeTravelInfo>> TimeTravelChange;

    /// <summary>
    /// Triggers when the view (pitch, hFov or yaw) of the panorama is altered.
    /// </summary>
    event EventHandler<IEventArgs<IOrientation>> ViewChange;

    /// <summary>
    /// Triggers when everything that is needed for the view to dislay correctly is loaded.
    /// </summary>
    event EventHandler<EventArgs> ViewLoadEnd;

    #endregion

    #region Interface functions

    /// <summary>
    /// Returns whether the 3D cursor is visible
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The 3D cursor visible state.</returns>
    Task<bool> Get3DCursorVisible();

    /// <summary>
    /// Get the visibility of a button
    /// </summary>
    /// <param name="buttonId"></param>
    /// <returns></returns>
    Task<bool> GetButtonEnabled(PanoramaViewerButtons buttonId);

    /// <summary>
    /// Get the visibility of the panorama Sidebar
    /// </summary>
    /// <returns></returns>
    Task<bool> GetSidebarVisible();

    /// <summary>
    /// Get the expandability of the panorama Sidebar
    /// </summary>
    /// <returns></returns>
    Task<bool> GetSidebarEnabled();

    /// <summary>
    /// Get the expanded state of the panorama Sidebar
    /// </summary>
    /// <returns></returns>
    Task<bool> GetSidebarExpanded();

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
    Task LookAtCoordinate(ICoordinate coordinate, string srs = null);

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
    /// Set the elevation slider level
    /// </summary>
    /// <param name="elevationLevel">The elevation level at which the elevation slider should be set, as a number in feet or meter.</param>
    void SetElevationSliderLevel(double elevationLevel);

    /// <summary>
    /// Sets the orientation {yaw, pitch, hFov} of the PanoramaViewer to specific values all at once.
    /// </summary>
    /// <param name="orientation">Orientation object that contains values to change.</param>
    void SetOrientation(IOrientation orientation);

    /// <summary>
    /// Toggles the visibility of the Attribute information panel, decided if it should be shown on clicking on a feature.
    /// </summary>
    void ShowAttributePanelOnFeatureClick();

    /// <summary>
    /// Toggles the visibility of the Attribute information panel, decided if it should be shown on clicking on a feature.
    /// </summary>
    /// <param name="visible">visibility of the show attributes panel</param>
    void ShowAttributePanelOnFeatureClick(bool visible);

    /// <summary>
    /// Toggles the visibility of the 3D cursor in the PanoramaViewer
    /// </summary>
    /// <param name="visible">If available, sets visibility to this value.</param>
    void Toggle3DCursor(bool visible);

    /// <summary>
    /// Toggles the visibility of the Address features in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">If available, sets visibility to this value.</param>
    void ToggleAddressesVisible(bool visible);

    /// <summary>
    /// Toggle the visibility of a button.
    /// </summary>
    /// <param name="buttonId"></param>
    /// <param name="enabled">if available, sets enabled to this value</param>
    void ToggleButtonEnabled(PanoramaViewerButtons buttonId, bool enabled);

    /// <summary>
    /// Toggle viewers from linked to unlinked and vice versa
    /// </summary>
    void ToggleLinkedViewers();

    /// <summary>
    /// Toggles the visibility of the recording features in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleRecordingsVisible(bool visible);

    /// <summary>
    /// Toggles the expanded state of Sidebar in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleSidebarExpanded(bool visible);

    /// <summary>
    /// Toggles the visibility of Sidebar in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleSidebarVisible(bool visible);

    /// <summary>
    /// Toggles the expandability of Sidebar in the PanoramaViewer.
    /// </summary>
    /// <param name="visible">Sets visibility to this value.</param>
    void ToggleSidebarEnabled(bool visible);

    #endregion
  }
}
