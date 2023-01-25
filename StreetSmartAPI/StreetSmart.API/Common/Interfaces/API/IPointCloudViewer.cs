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
    event EventHandler<IEventArgs<PointSize>> PointSizeChanged;

    /// <summary>
    /// Triggers on a point style change
    /// </summary>
    event EventHandler<IEventArgs<ColorizationMode>> PointStyleChanged;

    /// <summary>
    /// Triggers on a point budged change
    /// </summary>
    event EventHandler<IEventArgs<Quality>> PointBudgedChanged;

    /// <summary>
    /// Background Changed
    /// </summary>
    event EventHandler<IEventArgs<BackgroundPreset>> BackGroundChanged;

    /// <summary>
    /// Get the background of the PointCloud. See the background enum
    /// </summary>
    /// <returns>The background of the PointCloud</returns>
    Task<BackgroundPreset> GetBackgroundPreset();

    /// <summary>
    /// Get the visibility of a button
    /// </summary>
    /// <param name="buttonId">The buttonId of which the visibility is requested</param>
    /// <returns>Visibility of the button</returns>
    Task<bool> GetButtonEnabled(PointCloudViewerButtons buttonId);

    /// <summary>
    /// Get current visibility of black edges around points.
    /// </summary>
    /// <returns>Visibility of edges around points</returns>
    Task<bool> GetEdgesVisibility();

    /// <summary>
    /// Get the maximal height colorization, these values are only used with the point style: Height
    /// </summary>
    /// <returns>Maximal height colorization can be between -10 and 50</returns>
    Task<double> GetMaxHeightColorization();

    /// <summary>
    /// Get the minimal height colorization, these values are only used with the point style: Height
    /// </summary>
    /// <returns>Minimal height colorization can be between -10 and 50</returns>
    Task<double> GetMinHeightColorization();

    /// <summary>
    /// Get current point amount, see quality enum
    /// </summary>
    /// <returns>Amount - can be 'low', 'medium' or 'high' or 'ultra'</returns>
    Task<Quality> GetPointAmount();

    /// <summary>
    /// Get current size of points, see PointSize enum
    /// </summary>
    /// <returns>Size of points</returns>
    Task<PointSize> GetPointSize();

    /// <summary>
    /// Get current style of points
    /// </summary>
    /// <returns>style - the style of points</returns>
    Task<ColorizationMode> GetPointStyle();

    /// <summary>
    /// Set the background. See the background enum.
    /// </summary>
    /// <param name="background">The new background</param>
    void SetBackgroundPreset(BackgroundPreset background);

    /// <summary>
    /// Set the maximum height colorization, this function can only be used with the point style: Height
    /// </summary>
    /// <param name="heightColorization">The maximum height colorization</param>
    void SetMaxHeightColorization(double heightColorization);

    /// <summary>
    /// Set the minimum height colorization, this function can only be used with the point style: Height
    /// </summary>
    /// <param name="heightColorization">The minimum height colorization</param>
    void SetMinHeightColorization(double heightColorization);

    /// <summary>
    /// Set the maximum amount of point displayed in the viewer.
    /// </summary>
    /// <param name="amount">can be set to 'Low', 'Med' or 'High'</param>
    void SetPointAmount(Quality amount);

    /// <summary>
    /// Set the size points are displayed on, see PointSize enum.
    /// </summary>
    /// <param name="size">new size of points in the viewer.</param>
    void SetPointSize(PointSize size);

    /// <summary>
    /// Set the style of points. See colorizationMode Enum.
    /// </summary>
    /// <param name="style">new the style of points</param>
    void SetPointStyle(ColorizationMode style);

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

    /// <summary>
    /// Toggles between aerial point cloud and street point cloud
    /// </summary>
    /// <param name="value">)If available, sets visibility to this value.</param>
    void TogglePointCloudType(PointCloudType? value);
  }
}
