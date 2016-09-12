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

using StreetSmart.WinForms;
using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Interfaces;

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using static Demo.WinForms.Properties.Resources;
using Orientation = StreetSmart.WinForms.Orientation;

namespace Demo.WinForms
{
  public partial class Demo : Form
  {
    private readonly IStreetSmartAPI _api;

    private IPanoramaViewer _viewer;
    private IPanoramaViewer _viewer2;

    public Demo()
    {
      InitializeComponent();
      _api = APIBuilder.CreateAPI();
      _api.FrameLoaded += OnFrameLoaded;
      _api.InitComplete += OnInitComplete;
      plStreetSmart.Controls.Add(_api.GUI);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      IStreetSmartAPI api = sender as IStreetSmartAPI;
      api?.Init(txtUsername.Text, txtPassword.Text, apiKey, srs, locale);
    }

    private void btRotateLeft_Click(object sender, EventArgs e)
    {
      _viewer.RotateLeft(1);
    }

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
      _viewer.RotateRight(1);
    }

    #region events api

    private void OnFrameLoaded(object sender, EventArgs args)
    {
      IStreetSmartAPI api = sender as IStreetSmartAPI;
      api?.Init(username, password, apiKey, srs, locale);
    }

    private void OnOpenImageError(object sender, EventOpenImageErrorArgs args)
    {
      MessageBox.Show(args.Message);
    }

    private void OnRecordingClick(object sender, EventRecordingClickArgs args)
    {
      MessageBox.Show("Click");
    }

    private void OnInitComplete(object sender, EventInitArgs args)
    {
      if (args.Success)
      {
        string domElementScript = @"var element1 = document.createElement('div');
           element1.setAttribute('id', 'panoramaviewer1Window');
           element1.setAttribute('style', 'width:40%; height:40%; position:absolute; top:300px; left:400px');";
        string domElementName = "element1";

        string viewerObjectName = "viewer";
        IStreetSmartAPI api = sender as IStreetSmartAPI;
//       _viewer = api?.AddPanoramaViewer(viewerObjectName, true, true);
        _viewer = api?.AddPanoramaViewer(viewerObjectName, true, true, domElementName, domElementScript);

        if (_viewer != null)
        {
          _viewer.OpenByImageId("5D123456", "EPSG:28992");
          _viewer.RecordingClick += OnRecordingClick;
          _viewer.OpenImageError += OnOpenImageError;
/*
          string domElementScript2 = @"var element2 = document.createElement('div');
           element2.setAttribute('id', 'panoramaviewer1Window');
           element2.setAttribute('style', 'width:40%; height:40%; position:absolute; top:0px; left:0px');";
          string domElementName2 = "element2";

          string viewerObjectName2 = "viewer2";
          _viewer2 = _api?.RenderPanoramaViewer(viewerObjectName2, true, true, domElementName2, domElementScript2);

          if (_viewer2 != null)
          {
            _viewer2.OpenByImageId("5D43HW1T", "EPSG:28992");
          }
*/
        }
      }
      else
      {
        MessageBox.Show(args.ErrorMessage);
      }
    }

    #endregion

    private void btnDestroyViewer_Click(object sender, EventArgs e)
    {
      _api.DestroyPanoramaViewer(_viewer);
    }

    private async void btnApiReadyState_Click(object sender, EventArgs e)
    {
      bool apiReadyState = await _api.getAPIReadyStateAsync();
    }

    private async void btnApplicationVersion_Click(object sender, EventArgs e)
    {
      string version = await _api.getApplicationVersionAsync();
    }

    private async void btnApplicationName_Click(object sender, EventArgs e)
    {
      string name = await _api.getApplicationNameAsync();
    }

    private async void btnPermissions_Click(object sender, EventArgs e)
    {
      string[] permissions = await _api.getPermissionsAsync();
    }

    private void btnOpenByAddress_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtSrs.Text))
      {
        _viewer.OpenByAddress(txtAdress.Text);
      }
      else
      {
        _viewer.OpenByAddress(txtAdress.Text, txtSrs.Text);
      }
    }

    private async void btnGetViewerColor_Click(object sender, EventArgs e)
    {
      Color color = await _viewer.GetViewerColorAsync();
    }

    private void btnRotateUp_Click(object sender, EventArgs e)
    {
      _viewer.RotateUp(1);
    }

    private void btnRotateDown_Click(object sender, EventArgs e)
    {
      _viewer.RotateDown(1);
    }

    private async void btnOrientation_Click(object sender, EventArgs e)
    {
      Orientation orientation = await _viewer.GetOrientationAsync();
    }

    private void btnSetOrientation_Click(object sender, EventArgs e)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      double? hFov = string.IsNullOrEmpty(txthFov.Text) ? null : (double?) double.Parse(txthFov.Text, ci);
      double? yaw = string.IsNullOrEmpty(txtYaw.Text) ? null : (double?) double.Parse(txtYaw.Text, ci);
      double? pitch = string.IsNullOrEmpty(txtPitch.Text) ? null : (double?) double.Parse(txtPitch.Text, ci);
      _viewer.SetOrientation(new Orientation {hFov = hFov, Yaw = yaw, Pitch = pitch});
    }

    private async void btnGetRecording_Click(object sender, EventArgs e)
    {
      Recording recording = await _viewer.GetRecordingAsync();
    }

    private void btnLookAtCoordinate_Click(object sender, EventArgs e)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;

      Coordinate coordinate = new Coordinate
      {
        X = double.Parse(txtX.Text, ci),
        Y = double.Parse(txtY.Text, ci),
        Z = string.IsNullOrEmpty(txtZ.Text) ? null : ((double?) double.Parse(txtZ.Text, ci))
      };

      if (string.IsNullOrEmpty(txtSrs.Text))
      {
        _viewer.LookAtCoordinate(coordinate);
      }
      else
      {
        _viewer.LookAtCoordinate(coordinate, txtSrs.Text);
      }
    }

    private async void btnToggleRecordingsVisible_Click(object sender, EventArgs e)
    {
      bool visible = await _viewer.GetRecordingsVisibleAsync();
      _viewer.ToggleRecordingsVisible(!visible);
    }

    private async void btnToggleNavbarVisible_Click(object sender, EventArgs e)
    {
      bool visible = await _viewer.getNavbarVisibleAsync();
      _viewer.ToggleNavbarVisible(!visible);
    }

    private async void btnToggleNavbarExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await _viewer.getNavbarExpandedAsync();
      _viewer.ToggleNavbarExpanded(!expanded);
    }

    private async void btnToggleTimeTravelVisible_Click(object sender, EventArgs e)
    {
      bool visible = await _viewer.getTimeTravelVisibleAsync();
      _viewer.ToggleTimeTravelVisible(!visible);
    }

    private async void btnToggleTimeTravelExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await _viewer.getTimeTravelExpandedAsync();
      _viewer.ToggleTimeTravelExpanded(!expanded);
    }

    private void btnOpenByImageId_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtSrs.Text))
      {
        _viewer.OpenByImageId(txtImageId.Text);
      }
      else
      {
        _viewer.OpenByImageId(txtImageId.Text, txtSrs.Text);
      }
    }

    private void btnOpenByCoordinate_Click(object sender, EventArgs e)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;

      Coordinate coordinate = new Coordinate
      {
        X = double.Parse(txtX.Text, ci),
        Y = double.Parse(txtY.Text, ci),
        Z = string.IsNullOrEmpty(txtZ.Text) ? null : ((double?)double.Parse(txtZ.Text, ci))
      };

      if (string.IsNullOrEmpty(txtSrs.Text))
      {
        _viewer.OpenByCoordinate(coordinate);
      }
      else
      {
        _viewer.OpenByCoordinate(coordinate, txtSrs.Text);
      }
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
      _viewer.ZoomIn();
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
      _viewer.ZoomOut();
    }

    private void btnOpen2eViewer_Click(object sender, EventArgs e)
    {
      string domElementScript2 = @"var element2 = document.createElement('div');
           element2.setAttribute('id', 'panoramaviewer1Window');
           element2.setAttribute('style', 'width:40%; height:40%; position:absolute; top:0px; left:0px');";
      string domElementName2 = "element2";

      string viewerObjectName2 = "viewer2";
      _viewer2 = _api?.AddPanoramaViewer(viewerObjectName2, true, true, domElementName2, domElementScript2);

      if (_viewer2 != null)
      {
        _viewer2.OpenByImageId("5D43HW1T", "EPSG:28992");
      }
    }
  }
}
