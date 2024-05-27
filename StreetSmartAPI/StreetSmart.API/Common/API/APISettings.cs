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

using System;
using System.IO;
using System.Reflection;
using CefSharp;
using StreetSmart.Common.Interfaces.API;

#if WINFORMS
using CefSharp.WinForms;
using StreetSmart.WinForms.Properties;
#else
using CefSharp.Wpf;
using StreetSmart.Wpf.Properties;
#endif

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal class APISettings: CefSettings, IAPISettings
  {
    public APISettings(string cachePath, string browserSubprocessPath, string localesDirPath, string resourcesDirPath)
    {
      LogSeverity = LogSeverity.Disable;
      CachePath = cachePath ?? CachePath;
      BrowserSubprocessPath = browserSubprocessPath ?? BrowserSubprocessPath;
      LocalesDirPath = localesDirPath ?? LocalesDirPath;
      ResourcesDirPath = resourcesDirPath ?? ResourcesDirPath;
    }

    public APISettings()
      : this(null, null, null, null)
    {
    }

    private string DirectoryPath
    {
      get
      {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path) ?? string.Empty;
      }
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

    public bool AllowInsecureContent
    {
      get => GetCommandLineArgs(CommandLineArgs.AllowInsecureContent);
      set => SetCommandLineArgs(value, CommandLineArgs.AllowInsecureContent);
    }

    public void SetDefaultBrowserSubprocessPath()
    {
      BrowserSubprocessPath = Path.Combine(DirectoryPath, Resources.BrowserSubprocess);
    }

    public void SetDefaultLocalesDirPath()
    {
      LocalesDirPath = Path.Combine(DirectoryPath, Resources.LocalesPath);
    }

    public void SetDefaultResourcesDirPath()
    {
      ResourcesDirPath = Path.Combine(DirectoryPath, Resources.ResourcesPath);
    }
  }
}
