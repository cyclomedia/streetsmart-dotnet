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

namespace StreetSmart.WinForms.Interfaces.GeoJson
{
  /// <summary>
  /// Smart click / Forward intersection Details
  /// </summary>
  public interface IDetailsSmartClick : IDetailsForwardIntersection
  {
    /// <summary>
    /// Undocumented SmartClick behavior:
    /// If no result could be found, Confidence is -1 and ResultDirections contains a single 'i:nil' attribute with a value of true.
    /// Test location: corner of West-Kruiskade / Schouwburgplein and Mauritsweg, Rotterdam (January 2017, photo from 08/08/2016)
    /// https://streetsmart.cyclomedia.com/streetsmart?q=5D4FMDNX&imageParams=11;18;30
    /// </summary>
    int Confidence { get; }

    /// <summary>
    /// Depth
    /// </summary>
    double Depth { get; }
  }
}
