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

namespace StreetSmart.Common.Interfaces.DomElement
{
  /// <summary>
  /// Represents an object which takes a panorama viewer.
  /// </summary>
  public interface IDomElement
  {
    /// <summary>
    /// The Id of the element
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// The Style of the element
    /// </summary>
    IStyle Style { get; set; }

    /// <summary>
    /// The name of the element
    /// </summary>
    string Name { get; }
  }
}
