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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Defines the measureMethod of the API
  /// </summary>
  public enum MeasureMethods
  {
    /// <summary>
    /// anything else
    /// </summary>
    [Description("MeasureMethods.UNKNOWN")]
    Unknown = -1,

    /// <summary>
    /// depth map
    /// </summary>
    [Description("MeasureMethods.DEPTH_MAP")]
    DepthMap = 1,

    /// <summary>
    /// smart click
    /// </summary>
    [Description("MeasureMethods.SMART_CLICK")]
    SmartClick = 2,

    /// <summary>
    /// forward intersection
    /// </summary>
    [Description("MeasureMethods.FORWARD_INTERSECTION")]
    ForwardIntersection = 3
  }
}
