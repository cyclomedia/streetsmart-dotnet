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

using System;
using System.IO;
using System.Reflection;

using CefSharp;

#if WINFORMS
using CefSharp.WinForms;

using StreetSmart.WinForms.Properties;
#else
using CefSharp.Wpf;

using StreetSmart.Wpf.Properties;
#endif

using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal class APISettings: CefSettings, IAPISettings
  {
    public APISettings(string cachePath, string browserSubprocessPath)
    {
      CachePath = cachePath;
      BrowserSubprocessPath = browserSubprocessPath ?? GetBrowserSubprocessPath();
      LogSeverity = LogSeverity.Disable;
    }

    public APISettings()
      : this(null, null)
    {
    }

    private string GetBrowserSubprocessPath()
    {
      string codeBase = Assembly.GetExecutingAssembly().CodeBase;
      UriBuilder uri = new UriBuilder(codeBase);
      string path = Uri.UnescapeDataString(uri.Path);
      string browserSubprocessPath = Path.GetDirectoryName(path) ?? string.Empty;
      return Path.Combine(browserSubprocessPath, Resources.BrowserSubprocess);
    }

    private bool GetCommandLineArgs(string commandLine)
    {
      return CefCommandLineArgs.ContainsKey(commandLine);
    }

    private void SetCommandLineArgs(bool enabled, string commandLine)
    {
      if (enabled && !CefCommandLineArgs.ContainsKey(commandLine))
      {
        CefCommandLineArgs.Add(commandLine, "1");
      }
      else if (!enabled && CefCommandLineArgs.ContainsKey(commandLine))
      {
        CefCommandLineArgs.Remove(commandLine);
      }
    }

    public bool DisableGPUCache
    {
      get => GetCommandLineArgs(CommandLineArgs.DisableGPUCache);
      set => SetCommandLineArgs(value, CommandLineArgs.DisableGPUCache);
    }

    public bool DisableLocalStorage
    {
      get => GetCommandLineArgs(CommandLineArgs.DisableLogalStorage);
      set => SetCommandLineArgs(value, CommandLineArgs.DisableLogalStorage);
    }
  }
}
