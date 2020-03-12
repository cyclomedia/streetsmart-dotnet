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

using System.ComponentModel;

namespace StreetSmart.Common.Interfaces.GeoJson
{
  /// <summary>
  /// Reliability
  /// </summary>
  public enum Reliability
  {
    /// <summary>
    /// Not defined
    /// </summary>
    [Description("")]
    NotDefined = 0,

    /// <summary>
    /// Good reliablity
    /// </summary>
    [Description("RELIABLE")]
    Reliable = 1,

    /// <summary>
    /// Acceptable reliability
    /// </summary>
    [Description("ACCEPTABLE")]
    Acceptable = 2,

    /// <summary>
    /// Bad reliability
    /// </summary>
    [Description("UNRELIABLE")]
    Unreliable = 3
  }
}
