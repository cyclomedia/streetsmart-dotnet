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

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  // ReSharper disable InconsistentNaming

  internal class Options : NotifyPropertyChanged, IOptions
  {
    public string _userName;
    public SecureString _password;
    public string _apiKey;
    public string _srs;
    public CultureInfo _locale;
    public Uri _configurationURL;
    public IAddressSettings _addressSettings;

    public Options(string userName, SecureString password, string apiKey, string srs, CultureInfo locale,
      Uri configurationURL, IAddressSettings addressSettings)
    {
      Username = userName;
      Password = password;
      APIKey = apiKey;
      SRS = srs;
      Locale = locale;
      ConfigurationURL = configurationURL;
      AddressSettings = addressSettings;
    }

    public string Username
    {
      get { return _userName; }
      set
      {
        _userName = value;
        RaisePropertyChanged();
      }
    }

    public SecureString Password
    {
      get { return _password; }
      set
      {
        _password = value;
        RaisePropertyChanged();
      }
    }

    public string APIKey
    {
      get
      {
        return _apiKey;
      }
      set
      {
        _apiKey = value;
        RaisePropertyChanged();
      }
    }

    public string SRS
    {
      get { return _srs; }
      set
      {
        _srs = value;
        RaisePropertyChanged();
      }
    }

    public CultureInfo Locale
    {
      get { return _locale; }
      set
      {
        _locale = value;
        RaisePropertyChanged();
      }
    }

    public Uri ConfigurationURL
    {
      get { return _configurationURL; }
      set
      {
        _configurationURL = value;
        RaisePropertyChanged();
      }
    }

    public IAddressSettings AddressSettings
    {
      get { return _addressSettings; }
      set
      {
        _addressSettings = value;
        RaisePropertyChanged();
      }
    }
  }

  // ReSharper restore InconsistentNaming
}
