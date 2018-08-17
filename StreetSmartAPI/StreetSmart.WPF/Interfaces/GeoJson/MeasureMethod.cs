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

namespace StreetSmart.Wpf.Interfaces.GeoJson
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
    NotDefined = -1,

    /// <summary>
    ///  Measure using depth map (in marketing terms: Measure Smart)
    /// </summary>
    DepthMap = 1,

    /// <summary>
    ///Measure using Smart Click
    /// </summary>
    SmartClick = 2,

    /// <summary>
    /// Measure using Auto Focus
    /// </summary>
    AutoFocus = 3,

    /// <summary>
    /// Measure using manual forward intersection
    /// </summary>
    ForwardIntersection = 4
  }
}
