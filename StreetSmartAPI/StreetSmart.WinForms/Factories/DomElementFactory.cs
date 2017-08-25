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

using StreetSmart.WinForms.Data.DomElement;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// Factory for create a object which takes a panorama viewer
  /// </summary>
  public static class DomElementFactory
  {
    /// <summary>
    /// Creates a default DomElement which takes a panorama viewer
    /// </summary>
    /// <returns>Represents an object which takes a panorama viewer.</returns>
    public static IDomElement Create()
    {
      Style style = new Style();
      style.AddStyle(StyleElementName.Width, 100, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Height, 100, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Position, "absolute");
      style.AddStyle(StyleElementName.Top, 0, StyleElementNumberType.Pixels);
      style.AddStyle(StyleElementName.Left, 0, StyleElementNumberType.Pixels);
      return new DomElement(style);
    }

    /// <summary>
    /// Creates a default DomElement which takes a panorama viewer
    /// </summary>
    /// <param name="width">Width in percent</param>
    /// <param name="height">Height in percent</param>
    /// <param name="top">Top in pixels</param>
    /// <param name="left">Left in pixels</param>
    /// <returns>Represents an object which takes a panorama viewer.</returns>
    public static IDomElement Create(int width, int height, int top, int left)
    {
      Style style = new Style();
      style.AddStyle(StyleElementName.Width, width, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Height, height, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Position, "absolute");
      style.AddStyle(StyleElementName.Top, top, StyleElementNumberType.Pixels);
      style.AddStyle(StyleElementName.Left, left, StyleElementNumberType.Pixels);
      return new DomElement(style);
    }
  }
}
