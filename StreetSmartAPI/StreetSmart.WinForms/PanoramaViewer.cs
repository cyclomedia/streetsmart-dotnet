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

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<IDictionary<string, object>>> ImageChange;
    public event EventHandler<EventRecordingClickArgs> RecordingClick;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> TileLoadError;
    public event EventHandler<EventViewChangeArgs> ViewChange;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadEnd;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadStart;

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
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{ViewerObjectName}', {ViewerObjectName}.getNavbarExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> getNavbarVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{ViewerObjectName}', {ViewerObjectName}.getNavbarVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<Orientation> GetOrientationAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"panoramaViewerEvents.onResult('{ViewerObjectName}',{ViewerObjectName}.getOrientation());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return new Orientation((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<Recording> GetRecordingAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      var script = $@"recording{ViewerObjectName} = {ViewerObjectName}.getRecording();
                      delete recording{ViewerObjectName}.thumbs;
                      panoramaViewerEvents.onResult('{ViewerObjectName}', recording{ViewerObjectName});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<bool> GetRecordingsVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{ViewerObjectName}', {ViewerObjectName}.getRecordingsVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> getTimeTravelExpandedAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script =
        $"panoramaViewerEvents.onResult('{ViewerObjectName}', {ViewerObjectName}.getTimeTravelExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> getTimeTravelVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{ViewerObjectName}', {ViewerObjectName}.getTimeTravelVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<Color> GetViewerColorAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"panoramaViewerEvents.onResult('{ViewerObjectName}',{ViewerObjectName}.getViewerColor());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      object[] color = (object[]) _resultTask.Task.Result;
      return Color.FromArgb((int) ((double) color[3]*255), (int) color[0], (int) color[1], (int) color[2]);
    }

    public void LookAtCoordinate(Coordinate coordinate, string srs = null)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double) coordinate.Z).ToString(ci)}";
      string srsComponent = (srs == null) ? string.Empty : $", '{srs}'";
      var script =
        $"{ViewerObjectName}.lookAtCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}]{srsComponent});";
      _browser.ExecuteScriptAsync(script);
    }

    public async Task<Recording> OpenByAddressAsync(string query, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      string srsComponent = (srs == null) ? string.Empty : $", '{srs}'";
      string script =
        $@"{ViewerObjectName}.openByAddress('{query}'{srsComponent}).catch(function(e){{panoramaViewerEvents.onError('{
          ViewerObjectName}', e.message)}}).then(function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{
          ViewerObjectName}', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception) _resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<Recording> OpenByCoordinateAsync(Coordinate coordinate, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = (coordinate.Z == null) ? string.Empty : $", {((double) coordinate.Z).ToString(ci)}";
      string srsComponent = (srs == null) ? string.Empty : $", '{srs}'";
      var script =
        $@"{ViewerObjectName}.openByCoordinate([{coordinate.X.ToString(ci)}, {coordinate.Y.ToString(ci)}{zComponent}]{
          srsComponent}).catch(function(e){{panoramaViewerEvents.onError('{ViewerObjectName
          }', e.message)}}).then(function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{ViewerObjectName
          }', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception)_resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<Recording> OpenByImageIdAsync(string imageId, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      string srsComponent = (srs == null) ? string.Empty : $", '{srs}'";
      string script =
        $@"{ViewerObjectName}.openByImageId('{imageId}'{srsComponent
          }).catch(function(e){{panoramaViewerEvents.onError('{ViewerObjectName
          }', e.message)}}).then(function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{ViewerObjectName
          }', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception)_resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
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
      ImageChange?.Invoke(this, new EventArgs<IDictionary<string, object>>(args));
    }

    public void OnRecordingClick(Dictionary<string, object> args)
    {
      Dictionary<string, object> recording = (Dictionary<string, object>)args["recording"];
      Dictionary<string, object> eventData = (Dictionary<string, object>)args["eventData"];

      RecordingClick?.Invoke(this, new EventRecordingClickArgs
      {
        Recording = new Recording(recording),
        shiftKey = (bool) eventData["shiftKey"],
        altKey = (bool) eventData["altKey"],
        ctrlKey = (bool) eventData["ctrlKey"]
      });
    }

    public void OnTileLoadError(Dictionary<string, object> args)
    {
      Dictionary<string, object> request = (Dictionary<string, object>) args["request"];
      TileLoadError?.Invoke(this, new EventArgs<Dictionary<string, object>>(request));
    }

    public void OnViewChange(Dictionary<string, object> args)
    {
      Orientation orientation = new Orientation(args);
      ViewChange?.Invoke(this, new EventViewChangeArgs {Orientation = orientation});
    }

    public void OnViewLoadEnd(Dictionary<string, object> args)
    {
      ViewLoadEnd?.Invoke(this, new EventArgs<IDictionary<string, object>>(args));
    }

    public void OnViewLoadStart(Dictionary<string, object> args)
    {
      ViewLoadStart?.Invoke(this, new EventArgs<IDictionary<string, object>>(args));
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnResult(object result)
    {
      _resultTask.TrySetResult(result);
    }

    public void OnError(string message)
    {
      _resultTask.TrySetResult(new StreetSmartAPIException(message));
    }

    #endregion
  }
}
