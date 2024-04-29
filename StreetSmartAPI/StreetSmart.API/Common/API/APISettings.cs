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
using System.Linq;


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
    internal class APISettings : CefSettings, IAPISettings
    {
        public APISettings(string cachePath, string browserSubprocessPath, string localesDirPath, string resourcesDirPath)
        {
            LogSeverity = LogSeverity.Disable;
            CachePath = cachePath ?? CachePath;
            BrowserSubprocessPath = browserSubprocessPath ?? GetDefaultBrowserSubprocessPath();
            LocalesDirPath = localesDirPath ?? GetDefaultLocalesDirPath();
            ResourcesDirPath = resourcesDirPath ?? GetDefaultResourcesDirPath();
        }

        public APISettings()
          : this(null, null, null, null)
        {
        }

        private readonly string DirectoryPath = GetDirectoryPath();

        private static string GetDirectoryPath()
        {
            string codeBase = new Uri(
#if NET462
                Assembly.GetExecutingAssembly().CodeBase
#elif NET6_0
                Assembly.GetExecutingAssembly().Location
#endif
                ).LocalPath;

            var indexOfLastBackslash = codeBase.LastIndexOf(@"\");
            while (indexOfLastBackslash > 0)
            {
                codeBase = codeBase.Substring(0, indexOfLastBackslash + 1);
                var files = Directory.GetFiles(codeBase, "CefSharp.dll", SearchOption.TopDirectoryOnly);
                if(files.Any())
                {
                    return Path.GetDirectoryName(codeBase);
                }

                indexOfLastBackslash = codeBase.LastIndexOf(@"\");
            }

            return ""; // if the file isn't found throw an exception
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

        public string GetDefaultBrowserSubprocessPath()
        {
            return Path.Combine(DirectoryPath, Resources.BrowserSubprocess);
        }

        public string GetDefaultLocalesDirPath()
        {
            return Path.Combine(DirectoryPath, Resources.LocalesPath);
        }

        public string GetDefaultResourcesDirPath()
        {
            return Path.Combine(DirectoryPath, Resources.ResourcesPath);
        }
    }
}
