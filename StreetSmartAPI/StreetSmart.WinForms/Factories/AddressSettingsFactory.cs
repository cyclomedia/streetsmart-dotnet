/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
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
  /// <example> 
  /// This sample shows how to use the <see cref="AddressSettingsFactory"/>.
  /// <code>
  /// using System;
  /// using StreetSmart.WinForms.Factories;
  /// using StreetSmart.WinForms.Interfaces;
  ///
  /// namespace Demo
  /// {
  ///   public class Example
  ///   {
  ///     private IStreetSmartAPI _api;
  ///     private System.Windows.Forms.Panel _plStreetSmart = new System.Windows.Forms.Panel();
  ///
  ///     public void StartAPI()
  ///     {
  ///       _api = StreetSmartAPIFactory.Create();
  ///       _api.APIReady += OnAPIReady;
  ///       plStreetSmart.Controls.Add(_api.GUI);
  ///     }
  ///
  ///     private void OnAPIReady(object sender, EventArgs args)
  ///     {
  ///       // Create a address settings that are used in the application
  ///       string locale = "nl";
  ///       string database = "CMDatabase";
  ///       IAddressSettings addressSettings = AddressSettingsFactory.Create(locale, database);
  ///
  ///       // The dom element within the api must be rendered.
  ///       IDomElement element = DomElementFactory.Create();
  ///
  ///       // The initialisation options of the api
  ///       // The address settings are used in the initialization of the api.
  ///       IOptions options = OptionsFactory.Create("myUsername", "myPassword", "myAPIKey", "EPSG:28992", addressSettings, element, 1);
  ///
  ///       // Initialize the api.
  ///       await _api.Init(options);
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public static class AddressSettingsFactory
  {
    /// <summary>
    /// Create address settings to use for address searches, based on the current culture settings and the address database.
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="AddressSettingsFactory.Create(string)"/> method.
    /// <code>
    /// // Create an address settings that are used in the application
    /// string database = "CMDatabase";
    /// IAddressSettings addressSettings = AddressSettingsFactory.Create(database);
    /// </code>
    /// </example>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings interface to use for address searches</returns>
    public static IAddressSettings Create(string database) => Create(CultureInfo.CurrentCulture, database);

    /// <summary>
    /// Create address settings to use for address searches, based on the locale string and the address database.
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="AddressSettingsFactory.Create(string, string)"/> method.
    /// <code>
    /// // Create an address settings that are used in the application
    /// string locale = "nl";
    /// string database = "CMDatabase";
    /// IAddressSettings addressSettings = AddressSettingsFactory.Create(locale, database);
    /// </code>
    /// </example>
    /// <param name="locale">The locale to use. e.g. 'nl'</param>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings interface to use for address searches</returns>
    public static IAddressSettings Create(string locale, string database) => Create(new CultureInfo(locale), database);

    /// <summary>
    /// Create address settings to use for address searches, based on the locale culture and the address database.
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="AddressSettingsFactory.Create(CultureInfo, string)"/> method.
    /// <code>
    /// // Create an address settings that are used in the application
    /// CultureInfo ci = new CultureInfo("en-US");
    /// string database = "CMDatabase";
    /// IAddressSettings addressSettings = AddressSettingsFactory.Create(ci, database);
    /// </code>
    /// </example>
    /// <param name="locale">The locale to use. e.g. 'nl'</param>
    /// <param name="database">The name of the database. e.g. 'CMDatabase'</param>
    /// <returns>The address settings interface to use for address searches</returns>
    public static IAddressSettings Create(CultureInfo locale, string database) => new AddressSettings(locale, database);
  }
}
