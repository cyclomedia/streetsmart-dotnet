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

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Options for initialize the API
  /// </summary>
  public interface IOptions
  {
    /// <summary>
    /// Username of the user
    /// </summary>
    string Username { get; set; }

    /// <summary>
    /// Password of the user
    /// </summary>
    SecureString Password { get; set; }

    // ReSharper disable InconsistentNaming

    /// <summary>
    /// ApiKey given to the user
    /// </summary>
    string APIKey { get; set; }

    /// <summary>
    /// Coordinate system used in the API
    /// </summary>
    string SRS { get; set; }

    /// <summary>
    /// Language used as default
    /// </summary>
    CultureInfo Locale { get; set; }

    /// <summary>
    /// Alternate configuration URL to use for all configuration services
    /// </summary>
    Uri ConfigurationURL { get; set; }

    // ReSharper restore InconsistentNaming

    /// <summary>
    /// Address search settings
    /// </summary>
    IAddressSettings AddressSettings { get; set; }
  }
}
