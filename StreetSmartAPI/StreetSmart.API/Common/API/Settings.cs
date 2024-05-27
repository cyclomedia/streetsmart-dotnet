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

#if WINFORMS
using StreetSmart.WinForms.Properties;
#else
using StreetSmart.Wpf.Properties;
#endif

using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal sealed class Settings : APIBase, ISettings
  {
    #region Properties

    private string JsApi => Resources.JsApi;

    protected override string CallFunctionBase => $"{JsApi}.Settings";

    #endregion

    #region Constructors

    public Settings(IStreetSmartBrowser browser)
      : base(browser)
    {
      RegisterThisJsObject();
    }

    #endregion

    #region Interface Functions

    public void SetUnitPreference(UnitPreference unitPreference)
    {
      Browser.ExecuteScriptAsync(GetScript($"setUnitPreference({unitPreference.Description()})"));
    }

    public async Task<UnitPreference> GetUnitPreference()
    {
      string type = ToString(await CallJsGetScriptAsync("getUnitPreference()"));
      UnitPreference preference = UnitPreference.Default;

      switch (type)
      {
        case "default":
          preference = UnitPreference.Default;
          break;
        case "ft":
          preference = UnitPreference.Feet;
          break;
        case "m":
          preference = UnitPreference.Meter;
          break;
      }

      return preference;
    }

    #endregion
  }
}
