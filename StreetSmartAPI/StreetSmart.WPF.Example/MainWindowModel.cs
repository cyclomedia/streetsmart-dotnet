/*
 * Street Smart .NET integration
 * Copyright (c) 2018, CycloMedia, All rights reserved.
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

using StreetSmart.Wpf.Factories;
using StreetSmart.Wpf.Interfaces.API;
using StreetSmart.WPF.Example.Properties;

using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.WPF.Example
{
  public class MainWindowModel
  {
    #region Constants

    private const string Srs = "EPSG:28992";
    private const string Language = "nl";
    private const string Database = "CMDatabase";
    private const string TestLocation = "van voordenpark 1a, zaltbommel";

    #endregion

    #region Members

    private IOptions _options;

    #endregion

    #region Properties

    public IStreetSmartAPI Api { get; }

    #endregion

    #region Constructor

    public MainWindowModel()
    {
      Api = StreetSmartAPIFactory.Create();
      Api.APIReady += ApiReady;
    }

    #endregion

    #region api ready function

    private async void ApiReady(object sender, EventArgs args)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create(Language, Database);
      IDomElement element = DomElementFactory.Create();
      _options = OptionsFactory.Create(Resources.Username, Resources.Password, Resources.ApiKey, Srs, Language,
        addressSettings, element);
      await Api.Init(_options);

      IList<ViewerType> viewerTypes = new List<ViewerType> { ViewerType.Panorama };
      IPanoramaViewerOptions panoramaOptions = PanoramaViewerOptionsFactory.Create(false, false, true, true, true, true);
      IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, Srs, panoramaOptions);
      await Api.Open(TestLocation, viewerOptions);
    }

    #endregion
  }
}
