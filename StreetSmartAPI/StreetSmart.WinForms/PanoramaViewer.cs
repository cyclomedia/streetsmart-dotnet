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

using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Events;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;

namespace StreetSmart.WinForms
{
  internal class PanoramaViewer : IPanoramaViewer
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;

    #endregion

    #region Tasks

    private TaskCompletionSource<object[]> _viewerColorTask;
    private TaskCompletionSource<Dictionary<string, object>> _orientationTask;
    private TaskCompletionSource<Dictionary<string, object>> _recordingTask;
    private TaskCompletionSource<bool> _recordingsVisibleTask;
    private TaskCompletionSource<bool> _navbarVisibleTask;
    private TaskCompletionSource<bool> _navbarExpandedTask;
    private TaskCompletionSource<bool> _timeTravelVisibleTask;
    private TaskCompletionSource<bool> _timeTravelExpandedTask;

    #endregion

    #region Events

    public event EventHandler<EventViewerArgs> ImageChange;
    public event EventHandler<EventRecordingClickArgs> RecordingClick;
    public event EventHandler<EventTileLoadErrorArgs> TileLoadError;
    public event EventHandler<EventViewChangeArgs> ViewChange;
    public event EventHandler<EventViewerArgs> ViewLoadEnd;
    public event EventHandler<EventViewerArgs> ViewLoadStart;
    public event EventHandler<EventOpenImageErrorArgs> OpenImageError;

    #endregion

    #region Properties

    public string ViewerObjectName { get; }

    public string DomElementName { get; }

    #endregion

    #region Constructors

    public PanoramaViewer(ChromiumWebBrowser browser, string viewerObjectName)
    {
      _browser = browser;
      ViewerObjectName = viewerObjectName;
      DomElementName = $@"dom{ViewerObjectName}Element";
      string script =
        $@"var {DomElementName} = document.createElement('div');
           {DomElementName}.setAttribute('id', 'panorama{ViewerObjectName}Window');
           {DomElementName}.setAttribute('style', 'width:100%; height:100%;');
           document.body.appendChild({DomElementName});
           var {ViewerObjectName} = StreetSmartApi.addPanoramaViewer({DomElementName});";
      _browser.ExecuteScriptAsync(script);
    }

    public PanoramaViewer(ChromiumWebBrowser browser, string viewerObjectName, bool recordingsVisible,
      bool timeTravelEnabled)
    {
      _browser = browser;
      ViewerObjectName = viewerObjectName;
      DomElementName = $@"dom{ViewerObjectName}Element";
      string script =
        $@"var {DomElementName} = document.createElement('div');
           {DomElementName}.setAttribute('id', 'panorama{ViewerObjectName}Window');
           {DomElementName}.setAttribute('style', 'width:100%; height:100%;')
           document.body.appendChild({DomElementName});
           var {ViewerObjectName} = StreetSmartApi.addPanoramaViewer({DomElementName},
           {{recordingsVisible: {recordingsVisible.ToString().ToLower()},
           timeTravelEnabled: {timeTravelEnabled.ToString().ToLower()}}});";
      _browser.ExecuteScriptAsync(script);
    }

    public PanoramaViewer(ChromiumWebBrowser browser, string viewerObjectName, string domElementName,
      string domElementScript)
    {
      _browser = browser;
      ViewerObjectName = viewerObjectName;
      DomElementName = domElementName;
      string script =
        $@"{domElementScript}
           document.body.appendChild({DomElementName});
           var {ViewerObjectName} = StreetSmartApi.addPanoramaViewer({DomElementName});";
      _browser.ExecuteScriptAsync(script);
    }

    public PanoramaViewer(ChromiumWebBrowser browser, string viewerObjectName, bool recordingsVisible,
      bool timeTravelEnabled, string domElementName, string domElementScript)
    {
      _browser = browser;
      ViewerObjectName = viewerObjectName;
      DomElementName = domElementName;
      string script =
        $@"{domElementScript}
           document.body.appendChild({DomElementName});
           var {ViewerObjectName} = StreetSmartApi.addPanoramaViewer({DomElementName},
           {{recordingsVisible: {recordingsVisible.ToString().ToLower()},
           timeTravelEnabled: {timeTravelEnabled.ToString().ToLower()}}});";
      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Functions

    public async Task<bool> getNavbarExpandedAsync()
    {
      _navbarExpandedTask = new TaskCompletionSource<bool>();
      string script =
        $"panoramaViewerEvents.onNavbarExpanded('{ViewerObjectName}', {ViewerObjectName}.getNavbarExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _navbarExpandedTask.Task;
      return _navbarExpandedTask.Task.Result;
    }

    public async Task<bool> getNavbarVisibleAsync()
    {
      _navbarVisibleTask = new TaskCompletionSource<bool>();
      string script =
        $"panoramaViewerEvents.onNavbarVisible('{ViewerObjectName}', {ViewerObjectName}.getNavbarVisible());";
      _browser.ExecuteScriptAsync(script);
      await _navbarVisibleTask.Task;
      return _navbarVisibleTask.Task.Result;
    }

    public async Task<Orientation> GetOrientationAsync()
    {
      _orientationTask = new TaskCompletionSource<Dictionary<string, object>>();
      string script = $@"panoramaViewerEvents.onOrientation('{ViewerObjectName}',{ViewerObjectName}.getOrientation());";
      _browser.ExecuteScriptAsync(script);
      await _orientationTask.Task;
      Dictionary<string, object> orientation = _orientationTask.Task.Result;
      return CreateOrientation(orientation);
    }

    public async Task<Recording> GetRecordingAsync()
    {
      _recordingTask = new TaskCompletionSource<Dictionary<string, object>>();
      var script = $@"recording{ViewerObjectName} = {ViewerObjectName}.getRecording();
                      delete recording{ViewerObjectName}.thumbs;
                      panoramaViewerEvents.onRecording('{ViewerObjectName}', recording{ViewerObjectName});";
      _browser.ExecuteScriptAsync(script);
      await _recordingTask.Task;
      Dictionary<string, object> recording = _recordingTask.Task.Result;
      return CreateRecording(recording);
    }

    public async Task<bool> GetRecordingsVisibleAsync()
    {
      _recordingsVisibleTask = new TaskCompletionSource<bool>();
      string script =
        $"panoramaViewerEvents.onRecordingsVisible('{ViewerObjectName}', {ViewerObjectName}.getRecordingsVisible());";
      _browser.ExecuteScriptAsync(script);
      await _recordingsVisibleTask.Task;
      return _recordingsVisibleTask.Task.Result;
    }

    public async Task<bool> getTimeTravelExpandedAsync()
    {
      _timeTravelExpandedTask = new TaskCompletionSource<bool>();
      string script =
        $"panoramaViewerEvents.onTimeTravelExpanded('{ViewerObjectName}', {ViewerObjectName}.getTimeTravelExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _timeTravelExpandedTask.Task;
      return _timeTravelExpandedTask.Task.Result;
    }

    public async Task<bool> getTimeTravelVisibleAsync()
    {
      _timeTravelVisibleTask = new TaskCompletionSource<bool>();
      string script =
        $"panoramaViewerEvents.onTimeTravelVisible('{ViewerObjectName}', {ViewerObjectName}.getTimeTravelVisible());";
      _browser.ExecuteScriptAsync(script);
      await _timeTravelVisibleTask.Task;
      return _timeTravelVisibleTask.Task.Result;
    }

    public async Task<Color> GetViewerColorAsync()
    {
      _viewerColorTask = new TaskCompletionSource<object[]>();
      string script = $@"panoramaViewerEvents.onViewerColor('{ViewerObjectName}',{ViewerObjectName}.getViewerColor());";
      _browser.ExecuteScriptAsync(script);
      await _viewerColorTask.Task;
      object[] color = _viewerColorTask.Task.Result;
      return Color.FromArgb((int)((double)color[3] * 255), (int)color[0], (int)color[1], (int)color[2]);
    }

    public void LookAtCoordinate(Coordinate coordinate)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double)coordinate.Z).ToString(ci)}";
      var script =
        $"{ViewerObjectName}.lookAtCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}]);";
      _browser.ExecuteScriptAsync(script);
    }

    public void LookAtCoordinate(Coordinate coordinate, string srs)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double)coordinate.Z).ToString(ci)}";
      var script =
        $"{ViewerObjectName}.lookAtCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}], '{srs}');";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByAddress(string query)
    {
      string script =
        $@"{ViewerObjectName}.openByAddress('{query}').catch(function(e)
           {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByAddress(string query, string srs)
    {
      string script =
        $@"{ViewerObjectName}.openByAddress('{query}', '{srs}').catch(function(e)
         {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByCoordinate(Coordinate coordinate)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double)coordinate.Z).ToString(ci)}";
      string script =
        $@"{ViewerObjectName}.openByCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}]).catch(function(e)
           {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByCoordinate(Coordinate coordinate, string srs)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double)coordinate.Z).ToString(ci)}";
      var script =
        $@"{ViewerObjectName}.openByCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}], '{srs}').catch(function(e)
           {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByImageId(string imageId)
    {
      string script =
        $@"{ViewerObjectName}.openByImageId('{imageId}').catch(function(e)
           {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void OpenByImageId(string imageId, string srs)
    {
      string script =
        $@"{ViewerObjectName}.openByImageId('{imageId}', '{srs}').catch(function(e)
           {{panoramaViewerEvents.onOpenImageError('{ViewerObjectName}', e.message)}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateDown(double deltaPitch)
    {
      var script = $"{ViewerObjectName}.rotateDown({deltaPitch});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateLeft(double deltaYaw)
    {
      var script = $"{ViewerObjectName}.rotateLeft({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateRight(double deltaYaw)
    {
      var script = $"{ViewerObjectName}.rotateRight({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateUp(double deltaPitch)
    {
      var script = $"{ViewerObjectName}.rotateUp({deltaPitch});";
      _browser.ExecuteScriptAsync(script);
    }

    public void SetOrientation(Orientation orientation)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string partYaw = (orientation.Yaw == null) ? string.Empty : $"yaw:{((double) orientation.Yaw).ToString(ci)}";
      string partPitch = partYaw + ((orientation.Pitch == null) ? string.Empty
        : string.Concat((string.IsNullOrEmpty(partYaw) ? string.Empty : ","),
          $"pitch:{((double) orientation.Pitch).ToString(ci)}"));
      string parthFov = partPitch + ((orientation.hFov == null) ? string.Empty
        : string.Concat((string.IsNullOrEmpty(partPitch) ? string.Empty : ","),
          $"hFov:{((double) orientation.hFov).ToString(ci)}"));
      string script = $@"{ViewerObjectName}.setOrientation({{{parthFov}}});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleNavbarExpanded(bool expanded)
    {
      var script = $"{ViewerObjectName}.toggleNavbarExpanded({expanded.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleNavbarVisible(bool visible)
    {
      var script = $"{ViewerObjectName}.toggleNavbarVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleRecordingsVisible(bool visible)
    {
      var script = $"{ViewerObjectName}.toggleRecordingsVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleTimeTravelExpanded(bool expanded)
    {
      var script = $"{ViewerObjectName}.toggleTimeTravelExpanded({expanded.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleTimeTravelVisible(bool visible)
    {
      var script = $"{ViewerObjectName}.toggleTimeTravelVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ZoomIn()
    {
      string script = $@"{ViewerObjectName}.zoomIn();";
      _browser.ExecuteScriptAsync(script);
    }

    public void ZoomOut()
    {
      string script = $@"{ViewerObjectName}.zoomOut();";
      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnImageChange(Dictionary<string, object> args)
    {
      ImageChange?.Invoke(this, new EventViewerArgs { ViewerArgs = args });
    }

    public void OnRecordingClick(Dictionary<string, object> args)
    {
      Dictionary<string, object> recording = (Dictionary<string, object>)args["recording"];
      Dictionary<string, object> eventData = (Dictionary<string, object>)args["eventData"];

      RecordingClick?.Invoke(this, new EventRecordingClickArgs
      {
        Recording = CreateRecording(recording),
        shiftKey = (bool) eventData["shiftKey"],
        altKey = (bool) eventData["altKey"],
        ctrlKey = (bool) eventData["ctrlKey"]
      });
    }

    public void OnTileLoadError(Dictionary<string, object> args)
    {
      Dictionary<string, object> request = (Dictionary<string, object>) args["request"];
      TileLoadError?.Invoke(this, new EventTileLoadErrorArgs { Request = request });
    }

    public void OnViewChange(Dictionary<string, object> args)
    {
      Orientation orientation = CreateOrientation(args);
      ViewChange?.Invoke(this, new EventViewChangeArgs {Orientation = orientation});
    }

    public void OnViewLoadEnd(Dictionary<string, object> args)
    {
      ViewLoadEnd?.Invoke(this, new EventViewerArgs { ViewerArgs = args });
    }

    public void OnViewLoadStart(Dictionary<string, object> args)
    {
      ViewLoadStart?.Invoke(this, new EventViewerArgs { ViewerArgs = args });
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnNavbarExpanded(bool expanded)
    {
      _navbarExpandedTask.TrySetResult(expanded);
    }

    public void OnNavbarVisible(bool visible)
    {
      _navbarVisibleTask.TrySetResult(visible);
    }

    public void OnOpenImageError(string message)
    {
      OpenImageError?.Invoke(this, new EventOpenImageErrorArgs { Message = message });
    }

    public void OnOrientation(Dictionary<string, object> orientation)
    {
      _orientationTask.TrySetResult(orientation);
    }

    public void OnRecording(Dictionary<string, object> recording)
    {
      _recordingTask.TrySetResult(recording);
    }

    public void OnRecordingsVisible(bool visible)
    {
      _recordingsVisibleTask.TrySetResult(visible);
    }

    public void OnTimeTravelExpanded(bool expanded)
    {
      _timeTravelExpandedTask.TrySetResult(expanded);
    }

    public void OnTimeTravelVisible(bool visible)
    {
      _timeTravelVisibleTask.TrySetResult(visible);
    }

    public void OnViewerColor(object[] color)
    {
      _viewerColorTask.TrySetResult(color);
    }

    #endregion

    #region private functions

    private Orientation CreateOrientation(Dictionary<string, object> orientation)
    {
      return new Orientation
      {
        Yaw = double.Parse(orientation["yaw"].ToString()),
        Pitch = double.Parse(orientation["pitch"].ToString()),
        hFov = double.Parse(orientation["hFov"].ToString())
      };
    }

    private Recording CreateRecording(Dictionary<string, object> recording)
    {
      Dictionary<string, object> xyz = (Dictionary<string, object>)recording["xyz"];

      Coordinate coordinate = new Coordinate
      {
        X = (double)xyz["0"],
        Y = (double)xyz["1"],
        Z = (double)xyz["2"]
      };

      return new Recording
      {
        GroundLevelOffset = (double?) recording["groundLevelOffset"],
        RecorderDirection = (double?) recording["recorderDirection"],
        Orientation = (double?) recording["orientation"],
        RecordedAt = (DateTime?) recording["recordedAt"],
        Id = (string) recording["id"],
        XYZ = coordinate,
        SRS = (string) recording["srs"],
        OrientationPrecision = (double?) recording["orientationPrecision"],
        TileSchema = (TileSchema) Enum.Parse(typeof (TileSchema), (string) recording["tileSchema"]),
        LongitudePrecision = (double?) recording["longitudePrecision"],
        LatitudePrecision = (double?) recording["latitudePrecision"],
        HeightPrecision = (double?) recording["heightPrecision"],
        ProductType = (ProductType) Enum.Parse(typeof (ProductType), (string) recording["productType"]),
        HeightSystem = (string) recording["heightSystem"],
        ExpiredAt = (DateTime?) recording["expiredAt"]
      };
    }

    #endregion
  }
}
