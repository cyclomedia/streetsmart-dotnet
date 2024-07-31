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

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Measure method
  /// </summary>
  // ReSharper disable once InconsistentNaming
  public enum MeasureMethod
  {
    /// <summary>
    /// Not defined
    /// </summary>
    [Description("")]
    NotDefined = -1,

    /// <summary>
    /// unknown measurement method
    /// </summary>
    [Description("Unknown")]
    // ReSharper disable once InconsistentNaming
    Unknown = 0,

    /// <summary>
    ///  Measure using depth map (in marketing terms: Measure Smart)
    /// </summary>
    [Description("DepthMap")]
    DepthMap = 1,

    /// <summary>
    ///Measure using Smart Click
    /// </summary>
    [Description("SmartClick")]
    SmartClick = 2,

    /// <summary>
    /// Measure using Auto Focus
    /// </summary>
    [Description("AutoFocus")]
    AutoFocus = 3,

    /// <summary>
    /// Measure using manual forward intersection
    /// </summary>
    [Description("ForwardIntersection")]
    ForwardIntersection = 4,

    /// <summary>
    /// unknown measurement method
    /// </summary>
    [Description("unknown")]
    // ReSharper disable once InconsistentNaming
    unknown
  }
}
