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

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// Unit Preference of measurements
  /// </summary>
  public enum UnitPreference
  {
    /// <summary>
    /// Default value
    /// </summary>
    [Description("StreetSmartApi.Settings.UNIT_PREFERENCE.DEFAULT")]
    Default = 0,

    /// <summary>
    /// Meter value
    /// </summary>
    [Description("StreetSmartApi.Settings.UNIT_PREFERENCE.METER")]
    Meter = 1,

    /// <summary>
    /// Feet value
    /// </summary>
    [Description("StreetSmartApi.Settings.UNIT_PREFERENCE.FEET")]
    Feet = 2
  }
}
