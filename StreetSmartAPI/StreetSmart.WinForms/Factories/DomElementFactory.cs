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
  /// This Factory creates DomElements
  /// </summary>
  public static class DomElementFactory
  {
    /// <summary>
    /// Creates a default DOMElement
    /// </summary>
    /// <returns></returns>
    public static IDomElement Create()
    {
      Style style = new Style();
      style.AddStyle(StyleElementName.Width, 100, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Height, 100, StyleElementNumberType.Percent);
      return new DomElement(style);
    }

    /// <summary>
    /// Creates a DOMElement
    /// </summary>
    /// <param name="width">width in percent</param>
    /// <param name="height">height in percent</param>
    /// <param name="top">top in pixels</param>
    /// <param name="left">left in pixels</param>
    /// <returns></returns>
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
