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
    private readonly List<IPointCloudViewer> _pointCloudViewers;
    private readonly List<IMeshViewer> _meshViewers;
    private readonly CultureInfo _ci;
    private readonly Login _login;

    private IFeatureCollection _measurement;

    private IOptions _options;
    private IOverlay _overlay;
    private bool _addressLayerOverlayVisible;
    private IPanoramaViewer _panoramaViewer;
    private IViewer _viewer;

    #endregion

    #region Properties

    private IPanoramaViewer PanoramaViewer
    {
      get => _panoramaViewer ?? (_panoramaViewers.Count == 0 ? null : _panoramaViewers[_panoramaViewers.Count - 1]);
      set => _panoramaViewer = value;
    }

    private IObliqueViewer ObliqueViewer
    {
      get => _obliqueViewers.Count == 0 ? null : _obliqueViewers [_obliqueViewers.Count - 1];
      set
      {
        if (_obliqueViewers.Count == 0)
        {
          _obliqueViewers.Add(value);
        }
        else
        {
          _obliqueViewers[_obliqueViewers.Count - 1] = value;
        }
      }
    }

    private IPointCloudViewer PointCloudViewer
    {
      get => _pointCloudViewers.Count == 0 ? null : _pointCloudViewers[_pointCloudViewers.Count - 1];
      set
      {
        if (_pointCloudViewers.Count == 0)
        {
          _pointCloudViewers.Add(value);
        }
        else
        {
          _pointCloudViewers[_pointCloudViewers.Count - 1] = value;
        }
      }
    }

    private IMeshViewer MeshViewer
    {
      get => _meshViewers.Count == 0 ? null : _meshViewers[_meshViewers.Count - 1];
      set
      {
        if (_meshViewers.Count == 0)
        {
          _meshViewers.Add(value);
        }
        else
        {
          _meshViewers[_meshViewers.Count - 1] = value;
        }
      }
    }

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
      _pointCloudViewers = new List<IPointCloudViewer>();
      _meshViewers = new List<IMeshViewer>();
      _addressLayerOverlayVisible = true;
      txtOverlayColor.BackColor = Color.Blue;

      // IAPISettings apiSettings = CefSettingsFactory.Create();
      //      IAPISettings apiSettings = CefSettingsFactory.Create(
      //        @"D:\StreetSmartFiles\Cache",
      //        @"D:\StreetSmartFiles\BrowserSubprocess\CefSharp.BrowserSubprocess.exe",
      //        @"D:\StreetSmartFiles\Locales",
      //        @"D:\StreetSmartFiles\Resources");
      IAPISettings apiSettings = CefSettingsFactory.Create(@"D:\StreetSmartAPI\Cache");
      apiSettings.DisableGPUCache = true;
      apiSettings.AllowInsecureContent = true;

      _api = string.IsNullOrEmpty(StreetSmartLocation)
        ? StreetSmartAPIFactory.Create(apiSettings)
        : StreetSmartAPIFactory.Create(StreetSmartLocation, apiSettings);
      _api.APIReady += OnAPIReady;
      _api.MeasurementChanged += OnMeasurementChanged;
      _api.MeasurementStarted += OnMeasurementStarted;
      _api.MeasurementStopped += OnMeasurementStopped;
      _api.MeasurementSaved += OnMeasurementSaved;
      _api.ViewerAdded += OnViewerAdded;
      _api.ViewerRemoved += OnViewerRemoved;
      _api.BearerTokenChanged += OnBearerTokenChanged;
      plStreetSmart.Controls.Add(_api.GUI);

      grLogin.Enabled = false;
      DisableGroups();

      txtUsername.Text = _login.Username;
      txtPassword.Text = _login.Password;
      txtAPIKey.Text = _login.ApiKey;
      txtClientId.Text = _login.ClientId;
      cbUseOAuth.Checked = _login.UseOAuth;

      ObliqueViewerButtons[] obButtons =
      {
        ObliqueViewerButtons.Overlays, ObliqueViewerButtons.ImageInformation,
        ObliqueViewerButtons.ZoomIn, ObliqueViewerButtons.ZoomOut,
        ObliqueViewerButtons.SwitchDirection, ObliqueViewerButtons.SaveImage,
        ObliqueViewerButtons.ToggleNadir, ObliqueViewerButtons.Measure,
        ObliqueViewerButtons.SaveMeasurement
      };

      foreach (var obButton in obButtons)
      {
        cbViewerButton.Items.Add(new ViewerButtonsBox(obButton));
      }

      PointCloudViewerButtons[] pcButtons =
      {
        PointCloudViewerButtons.Measure, PointCloudViewerButtons.Display,
        PointCloudViewerButtons.Download, PointCloudViewerButtons.ImageInformation,
        PointCloudViewerButtons.Overlays, PointCloudViewerButtons.Sections,
        PointCloudViewerButtons.ToggleAerialStreet, PointCloudViewerButtons.SaveMeasurement
      };

      foreach (var pcButton in pcButtons)
      {
        cbViewerButton.Items.Add(new ViewerButtonsBox(pcButton));
      }

      PanoramaViewerButtons[] pnButtons =
      {
        PanoramaViewerButtons.Elevation, PanoramaViewerButtons.Overlays,
        PanoramaViewerButtons.OpenOblique, PanoramaViewerButtons.ReportBlurring,
        PanoramaViewerButtons.Measure, PanoramaViewerButtons.ImageInformation,
        PanoramaViewerButtons.SaveImage, PanoramaViewerButtons.ZoomIn,
        PanoramaViewerButtons.ZoomOut, PanoramaViewerButtons.ZoomWindow,
        PanoramaViewerButtons.SaveMeasurement
      };

      foreach (var pnButton in pnButtons)
      {
        cbViewerButton.Items.Add(new ViewerButtonsBox(pnButton));
      }

      cbPointBudget.Items.Add(Quality.Low);
      cbPointBudget.Items.Add(Quality.Medium);
      cbPointBudget.Items.Add(Quality.High);

      cbPointStyle.Items.Add(ColorizationMode.Classification);
      cbPointStyle.Items.Add(ColorizationMode.Height);
      cbPointStyle.Items.Add(ColorizationMode.Intensity);
      cbPointStyle.Items.Add(ColorizationMode.Rgb);

      cbUnit.Items.Add(UnitPreference.Default);
      cbUnit.Items.Add(UnitPreference.Feet);
      cbUnit.Items.Add(UnitPreference.Meter);

      cbShortCuts.Items.Add(ShortcutNames.CopyCoordinateToClipboard);
      cbShortCuts.Items.Add(ShortcutNames.CloseAllPanoramas);
      cbShortCuts.Items.Add(ShortcutNames.MoveToPanoramaPosition);
      cbShortCuts.Items.Add(ShortcutNames.MovePanoramaWithArrowKeys);
      cbShortCuts.Items.Add(ShortcutNames.StartMeasurementFromPanorama);
      cbShortCuts.Items.Add(ShortcutNames.ClosePanorama);
      cbShortCuts.Items.Add(ShortcutNames.CloseOtherPanorama);
      cbShortCuts.Items.Add(ShortcutNames.StartMeasurementFromMap);
      cbShortCuts.Items.Add(ShortcutNames.StartMeasurementFromOblique);
      cbShortCuts.Items.Add(ShortcutNames.CloseOblique);
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

    private void OnMeasurementStarted(object sender, IEventArgs<IFeatureCollection> args)
    {
      string text = "Measurement started";
      AddViewerEventsText(text);
    }

    private void OnMeasurementStopped(object sender, IEventArgs<IFeatureCollection> args)
    {
      string text = "Measurement stopped";
      AddViewerEventsText(text);
    }

    private void OnMeasurementSaved(object sender, IEventArgs<IFeatureCollection> args)
    {
      string text = "Measurement saved";
      AddViewerEventsText(text);
    }

    private async void OnViewerAdded(object sender, IEventArgs<IViewer> args)
    {
      string text = "Viewer added";
      AddViewerEventsText(text);
      IViewer viewer = args.Value;

      if (viewer is IImageViewer imageViewer)
      {
        imageViewer.LayerVisibilityChange += OnLayerVisibilityChange;
      }

      ViewerElement viewerElement = new ViewerElement();
      await viewerElement.AddViewer(viewer);

      if (lbPanoramaList.InvokeRequired)
      {
        lbPanoramaList.Invoke(new MethodInvoker(() => lbPanoramaList.Items.Add(viewerElement)));
      }
      else
      {
        lbPanoramaList.Items.Add(viewerElement);
      }

      if (viewer is IPanoramaViewer panoramaViewer)
      {
        _panoramaViewers.Add(panoramaViewer);

        panoramaViewer.ElevationChange += OnElevationChange;
        panoramaViewer.ImageChange += OnImageChange;
        panoramaViewer.RecordingClick += OnRecordingClick;
        panoramaViewer.TileLoadError += OnTileLoadError;
        panoramaViewer.ViewChange += OnViewChange;
        panoramaViewer.SurfaceCursorChange += OnSurfaceCursorChange;
        panoramaViewer.ViewLoadEnd += OnViewLoadEnd;
        panoramaViewer.TimeTravelChange += OnTimeTravelChange;
        panoramaViewer.FeatureClick += OnFeatureClick;
        panoramaViewer.FeatureSelectionChange += OnFeatureSelectionChange;
      }

      if (viewer is IObliqueViewer obliqueViewer)
      {
        _obliqueViewers.Add(obliqueViewer);

        obliqueViewer.SwitchViewingDir += OnSwitchDirection;
        obliqueViewer.FeatureClick += OnObliqueFeatureClick;
        obliqueViewer.FeatureSelectionChange += OnObliqueFeatureSelectionChange;
        obliqueViewer.ImageChange += OnObliqueImageChange;
        obliqueViewer.ViewChange += OnObliqueViewChange;
        obliqueViewer.ViewLoadEnd += OnObliqueViewLoadEnd;
        obliqueViewer.TimeTravelChange += OnObliqueTimeTravelChange;
      }

      if (viewer is IPointCloudViewer pointCloudViewer)
      {
        _pointCloudViewers.Add(pointCloudViewer);

        pointCloudViewer.ViewChange += OnPointCloudViewChange;
        pointCloudViewer.EdgesChanged += OnEdgesChange;
        pointCloudViewer.PointBudgedChanged += OnBudgedChanged;
        pointCloudViewer.PointSizeChanged += OnPointSizeChanged;
        pointCloudViewer.PointStyleChanged += OnPointStyleChanged;
        pointCloudViewer.BackGroundChanged += OnBackGroundChanged;
      }

      if (viewer is IMeshViewer meshViewer)
      {
        _meshViewers.Add(meshViewer);
      }
    }

    private void OnViewerRemoved(object sender, IEventArgs<IViewer> args)
    {
      string text = "Viewer removed";
      AddViewerEventsText(text);
      IViewer viewer = args.Value;

      if (viewer != null)
      {
        if (viewer is IImageViewer imageViewer)
        {
          imageViewer.LayerVisibilityChange -= OnLayerVisibilityChange;
        }

        ViewerElement remove = null;

        foreach (var item in lbPanoramaList.Items)
        {
          remove = item is ViewerElement element && element.Viewer == viewer ? element : remove;
        }

        if (viewer is IPanoramaViewer panoramaViewer)
        {
          _panoramaViewers.Remove(panoramaViewer);

          panoramaViewer.ElevationChange -= OnElevationChange;
          panoramaViewer.ImageChange -= OnImageChange;
          panoramaViewer.RecordingClick -= OnRecordingClick;
          panoramaViewer.TileLoadError -= OnTileLoadError;
          panoramaViewer.ViewChange -= OnViewChange;
          panoramaViewer.SurfaceCursorChange -= OnSurfaceCursorChange;
          panoramaViewer.ViewLoadEnd -= OnViewLoadEnd;
          panoramaViewer.TimeTravelChange -= OnTimeTravelChange;
          panoramaViewer.FeatureClick -= OnFeatureClick;
          panoramaViewer.FeatureSelectionChange -= OnFeatureSelectionChange;
        }

        if (viewer is IObliqueViewer obliqueViewer)
        {
          _obliqueViewers.Remove(obliqueViewer);

          obliqueViewer.SwitchViewingDir -= OnSwitchDirection;
          obliqueViewer.FeatureClick -= OnObliqueFeatureClick;
          obliqueViewer.FeatureSelectionChange -= OnObliqueFeatureSelectionChange;
          obliqueViewer.ImageChange -= OnObliqueImageChange;
          obliqueViewer.ViewChange -= OnObliqueViewChange;
          obliqueViewer.ViewLoadEnd -= OnObliqueViewLoadEnd;
          obliqueViewer.TimeTravelChange -= OnObliqueTimeTravelChange;
        }

        if (viewer is IPointCloudViewer pointCloudViewer)
        {
          _pointCloudViewers.Remove(pointCloudViewer);
        }

        if (viewer is IMeshViewer meshViewer)
        {
          _meshViewers.Remove(meshViewer);
        }

        if (remove != null)
        {
          if (lbPanoramaList.InvokeRequired)
          {
            lbPanoramaList.Invoke(new MethodInvoker(() => lbPanoramaList.Items.Remove(remove)));
          }
          else
          {
            lbPanoramaList.Items.Remove(remove);
          }
        }
      }
    }

    private void OnBearerTokenChanged(object sender, IEventArgs<IBearer> args)
    {
      string text = "Bearer token changed";
      AddViewerEventsText(text);
    }

    #endregion

    #region events oblique viewer 

    private void OnSwitchDirection(object sender, IEventArgs<IDirectionInfo> args)
    {
      string text = "Switch Direction";
      AddViewerEventsText(text);
    }

    private void OnObliqueFeatureClick(object sender, IEventArgs<IFeatureInfo> args)
    {
      string text = "feature Oblique Clicked";
      AddViewerEventsText(text);
    }

    private void OnObliqueFeatureSelectionChange(object sender, IEventArgs<IFeatureInfo> args)
    {
      string text = "feature Oblique Selection Change";
      AddViewerEventsText(text);
    }

    private void OnObliqueImageChange(object sender, IEventArgs<IObliqueImageInfo> args)
    {
      string text = "Oblique Image change";
      AddViewerEventsText(text);
    }

    private void OnObliqueViewChange(object sender, IEventArgs<IObliqueOrientation> args)
    {
      string text = "Oblique View change";
      AddViewerEventsText(text);
    }

    private void OnObliqueViewLoadEnd(object sender, EventArgs args)
    {
      string text = "Oblique view load end";
      AddViewerEventsText(text);
    }

    private void OnObliqueTimeTravelChange(object sender, IEventArgs<ITimeTravelInfo> args)
    {
      string text = "Oblique Time travel change";
      AddViewerEventsText(text);
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

    private async void OnViewChange(object sender, IEventArgs<IOrientation> args)
    {
      if (sender is IPanoramaViewer panoramaViewer)
      {
        string id = await panoramaViewer.GetId();
        IOrientation orientation = args.Value;
        string text =
          $"Id: {id}, View change args, pitch: {orientation.Pitch}, yaw: {orientation.Yaw}, hFov: {orientation.HFov}";
        AddViewerEventsText(text);
      }
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

    private void OnFeatureClick(object sender, IEventArgs<IFeatureInfo> args)
    {
      string text = "featureClicked";
      AddViewerEventsText(text);
    }

    private void OnFeatureSelectionChange(object sender, IEventArgs<IFeatureInfo> args)
    {
      string text = "featureSelectionChange";
      AddViewerEventsText(text);
    }

    private void ckShowAttributePanelOnFeatureClick_CheckedChanged(object sender, EventArgs e)
    {
      PanoramaViewer.ShowAttributePanelOnFeatureClick(ckShowAttributePanelOnFeatureClick.Checked);
    }

    #endregion

    #region events point cloud viewer

    private void OnPointCloudViewChange(object sencer, IEventArgs<ICamera> args)
    {
      string text = "On point cloud view change";
      AddViewerEventsText(text);
    }

    private void OnEdgesChange(object sender, IEventArgs<bool> args)
    {
      string text = "On edges change";
      AddViewerEventsText(text);
    }

    private void OnBudgedChanged(object sender, IEventArgs<Quality> args)
    {
      string text = "On point budget change";
      AddViewerEventsText(text);
    }

    private void OnPointSizeChanged(object sender, IEventArgs<PointSize> args)
    {
      string text = "On point size change";
      AddViewerEventsText(text);
    }

    private void OnPointStyleChanged(object sender, IEventArgs<ColorizationMode> args)
    {
      string text = "On point style change";
      AddViewerEventsText(text);
    }

    private void OnBackGroundChanged(object sender, IEventArgs<BackgroundPreset> args)
    {
      string text = "On back ground preset change";
      AddViewerEventsText(text);
    }

    #endregion

    #region events from user interface

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create("nl", "CMdatabase");
      IDomElement element = DomElementFactory.Create();

      if (cbUseOAuth.Checked)
      {
      _options = OptionsFactory.CreateOauth(
          txtUsername.Text,
        txtClientId.Text,
          txtAPIKey.Text,
          txtSrs.Text,
          locale,
          addressSettings, // address settings
          element, // target element
          cbSilentOAuthOnly.Checked,
          cbLogoutOnDestroy.Checked
        );
      }
      else
      {
        _options = OptionsFactory.Create(
          txtUsername.Text, 
          txtPassword.Text,                
        txtAPIKey.Text,
        txtSrs.Text,
        locale,
        addressSettings, // address settings
        element // target element
      );
      }

      //_options = OptionsFactory.Create(txtUsername.Text, txtPassword.Text, txtClientId.Text, txtAPIKey.Text, txtSrs.Text, locale,
      //  ConfigurationUrl, addressSettings, element, true);

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

      if (txtClientId.InvokeRequired)
      {
        txtClientId.Invoke(new MethodInvoker(() => txtClientId.Enabled = enabled));
      }
      else
      {
        txtClientId.Enabled = enabled;
      }

      if (txtSrs.InvokeRequired)
      {
        txtSrs.Invoke(new MethodInvoker(() => txtSrs.Enabled = enabled));
      }
      else
      {
        txtSrs.Enabled = enabled;
      }

      if (cbUseOAuth.InvokeRequired)
      {
        cbUseOAuth.Invoke(new MethodInvoker(() => cbUseOAuth.Enabled = enabled));
      }
      else
      {
        cbUseOAuth.Enabled = enabled;
      }

      if (cbSilentOAuthOnly.InvokeRequired)
      {
        cbSilentOAuthOnly.Invoke(new MethodInvoker(() => cbSilentOAuthOnly.Enabled = enabled));
      }
      else
      {
        cbSilentOAuthOnly.Enabled = enabled;
      }

      if (cbLogoutOnDestroy.InvokeRequired)
      {
        cbLogoutOnDestroy.Invoke(new MethodInvoker(() => cbLogoutOnDestroy.Enabled = enabled));
      }
      else
      {
        cbLogoutOnDestroy.Enabled = enabled;
      }
    }

    private async void btnLogout_Click(object sender, EventArgs e)
    {
      if (_options != null)
      {
        await _api.Destroy(_options);
        _panoramaViewers.Clear();
        _obliqueViewers.Clear();
        _pointCloudViewers.Clear();

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

    private void txtClientId_TextChanged(object sender, EventArgs e)
    {
      _login.ClientId = txtClientId.Text;
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

      if (cbPointCloud.Checked)
      {
        viewerTypes.Add(ViewerType.PointCloud);
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

          if (viewer is IPointCloudViewer)
          {
            IPointCloudViewer pointCloudViewer = viewer as IPointCloudViewer;

            if (!_pointCloudViewers.Contains(pointCloudViewer))
            {
              MessageBox.Show("point cloud viewer doesn't exists in the list");
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
      if (PanoramaViewer != null)
      {
        bool visible = await PanoramaViewer.GetRecordingsVisible();
        PanoramaViewer.ToggleRecordingsVisible(!visible);
      }
    }

    private async void btnToggleNavbarVisible_Click(object sender, EventArgs e)
    {
      IViewer viewer = _viewer ?? PanoramaViewer;
      bool visible = await viewer.GetNavbarVisible();
      viewer.ToggleNavbarVisible(!visible);
    }

    private async void btnToggleNavbarExpanded_Click(object sender, EventArgs e)
    {
      IViewer viewer = _viewer ?? PanoramaViewer;
      bool expanded = await viewer.GetNavbarExpanded();
      viewer.ToggleNavbarExpanded(!expanded);
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

      if (cbPointCloud.Checked)
      {
        viewerTypes.Add(ViewerType.PointCloud);
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

          if (viewer is IPointCloudViewer)
          {
            IPointCloudViewer pointCloudViewer = viewer as IPointCloudViewer;

            if (!_pointCloudViewers.Contains(pointCloudViewer))
            {
              MessageBox.Show("point cloud viewer doesn't exists in the list");
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

      if (cbPointCloud.Checked)
      {
        viewerTypes.Add(ViewerType.PointCloud);
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

          if (viewer is IPointCloudViewer)
          {
            IPointCloudViewer pointCloudViewer = viewer as IPointCloudViewer;

            if (!_pointCloudViewers.Contains(pointCloudViewer))
            {
              MessageBox.Show("point cloud viewer doesn't exists in the list");
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

      if (cbPointCloud.Checked)
      {
        viewerTypes.Add(ViewerType.PointCloud);
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

          if (viewer is IPointCloudViewer)
          {
            IPointCloudViewer pointCloudViewer = viewer as IPointCloudViewer;

            if (!_pointCloudViewers.Contains(pointCloudViewer))
            {
              MessageBox.Show("point cloud viewer doesn't exists in the list");
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

    private async void btnStartMeasurementMode_Click(object sender, EventArgs e)
    {
      MeasurementGeometryType? type = null;
      MeasureMethods? method = null;
      IMeasurementOptions options = null;

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

      if (rbMethodDepthMap.Checked)
      {
        method = MeasureMethods.DepthMap;
      }
      else if (rbMethodSmartClick.Checked)
      {
        method = MeasureMethods.SmartClick;
      }
      else if (rbMethodForwardIntersection.Checked)
      {
        method = MeasureMethods.ForwardIntersection;
      }

      if (type == null && method == null)
      {
        options = MeasurementOptionsFactory.Create();
      }
      else if (type == null)
      {
        options = MeasurementOptionsFactory.Create((MeasureMethods) method);
      }
      else if (method == null)
      {
        options = MeasurementOptionsFactory.Create((MeasurementGeometryType) type);
      }
      else
      {
        options = MeasurementOptionsFactory.Create((MeasurementGeometryType) type, (MeasureMethods) method, true);
      }

      IViewer viewer = _viewer ?? PanoramaViewer;

      if (viewer != null)
      {
        try
        {
          await _api.StartMeasurementMode(viewer, options);
        }
        catch (StreetSmartMeasurementException exception)
        {
          MessageBox.Show($"exception during start measurement: {exception}");
        }
      }
    }

    private void btnStopMeasurementMode_Click(object sender, EventArgs e)
    {
      _api.StopMeasurementMode();
    }

    private async void btnGetMeasurementInfo_Click(object sender, EventArgs e)
    {
      _measurement = await _api.GetActiveMeasurement();
      AddViewerEventsText(_measurement?.ToString() ?? string.Empty);
    }

    private async void btnAddOverlay_Click(object sender, EventArgs e)
    {
      if (_overlay == null)
      {
        string name = "My GeoJSON";
        string geoJson = txtOverlayGeoJson.Text;
        string sld = txtSld.Text;
        IGeoJsonOverlay overlay;

        if (rbSLD.Checked)
        {
          overlay = string.IsNullOrEmpty(sld)
            ? OverlayFactory.Create(geoJson, name)
            : OverlayFactory.Create(geoJson, name, txtSrs.Text, sld);
        }
        else
        {
          overlay = OverlayFactory.Create(geoJson, name, txtSrs.Text, txtOverlayColor.BackColor);
        }

        try
        {
          _overlay = await _api.AddOverlay(overlay);
        }
        catch (StreetSmartJsonException ex)
        {
          MessageBox.Show("Json exception", ex.Message);
        }
        catch (StreetSmartException ex)
        {
          MessageBox.Show("Street smart exception", ex.Message);
        }
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
          ObliqueViewerButtons.Overlays, ObliqueViewerButtons.ImageInformation,
          ObliqueViewerButtons.ZoomIn, ObliqueViewerButtons.ZoomOut,
          ObliqueViewerButtons.SwitchDirection, ObliqueViewerButtons.SaveImage,
          ObliqueViewerButtons.ToggleNadir, ObliqueViewerButtons.Measure
        };

        foreach (var button in buttons)
        {
          bool enabled = await ObliqueViewer.GetButtonEnabled(button);
          txtRecordingViewerColorPermissions.Text += $@"Oblique viewer: {button}: {enabled}{Environment.NewLine}";
        }
      }

      if (PointCloudViewer != null)
      {
        PointCloudViewerButtons[] buttons =
        {
          PointCloudViewerButtons.Measure, PointCloudViewerButtons.Display,
          PointCloudViewerButtons.Download, PointCloudViewerButtons.ImageInformation,
          PointCloudViewerButtons.Overlays, PointCloudViewerButtons.Sections,
          PointCloudViewerButtons.ToggleAerialStreet
        };

        foreach (var button in buttons)
        {
          bool enabled = await PointCloudViewer.GetButtonEnabled(button);
          txtRecordingViewerColorPermissions.Text += $@"Point cloud viewer: {button}: {enabled}{Environment.NewLine}";
        }
      }

      if (PanoramaViewer != null)
      {
        PanoramaViewerButtons[] buttons =
        {
          PanoramaViewerButtons.Elevation, PanoramaViewerButtons.Overlays,
          PanoramaViewerButtons.OpenOblique, PanoramaViewerButtons.ReportBlurring,
          PanoramaViewerButtons.Measure, PanoramaViewerButtons.ImageInformation,
          PanoramaViewerButtons.SaveImage, PanoramaViewerButtons.ZoomIn,
          PanoramaViewerButtons.ZoomOut, PanoramaViewerButtons.ZoomWindow
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

      if (selectedItem is PointCloudViewerButtons pcButtons && PointCloudViewer != null)
      {
        bool enabled = await PointCloudViewer.GetButtonEnabled(pcButtons);
        PointCloudViewer.ToggleButtonEnabled(pcButtons, !enabled);
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
      Dictionary<string, string> properties = new Dictionary<string, string> {{txtName.Text, txtValue.Text}};
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

    private void btnToggleAddressOverlays_Click(object sender, EventArgs e)
    {
      PanoramaViewer?.ToggleAddressesVisible(!_addressLayerOverlayVisible);
      _addressLayerOverlayVisible = !_addressLayerOverlayVisible;
    }

    private void btnColorOverlay_Click(object sender, EventArgs e)
    {
      colorOverlay.Color = txtOverlayColor.BackColor;

      if (colorOverlay.ShowDialog() == DialogResult.OK)
      {
        txtOverlayColor.BackColor = colorOverlay.Color;
      }
    }

    private async void btnDemoWFSLayer_Click(object sender, EventArgs e)
    {
      if (_overlay == null)
      {
        string name = "PDOK BGT WFS";
        string url = "https://geodata.nationaalgeoregister.nl/beta/bgt/wfs";
        string typeName = "bgt:pand";
        string version = "1.1.0";
        string sld = txtSld.Text;
        IWFSOverlay wfsOverlay;

        if (rbSLD.Checked)
        {
          _overlay = string.IsNullOrEmpty(sld)
            ? wfsOverlay =
              OverlayFactory.CreateWfsOverlay(name, url, typeName, version, txtOverlayColor.BackColor, false)
            : wfsOverlay = OverlayFactory.CreateWfsOverlay(name, url, typeName, version, sld, false);
        }
        else
        {
          wfsOverlay = OverlayFactory.CreateWfsOverlay(name, url, typeName, version, txtOverlayColor.BackColor, false);
        }

        _overlay = await _api.AddWFSLayer(wfsOverlay);
      }

      /*
            string name = "My Supper cool layer";
            string url = "http://sandboxgeoserver.westeurope.cloudapp.azure.com/geoserver/agro/wfs";
            string typeName = "agro:polygon_agro_inventory";
            string version = "1.1.0";
            Color color = txtOverlayColor.BackColor;
            string username = "agro";
            string password = "XdEVA!7r";

            IWFSOverlay wfsOverlay = rbSLD.Checked
              ? OverlayFactory.CreateWfsOverlay(name, url, typeName, version, txtSld.Text, true, username, password)
              : OverlayFactory.CreateWfsOverlay(name, url, typeName, version, color, true, username, password);

            _overlay = await _api.AddWFSLayer(wfsOverlay);
      */
    }

    private void lbPanoramaList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lbPanoramaList.SelectedItem is ViewerElement element)
      {
        _viewer = element.Viewer;

        if (element.Viewer is IPanoramaViewer panoramaViewer)
        {
          PanoramaViewer = panoramaViewer;
        }
        else if (element.Viewer is IObliqueViewer obliqueViewer)
        {
          ObliqueViewer = obliqueViewer;
        }
        else if (element.Viewer is IPointCloudViewer pointCloudViewer)
        {
          PointCloudViewer = pointCloudViewer;
        }
      }
    }

    private async void btnToggleSidebar_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetSidebarExpanded();
      PanoramaViewer.ToggleSidebarExpanded(!visible);
    }

    private async void btnToggleSidebarExpandable_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetSidebarEnabled();
      PanoramaViewer.ToggleSidebarEnabled(!visible);
    }

    private async void btnToggleSidebarVisibility_Click(object sender, EventArgs e)
    {
      bool visible = await PanoramaViewer.GetSidebarVisible();
      PanoramaViewer.ToggleSidebarVisible(!visible);
    }

    private async void btnCloseObliqueViewer_Click(object sender, EventArgs e)
    {
      if (ObliqueViewer != null)
      {
        string viewerId = await ObliqueViewer.GetId();
        await _api.CloseViewer(viewerId);
      }
    }

    private async void btnClosePointViewer_Click(object sender, EventArgs e)
    {
      if (PointCloudViewer != null)
      {
        string viewerId = await PointCloudViewer.GetId();
        await _api.CloseViewer(viewerId);
      }
    }

    private async void btnGetType_Click(object sender, EventArgs e)
    {
      ViewerType type = await (_viewer ?? PanoramaViewer).GetType();
      MessageBox.Show($"Get viewer type: {type}");
    }

    private void btnFlyTo_Click(object sender, EventArgs e)
    {
    }

    private void btnCameraPosition_Click(object sender, EventArgs e)
    {
    }

    private async void btnEdges_Click(object sender, EventArgs e)
    {
      bool visible = await PointCloudViewer.GetEdgesVisibility();
      PointCloudViewer.ToggleEdges(!visible);
    }

    private async void btnGetPointBudget_Click(object sender, EventArgs e)
    {
      Quality budget = await PointCloudViewer.GetPointAmount();

      foreach (var item in cbPointBudget.Items)
      {
        if ((Quality) item == budget)
        {
          cbPointBudget.SelectedItem = item;
        }
      }
    }

    private void btnSetPointBudget_Click(object sender, EventArgs e)
    {
      if (cbPointBudget.SelectedItem is Quality budget)
      {
        PointCloudViewer.SetPointAmount(budget);
      }
    }

    private async void btnGetPointSize_Click(object sender, EventArgs e)
    {
      txtPointSize.Text = (await PointCloudViewer.GetPointSize()).ToString();
    }

    private void btnSetPointSize_Click(object sender, EventArgs e)
    {
      int.TryParse(txtPointSize.Text, out int size);
      PointSize pointSize = size == 1 ? PointSize.Single : size == 2 ? PointSize.Double : PointSize.Large;
      PointCloudViewer.SetPointSize(pointSize);
    }

    private async void btnGetPointStyle_Click(object sender, EventArgs e)
    {
      ColorizationMode style = await PointCloudViewer.GetPointStyle();

      foreach (var item in cbPointStyle.Items)
      {
        if ((ColorizationMode) item == style)
        {
          cbPointStyle.SelectedItem = item;
        }
      }
    }

    private void btnSetPointStyle_Click(object sender, EventArgs e)
    {
      if (cbPointStyle.SelectedItem is ColorizationMode style)
      {
        PointCloudViewer.SetPointStyle(style);
      }
    }

    private void btnPointCloudLookAt_Click(object sender, EventArgs e)
    {
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
    }

    private void btnLeft_Click(object sender, EventArgs e)
    {
    }

    private void btnRight_Click(object sender, EventArgs e)
    {
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
    }

    private void btnSetUnitPreference_Click(object sender, EventArgs e)
    {
      if (cbUnit.SelectedItem != null)
      {
        _api.Settings.SetUnitPreference((UnitPreference) cbUnit.SelectedItem);
      }
    }

    private async void btnGetUnitPreference_Click(object sender, EventArgs e)
    {
      UnitPreference unit = await _api.Settings.GetUnitPreference();
      cbUnit.SelectedItem = unit;
    }

    private async void btnEnableShortCut_Click(object sender, EventArgs e)
    {
      if (cbShortCuts.SelectedItem != null)
      {
        txtShortcutResult.Text =
          (await _api.Shortcuts.EnableShortcut((ShortcutNames) cbShortCuts.SelectedItem)).ToString();
      }
    }

    private async void btnDisableShortCut_Click(object sender, EventArgs e)
    {
      if (cbShortCuts.SelectedItem != null)
      {
        txtShortcutResult.Text =
          (await _api.Shortcuts.DisableShortcut((ShortcutNames) cbShortCuts.SelectedItem)).ToString();
      }
    }


    private void setElevationLevel(double elevationLevel)
    {
      PanoramaViewer.SetElevationSliderLevel(elevationLevel);
    }

    private void cbUseOAuth_CheckedChanged(object sender, EventArgs e)
    {
      _login.UseOAuth = cbUseOAuth.Checked;
    }
  }
}
