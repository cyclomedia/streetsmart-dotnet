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
using System.Windows.Forms;

using MultipleAPI.WinForms.Properties;

using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace MultipleAPI.WinForms
{
  enum State
  {
    ApiReady = 0,
    ApiInitialized = 1,
    PanoramaOpened = 2
  }

  public partial class MultipleDemo : Form
  {
    private const string Srs = "EPSG:28992";
    private const string Language = "nl";
    private const string Database = "CMDatabase";

    private readonly IStreetSmartAPI _api;
    private IOptions _options;

    public MultipleDemo()
    {
      InitializeComponent();
      _api = StreetSmartAPIFactory.Create();
      _api.APIReady += OnApiReady;
      plStreetSmart.Controls.Add(_api.GUI);
    }

    private void OnApiReady(object sender, EventArgs args)
    {
      SetApiState(State.ApiReady);
    }

    private async void btnInit_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create(Language, Database);
      IDomElement element = DomElementFactory.Create();
      _options = OptionsFactory.Create(Resources.Username, Resources.Password, Resources.APIKey, Srs, Language, addressSettings, element);
      await _api.Init(_options);
      SetApiState(State.ApiInitialized);
    }

    private async void btnDestroy_Click(object sender, EventArgs e)
    {
      await _api.Destroy(_options);
      SetApiState(State.ApiReady);
    }

    private async void btnOpen_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType> { ViewerType.Panorama };
      IPanoramaViewerOptions panoramaOptions = PanoramaViewerOptionsFactory.Create(false, false, true, true, true, true);
      IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, Srs, panoramaOptions);
      await _api.Open(txtSearch.Text, viewerOptions);
      SetApiState(State.PanoramaOpened);
    }

    private void btnDevTools_Click(object sender, EventArgs e)
    {
      _api.ShowDevTools();
    }

    private void SetApiState(State state)
    {
      if (btnOpen.InvokeRequired)
      {
        btnOpen.Invoke(new MethodInvoker(() => btnOpen.Enabled = state == State.ApiInitialized));
      }
      else
      {
        btnOpen.Enabled = state == State.ApiInitialized;
      }

      if (btnDestroy.InvokeRequired)
      {
        btnDestroy.Invoke(new MethodInvoker(() => btnDestroy.Enabled = state == State.PanoramaOpened));
      }
      else
      {
        btnDestroy.Enabled = state == State.PanoramaOpened;
      }

      if (btnInit.InvokeRequired)
      {
        btnInit.Invoke(new MethodInvoker(() => btnInit.Enabled = state == State.ApiReady));
      }
      else
      {
        btnInit.Enabled = state == State.ApiReady;
      }
    }
  }
}
