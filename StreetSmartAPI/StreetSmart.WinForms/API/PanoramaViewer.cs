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
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Exceptions;
using StreetSmart.WinForms.Interfaces;

using Orientation = StreetSmart.WinForms.Data.Orientation;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewer : IPanoramaViewer
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private readonly IDomElement _domElement;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<IDictionary<string, object>>> ImageChange;
    public event EventHandler<IEventArgs<IRecordingClickInfo>> RecordingClick;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> TileLoadError;
    public event EventHandler<IEventArgs<IOrientation>> ViewChange;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadEnd;
    public event EventHandler<IEventArgs<IDictionary<string, object>>> ViewLoadStart;

    #endregion

    #region Properties

    public string Name { get; }

    #endregion

    #region Constructors

    public PanoramaViewer(ChromiumWebBrowser browser, IDomElement element, IPanoramaViewerOptions options)
    {
      _browser = browser;
      _domElement = element;
      Name = $"pan{Guid.NewGuid().ToString("N")}";

      string script = $@"{element} document.body.appendChild({element.Name});
                      var {Name} = StreetSmartApi.addPanoramaViewer({element.Name}, {options});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.RECORDING_CLICK, onRecordingClick{Name} = function(e)
                      {{ delete e.detail.recording.thumbs; panoramaViewerEvents.onRecordingClick('{Name}', e.detail); }});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.IMAGE_CHANGE, onImageChange{Name} = function(e)
                      {{ panoramaViewerEvents.onImageChange('{Name}', e); }});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.VIEW_CHANGE, onViewChange{Name} = function(e)
                      {{ panoramaViewerEvents.onViewChange('{Name}', e.detail); }});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_START, onViewLoadStart{Name} = function(e)
                      {{ panoramaViewerEvents.onViewLoadStart('{Name}', e); }});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_END, onViewLoadEnd{Name} = function(e)
                      {{ panoramaViewerEvents.onViewLoadEnd('{Name}', e); }});
                      {Name}.on(StreetSmartApi.Events.panoramaViewer.TILE_LOAD_ERROR, onTileLoadError{Name} = function(e)
                      {{ panoramaViewerEvents.onTileLoadError('{Name}', e.detail); }});";

      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetNavbarExpandedAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{Name}', {Name}.getNavbarExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> GetNavbarVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{Name}', {Name}.getNavbarVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<IOrientation> GetOrientationAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"panoramaViewerEvents.onResult('{Name}',{Name}.getOrientation());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return new Orientation((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<IRecording> GetRecordingAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      var script = $@"recording{Name} = {Name}.getRecording(); delete recording{Name}.thumbs;
                   panoramaViewerEvents.onResult('{Name}', recording{Name});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<bool> GetRecordingsVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{Name}', {Name}.getRecordingsVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> GetTimeTravelExpandedAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{Name}', {Name}.getTimeTravelExpanded());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<bool> GetTimeTravelVisibleAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $"panoramaViewerEvents.onResult('{Name}', {Name}.getTimeTravelVisible());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return (bool) _resultTask.Task.Result;
    }

    public async Task<Color> GetViewerColorAsync()
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"panoramaViewerEvents.onResult('{Name}',{Name}.getViewerColor());";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      object[] color = (object[]) _resultTask.Task.Result;
      return Color.FromArgb((int) ((double) color[3]*255), (int) color[0], (int) color[1], (int) color[2]);
    }

    public void LookAtCoordinate(ICoordinate coordinate, string srs = null)
    {
      var script = $"{Name}.lookAtCoordinate({coordinate}{SrsComponent(srs)});";
      _browser.ExecuteScriptAsync(script);
    }

    public async Task<IRecording> OpenByAddressAsync(string query, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"{Name}.openByAddress('{query}'{SrsComponent(srs)}).catch(function(e)
                      {{panoramaViewerEvents.onImageNotFoundException('{Name}', e.message)}}).then
                      (function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{Name}', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception) _resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<IRecording> OpenByCoordinateAsync(ICoordinate coordinate, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      var script = $@"{Name}.openByCoordinate({coordinate}{SrsComponent(srs)}).catch(function(e)
                   {{panoramaViewerEvents.onImageNotFoundException('{Name}', e.message)}}).then
                   (function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{Name}', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception)_resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public async Task<IRecording> OpenByImageIdAsync(string imageId, string srs = null)
    {
      _resultTask = new TaskCompletionSource<object>();
      string script = $@"{Name}.openByImageId('{imageId}'{SrsComponent(srs)}).catch(function(e)
                      {{panoramaViewerEvents.onImageNotFoundException('{Name}', e.message)}}).then
                      (function(r){{delete r.thumbs; panoramaViewerEvents.onResult('{Name}', r)}});";
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;

      if (_resultTask.Task.Result is Exception)
      {
        throw (Exception) _resultTask.Task.Result;
      }

      return new Recording((Dictionary<string, object>) _resultTask.Task.Result);
    }

    public void RotateDown(double deltaPitch)
    {
      var script = $"{Name}.rotateDown({deltaPitch});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateLeft(double deltaYaw)
    {
      var script = $"{Name}.rotateLeft({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateRight(double deltaYaw)
    {
      var script = $"{Name}.rotateRight({deltaYaw});";
      _browser.ExecuteScriptAsync(script);
    }

    public void RotateUp(double deltaPitch)
    {
      var script = $"{Name}.rotateUp({deltaPitch});";
      _browser.ExecuteScriptAsync(script);
    }

    public void SetOrientation(IOrientation orientation)
    {
      string script = $@"{Name}.setOrientation({orientation});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleNavbarExpanded(bool expanded)
    {
      var script = $"{Name}.toggleNavbarExpanded({expanded.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleNavbarVisible(bool visible)
    {
      var script = $"{Name}.toggleNavbarVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleRecordingsVisible(bool visible)
    {
      var script = $"{Name}.toggleRecordingsVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleTimeTravelExpanded(bool expanded)
    {
      var script = $"{Name}.toggleTimeTravelExpanded({expanded.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ToggleTimeTravelVisible(bool visible)
    {
      var script = $"{Name}.toggleTimeTravelVisible({visible.ToString().ToLower()});";
      _browser.ExecuteScriptAsync(script);
    }

    public void ZoomIn()
    {
      string script = $@"{Name}.zoomIn();";
      _browser.ExecuteScriptAsync(script);
    }

    public void ZoomOut()
    {
      string script = $@"{Name}.zoomOut();";
      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnImageChange(Dictionary<string, object> args)
    {
      ImageChange?.Invoke(this, new EventArgs<Dictionary<string, object>>(args));
    }

    public void OnRecordingClick(Dictionary<string, object> args)
    {
      Dictionary<string, object> recording = (Dictionary<string, object>) args["recording"];
      Dictionary<string, object> eventData = (Dictionary<string, object>) args["eventData"];
      RecordingClick?.Invoke(this, new EventArgs<RecordingClickInfo>(new RecordingClickInfo(recording, eventData)));
    }

    public void OnTileLoadError(Dictionary<string, object> args)
    {
      Dictionary<string, object> request = (Dictionary<string, object>) args["request"];
      TileLoadError?.Invoke(this, new EventArgs<Dictionary<string, object>>(request));
    }

    public void OnViewChange(Dictionary<string, object> args)
    {
      Orientation orientation = new Orientation(args);
      ViewChange?.Invoke(this, new EventArgs<Orientation>(orientation));
    }

    public void OnViewLoadEnd(Dictionary<string, object> args)
    {
      ViewLoadEnd?.Invoke(this, new EventArgs<Dictionary<string, object>>(args));
    }

    public void OnViewLoadStart(Dictionary<string, object> args)
    {
      ViewLoadStart?.Invoke(this, new EventArgs<Dictionary<string, object>>(args));
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnResult(object result)
    {
      _resultTask.TrySetResult(result);
    }

    public void OnImageNotFoundException(string message)
    {
      _resultTask.TrySetResult(new StreetSmartImageNotFoundException(message));
    }

    #endregion

    #region Functions with no interface

    public void DestroyPanoramaViewer()
    {
      string script = $@"{Name}.off(StreetSmartApi.Events.panoramaViewer.RECORDING_CLICK, onRecordingClick{Name});
                      {Name}.off(StreetSmartApi.Events.panoramaViewer.IMAGE_CHANGE, onImageChange{Name});
                      {Name}.off(StreetSmartApi.Events.panoramaViewer.VIEW_CHANGE, onViewChange{Name});
                      {Name}.off(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_START, onViewLoadStart{Name});
                      {Name}.off(StreetSmartApi.Events.panoramaViewer.VIEW_LOAD_END, onViewLoadEnd{Name});
                      {Name}.off(StreetSmartApi.Events.panoramaViewer.TILE_LOAD_ERROR, onTileLoadError{Name});
                      StreetSmartApi.destroyPanoramaViewer({Name},{_domElement.Name});";
      _browser.ExecuteScriptAsync(script);
    }

    private string SrsComponent(string srs)
    {
      return (srs == null) ? string.Empty : $", '{srs}'";
    }

    #endregion
  }
}
