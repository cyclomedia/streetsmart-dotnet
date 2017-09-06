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

using System.Globalization;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// Factory for create address settings to use for address searches
  /// </summary>
  public static class AddressSettingsFactory
  {
    /// <summary>
    /// Create address settings to use for address searches
    /// </summary>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings to use for address searches</returns>
    public static IAddressSettings Create(string database) => Create(CultureInfo.CurrentCulture, database);

    /// <summary>
    /// Create address settings to use for address searches
    /// </summary>
    /// <param name="locale">The locale to use. e.g. 'nl'</param>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings to use for address searches</returns>
    public static IAddressSettings Create(string locale, string database) => Create(new CultureInfo(locale), database);

    /// <summary>
    /// Create address settings to use for address searches
    /// </summary>
    /// <param name="locale">The locale to use. e.g. 'nl'</param>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings to use for address searches</returns>
    public static IAddressSettings Create(CultureInfo locale, string database) => new AddressSettings(locale, database);
  }
}
