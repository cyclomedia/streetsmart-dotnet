/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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
  /// <inheritdoc />
  /// <summary>
  /// ObliqueViewer component. Gets created by the StreetSmartAPI.
  /// </summary>
  public interface IPointCloudViewer : IViewer
  {
    /// <summary>
    /// Triggers on a view change
    /// </summary>
    event EventHandler<IEventArgs<ICamera>> ViewChange;

    /// <summary>
    /// Triggers on a edges change
    /// </summary>
    event EventHandler<IEventArgs<bool>> EdgesChanged;

    /// <summary>
    /// Triggers on a point size change
    /// </summary>
    event EventHandler<IEventArgs<int>> PointSizeChanged;

    /// <summary>
    /// Triggers on a point style change
    /// </summary>
    event EventHandler<IEventArgs<PointStyle>> PointStyleChanged;

    /// <summary>
    /// Triggers on a point budged change
    /// </summary>
    event EventHandler<IEventArgs<PointBudget>> PointBudgedChanged;

    /// <summary>
    /// Moves the camera of the pointcloud viewer towards a given coordinate.
    /// </summary>
    /// <param name="position">coordinate to move to</param>
    /// <param name="lookAt">coordinate to look at</param>
    void FlyTo(ICoordinate position, ICoordinate lookAt);

    /// <summary>
    /// Get the visibility of a button
    /// </summary>
    /// <param name="buttonId"></param>
    /// <returns></returns>
    Task<bool> GetButtonEnabled(PointCloudViewerButtons buttonId);

    /// <summary>
    /// Returns the current position of the camera, and position of the target its looking at.
    /// </summary>
    /// <returns>Current position of target the camera is looking at</returns>
    Task<ICamera> GetCameraPosition();

    /// <summary>
    /// Get current visibility of black edges around points.
    /// </summary>
    /// <returns>Visibility of edges around points</returns>
    Task<bool> GetEdgesVisibility();

    /// <summary>
    /// Get current point budget.
    /// </summary>
    /// <returns>budget - can be 'Low', 'Med' or 'High'</returns>
    Task<PointBudget> GetPointBudget();

    /// <summary>
    /// Get current size of points
    /// </summary>
    /// <returns></returns>
    Task<int> GetPointSize();

    /// <summary>
    /// Get current style of points
    /// </summary>
    /// <returns></returns>
    Task<PointStyle> GetPointStyle();

    /// <summary>
    /// Rotates the camera of the pointcloud viewer towards a given coordinate.
    /// </summary>
    /// <param name="lookAt">Coordinate to look at</param>
    void LookAtCoordinate(ICoordinate lookAt);

    /// <summary>
    /// Rotates the camera a given amount of degrees towards the down
    /// </summary>
    /// <param name="deg">amount of degrees to rotate right</param>
    void RotateDown(double deg);

    /// <summary>
    /// Rotates the camera a given amount of degrees towards the left
    /// </summary>
    /// <param name="deg">amount of degrees to rotate left</param>
    void RotateLeft(double deg);

    /// <summary>
    /// Rotates the camera a given amount of degrees towards the right
    /// </summary>
    /// <param name="deg">amount of degrees to rotate right</param>
    void RotateRight(double deg);

    /// <summary>
    /// Rotates the camera a given amount of degrees towards the up
    /// </summary>
    /// <param name="deg">amount of degrees to rotate right</param>
    void RotateUp(double deg);

    /// <summary>
    /// Set the maximum amount of point displayed in the viewer.
    /// </summary>
    /// <param name="pointBudget">can be set to 'Low', 'Med' or 'High'</param>
    void SetPointBudget(PointBudget pointBudget);

    /// <summary>
    /// Set the size points are displayed on.
    /// </summary>
    /// <param name="size">new size of points in the viewer. Range between 0.1 and 50.</param>
    void SetPointSize(int size);

    /// <summary>
    /// Set the style of points. See PointStyle Enum.
    /// </summary>
    /// <param name="pointStyle">new the style of points</param>
    void SetPointStyle(PointStyle pointStyle);

    /// <summary>
    /// Toggle the visibility of a button.
    /// </summary>
    /// <param name="buttonId"></param>
    /// <param name="enabled">if available, sets enabled to this value</param>
    void ToggleButtonEnabled(PointCloudViewerButtons buttonId, bool enabled);

    /// <summary>
    /// Toggles or sets the visibility of edges around points.
    /// </summary>
    /// <param name="visible">if available, set visibility to this value</param>
    void ToggleEdges(bool visible);
  }
}
