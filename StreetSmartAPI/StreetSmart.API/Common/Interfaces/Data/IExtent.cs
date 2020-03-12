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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Extent definition
  /// </summary>
  public interface IExtent
  {
    /// <summary>
    /// X1 of the extent
    /// </summary>
    double X1 { get; set; }

    /// <summary>
    /// X2 of the extent
    /// </summary>
    double X2 { get; set; }

    /// <summary>
    /// Y1 of the extent
    /// </summary>
    double Y1 { get; set; }

    /// <summary>
    /// Y2 of the extent
    /// </summary>
    double Y2 { get; set; }
  }
}
