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
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using static Demo.WinForms.Properties.Resources;
using Orientation = StreetSmart.WinForms.Orientation;

namespace Demo.WinForms
{
  public partial class Demo : Form
  {
    #region Members

    private readonly IStreetSmartAPI _api;
    private readonly List<IPanoramaViewer> _viewers;
    private readonly CultureInfo _ci;

    #endregion

    #region Properties

    private IPanoramaViewer Viewer => (_viewers.Count == 0) ? null : _viewers[_viewers.Count - 1];

    private int DeltaYawPitch
    {
      get
      {
        int result;

        if (!int.TryParse(txtDeltaYawPitch.Text, out result))
        {
          result = 0;
        }

        return result;
      }
    }

    #endregion

    public Demo()
    {
      InitializeComponent();
      _ci = CultureInfo.InvariantCulture;
      _viewers = new List<IPanoramaViewer>();
      _api = APIBuilder.CreateAPI();
      _api.FrameLoaded += OnFrameLoaded;
      _api.InitComplete += OnInitComplete;
      plStreetSmart.Controls.Add(_api.GUI);
      grLogin.Enabled = false;
      grOpenByAddress.Enabled = false;
      grViewerToggles.Enabled = false;
      grRotationsZoomInOut.Enabled = false;
      grAPIInfo.Enabled = false;
      grOpenCloseViewer.Enabled = false;
      grCoordinate.Enabled = false;
      grOrientation.Enabled = false;
      grOpenByImageId.Enabled = false;
      grRecordingViewerColorPermissions.Enabled = false;

      txtDomElementScript.Text =
        @"var element1 = document.createElement('div');
          element1.setAttribute('id', 'panoramaviewer1Window');
          element1.setAttribute('style', 'width:40%; height:40%; position:absolute; top:300px; left:400px');";
      txtDomElementName.Text = @"element1";
    }

    #region events api

    private void OnFrameLoaded(object sender, EventArgs args)
    {
      if (grLogin.InvokeRequired)
      {
        grLogin.Invoke(new MethodInvoker(() => grLogin.Enabled = true));
      }
      else
      {
        grLogin.Enabled = true;
      }
    }

    private void OnInitComplete(object sender, EventInitArgs args)
    {
      if (args.Success)
      {
        if (grAPIInfo.InvokeRequired)
        {
          grAPIInfo.Invoke(new MethodInvoker(() => grAPIInfo.Enabled = true));
        }
        else
        {
          grAPIInfo.Enabled = true;
        }

        if (grOpenCloseViewer.InvokeRequired)
        {
          grOpenCloseViewer.Invoke(new MethodInvoker(() => grOpenCloseViewer.Enabled = true));
        }
        else
        {
          grOpenCloseViewer.Enabled = true;
        }

        MessageBox.Show("Login successfully");
      }
      else
      {
        MessageBox.Show(args.ErrorMessage);
      }
    }

    private void OnImageChange(object sender, EventViewerArgs args)
    {
      string text = "Image change";
      AddViewerEventsText(text);
    }

    private void OnRecordingClick(object sender, EventRecordingClickArgs args)
    {
      string text = $"Recording click: {args.Recording.Id}";
      AddViewerEventsText(text);
    }

    private void OnTileLoadError(object sender, EventTileLoadErrorArgs args)
    {
      string text = "Tile load error";
      AddViewerEventsText(text);
    }

    private void OnViewChange(object sender, EventViewChangeArgs args)
    {
      Orientation orientation = args.Orientation;
      string text = $"View change args, pitch: {orientation.Pitch}, yaw: {orientation.Yaw}, hFov: {orientation.hFov}";
      AddViewerEventsText(text);
    }

    private void OnViewLoadEnd(object sender, EventViewerArgs args)
    {
      string text = "Image load end";
      AddViewerEventsText(text);
    }

    private void OnViewLoadStart(object sender, EventViewerArgs args)
    {
      string text = "Image load start";
      AddViewerEventsText(text);
    }

    private void OnOpenImageError(object sender, EventOpenImageErrorArgs args)
    {
      string text = $"Open image error, message: {args.Message}";
      AddViewerEventsText(text);
    }

    #endregion

    #region events from user interface

    private void btnLogin_Click(object sender, EventArgs e)
    {
      AddressSettings addressSettings = new AddressSettings { Locale = "nl", Database = "CMDatabase" };
      _api?.Init(txtUsername.Text, txtPassword.Text, apiKey, srs, locale, addressSettings);
    }

    private void btRotateLeft_Click(object sender, EventArgs e)
    {
      Viewer?.RotateLeft(DeltaYawPitch);
    }

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
      Viewer?.RotateRight(DeltaYawPitch);
    }

    private void btnDestroyViewer_Click(object sender, EventArgs e)
    {
      if (Viewer != null)
      {
        Viewer.ImageChange -= OnImageChange;
        Viewer.RecordingClick -= OnRecordingClick;
        Viewer.TileLoadError -= OnTileLoadError;
        Viewer.ViewChange -= OnViewChange;
        Viewer.ViewLoadEnd -= OnViewLoadEnd;
        Viewer.ViewLoadStart -= OnViewLoadStart;
        Viewer.OpenImageError -= OnOpenImageError;

        _api?.DestroyPanoramaViewer(Viewer);
        _viewers.RemoveAt(_viewers.Count - 1);

        if (_viewers.Count == 0)
        {
          ToggleViewerEnables(false);
          EnableImageEnables(false);
        }
      }
    }

    private async void btnApiReadyState_Click(object sender, EventArgs e)
    {
      bool apiReadyState = await _api.getAPIReadyStateAsync();
      txtAPIResult.Text = apiReadyState.ToString();
    }

    private async void btnApplicationVersion_Click(object sender, EventArgs e)
    {
      string version = await _api.getApplicationVersionAsync();
      txtAPIResult.Text = version;
    }

    private async void btnApplicationName_Click(object sender, EventArgs e)
    {
      string name = await _api.getApplicationNameAsync();
      txtAPIResult.Text = name;
    }

    private async void btnPermissions_Click(object sender, EventArgs e)
    {
      string[] permissions = await _api.getPermissionsAsync();
      string permissionsString = permissions.Aggregate(string.Empty,
        (current, permission) => $"{current}{permission}{Environment.NewLine}");
      txtRecordingViewerColorPermissions.Text = permissionsString;
    }

    private void btnOpenByAddress_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtAddressSrs.Text))
      {
        Viewer?.OpenByAddress(txtAdress.Text);
      }
      else
      {
        Viewer?.OpenByAddress(txtAdress.Text, txtAddressSrs.Text);
      }

      EnableImageEnables(true);
    }

    private async void btnGetViewerColor_Click(object sender, EventArgs e)
    {
      Color color = await Viewer.GetViewerColorAsync();
      string text = $"Alpha: {color.A}{Environment.NewLine}Red: {color.R}{Environment.NewLine}Green: {color.G}{Environment.NewLine}Blue: {color.B}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    private void btnRotateUp_Click(object sender, EventArgs e)
    {
      Viewer.RotateUp(DeltaYawPitch);
    }

    private void btnRotateDown_Click(object sender, EventArgs e)
    {
      Viewer.RotateDown(DeltaYawPitch);
    }

    private async void btnOrientation_Click(object sender, EventArgs e)
    {
      Orientation orientation = await Viewer.GetOrientationAsync();
      txtYaw.Text = orientation.Yaw.ToString();
      txtPitch.Text = orientation.Pitch.ToString();
      txthFov.Text = orientation.hFov.ToString();
    }

    private void btnSetOrientation_Click(object sender, EventArgs e)
    {
      double? hFov = string.IsNullOrEmpty(txthFov.Text) ? null : (double?) ParseDouble(txthFov.Text);
      double? yaw = string.IsNullOrEmpty(txtYaw.Text) ? null : (double?) ParseDouble(txtYaw.Text);
      double? pitch = string.IsNullOrEmpty(txtPitch.Text) ? null : (double?) ParseDouble(txtPitch.Text);
      Orientation orientation = new Orientation {hFov = hFov, Yaw = yaw, Pitch = pitch};
      Viewer.SetOrientation(orientation);
    }

    private async void btnGetRecording_Click(object sender, EventArgs e)
    {
      Recording recording = await Viewer.GetRecordingAsync();
      string text = $"Id: {recording.Id}{Environment.NewLine}recordedAt: {recording.RecordedAt}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    private void btnLookAtCoordinate_Click(object sender, EventArgs e)
    {
      Coordinate coordinate = new Coordinate
      {
        X = ParseDouble(txtX.Text),
        Y = ParseDouble(txtY.Text),
        Z = string.IsNullOrEmpty(txtZ.Text) ? null : ((double?) ParseDouble(txtZ.Text))
      };

      if (string.IsNullOrEmpty(txtCoordinateSrs.Text))
      {
        Viewer.LookAtCoordinate(coordinate);
      }
      else
      {
        Viewer.LookAtCoordinate(coordinate, txtCoordinateSrs.Text);
      }
    }

    private async void btnToggleRecordingsVisible_Click(object sender, EventArgs e)
    {
      bool visible = await Viewer.GetRecordingsVisibleAsync();
      Viewer.ToggleRecordingsVisible(!visible);
    }

    private async void btnToggleNavbarVisible_Click(object sender, EventArgs e)
    {
      bool visible = await Viewer.getNavbarVisibleAsync();
      Viewer.ToggleNavbarVisible(!visible);
    }

    private async void btnToggleNavbarExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await Viewer.getNavbarExpandedAsync();
      Viewer.ToggleNavbarExpanded(!expanded);
    }

    private async void btnToggleTimeTravelVisible_Click(object sender, EventArgs e)
    {
      bool visible = await Viewer.getTimeTravelVisibleAsync();
      Viewer.ToggleTimeTravelVisible(!visible);
    }

    private async void btnToggleTimeTravelExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await Viewer.getTimeTravelExpandedAsync();
      Viewer.ToggleTimeTravelExpanded(!expanded);
    }

    private void btnOpenByImageId_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtOpenByImageSrs.Text))
      {
        Viewer.OpenByImageId(txtImageId.Text);
      }
      else
      {
        Viewer.OpenByImageId(txtImageId.Text, txtOpenByImageSrs.Text);
      }

      EnableImageEnables(true);
    }

    private void btnOpenByCoordinate_Click(object sender, EventArgs e)
    {
      Coordinate coordinate = new Coordinate
      {
        X = ParseDouble(txtX.Text),
        Y = ParseDouble(txtY.Text),
        Z = string.IsNullOrEmpty(txtZ.Text) ? null : ((double?) ParseDouble(txtZ.Text))
      };

      if (string.IsNullOrEmpty(txtCoordinateSrs.Text))
      {
        Viewer.OpenByCoordinate(coordinate);
      }
      else
      {
        Viewer.OpenByCoordinate(coordinate, txtCoordinateSrs.Text);
      }

      EnableImageEnables(true);
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
      Viewer.ZoomIn();
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
      Viewer.ZoomOut();
    }

    private void btnOpenViewer_Click(object sender, EventArgs e)
    {
      _viewers.Add(rbDefault.Checked
        ? _api.AddPanoramaViewer(txtViewerName.Text, true, true)
        : _api.AddPanoramaViewer(txtViewerName.Text, true, true, txtDomElementName.Text, txtDomElementScript.Text));

      ToggleViewerEnables(true);

      Viewer.ImageChange += OnImageChange;
      Viewer.RecordingClick += OnRecordingClick;
      Viewer.TileLoadError += OnTileLoadError;
      Viewer.ViewChange += OnViewChange;
      Viewer.ViewLoadEnd += OnViewLoadEnd;
      Viewer.ViewLoadStart += OnViewLoadStart;
      Viewer.OpenImageError += OnOpenImageError;
    }

    private async void btnGetAddress_Click(object sender, EventArgs e)
    {
      AddressSettings addressSettings = await _api.getAddressSettingsAsync();
      string text = $"Locale: {addressSettings.Locale}{Environment.NewLine}Database: {addressSettings.Database}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    #endregion

    #region Private Functions

    private double ParseDouble(string text)
    {
      double result;

      if (!double.TryParse(text, out result))
      {
        result = 0.0;
      }

      return result;
    }

    private void AddViewerEventsText(string text)
    {
      if (lbViewerEvents.InvokeRequired)
      {
        lbViewerEvents.Invoke(new MethodInvoker(() => lbViewerEvents.Items.Add(text)));
      }
      else
      {
        lbViewerEvents.Items.Add(text);
      }
    }

    private void ToggleViewerEnables(bool value)
    {
      if (grOpenByAddress.InvokeRequired)
      {
        grOpenByAddress.Invoke(new MethodInvoker(() => grOpenByAddress.Enabled = value));
      }
      else
      {
        grOpenByAddress.Enabled = value;
      }

      if (grCoordinate.InvokeRequired)
      {
        grCoordinate.Invoke(new MethodInvoker(() => grCoordinate.Enabled = value));
      }
      else
      {
        grCoordinate.Enabled = value;
      }

      if (grOpenByImageId.InvokeRequired)
      {
        grOpenByImageId.Invoke(new MethodInvoker(() => grOpenByImageId.Enabled = value));
      }
      else
      {
        grOpenByImageId.Enabled = value;
      }
    }

    private void EnableImageEnables(bool value)
    {
      if (grViewerToggles.InvokeRequired)
      {
        grViewerToggles.Invoke(new MethodInvoker(() => grViewerToggles.Enabled = value));
      }
      else
      {
        grViewerToggles.Enabled = value;
      }

      if (grRotationsZoomInOut.InvokeRequired)
      {
        grRotationsZoomInOut.Invoke(new MethodInvoker(() => grRotationsZoomInOut.Enabled = value));
      }
      else
      {
        grRotationsZoomInOut.Enabled = value;
      }

      if (grOrientation.InvokeRequired)
      {
        grOrientation.Invoke(new MethodInvoker(() => grOrientation.Enabled = value));
      }
      else
      {
        grOrientation.Enabled = value;
      }

      if (grRecordingViewerColorPermissions.InvokeRequired)
      {
        grRecordingViewerColorPermissions.Invoke(
          new MethodInvoker(() => grRecordingViewerColorPermissions.Enabled = value));
      }
      else
      {
        grRecordingViewerColorPermissions.Enabled = value;
      }
    }

    #endregion
  }
}
