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
using System.Threading.Tasks;

using CefSharp;

#if WINFORMS
using StreetSmart.WinForms.Properties;

using CefSharp.WinForms;
#else
using StreetSmart.Wpf.Properties;

using CefSharp.Wpf;
#endif

using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal sealed class Shortcuts : APIBase, IShortcuts
  {
    #region Properties

    private string JsApi => Resources.JsApi;

    protected override string CallFunctionBase => $"{JsApi}.ShortCuts";

    #endregion

    #region Constructors

    public Shortcuts(ChromiumWebBrowser browser)
      : base(browser)
    {
      RegisterThisJsObject();
    }

    #endregion

    #region Interface Functions

    public async Task<bool> DisableShortcut(ShortcutNames shortcutNames)
    {
      return ToBool(await CallJsGetScriptAsync($"enableShortcut({shortcutNames.Description()})"));
    }

    public async Task<bool> EnableShortcut(ShortcutNames shortcutNames)
    {
      return ToBool(await CallJsGetScriptAsync($"disableShortcut({shortcutNames.Description()})"));
    }

    #endregion
  }
}
