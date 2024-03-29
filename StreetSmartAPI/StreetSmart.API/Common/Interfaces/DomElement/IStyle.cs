﻿/*
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

namespace StreetSmart.Common.Interfaces.DomElement
{
  /// <summary>
  /// Style element of the domElement
  /// </summary>
  public interface IStyle
  {
    /// <summary>
    /// Add a style element
    /// </summary>
    /// <param name="name">Name of the style element</param>
    /// <param name="value">Value of the style element</param>
    void AddStyle(StyleElementName name, string value);

    /// <summary>
    /// Add a style element
    /// </summary>
    /// <param name="name">Name of the style element</param>
    /// <param name="value">Value of the style element</param>
    /// <param name="type">Type of the style element</param>
    void AddStyle(StyleElementName name, int value, StyleElementNumberType type);

    /// <summary>
    /// Remove a style element
    /// </summary>
    /// <param name="name">Name of the style element</param>
    void RemoveStyle(StyleElementName name);

    /// <summary>
    /// Update a style element
    /// </summary>
    /// <param name="name">Name of the style element</param>
    /// <param name="value">Value of the style element</param>
    void UpdateStyle(StyleElementName name, string value);

    /// <summary>
    /// Update a style element
    /// </summary>
    /// <param name="name">Name of the style element</param>
    /// <param name="value">Value of the style element</param>
    /// <param name="type">Type of the style element</param>
    void UpdateStyle(StyleElementName name, int value, StyleElementNumberType type);
  }
}
