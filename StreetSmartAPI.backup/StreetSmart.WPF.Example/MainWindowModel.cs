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
using System.Collections.Generic;
using System.Windows.Input;

using StreetSmart.WPF.Example.Properties;

using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.WPF.Example
{
  public class MainWindowModel: NotifyPropertyChanged
  {
    #region Constants

    private const string Srs = "EPSG:28992";
    private const string Language = "nl";
    private const string Database = "CMDatabase";
    private const string TestLocation = "van voordenpark 1a, zaltbommel";

    #endregion

    #region Properties

    private bool _developerTools;
    private IOptions _options;
    private string _restartUrl;
    private string _configurationUrl;
    private string _username;
    private string _password;

    public IStreetSmartAPI Api { get; set; }

    public string RestartUrl
    {
      get => _restartUrl;
      set
      {
        _restartUrl = value;
        RaisePropertyChanged();
      }
    }

    public string ConfigurationUrl
    {
      get => _configurationUrl;
      set
      {
        _configurationUrl = value;
        RaisePropertyChanged();
      }
    }

    public string Username
    {
      get => _username;
      set
      {
        _username = value;
        RaisePropertyChanged();
      }
    }

    public string Password
    {
      get => _password;
      set
      {
        _password = value;
        RaisePropertyChanged();
      }
    }

    public ICommand RestartCommand => new DelegateCommand(RestartStreetSmart);

    public ICommand DeveloperCommand => new DelegateCommand(ToggleDeveloperTools);

    #endregion

    #region Constructor

    public MainWindowModel()
    {
      _developerTools = false;
      Username = Resources.Username;
      Password = Resources.Password;
      ConfigurationUrl = "https://atlas.cyclomedia.com/configuration";
      Api = StreetSmartAPIFactory.Create();
      Api.APIReady += ApiReady;
    }

    #endregion

    #region api ready function

    private async void ApiReady(object sender, EventArgs args)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create(Language, Database);
      IDomElement element = DomElementFactory.Create();
      _options = string.IsNullOrEmpty(ConfigurationUrl)
        ? OptionsFactory.Create(Username, Password, Resources.ApiKey, Srs, Language, addressSettings, element)
        : OptionsFactory.Create(Username, Password, Resources.ApiKey, Srs, Language, ConfigurationUrl,
          addressSettings, element);
      await Api.Init(_options);

      IList<ViewerType> viewerTypes = new List<ViewerType> {ViewerType.Panorama};
      IPanoramaViewerOptions panoramaOptions =
        PanoramaViewerOptionsFactory.Create(false, false, true, true, true, true);
      IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, Srs, panoramaOptions);
      await Api.Open(TestLocation, viewerOptions);

      Username = "cyclo";
      Password = "cyclo";
      ConfigurationUrl = Resources.ConfigurationUrl;
      RestartUrl = Resources.StreetSmartLocation;
    }

    private async void RestartStreetSmart()
    {
      // "https://streetsmart.cyclomedia.com/api/v18.10/api-dotnet.html"
      await Api.Destroy(_options);
      Api.RestartStreetSmart(RestartUrl);
    }

    private void ToggleDeveloperTools()
    {
      _developerTools = !_developerTools;

      if (_developerTools)
      {
        Api.ShowDevTools();
      }
      else
      {
        Api.CloseDevTools();
      }
    }

    #endregion
  }
}
