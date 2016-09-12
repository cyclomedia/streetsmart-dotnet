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

using CefSharp;

using StreetSmart.WinForms.Interfaces;

using static StreetSmart.WinForms.Properties.Resources;

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Creates a new instance of the API.
  /// </summary>
  public class APIBuilder
  {
    static APIBuilder()
    {
      Cef.Initialize(new CefSettings(), false, true);
    }

    /// <summary>
    /// Creates a new instance of the API.
    /// </summary>
    /// <returns>A new instance of the API.</returns>
    public static IStreetSmartAPI CreateAPI()
    {
      return CreateAPI(StreetSmartLocation);
    }

    /// <summary>
    /// Creates a new instance of the API
    /// </summary>
    /// <param name="streetSmartLocation">The location of StreetSmart</param>
    /// <returns>A new instance of the API.</returns>
    public static IStreetSmartAPI CreateAPI(string streetSmartLocation)
    {
      return new StreetSmartAPI(streetSmartLocation);
    }
  }

  // ReSharper restore InconsistentNaming
}
