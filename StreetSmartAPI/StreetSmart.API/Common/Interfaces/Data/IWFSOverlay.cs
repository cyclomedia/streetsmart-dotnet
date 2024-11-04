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

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Information about the overlay
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  // ReSharper disable once InconsistentNaming
  // ReSharper disable once IdentifierTypo
  public interface IWFSOverlay : IOverlay
  {
    /// <summary>
    /// The url where the WFS is hosted
    /// </summary>
    // ReSharper disable once InconsistentNaming
    Uri Url { get; set; }

    /// <summary>
    /// The type name of the layer
    /// </summary>
    string TypeName { get; set; }

    /// <summary>
    /// The WFS version to be used
    /// </summary>
    string Version { get; set; }

    /// <summary>
    /// Whether this layer requires authentication to access
    /// </summary>
    bool AuthRequired { get; set; }

    /// <summary>
    /// Credentials used to access the layer.
    /// </summary>
    ICredentials Credentials { get; set; }
  }
}
