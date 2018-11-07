/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.GeoJson;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;
using StreetSmart.Common.Interfaces.Events;

using static Demo.WinForms.Properties.Resources;

namespace Demo.WinForms
{
  public partial class Demo : Form
  {
    #region Members

    private readonly IStreetSmartAPI _api;
    private readonly List<IPanoramaViewer> _panoramaViewers;
    private readonly List<IObliqueViewer> _obliqueViewers;
    private readonly CultureInfo _ci;
    private readonly Login _login;

    private IOptions _options;
    private IOverlay _overlay;

    #endregion

    #region Properties

    private IPanoramaViewer PanoramaViewer =>
      _panoramaViewers.Count == 0 ? null : _panoramaViewers[_panoramaViewers.Count - 1];

    private IObliqueViewer ObliqueViewer =>
      _obliqueViewers.Count == 0 ? null : _obliqueViewers[_obliqueViewers.Count - 1];

    private int DeltaYawPitch
    {
      get
      {
        if (!int.TryParse(txtDeltaYawPitch.Text, out var result))
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
      _login = Login.Instance;
      _ci = CultureInfo.InvariantCulture;
      _panoramaViewers = new List<IPanoramaViewer>();
      _obliqueViewers = new List<IObliqueViewer>();

      _api = string.IsNullOrEmpty(StreetSmartLocation)
        ? StreetSmartAPIFactory.Create()
        : StreetSmartAPIFactory.Create(StreetSmartLocation);
      _api.APIReady += OnAPIReady;
      _api.MeasurementChanged += OnMeasurementChanged;
      _api.ViewerAdded += OnViewerAdded;
      _api.ViewerRemoved += OnViewerRemoved;
      plStreetSmart.Controls.Add(_api.GUI);

      grLogin.Enabled = false;
      DisableGroups();

      txtUsername.Text = _login.Username;
      txtPassword.Text = _login.Password;
      txtAPIKey.Text = _login.ApiKey;

      ObliqueViewerButtons[] obButtons =
      {
        ObliqueViewerButtons.Overlays, ObliqueViewerButtons.CenterMap,
        ObliqueViewerButtons.ImageInformation, ObliqueViewerButtons.ZoomIn,
        ObliqueViewerButtons.ZoomOut, ObliqueViewerButtons.SwitchDirection,
        ObliqueViewerButtons.ToggleNadir
      };

      foreach (var obButton in obButtons)
      {
        cbViewerButton.Items.Add(new ViewerButtonsBox(obButton));
      }

      PanoramaViewerButtons[] pnButtons =
      {
        PanoramaViewerButtons.Elevation, PanoramaViewerButtons.Overlays,
        PanoramaViewerButtons.OpenOblique, PanoramaViewerButtons.OpenPointCloud,
        PanoramaViewerButtons.ReportBlurring, PanoramaViewerButtons.Measure,
        PanoramaViewerButtons.PlayList, PanoramaViewerButtons.CenterMap,
        PanoramaViewerButtons.ImageInformation, PanoramaViewerButtons.ZoomIn,
        PanoramaViewerButtons.ZoomOut
      };

      foreach (var pnButton in pnButtons)
      {
        cbViewerButton.Items.Add(new ViewerButtonsBox(pnButton));
      }
    }

    #region events api

    // ReSharper disable once InconsistentNaming
    private void OnAPIReady(object sender, EventArgs args)
    {
      if (grLogin.InvokeRequired)
      {
        grLogin.Invoke(new MethodInvoker(() => grLogin.Enabled = true));
      }
      else
      {
        grLogin.Enabled = true;
        LogInOut(true);
      }
    }

    private void OnMeasurementChanged(object sender, IEventArgs<IFeatureCollection> args)
    {
      string text = "Measurement changed";
      AddViewerEventsText(text);
    }

    private void OnViewerAdded(object sender, IEventArgs<IViewer> args)
    {
      string text = "Viewer added";
      AddViewerEventsText(text);
      IViewer viewer = args.Value;
      viewer.LayerVisibilityChange += OnLayerVisibilityChange;

      if (viewer is IPanoramaViewer)
      {
        IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;
        _panoramaViewers.Add(panoramaViewer);

        panoramaViewer.ElevationChange += OnElevationChange;
        panoramaViewer.ImageChange += OnImageChange;
        panoramaViewer.RecordingClick += OnRecordingClick;
        panoramaViewer.TileLoadError += OnTileLoadError;
        panoramaViewer.ViewChange += OnViewChange;
        panoramaViewer.SurfaceCursorChange += OnSurfaceCursorChange;
        panoramaViewer.ViewLoadEnd += OnViewLoadEnd;
        panoramaViewer.ViewLoadStart += OnViewLoadStart;
        panoramaViewer.TimeTravelChange += OnTimeTravelChange;
      }

      if (viewer is IObliqueViewer)
      {
        IObliqueViewer obliqueViewer = viewer as IObliqueViewer;
        _obliqueViewers.Add(obliqueViewer);
      }
    }

    private void OnViewerRemoved(object sender, IEventArgs<IViewer> args)
    {
      string text = "Viewer removed";
      AddViewerEventsText(text);
      IViewer viewer = args.Value;
      viewer.LayerVisibilityChange -= OnLayerVisibilityChange;

      if (viewer is IPanoramaViewer)
      {
        IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;
        _panoramaViewers.Remove(panoramaViewer);

        panoramaViewer.ElevationChange -= OnElevationChange;
        panoramaViewer.ImageChange -= OnImageChange;
        panoramaViewer.RecordingClick -= OnRecordingClick;
        panoramaViewer.TileLoadError -= OnTileLoadError;
        panoramaViewer.ViewChange -= OnViewChange;
        panoramaViewer.SurfaceCursorChange -= OnSurfaceCursorChange;
        panoramaViewer.ViewLoadEnd -= OnViewLoadEnd;
        panoramaViewer.ViewLoadStart -= OnViewLoadStart;
        panoramaViewer.TimeTravelChange -= OnTimeTravelChange;
      }

      if (viewer is IObliqueViewer)
      {
        IObliqueViewer obliqueViewer = viewer as IObliqueViewer;
        _obliqueViewers.Remove(obliqueViewer);
      }
    }

    #endregion

    #region events panorama viewer 

    private void OnElevationChange(object sender, IEventArgs<IElevationInfo> args)
    {
      string text = "Elevation change";
      AddViewerEventsText(text);
    }

    private void OnImageChange(object sender, EventArgs args)
    {
      string text = "Image change";
      AddViewerEventsText(text);
    }

    private void OnRecordingClick(object sender, IEventArgs<IRecordingClickInfo> args)
    {
      string text = $"Recording click: {args.Value.Recording.Id}";
      AddViewerEventsText(text);
    }

    private void OnTileLoadError(object sender, IEventArgs<IDictionary<string, object>> args)
    {
      string text = "Tile load error";
      AddViewerEventsText(text);
    }

    private void OnViewChange(object sender, IEventArgs<IOrientation> args)
    {
      IOrientation orientation = args.Value;
      string text = $"View change args, pitch: {orientation.Pitch}, yaw: {orientation.Yaw}, hFov: {orientation.HFov}";
      AddViewerEventsText(text);
    }

    private void OnSurfaceCursorChange(object sender, IEventArgs<IDepthInfo> args)
    {
      IDepthInfo depthInfo = args.Value;
      string text = $"Surface cursor change" +
                    $", depth: {depthInfo.Depth}, depth in meters: {depthInfo.DepthInMeters}" +
                    $", SRS: {depthInfo.SRS}, X: {depthInfo.XYZ.X}, Y: {depthInfo.XYZ.Y}, Z: {depthInfo.XYZ.Z}";
      AddViewerEventsText(text);
    }

    private void OnViewLoadEnd(object sender, EventArgs args)
    {
      string text = "Image load end";
      AddViewerEventsText(text);
    }

    private void OnViewLoadStart(object sender, EventArgs args)
    {
      string text = "Image load start";
      AddViewerEventsText(text);
    }

    private void OnTimeTravelChange(object sender, IEventArgs<ITimeTravelInfo> args)
    {
      string text = "Time travel change";
      AddViewerEventsText(text);
    }

    private void OnLayerVisibilityChange(object sender, IEventArgs<ILayerInfo> args)
    {
      string text = "Layer visible change";
      AddViewerEventsText(text);
    }

    #endregion

    #region events from user interface

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create("nl", "CMdatabase");
      IDomElement element = DomElementFactory.Create();

      _options = OptionsFactory.Create(txtUsername.Text, txtPassword.Text, txtAPIKey.Text, txtSrs.Text, locale,
        ConfigurationUrl, addressSettings, element);

      try
      {
        await _api.Init(_options);

        if (grAPIInfo.InvokeRequired)
        {
          grAPIInfo.Invoke(new MethodInvoker(() => grAPIInfo.Enabled = true));
        }
        else
        {
          grAPIInfo.Enabled = true;
        }

        if (grOpenByQuery.InvokeRequired)
        {
          grOpenByQuery.Invoke(new MethodInvoker(() => grOpenByQuery.Enabled = true));
        }
        else
        {
          grOpenByQuery.Enabled = true;
        }

        if (grOpenByAddress.InvokeRequired)
        {
          grOpenByAddress.Invoke(new MethodInvoker(() => grOpenByAddress.Enabled = true));
        }
        else
        {
          grOpenByAddress.Enabled = true;
        }

        if (grCoordinate.InvokeRequired)
        {
          grCoordinate.Invoke(new MethodInvoker(() => grCoordinate.Enabled = true));
        }
        else
        {
          grCoordinate.Enabled = true;
        }

        if (grOpenByImageId.InvokeRequired)
        {
          grOpenByImageId.Invoke(new MethodInvoker(() => grOpenByImageId.Enabled = true));
        }
        else
        {
          grOpenByImageId.Enabled = true;
        }

        LogInOut(false);
        MessageBox.Show("Login successfully");
      }
      catch (StreetSmartLoginFailedException ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void LogInOut(bool enabled)
    {
      if (btnLogin.InvokeRequired)
      {
        btnLogin.Invoke(new MethodInvoker(() => btnLogin.Enabled = enabled));
      }
      else
      {
        btnLogin.Enabled = enabled;
      }

      if (txtUsername.InvokeRequired)
      {
        txtUsername.Invoke(new MethodInvoker(() => txtUsername.Enabled = enabled));
      }
      else
      {
        txtUsername.Enabled = enabled;
      }

      if (txtPassword.InvokeRequired)
      {
        txtPassword.Invoke(new MethodInvoker(() => txtPassword.Enabled = enabled));
      }
      else
      {
        txtPassword.Enabled = enabled;
      }

      if (txtAPIKey.InvokeRequired)
      {
        txtAPIKey.Invoke(new MethodInvoker(() => txtAPIKey.Enabled = enabled));
      }
      else
      {
        txtAPIKey.Enabled = enabled;
      }

      if (txtSrs.InvokeRequired)
      {
        txtSrs.Invoke(new MethodInvoker(() => txtSrs.Enabled = enabled));
      }
      else
      {
        txtSrs.Enabled = enabled;
      }
    }

    private async void btnLogout_Click(object sender, EventArgs e)
    {
      if (_options != null)
      {
        await _api.Destroy(_options);
        _panoramaViewers.Clear();
        _obliqueViewers.Clear();

        LogInOut(true);
        DisableGroups();
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      _login.Save();
      MessageBox.Show("The username, password and API Key have been saved.");
    }

    private void btnLogin_EnabledChanged(object sender, EventArgs e)
    {
      btnLogout.Enabled = !btnLogin.Enabled;
    }

    private void txtUsername_TextChanged(object sender, EventArgs e)
    {
      _login.Username = txtUsername.Text;
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      _login.Password = txtPassword.Text;
    }

    private void txtAPIKey_TextChanged(object sender, EventArgs e)
    {
      _login.ApiKey = txtAPIKey.Text;
    }

    private void btRotateLeft_Click(object sender, EventArgs e)
    {
      PanoramaViewer?.RotateLeft(DeltaYawPitch);
    }

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
      PanoramaViewer?.RotateRight(DeltaYawPitch);
    }

    private async void btnApiReadyState_Click(object sender, EventArgs e)
    {
      bool apiReadyState = await _api.GetApiReadyState();
      txtAPIResult.Text = apiReadyState.ToString();
    }

    private async void btnApplicationVersion_Click(object sender, EventArgs e)
    {
      string version = await _api.GetApplicationVersion();
      txtAPIResult.Text = version;
    }

    private async void btnApplicationName_Click(object sender, EventArgs e)
    {
      string name = await _api.GetApplicationName();
      txtAPIResult.Text = name;
    }

    private async void btnPermissions_Click(object sender, EventArgs e)
    {
      string[] permissions = await _api.GetPermissions();
      string permissionsString = permissions.Aggregate(string.Empty,
        (current, permission) => $"{current}{permission}{Environment.NewLine}");
      txtRecordingViewerColorPermissions.Text = permissionsString;
    }

    private async void btnOpenByAddress_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();
      IPanoramaViewerOptions panoramaViewerOptions = null;
      IObliqueViewerOptions obliqueViewerOptions = null;

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
        obliqueViewerOptions = ObliqueViewerOptionsFactory.Create(true, true, true, true);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
        panoramaViewerOptions = PanoramaViewerOptionsFactory.Create(true, true, true, true, ckReplace.Checked, true);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtSrs.Text,
          panoramaViewerOptions, obliqueViewerOptions);
        IList<IViewer> viewers = await _api.Open(txtAdress.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;

            if (!_panoramaViewers.Contains(panoramaViewer))
            {
              MessageBox.Show("panorama viewer doesn't exists in the list");
            }
          }

          if (viewer is IObliqueViewer)
          {
            IObliqueViewer obliqueViewer = viewer as IObliqueViewer;

            if (!_obliqueViewers.Contains(obliqueViewer))
            {
              MessageBox.Show("oblique viewer doesn't exists in the list");
            }
          }
        }
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
      }

      EnableImageEnables(true);
    }

    private async void btnGetViewerColor_Click(object sender, EventArgs e)
    {
      Color color = await PanoramaViewer.GetViewerColor();
      string text =
        $"Alpha: {color.A}{Environment.NewLine}Red: {color.R}{Environment.NewLine}Green: {color.G}{Environment.NewLine}Blue: {color.B}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    private void btnRotateUp_Click(object sender, EventArgs e)
    {
      PanoramaViewer.RotateUp(DeltaYawPitch);
    }

    private void btnRotateDown_Click(object sender, EventArgs e)
    {
      PanoramaViewer.RotateDown(DeltaYawPitch);
    }

    private async void btnOrientation_Click(object sender, EventArgs e)
    {
      IOrientation orientation = await PanoramaViewer.GetOrientation();
      txtYaw.Text = orientation.Yaw.ToString();
      txtPitch.Text = orientation.Pitch.ToString();
      txthFov.Text = orientation.HFov.ToString();
    }

    private void btnSetOrientation_Click(object sender, EventArgs e)
    {
      double? hFov = string.IsNullOrEmpty(txthFov.Text) ? null : (double?) ParseDouble(txthFov.Text);
      double? yaw = string.IsNullOrEmpty(txtYaw.Text) ? null : (double?) ParseDouble(txtYaw.Text);
      double? pitch = string.IsNullOrEmpty(txtPitch.Text) ? null : (double?) ParseDouble(txtPitch.Text);
      IOrientation orientation = OrientationFactory.Create(yaw, pitch, hFov);
      PanoramaViewer.SetOrientation(orientation);
    }

    private async void btnGetRecording_Click(object sender, EventArgs e)
    {
      IRecording recording = await PanoramaViewer.GetRecording();
      PrintRecordingText(recording);
    }

    private async void btnLookAtCoordinate_Click(object sender, EventArgs e)
    {
      ICoordinate coordinate = string.IsNullOrEmpty(txtZ.Text)
        ? CoordinateFactory.Create(ParseDouble(txtX.Text), ParseDouble(txtY.Text))
        : CoordinateFactory.Create(ParseDouble(txtX.Text), ParseDouble(txtY.Text), ParseDouble(txtZ.Text));

      if (string.IsNullOrEmpty(txtSrs.Text))
      {
        await PanoramaViewer.LookAtCoordinate(coordinate);
      }
      else
      {
        await PanoramaViewer.LookAtCoordinate(coordinate, txtSrs.Text);
      }
    }

    private async void btnToggleRecordingsVisible_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetRecordingsVisible();
      PanoramaViewer.ToggleRecordingsVisible(!visible);
    }

    private async void btnToggleNavbarVisible_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetNavbarVisible();
      PanoramaViewer.ToggleNavbarVisible(!visible);
    }

    private async void btnToggleNavbarExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await PanoramaViewer.GetNavbarExpanded();
      PanoramaViewer.ToggleNavbarExpanded(!expanded);
    }

    private async void btnToggleTimeTravelVisible_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetTimeTravelVisible();
      PanoramaViewer.ToggleTimeTravelVisible(!visible);
    }

    private async void btnToggleTimeTravelExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await PanoramaViewer.GetTimeTravelExpanded();
      PanoramaViewer.ToggleTimeTravelExpanded(!expanded);
    }

    private async void btnOpenByImageId_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();
      IPanoramaViewerOptions panoramaViewerOptions = null;
      IObliqueViewerOptions obliqueViewerOptions = null;

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
        obliqueViewerOptions = ObliqueViewerOptionsFactory.Create(true, true, true, true);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
        panoramaViewerOptions = PanoramaViewerOptionsFactory.Create(true, true, true, true, ckReplace.Checked, true);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtSrs.Text,
          panoramaViewerOptions, obliqueViewerOptions);
        IList<IViewer> viewers = await _api.Open(txtImageId.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;

            if (!_panoramaViewers.Contains(panoramaViewer))
            {
              MessageBox.Show("panorama viewer doesn't exists in the list");
            }
          }

          if (viewer is IObliqueViewer)
          {
            IObliqueViewer obliqueViewer = viewer as IObliqueViewer;

            if (!_obliqueViewers.Contains(obliqueViewer))
            {
              MessageBox.Show("oblique viewer doesn't exists in the list");
            }
          }
        }
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
      }

      EnableImageEnables(true);
    }

    private async void btnOpenByCoordinate_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();
      IPanoramaViewerOptions panoramaViewerOptions = null;
      IObliqueViewerOptions obliqueViewerOptions = null;

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
        obliqueViewerOptions = ObliqueViewerOptionsFactory.Create(true, true, true, true);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
        panoramaViewerOptions = PanoramaViewerOptionsFactory.Create(true, true, true, true, ckReplace.Checked, true);
      }

      try
      {
        string txtcoordinate = string.IsNullOrEmpty(txtZ.Text)
          ? $"{ParseDouble(txtX.Text).ToString(_ci)}, {ParseDouble(txtY.Text).ToString(_ci)}"
          : $"{ParseDouble(txtX.Text).ToString(_ci)}, {ParseDouble(txtY.Text).ToString(_ci)}, {ParseDouble(txtZ.Text).ToString(_ci)}";

        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtSrs.Text,
          panoramaViewerOptions, obliqueViewerOptions);
        IList<IViewer> viewers = await _api.Open(txtcoordinate, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;

            if (!_panoramaViewers.Contains(panoramaViewer))
            {
              MessageBox.Show("panorama viewer doesn't exists in the list");
            }
          }

          if (viewer is IObliqueViewer)
          {
            IObliqueViewer obliqueViewer = viewer as IObliqueViewer;

            if (!_obliqueViewers.Contains(obliqueViewer))
            {
              MessageBox.Show("oblique viewer doesn't exists in the list");
            }
          }
        }
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
      }

      EnableImageEnables(true);
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
      PanoramaViewer.ZoomIn();
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
      PanoramaViewer.ZoomOut();
    }

    private async void btnOpenViewerByQuery_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();
      IPanoramaViewerOptions panoramaViewerOptions = null;
      IObliqueViewerOptions obliqueViewerOptions = null;

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
        obliqueViewerOptions = ObliqueViewerOptionsFactory.Create(true, true, true, true);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
        panoramaViewerOptions = PanoramaViewerOptionsFactory.Create(true, true, true, true, ckReplace.Checked, true);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtSrs.Text,
          panoramaViewerOptions, obliqueViewerOptions);
        IList<IViewer> viewers = await _api.Open(txtOpenByQuery.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            IPanoramaViewer panoramaViewer = viewer as IPanoramaViewer;

            if (!_panoramaViewers.Contains(panoramaViewer))
            {
              MessageBox.Show("panorama viewer doesn't exists in the list");
            }
          }

          if (viewer is IObliqueViewer)
          {
            IObliqueViewer obliqueViewer = viewer as IObliqueViewer;

            if (!_obliqueViewers.Contains(obliqueViewer))
            {
              MessageBox.Show("oblique viewer doesn't exists in the list");
            }
          }
        }
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
      }

      EnableImageEnables(true);
    }

    private async void btnGetAddress_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = await _api.GetAddressSettings();
      string text = $"Locale: {addressSettings.Locale}{Environment.NewLine}Database: {addressSettings.Database}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    private void btnShowDevTools_Click(object sender, EventArgs e)
    {
      _api?.ShowDevTools();
    }

    private void btnCloseDevTools_Click(object sender, EventArgs e)
    {
      _api?.CloseDevTools();
    }

    private void btnStartMeasurementMode_Click(object sender, EventArgs e)
    {
      MeasurementGeometryType? type = null;

      if (rbMeasPoint.Checked)
      {
        type = MeasurementGeometryType.Point;
      }
      else if (rbMeasLineString.Checked)
      {
        type = MeasurementGeometryType.LineString;
      }
      else if (rbMeasPolygon.Checked)
      {
        type = MeasurementGeometryType.Polygon;
      }

      IMeasurementOptions options = (type == null)
        ? MeasurementOptionsFactory.Create()
        : MeasurementOptionsFactory.Create((MeasurementGeometryType) type);

      _api.StartMeasurementMode(PanoramaViewer, options);
    }

    private void btnStopMeasurementMode_Click(object sender, EventArgs e)
    {
      _api.StopMeasurementMode();
    }

    private async void btnGetMeasurementInfo_Click(object sender, EventArgs e)
    {
      IFeatureCollection measurement = await _api.GetActiveMeasurement();
      AddViewerEventsText(measurement?.ToString() ?? string.Empty);
    }

    private async void btnAddOverlay_Click(object sender, EventArgs e)
    {
      if (_overlay == null)
      {
        string name = "My GeoJSON";
        string geoJson = txtOverlayGeoJson.Text;
        string sld = txtSld.Text;

        _overlay = string.IsNullOrEmpty(sld)
          ? OverlayFactory.Create(geoJson, name)
          : OverlayFactory.Create(geoJson, name, txtSrs.Text, sld);

        _overlay = await _api.AddOverlay(_overlay);
      }
    }

    private async void btnRemoveOverlay_Click(object sender, EventArgs e)
    {
      if (_overlay != null)
      {
        await _api.RemoveOverlay(_overlay.Id);
        _overlay = null;
      }
    }

    private async void btnGetButtonEnabled_Click(object sender, EventArgs e)
    {
      txtRecordingViewerColorPermissions.Text = string.Empty;

      if (ObliqueViewer != null)
      {
        ObliqueViewerButtons[] buttons =
        {
          ObliqueViewerButtons.Overlays, ObliqueViewerButtons.CenterMap,
          ObliqueViewerButtons.ImageInformation, ObliqueViewerButtons.ZoomIn,
          ObliqueViewerButtons.ZoomOut, ObliqueViewerButtons.SwitchDirection,
          ObliqueViewerButtons.ToggleNadir
        };

        foreach (var button in buttons)
        {
          bool enabled = await ObliqueViewer.GetButtonEnabled(button);
          txtRecordingViewerColorPermissions.Text += $@"Oblique viewer: {button}: {enabled}{Environment.NewLine}";
        }
      }

      if (PanoramaViewer != null)
      {

        PanoramaViewerButtons[] buttons =
        {
          PanoramaViewerButtons.Elevation, PanoramaViewerButtons.Overlays,
          PanoramaViewerButtons.OpenOblique, PanoramaViewerButtons.OpenPointCloud,
          PanoramaViewerButtons.ReportBlurring, PanoramaViewerButtons.Measure,
          PanoramaViewerButtons.PlayList, PanoramaViewerButtons.CenterMap,
          PanoramaViewerButtons.ImageInformation, PanoramaViewerButtons.ZoomIn,
          PanoramaViewerButtons.ZoomOut
        };

        foreach (var button in buttons)
        {
          bool enabled = await PanoramaViewer.GetButtonEnabled(button);
          txtRecordingViewerColorPermissions.Text += $@"Panorama viewer: {button}: {enabled}{Environment.NewLine}";
        }
      }
    }

    private async void btnSetButtonVisibility_Click(object sender, EventArgs e)
    {
      var selectedItem = ((ViewerButtonsBox) cbViewerButton.SelectedItem)?.ButtonId;

      if (selectedItem is ObliqueViewerButtons ovButtons && ObliqueViewer != null)
      {
        bool enabled = await ObliqueViewer.GetButtonEnabled(ovButtons);
        ObliqueViewer.ToggleButtonEnabled(ovButtons, !enabled);
      }

      if (selectedItem is PanoramaViewerButtons pvButtons && PanoramaViewer != null)
      {
        bool enabled = await PanoramaViewer.GetButtonEnabled(pvButtons);
        PanoramaViewer.ToggleButtonEnabled(pvButtons, !enabled);
      }
    }

    private async void btnGetDebugLogs_Click(object sender, EventArgs e)
    {
      string[] debugLogs = await _api.GetDebugLogs();
      txtRecordingViewerColorPermissions.Text = string.Empty;
      string permissionsString = debugLogs.Aggregate(string.Empty,
        (current, permission) => $"{current}{permission}{Environment.NewLine}");
      txtRecordingViewerColorPermissions.Text = permissionsString;
    }

    private void btnBrightness_Click(object sender, EventArgs e)
    {
      if (double.TryParse(txtBrightnessContrast.Text, out var value))
      {
        PanoramaViewer?.SetBrightness(value);
      }
    }

    private void btnContrast_Click(object sender, EventArgs e)
    {
      if (double.TryParse(txtBrightnessContrast.Text, out var value))
      {
        PanoramaViewer?.SetContrast(value);
      }
    }

    private async void btnToggle3DCursor_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.Get3DCursorVisible();
      PanoramaViewer.Toggle3DCursor(!visible);
    }

    private async void btnClosePanoramaViewer_Click(object sender, EventArgs e)
    {
      if (_panoramaViewers.Count >= 1)
      {
        string viewerId = await _panoramaViewers[_panoramaViewers.Count - 1].GetId();

        if (viewerId != null)
        {
          IList<IViewer> result = await _api.CloseViewer(viewerId);
          ShowOpenedViewers(result);
        }
      }
    }

    private async void btnGetViewers_Click(object sender, EventArgs e)
    {
      IList<IViewer> viewers = await _api.GetViewers();
      ShowOpenedViewers(viewers);
    }

    private void btnDrawDistance_Click(object sender, EventArgs e)
    {
      string text = txtDrawDistance.Text;

      if (int.TryParse(text, out var distance))
      {
        _api.SetOverlayDrawDistance(distance);
      }
    }

    private void btnSelectFeature_Click(object sender, EventArgs e)
    {
      Dictionary<string, string> properties = new Dictionary<string, string> { { txtName.Text, txtValue.Text } };
      IJson json = JsonFactory.Create(properties);
      string layerId = _overlay.Id;

      PanoramaViewer.SetSelectedFeatureByProperties(json, layerId);
    }

    #endregion

    #region Private Functions

    private double ParseDouble(string text)
    {
      text = text.Replace(",", ".");

      if (!double.TryParse(text, NumberStyles.Float, _ci, out var result))
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

      if (grMeasurement.InvokeRequired)
      {
        grMeasurement.Invoke(new MethodInvoker(() => grMeasurement.Enabled = value));
      }
      else
      {
        grMeasurement.Enabled = value;
      }

      if (grButtonVisibility.InvokeRequired)
      {
        grButtonVisibility.Invoke(new MethodInvoker(() => grButtonVisibility.Enabled = value));
      }
      else
      {
        grButtonVisibility.Enabled = value;
      }
    }

    private void PrintRecordingText(IRecording recording)
    {
      string text = $"GroundLevelOffset: {recording.GroundLevelOffset}{Environment.NewLine}";
      text += $"Recorderirection: {recording.RecorderDirection}{Environment.NewLine}";
      text += $"Orientation: {recording.Orientation}{Environment.NewLine}";
      text += $"RecordedAt: {recording.RecordedAt}{Environment.NewLine}";
      text += $"Id: {recording.Id}{Environment.NewLine}";
      text += $"Coordinate: {recording.XYZ.X}, {recording.XYZ.Y}, {recording.XYZ.Z}{Environment.NewLine}";
      text += $"SRS: {recording.SRS}{Environment.NewLine}";
      text += $"OrientationPrecision: {recording.OrientationPrecision}{Environment.NewLine}";
      text += $"TileSchema: {recording.TileSchema}{Environment.NewLine}";
      text += $"LongitudePrecision: {recording.LongitudePrecision}{Environment.NewLine}";
      text += $"LatitudePrecision: {recording.LatitudePrecision}{Environment.NewLine}";
      text += $"HeightPrecision: {recording.HeightPrecision}{Environment.NewLine}";
      text += $"ProductType: {recording.ProductType}{Environment.NewLine}";
      text += $"HeightSystem: {recording.HeightSystem}{Environment.NewLine}";
      text += $"ExpiredAt: {recording.ExpiredAt}{Environment.NewLine}";
      txtRecordingViewerColorPermissions.Text = text;
    }

    private void DisableGroups()
    {
      grOpenByAddress.Enabled = false;
      grViewerToggles.Enabled = false;
      grRotationsZoomInOut.Enabled = false;
      grAPIInfo.Enabled = false;
      grOpenByQuery.Enabled = false;
      grCoordinate.Enabled = false;
      grOrientation.Enabled = false;
      grOpenByImageId.Enabled = false;
      grRecordingViewerColorPermissions.Enabled = false;
      grMeasurement.Enabled = false;
      grButtonVisibility.Enabled = false;
    }

    private async void ShowOpenedViewers(IList<IViewer> viewers)
    {
      string openedViewers = $"These viewers are now open:{Environment.NewLine}";

      foreach (var viewer in viewers)
      {
        openedViewers += $" {await viewer.GetId()}{Environment.NewLine}";
      }

      MessageBox.Show(openedViewers);
    }

    #endregion
  }
}
