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

using CefSharp;

using StreetSmart.Common.Handlers;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.API;

#if WINFORMS
using CefSharp.WinForms;

using StreetSmart.WinForms.Properties;
#else
using CefSharp.Wpf;

using StreetSmart.Wpf.Properties;
#endif

namespace StreetSmart.Common.Factories
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Factory for creates a new instance of the API. API used to use and modify various StreetSmart components.
  /// </summary>
  public static class StreetSmartAPIFactory
  {
    private static void InitializeCefSharp(CefSettings settings)
    {
      if (settings != null)
      {
        CefSharpSettings.LegacyJavascriptBindingEnabled = true;
        BrowserProcessHandler browserProcessHandler = new BrowserProcessHandler();
        Cef.Initialize(settings, true, browserProcessHandler);
      }
    }

    /// <summary>
    /// Creates a new instance of the API. API used to use and modify various StreetSmart components.
    /// </summary>
    /// <param name="settings">The settings of CefSharp</param>
    /// <returns>API used to use and modify various StreetSmart components.</returns>
    public static IStreetSmartAPI Create(IAPISettings settings = null) => Create(Resources.StreetSmartLocation, settings);

    /// <summary>
    /// Creates a new instance of the API. API used to use and modify various StreetSmart components.
    /// </summary>
    /// <param name="streetSmartLocation">The location Uri of StreetSmart</param>
    /// <param name="settings">The settings of CefSharp</param>
    /// <returns>API used to use and modify various StreetSmart components.</returns>
    public static IStreetSmartAPI Create(string streetSmartLocation, IAPISettings settings = null)
    {
      InitializeCefSharp((settings ?? CefSettingsFactory.Create()) as CefSettings);
      return new StreetSmartAPI(streetSmartLocation);
    }
  }

  // ReSharper restore InconsistentNaming
}
