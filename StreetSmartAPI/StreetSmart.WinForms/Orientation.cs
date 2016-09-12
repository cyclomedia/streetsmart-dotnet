/*
 * Integration in ArcMap for Cycloramas
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Orientation {yaw, pitch, hFov} of the PanoramaViewer to specific values all at once.
  /// </summary>
  public class Orientation
  {
    /// <summary>
    ///  	Optional value of the yaw.
    /// </summary>
    public double? Yaw { get; set; }

    /// <summary>
    /// Optional value of the pitch.
    /// </summary>
    public double? Pitch { get; set; }

    /// <summary>
    /// Optional value of the hFov.
    /// </summary>    
    public double? hFov { get; set; }
  }

  // ReSharper restore InconsistentNaming
}
