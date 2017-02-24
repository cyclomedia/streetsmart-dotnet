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
using StreetSmart.WinForms.Properties;

using Orientation = StreetSmart.WinForms.Data.Orientation;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewer : IPanoramaViewer
  {
    #region Members

    private readonly ChromiumWebBrowser _browser;
    private readonly IDomElement _domElement;
    private readonly PanoramaViewerList _panoramaViewerList;

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

    public string JsThis => _panoramaViewerList.JsThis;

    public string JsResult => _panoramaViewerList.JsResult;

    public string JsImNotFound => _panoramaViewerList.JsImNotFound;

    public string JsImChange => _panoramaViewerList.JsImChange;

    public string JsRecClick => _panoramaViewerList.JsRecClick;

    public string JsTileLoadError => _panoramaViewerList.JsTileLoadError;

    public string JsViewChange => _panoramaViewerList.JsViewChange;

    public string JsViewLoadEnd => _panoramaViewerList.JsViewLoadEnd;

    public string JsViewLoadStart => _panoramaViewerList.JsViewLoadStart;

    #endregion

    #region Constructors

    public PanoramaViewer(ChromiumWebBrowser browser, IDomElement element, IPanoramaViewerOptions options,
      PanoramaViewerList panoramaViewerList)
    {
      _browser = browser;
      _domElement = element;
      _panoramaViewerList = panoramaViewerList;
      Name = $"pan{Guid.NewGuid().ToString("N")}";

      string script =
        $@"{element}document.body.appendChild({element.Name});
        var {Name}={Resources.JsApi}.addPanoramaViewer({element.Name},{options});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.RECORDING_CLICK,{JsRecClick}{Name}=
        function(e){{delete e.detail.recording.thumbs;{JsThis}.{JsRecClick}('{Name}',e.detail);}});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.IMAGE_CHANGE,{JsImChange}{Name}=
        function(e){{{JsThis}.{JsImChange}('{Name}',e);}});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.VIEW_CHANGE,{JsViewChange}{Name}=
        function(e){{{JsThis}.{JsViewChange}('{Name}',e.detail);}});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.VIEW_LOAD_START,{JsViewLoadStart}{Name}=
        function(e){{{JsThis}.{JsViewLoadStart}('{Name}',e);}});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.VIEW_LOAD_END,{JsViewLoadEnd}{Name}=
        function(e){{{JsThis}.{JsViewLoadEnd}('{Name}',e);}});
        {Name}.on({Resources.JsApi}.Events.panoramaViewer.TILE_LOAD_ERROR,{JsTileLoadError}{Name}=
        function(e){{{JsThis}.{JsTileLoadError}('{Name}',e.detail);}});";
      _browser.ExecuteScriptAsync(script);
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetNavbarExpandedAsync()
    {
      return (bool) await CallJsAsync(GetScript("getNavbarExpanded()"));
    }

    public async Task<bool> GetNavbarVisibleAsync()
    {
      return (bool) await CallJsAsync(GetScript("getNavbarVisible()"));
    }

    public async Task<IOrientation> GetOrientationAsync()
    {
      return new Orientation((Dictionary<string, object>) await CallJsAsync(GetScript("getOrientation()")));
    }

    public async Task<IRecording> GetRecordingAsync()
    {
      var script = $@"recording{Name}={Name}.getRecording();delete recording{Name}.thumbs;
                   {JsThis}.{JsResult}('{Name}',recording{Name});";
      return new Recording((Dictionary<string, object>) await CallJsAsync(script));
    }

    public async Task<bool> GetRecordingsVisibleAsync()
    {
      return (bool) await CallJsAsync(GetScript("getRecordingsVisible()"));
    }

    public async Task<bool> GetTimeTravelExpandedAsync()
    {
      return (bool) await CallJsAsync(GetScript("getTimeTravelExpanded()"));
    }

    public async Task<bool> GetTimeTravelVisibleAsync()
    {
      return (bool) await CallJsAsync(GetScript("getTimeTravelVisible()"));
    }

    public async Task<Color> GetViewerColorAsync()
    {
      return GetColor((object[]) await CallJsAsync(GetScript("getViewerColor()")));
    }

    public void LookAtCoordinate(ICoordinate coordinate, string srs = null)
    {
      _browser.ExecuteScriptAsync($"{Name}.lookAtCoordinate({coordinate}{SrsComponent(srs)});");
    }

    public async Task<IRecording> OpenByAddressAsync(string query, string srs = null)
    {
      return await SearchRecordingAsync("openByAddress", query, srs);
    }

    public async Task<IRecording> OpenByCoordinateAsync(ICoordinate coordinate, string srs = null)
    {
      return await SearchRecordingAsync("openByCoordinate", coordinate.ToString(), srs);
    }

    public async Task<IRecording> OpenByImageIdAsync(string imageId, string srs = null)
    {
      return await SearchRecordingAsync("openByImageId", imageId, srs);
    }

    public void RotateDown(double deltaPitch)
    {
      _browser.ExecuteScriptAsync($"{Name}.rotateDown({deltaPitch});");
    }

    public void RotateLeft(double deltaYaw)
    {
      _browser.ExecuteScriptAsync($"{Name}.rotateLeft({deltaYaw});");
    }

    public void RotateRight(double deltaYaw)
    {
      _browser.ExecuteScriptAsync($"{Name}.rotateRight({deltaYaw});");
    }

    public void RotateUp(double deltaPitch)
    {
      _browser.ExecuteScriptAsync($"{Name}.rotateUp({deltaPitch});");
    }

    public void SetOrientation(IOrientation orientation)
    {
      _browser.ExecuteScriptAsync($"{Name}.setOrientation({orientation});");
    }

    public void ToggleNavbarExpanded(bool expanded)
    {
      _browser.ExecuteScriptAsync($"{Name}.toggleNavbarExpanded({expanded.ToJsBool()});");
    }

    public void ToggleNavbarVisible(bool visible)
    {
      _browser.ExecuteScriptAsync($"{Name}.toggleNavbarVisible({visible.ToJsBool()});");
    }

    public void ToggleRecordingsVisible(bool visible)
    {
      _browser.ExecuteScriptAsync($"{Name}.toggleRecordingsVisible({visible.ToJsBool()});");
    }

    public void ToggleTimeTravelExpanded(bool expanded)
    {
      _browser.ExecuteScriptAsync($"{Name}.toggleTimeTravelExpanded({expanded.ToJsBool()});");
    }

    public void ToggleTimeTravelVisible(bool visible)
    {
      _browser.ExecuteScriptAsync($"{Name}.toggleTimeTravelVisible({visible.ToJsBool()});");
    }

    public void ZoomIn()
    {
      _browser.ExecuteScriptAsync($"{Name}.zoomIn();");
    }

    public void ZoomOut()
    {
      _browser.ExecuteScriptAsync($"{Name}.zoomOut();");
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
      TileLoadError?.Invoke(this, new EventArgs<Dictionary<string, object>>
        ((Dictionary<string, object>) args["request"]));
    }

    public void OnViewChange(Dictionary<string, object> args)
    {
      ViewChange?.Invoke(this, new EventArgs<Orientation>(new Orientation(args)));
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
      string script =
        $@"{Name}.off({Resources.JsApi}.Events.panoramaViewer.RECORDING_CLICK,{JsRecClick}{Name});
        {Name}.off({Resources.JsApi}.Events.panoramaViewer.IMAGE_CHANGE,{JsImChange}{Name});
        {Name}.off({Resources.JsApi}.Events.panoramaViewer.VIEW_CHANGE,{JsViewChange}{Name});
        {Name}.off({Resources.JsApi}.Events.panoramaViewer.VIEW_LOAD_START,{JsViewLoadStart}{Name});
        {Name}.off({Resources.JsApi}.Events.panoramaViewer.VIEW_LOAD_END,{JsViewLoadEnd}{Name});
        {Name}.off({Resources.JsApi}.Events.panoramaViewer.TILE_LOAD_ERROR,{JsTileLoadError}{Name});
        {Resources.JsApi}.destroyPanoramaViewer({Name},{_domElement.Name});";
      _browser.ExecuteScriptAsync(script);
    }

    private string SrsComponent(string srs)
    {
      return (srs == null) ? string.Empty : $", '{srs}'";
    }

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    private string GetScript(string funcName)
    {
      return $"{JsThis}.{JsResult}('{Name}',{Name}.{funcName});";
    }

    private Color GetColor(object[] color)
    {
      return Color.FromArgb((int) ((double) color[3]*255), (int) color[0], (int) color[1], (int) color[2]);
    }

    public async Task<IRecording> SearchRecordingAsync(string func, string query, string srs = null)
    {
      string script = $@"{Name}.{func}('{query}'{SrsComponent(srs)}).catch
                      (function(e){{{JsThis}.{JsImNotFound}('{Name}',e.message)}}).then
                      (function(r){{delete r.thumbs;{JsThis}.{JsResult}('{Name}',r)}});";
      object result = await CallJsAsync(script);

      if (result is Exception)
      {
        throw (Exception) result;
      }

      return new Recording((Dictionary<string, object>) result);
    }

    #endregion
  }
}
