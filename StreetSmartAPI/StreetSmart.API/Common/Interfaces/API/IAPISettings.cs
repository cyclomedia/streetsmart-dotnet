/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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

namespace StreetSmart.Common.Interfaces.API
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// API used to use and modify various StreetSmart components.
  /// </summary>
  public interface IAPISettings
  {
    /// <summary>
    /// The path to a separate executable that will be launched for sub-processes.By default the browser process
    /// executable is used.See the comments on Cef.ExecuteProcess() for details.Also configurable using the "browser-
    /// subprocess-path" command-line switch. Default is CefSharp.BrowserSubprocess.exe
    /// </summary>
    string BrowserSubprocessPath { get; set; }

    /// <summary>
    /// The location where cache data will be stored on disk. If empty then browsers will be created in "incognito mode"
    /// where in-memory caches are used for storage and no data is persisted to disk. HTML5 databases such as
    /// localStorage will only persist across sessions if a cache path is specified. Can be overridden for individual
    /// CefRequestContext instances via the RequestContextSettings.CachePath value.
    /// </summary>
    string CachePath { get; set; }

    /// <summary>
    /// Don't create a "GPUCache" directory when cache-path is unspecified.
    /// </summary>
    bool DisableGPUCache { get; set; }

    /// <summary>
    /// Allow insecure content
    /// </summary>
    bool AllowInsecureContent { get; set; }

    /// <summary>
    /// The path to the locales directory, if empty locales\ will be used.
    /// </summary>
    string LocalesDirPath { get; set; }

    /// <summary>
    /// The path to the resources directory, if empty the Executing Assembly path is used.
    /// </summary>
    string ResourcesDirPath { get; set; }

    /// <summary>
    /// The locale string that will be passed to WebKit. If empty the default locale of "en-US" will be used.
    /// </summary>
    string Locale { get; set; }

    /// <summary>
    /// Sets the default browserSupProcessPath
    /// </summary>
    void SetDefaultBrowserSubprocessPath();

    /// <summary>
    /// Sets the default localesDirPath
    /// </summary>
    void SetDefaultLocalesDirPath();

    /// <summary>
    /// Sets the default resourcesDirPath
    /// </summary>
    void SetDefaultResourcesDirPath();
  }

  // ReSharper restore InconsistentNaming
}
