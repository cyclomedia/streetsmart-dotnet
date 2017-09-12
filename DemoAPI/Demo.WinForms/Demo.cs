/*
 * Street Smart .NET integration
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

using StreetSmart.WinForms.Exceptions;
using StreetSmart.WinForms.Factories;
using StreetSmart.WinForms.Interfaces;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using Newtonsoft.Json;

using static Demo.WinForms.Properties.Resources;

namespace Demo.WinForms
{
  public partial class Demo : Form
  {
    private const string ApiLocation = null;

    #region Members

    private readonly IStreetSmartAPI _api;
    private readonly List<IPanoramaViewer> _viewers;
    private readonly CultureInfo _ci;
    private readonly Login _login;

    private IOptions _options;

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
      _login = Login.Instance;
      _ci = CultureInfo.InvariantCulture;
      _viewers = new List<IPanoramaViewer>();
      _api = string.IsNullOrEmpty(ApiLocation)
        ? StreetSmartAPIFactory.Create()
        : StreetSmartAPIFactory.Create(ApiLocation);
      _api.APIReady += OnAPIReady;
      plStreetSmart.Controls.Add(_api.GUI);
      grLogin.Enabled = false;
      DisableGroups();

      txtUsername.Text = _login.Username;
      txtPassword.Text = _login.Password;
      txtAPIKey.Text = _login.ApiKey;
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
        btnLogin.Enabled = true;
      }
    }

    private void OnImageChange(object sender, IEventArgs<IDictionary<string, object>> args)
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

    private void OnViewLoadEnd(object sender, IEventArgs<IDictionary<string, object>> args)
    {
      string text = "Image load end";
      AddViewerEventsText(text);
    }

    private void OnViewLoadStart(object sender, IEventArgs<IDictionary<string, object>> args)
    {
      string text = "Image load start";
      AddViewerEventsText(text);
    }

    private void OnTimeTravelChange(object sender, IEventArgs<IDictionary<string, object>> args)
    {
      string text = "Time travel change";
      AddViewerEventsText(text);
    }

    private void OnMeasurementChanged(object sender, IEventArgs<IDictionary<string, object>> args)
    {
      string text = "Measurement changed";
      AddViewerEventsText(text);
    }

    #endregion

    #region events from user interface

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create("nl", "CMDatabase");
      IDomElement element = DomElementFactory.Create();
      _options = OptionsFactory.Create(txtUsername.Text, txtPassword.Text, txtAPIKey.Text, srs, locale,
        addressSettings, element);

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

        if (btnLogin.InvokeRequired)
        {
          btnLogin.Invoke(new MethodInvoker(() => btnLogin.Enabled = false));
        }
        else
        {
          btnLogin.Enabled = false;
        }

        MessageBox.Show("Login successfully");
      }
      catch (StreetSmartLoginFailedException ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
      if (_options != null)
      {
        _api.Destroy(_options);
        _viewers.Clear();

        btnLogin.Enabled = true;
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
      Viewer?.RotateLeft(DeltaYawPitch);
    }

    private void btnRotateRight_Click(object sender, EventArgs e)
    {
      Viewer?.RotateRight(DeltaYawPitch);
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

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtAddressSrs.Text);
        IList<IViewer> viewers = await _api.OpenByQuery(txtAdress.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            _viewers.Add(viewer as IPanoramaViewer);

            Viewer.ImageChange += OnImageChange;
            Viewer.RecordingClick += OnRecordingClick;
            Viewer.TileLoadError += OnTileLoadError;
            Viewer.ViewChange += OnViewChange;
            Viewer.ViewLoadEnd += OnViewLoadEnd;
            Viewer.ViewLoadStart += OnViewLoadStart;
            Viewer.TimeTravelChange += OnTimeTravelChange;
          }
        }

        _api.MeasurementChanged += OnMeasurementChanged;
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
      }

      EnableImageEnables(true);
    }

    private async void btnGetViewerColor_Click(object sender, EventArgs e)
    {
      Color color = await Viewer.GetViewerColor();
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
      IOrientation orientation = await Viewer.GetOrientation();
      txtYaw.Text = orientation.Yaw.ToString();
      txtPitch.Text = orientation.Pitch.ToString();
      txthFov.Text = orientation.HFov.ToString();
    }

    private void btnSetOrientation_Click(object sender, EventArgs e)
    {
      double? hFov = string.IsNullOrEmpty(txthFov.Text) ? null : (double?)ParseDouble(txthFov.Text);
      double? yaw = string.IsNullOrEmpty(txtYaw.Text) ? null : (double?)ParseDouble(txtYaw.Text);
      double? pitch = string.IsNullOrEmpty(txtPitch.Text) ? null : (double?)ParseDouble(txtPitch.Text);
      IOrientation orientation = OrientationFactory.Create(yaw, pitch, hFov);
      Viewer.SetOrientation(orientation);
    }

    private async void btnGetRecording_Click(object sender, EventArgs e)
    {
      IRecording recording = await Viewer.GetRecording();
      PrintRecordingText(recording);
    }

    private void btnLookAtCoordinate_Click(object sender, EventArgs e)
    {
      ICoordinate coordinate = string.IsNullOrEmpty(txtZ.Text)
        ? CoordinateFactory.Create(ParseDouble(txtX.Text), ParseDouble(txtY.Text))
        : CoordinateFactory.Create(ParseDouble(txtX.Text), ParseDouble(txtY.Text), ParseDouble(txtZ.Text));

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
      bool visible = await Viewer.GetRecordingsVisible();
      Viewer.ToggleRecordingsVisible(!visible);
    }

    private async void btnToggleNavbarVisible_Click(object sender, EventArgs e)
    {
      bool visible = await Viewer.GetNavbarVisible();
      Viewer.ToggleNavbarVisible(!visible);
    }

    private async void btnToggleNavbarExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await Viewer.GetNavbarExpanded();
      Viewer.ToggleNavbarExpanded(!expanded);
    }

    private async void btnToggleTimeTravelVisible_Click(object sender, EventArgs e)
    {
      bool visible = await Viewer.GetTimeTravelVisible();
      Viewer.ToggleTimeTravelVisible(!visible);
    }

    private async void btnToggleTimeTravelExpanded_Click(object sender, EventArgs e)
    {
      bool expanded = await Viewer.GetTimeTravelExpanded();
      Viewer.ToggleTimeTravelExpanded(!expanded);
    }

    private async void btnOpenByImageId_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtOpenByImageSrs.Text);
        IList<IViewer> viewers = await _api.OpenByQuery(txtImageId.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            _viewers.Add(viewer as IPanoramaViewer);

            Viewer.ImageChange += OnImageChange;
            Viewer.RecordingClick += OnRecordingClick;
            Viewer.TileLoadError += OnTileLoadError;
            Viewer.ViewChange += OnViewChange;
            Viewer.ViewLoadEnd += OnViewLoadEnd;
            Viewer.ViewLoadStart += OnViewLoadStart;
            Viewer.TimeTravelChange += OnTimeTravelChange;
          }
        }

        _api.MeasurementChanged += OnMeasurementChanged;
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

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
      }

      try
      {
        string txtcoordinate = string.IsNullOrEmpty(txtZ.Text)
          ? $"{ParseDouble(txtX.Text).ToString(_ci)}, {ParseDouble(txtY.Text).ToString(_ci)}"
          : $"{ParseDouble(txtX.Text).ToString(_ci)}, {ParseDouble(txtY.Text).ToString(_ci)}, {ParseDouble(txtZ.Text).ToString(_ci)}";

        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtCoordinateSrs.Text);
        IList<IViewer> viewers = await _api.OpenByQuery(txtcoordinate, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            _viewers.Add(viewer as IPanoramaViewer);

            Viewer.ImageChange += OnImageChange;
            Viewer.RecordingClick += OnRecordingClick;
            Viewer.TileLoadError += OnTileLoadError;
            Viewer.ViewChange += OnViewChange;
            Viewer.ViewLoadEnd += OnViewLoadEnd;
            Viewer.ViewLoadStart += OnViewLoadStart;
            Viewer.TimeTravelChange += OnTimeTravelChange;
          }
        }

        _api.MeasurementChanged += OnMeasurementChanged;
      }
      catch (StreetSmartImageNotFoundException ex)
      {
        MessageBox.Show(ex.Message);
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

    private async void btnOpenViewerByQuery_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType>();

      if (cbOblique.Checked)
      {
        viewerTypes.Add(ViewerType.Oblique);
      }

      if (cbPanorama.Checked)
      {
        viewerTypes.Add(ViewerType.Panorama);
      }

      try
      {
        IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, txtOpenByImageSrs.Text);
        IList<IViewer> viewers = await _api.OpenByQuery(txtOpenByQuery.Text, viewerOptions);

        foreach (IViewer viewer in viewers)
        {
          if (viewer is IPanoramaViewer)
          {
            _viewers.Add(viewer as IPanoramaViewer);

            Viewer.ImageChange += OnImageChange;
            Viewer.RecordingClick += OnRecordingClick;
            Viewer.TileLoadError += OnTileLoadError;
            Viewer.ViewChange += OnViewChange;
            Viewer.ViewLoadEnd += OnViewLoadEnd;
            Viewer.ViewLoadStart += OnViewLoadStart;
            Viewer.TimeTravelChange += OnTimeTravelChange;
          }
        }

        _api.MeasurementChanged += OnMeasurementChanged;
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

    private void btnShowDefTools_Click(object sender, EventArgs e)
    {
      _api?.ShowDefTools();
    }

    private void btnCloseDefTools_Click(object sender, EventArgs e)
    {
      _api?.CloseDefTools();
    }

    #endregion

    #region Private Functions

    private double ParseDouble(string text)
    {
      double result;
      text = text.Replace(",", ".");

      if (!double.TryParse(text, NumberStyles.Float, _ci, out result))
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
    }

    #endregion

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

      _api.StartMeasurementMode(Viewer, options);
    }

    private void btnStopMeasurementMode_Click(object sender, EventArgs e)
    {
      _api.StopMeasurementMode();
    }

    private async void btnGetMeasurementInfo_Click(object sender, EventArgs e)
    {
      var measurement = await _api.GetMeasurementInfo();
      string json = JsonConvert.SerializeObject(measurement);
      const int maxLength = 128;
      AddViewerEventsText(json.Substring(0, Math.Min(json.Length, maxLength)));
    }

    private void btnAddOverlay_Click(object sender, EventArgs e)
    {
      _api.AddOverlay("My GeoJSON", txtOverlayGeoJson.Text);
    }
  }
}
