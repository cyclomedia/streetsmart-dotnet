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

using StreetSmart.Common.Interfaces.DomElement;
using System;
using System.Security;

namespace StreetSmart.Common.Interfaces.Data
{
  /// <summary>
  /// Object containing the options used for initializing the API
  /// </summary>
  public interface IOptions
  {
    /// <summary>
    /// Username of the user.
    /// </summary>
    string Username { get; set; }

    /// <summary>
    /// Password of the user.
    /// </summary>
    SecureString Password { get; set; }

    /// <summary>
    /// ClientId given to the user (for OAuth log in)
    /// </summary>
    string ClientId { get; set; }

    // ReSharper disable InconsistentNaming

    /// <summary>
    /// ApiKey given to the user.
    /// </summary>
    string APIKey { get; set; }

    /// <summary>
    /// Flag for login with oauth
    /// </summary>
    bool? LoginOauth { get; set; }

    /// <summary>
    /// Indicates to login with OAuth with silent authentication only. true means using silent authentication only. false means use silent authentication together with login popup authentication if silent authentication fails (for example when user session expired). This parameter is optional and false is default.
    /// </summary>
    bool? LoginOauthSilentOnly { get; set; }

    /// <summary>
    /// Flag for oauth logout to happen with destroy
    /// </summary>
    bool? DoOAuthLogoutOnDestroy { get; set; }

    /// <summary>
    /// Coordinate system used in the API. E.g. "EPSG:29882".
    /// </summary>
    string SRS { get; set; }

    /// <summary>
    /// Language used as default in the API.
    /// </summary>
    string Locale { get; set; }

    /// <summary>
    /// Deprecated - Alternate configuration url to use for all configuration services
    /// </summary>
    Uri ConfigurationURL { get; set; }

    // ReSharper restore InconsistentNaming

    /// <summary>
    /// The address settings to use for address searches.
    /// </summary>
    IAddressSettings AddressSettings { get; set; }

    /// <summary>
    /// DomElement where in the panoramic viewer is rendered
    /// </summary>
    IDomElement Element { get; set; }
  }
}
