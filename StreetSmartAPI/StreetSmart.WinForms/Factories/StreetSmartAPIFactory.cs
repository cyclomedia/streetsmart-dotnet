/*
 * Street Smart .NET integration
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

using StreetSmart.WinForms.API;
using StreetSmart.WinForms.Handlers;
using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Properties;

namespace StreetSmart.WinForms.Factories
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Factory for creates a new instance of the API. API used to use and modify various StreetSmart components.
  /// </summary>
  public static class StreetSmartAPIFactory
  {
    static StreetSmartAPIFactory()
    {
      Cef.Initialize(new CefSettings(), true, new BrowserProcessHandler());
    }

    /// <summary>
    /// Creates a new instance of the API. API used to use and modify various StreetSmart components.
    /// </summary>
    /// <returns>API used to use and modify various StreetSmart components.</returns>
    public static IStreetSmartAPI Create() => Create(Resources.StreetSmartLocation);

    /// <summary>
    /// Creates a new instance of the API. API used to use and modify various StreetSmart components.
    /// </summary>
    /// <param name="streetSmartLocation">The location Uri of StreetSmart</param>
    /// <returns>API used to use and modify various StreetSmart components.</returns>
    public static IStreetSmartAPI Create(string streetSmartLocation) => new StreetSmartAPI(streetSmartLocation);
  }

  // ReSharper restore InconsistentNaming
}
