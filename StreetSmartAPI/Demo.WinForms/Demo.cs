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
using System.Windows.Forms;
using StreetSmart.WinForms;
using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Interfaces;

namespace Demo.WinForms
{
  public partial class Demo : Form
  {
    private ICycloramaViewer _viewer;
 
    public Demo()
    {
      InitializeComponent();
      IStreetSmartAPI api = APIBuilder.CreateAPI();
      api.FrameLoaded += OnFrameLoaded;
      api.LoginComplete += OnLoginComplete;
      api.InitComplete += OnInitComplete;
      plStreetSmart.Controls.Add(api.GUI);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {

    }

    private void btRotateLeft_Click(object sender, EventArgs e)
    {
      _viewer.RotateLeft(1);
    }

    #region events api

    private void OnFrameLoaded(object sender, EventArgs args)
    {
      IStreetSmartAPI api = sender as IStreetSmartAPI;
      api?.Login("hbr", "MJUygv01");
    }

    private void OnRecordingClick(object sender, EventArgs args)
    {
      MessageBox.Show("Click");
    }

    private void OnLoginComplete(object sender, EventLoginArgs args)
    {
      if (args.Success)
      {
        // login success
      }
    }

    private void OnInitComplete(object sender, EventInitArgs args)
    {
      if (args.Success)
      {
        string viewerObjectName = "viewer";
        IStreetSmartAPI api = sender as IStreetSmartAPI;
        _viewer = api?.CreateCycloramaViewer(viewerObjectName);

        if (_viewer != null)
        {
          _viewer.OpenByImageId("5D123456", "EPSG:28992");
          _viewer.RecordingClick += OnRecordingClick;
        }
      }
    }

    #endregion

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
      _viewer.RotateRight(1);
    }
  }
}
