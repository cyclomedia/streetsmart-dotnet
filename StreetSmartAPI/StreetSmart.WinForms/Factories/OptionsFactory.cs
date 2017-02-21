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

using System;
using System.Globalization;
using System.Security;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// 
  /// </summary>
  public static class OptionsFactory
  {
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <returns></returns>
    public static IOptions Create(string userName, string password, string apiKey, string srs)
      => Create(userName, password, apiKey, srs, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <param name="addressSettings"></param>
    /// <returns></returns>
    public static IOptions Create(string userName, string password, string apiKey, string srs,
      IAddressSettings addressSettings)
      => Create(userName, password, apiKey, srs, string.Empty, string.Empty, addressSettings);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <param name="locale"></param>
    /// <param name="addressSettings"></param>
    /// <returns></returns>
    public static IOptions Create(string userName, string password, string apiKey, string srs, string locale,
      IAddressSettings addressSettings)
      => Create(userName, password, apiKey, srs, string.IsNullOrEmpty(locale) ? null : new CultureInfo(locale),
        string.Empty, addressSettings);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <param name="locale"></param>
    /// <param name="addressSettings"></param>
    /// <returns></returns>
    public static IOptions Create(string userName, string password, string apiKey, string srs, CultureInfo locale,
      IAddressSettings addressSettings)
      => Create(userName, password, apiKey, srs, locale, string.Empty, addressSettings);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <param name="locale"></param>
    /// <param name="configurationURL"></param>
    /// <param name="addressSettings"></param>
    /// <returns></returns>
    public static IOptions Create(string userName, string password, string apiKey, string srs, string locale,
      string configurationURL, IAddressSettings addressSettings)
      => Create(userName, password, apiKey, srs, string.IsNullOrEmpty(locale) ? null : new CultureInfo(locale),
        configurationURL, addressSettings);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="apiKey"></param>
    /// <param name="srs"></param>
    /// <param name="locale"></param>
    /// <param name="configurationURL"></param>
    /// <param name="addressSettings"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IOptions Create(string userName, string password, string apiKey, string srs, CultureInfo locale,
      string configurationURL, IAddressSettings addressSettings)
    {
      if (string.IsNullOrEmpty(userName))
      {
        throw new ArgumentNullException(nameof(userName));
      }

      if (string.IsNullOrEmpty(password))
      {
        throw new ArgumentNullException(nameof(password));
      }

      if (string.IsNullOrEmpty(apiKey))
      {
        throw new ArgumentNullException(nameof(apiKey));
      }

      if (string.IsNullOrEmpty(srs))
      {
        throw new ArgumentNullException(nameof(srs));
      }

      SecureString Password = new SecureString();

      foreach (var character in password)
      {
        Password.AppendChar(character);
      }

      return new Options(userName, Password, apiKey, srs, locale,
        string.IsNullOrEmpty(configurationURL) ? null : new Uri(configurationURL), addressSettings);
    }

    // ReSharper restore InconsistentNaming
  }
}
