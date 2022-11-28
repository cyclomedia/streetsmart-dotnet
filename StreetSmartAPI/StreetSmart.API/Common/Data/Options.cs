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
using System.Security;

using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.Common.Data
{
  internal class Options : NotifyPropertyChanged, IOptions
  {
    // ReSharper disable InconsistentNaming

    private string _userName;
    private SecureString _password;
    private string _clientId;
    private string _apiKey;
    private string _srs;
    private string _locale;
    private Uri _configurationURL;
    private IAddressSettings _addressSettings;
    private IDomElement _element;
    private bool? _loginOauth;

    public Options(string userName, SecureString password, string apiKey, string srs, string locale,
      Uri configurationURL, IAddressSettings addressSettings, IDomElement element, bool? loginOauth, string clientId)
    {
      Username = userName;
      Password = password;
      APIKey = apiKey;
      SRS = srs;
      Locale = locale;
      ConfigurationURL = configurationURL;
      AddressSettings = addressSettings;
      Element = element;
      LoginOauth = loginOauth;
      ClientId = clientId;
    }

    // ReSharper restore InconsistentNaming

    public string Username
    {
      get => _userName;
      set
      {
        _userName = value;
        RaisePropertyChanged();
      }
    }

    public SecureString Password
    {
      get => _password;
      set
      {
        _password = value;
        RaisePropertyChanged();
      }
    }

    public string ClientId
    {
      get => _clientId;
      set
      {
        _clientId = value;
        RaisePropertyChanged();
      }
    }

    public string APIKey
    {
      get => _apiKey;
      set
      {
        _apiKey = value;
        RaisePropertyChanged();
      }
    }

    public bool? LoginOauth
    {
      get => _loginOauth;
      set
      {
        _loginOauth = value;
        RaisePropertyChanged();
      }
    }

    public string SRS
    {
      get => _srs;
      set
      {
        _srs = value;
        RaisePropertyChanged();
      }
    }

    public string Locale
    {
      get => _locale;
      set
      {
        _locale = value;
        RaisePropertyChanged();
      }
    }

    public Uri ConfigurationURL
    {
      get => _configurationURL;
      set
      {
        _configurationURL = value;
        RaisePropertyChanged();
      }
    }

    public IAddressSettings AddressSettings
    {
      get => _addressSettings;
      set
      {
        _addressSettings = value;
        RaisePropertyChanged();
      }
    }

    public IDomElement Element
    {
      get => _element;
      set
      {
        _element = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      // ReSharper disable once InconsistentNaming
      string configurationURL = ConfigurationURL == null ? string.Empty : $",configurationUrl:'{ConfigurationURL}'";
      string locale = string.IsNullOrEmpty(Locale) ? string.Empty : $",locale:'{Locale}'";
      string addressSettings = AddressSettings?.ToString() ?? string.Empty;
      string userNamePassword = string.IsNullOrEmpty(Username) ? string.Empty : $",username:'{Username}',password:'{Password.ConvertToUnsecureString()}'";
      string clientId = string.IsNullOrEmpty(ClientId) ? string.Empty : $",clientId:'{ClientId}'";
      string loginOauth = LoginOauth == null ? string.Empty : $",loginOauth:{((bool)LoginOauth).ToJsBool()}{clientId}";
      return $"{{targetElement:{_element.Name}{userNamePassword},apiKey:'{APIKey}'{loginOauth},srs:'{SRS}'{locale}{configurationURL}{addressSettings}}}";
    }
  }
}
