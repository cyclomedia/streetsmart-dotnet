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

using System.Globalization;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// 
  /// </summary>
  public static class AddressSettingsFactory
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    /// <returns></returns>
    public static IAddressSettings Create(string database)
    {
      return Create(CultureInfo.CurrentCulture, database);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public static IAddressSettings Create(string locale, string database)
    {
      return Create(new CultureInfo(locale), database);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public static IAddressSettings Create(CultureInfo locale, string database)
    {
      return new AddressSettings(locale, database);
    }
  }
}
