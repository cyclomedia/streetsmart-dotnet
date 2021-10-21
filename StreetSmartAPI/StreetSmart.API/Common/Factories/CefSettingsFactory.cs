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

using CefSharp;

using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.API;

namespace StreetSmart.Common.Factories
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Factory for create a API settings class
  /// </summary>
  public static class CefSettingsFactory
  {
    /// <summary>
    /// Creates a new instance of the API Settings class.
    /// </summary>
    /// <returns>API Settings class</returns>
    public static IAPISettings Create(string cachePath, string browserSubprocessPath = null, string localesDirPath = null, string resourcesDirPath = null)
    {
      return new APISettings(cachePath, browserSubprocessPath, localesDirPath, resourcesDirPath);
    }

    /// <summary>
    /// Creates a new instance of the API Settings class.
    /// </summary>
    /// <returns>API Settings class</returns>
    public static IAPISettings Create()
    {
      return new APISettings();
    }

    /// <summary>
    /// Set the language code
    /// </summary>
    /// <param name="languageCode"></param>
    public static bool SetLanguage(string languageCode)
    {
      bool result = false;

      Cef.UIThreadTaskFactory.StartNew(() =>
      {
        using (var context = Cef.GetGlobalRequestContext())
        {
          result = SetLanguage(languageCode, context);
        }
      });

      return result;
    }

    private static bool SetLanguage(string languageCode, IRequestContext context)
    {
      return context.SetPreference("intl.accept_languages", languageCode, out _);
    }
  }

  // ReSharper restore InconsistentNaming
}
