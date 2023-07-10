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

namespace StreetSmart.Common.Interfaces.API
{
  /// <inheritdoc />
  /// <summary>
  /// MeshViewer component. Gets created by the StreetSmartAPI.
  /// </summary>
  public interface IMeshViewer : IViewer
  {
    /// <summary>
    /// Returns whether map is desatured or not
    /// </summary>
    /// <returns>desatured or not</returns>
    Task<bool> GetMapDesaturated();

    /// <summary>
    /// Sets the texture of the meshes either to gray-scale (desaturated=true) or color
    /// </summary>
    /// <param name="desaturated">gray-scale (desaturated=true) or color</param>
    void SetDesaturatedTexture(bool desaturated);

    /// <summary>
    /// Update the height of the eye in LOS analysis
    /// </summary>
    /// <param name="eyeHeight">height of the eye</param>
    void SetLOSEyeHeight(double eyeHeight);

    /// <summary>
    /// Determines whether user is able to interact with the RIA map or not
    /// </summary>
    /// <param name="enabled">user is able to interact with the RIA map or not</param>
    void SetNavigationState(bool enabled);

    /// <summary>
    /// Set the visibility of any layer. Creates one if the layer we want to be visible isn't added to the map yet
    /// </summary>
    /// <param name="layerId">The layerId</param>
    /// <param name="visibility">The visibility</param>
    void SetOverlayVisibility(string layerId, bool visibility);

    /// <summary>
    /// Saves time to state and sets the time in the Ria api
    /// </summary>
    /// <param name="time">if no date is passed, time is set to default of 12 p.m. (noon) 21 June</param>
    void SetTime(DateTime? time);
  }
}
