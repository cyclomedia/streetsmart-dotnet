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

using StreetSmart.Common.Data.SLD;

namespace StreetSmart.Common.Interfaces.SLD
{
  /// <summary>
  /// The rule
  /// </summary>
  public interface IRule
  {
    /// <summary>
    /// Vendor option
    /// </summary>
    VendorOption VendorOption { get; set; }

    /// <summary>
    /// Symbolizer
    /// </summary>
    Symbolizer Symbolizer { get; set; }
  }
}
