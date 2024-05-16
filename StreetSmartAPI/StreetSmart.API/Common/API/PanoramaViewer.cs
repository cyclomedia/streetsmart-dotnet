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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

using StreetSmart.Common.Data;
using StreetSmart.Common.Events;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

using StreetSmart.Common.API.Events;

using Orientation = StreetSmart.Common.Data.Orientation;

namespace StreetSmart.Common.API
{
    public sealed class PanoramaViewer : ImageViewer, IPanoramaViewer
    {
        #region Members

        private ApiEventList _panoramaViewerEventList;

        #endregion

        #region Events

        public event EventHandler<IEventArgs<IElevationInfo>> ElevationChange;
        public event EventHandler<EventArgs> ImageChange;
        public event EventHandler<IEventArgs<IRecordingClickInfo>> RecordingClick;
        public event EventHandler<IEventArgs<IFeatureInfo>> FeatureClick;
        public event EventHandler<IEventArgs<IFeatureInfo>> FeatureSelectionChange;
        public event EventHandler<IEventArgs<IDepthInfo>> SurfaceCursorChange;
        public event EventHandler<IEventArgs<IDictionary<string, object>>> TileLoadError;
        public event EventHandler<IEventArgs<ITimeTravelInfo>> TimeTravelChange;
        public event EventHandler<IEventArgs<IOrientation>> ViewChange;
        public event EventHandler<EventArgs> ViewLoadEnd;

        #endregion

        #region Callback definitions

        public string JsElevationChange => (ViewerList as PanoramaViewerList)?.JsElevationChange;

        public string JsImChange => (ViewerList as PanoramaViewerList)?.JsImChange;

        public string JsSurfaceCursorChange => (ViewerList as PanoramaViewerList)?.JsSurfaceCursorChange;

        public string JsRecClick => (ViewerList as PanoramaViewerList)?.JsRecClick;

        public string JsFeatureClick => (ViewerList as PanoramaViewerList)?.JsFeatureClick;

        public string JsTileLoadError => (ViewerList as PanoramaViewerList)?.JsTileLoadError;

        public string JsViewChange => (ViewerList as PanoramaViewerList)?.JsViewChange;

        public string JsViewLoadEnd => (ViewerList as PanoramaViewerList)?.JsViewLoadEnd;

        public string JsTimeTravelChange => (ViewerList as PanoramaViewerList)?.JsTimeTravelChange;

        public string JsFeatureSelectionChange => (ViewerList as PanoramaViewerList)?.JsFeatureSelectionChange;

        #endregion

        #region Properties

        public override string DisconnectEventsScript => $"{_panoramaViewerEventList.Destroy}{base.DisconnectEventsScript}";

        public override string ConnectEventsScript => $"{_panoramaViewerEventList}{base.ConnectEventsScript}";

        #endregion

        #region Constructors

        public PanoramaViewer(IStreetSmartBrowser browser, PanoramaViewerList panoramaViewerList, string name)
          : base(browser, panoramaViewerList)
        {
            Name = name;
            ConnectEvents();
        }

        #endregion

        #region Interface Functions

        public async Task<bool> Get3DCursorVisible()
        {
            return ToBool(await CallJsGetScriptAsync("get3DCursorVisible()"));
        }

        public async Task<bool> GetButtonEnabled(PanoramaViewerButtons buttonId)
        {
            return await base.GetButtonEnabled(buttonId);
        }

        public async Task<bool> GetSidebarVisible()
        {
            return ToBool(await CallJsGetScriptAsync("getSidebarVisible()"));
        }

        public async Task<bool> GetSidebarEnabled()
        {
            return ToBool(await CallJsGetScriptAsync("getSidebarEnabled()"));
        }

        public async Task<bool> GetSidebarExpanded()
        {
            return ToBool(await CallJsGetScriptAsync("getSidebarExpanded()"));
        }

        public async Task<IOrientation> GetOrientation()
        {
            return new Orientation(ToDictionary(await CallJsGetScriptAsync("getOrientation()")));
        }

        public async Task<IRecording> GetRecording()
        {
            int processId = GetProcessId;
            string funcId = $"{nameof(GetRecording)}{processId}".ToQuote();
            var script = $@"recording{Name}={Name}.getRecording();delete recording{Name}.thumbs;
                   {JsThis}.{JsResult}('{Name}',recording{Name},{funcId});";
            return new Recording(ToDictionary(await CallJsAsync(script, processId)));
        }

        public async Task<bool> GetRecordingsVisible()
        {
            return ToBool(await CallJsGetScriptAsync("getRecordingsVisible()"));
        }

        public async Task<Color> GetViewerColor()
        {
            return GetColor(ToArray(await CallJsGetScriptAsync("getViewerColor()")));
        }

        public async Task LookAtCoordinate(ICoordinate coordinate, string srs = null)
        {
            await CallJsGetScriptAsync($"lookAtCoordinate({coordinate}{srs.SrsComponent()})");
        }

        public async Task<IRecording> OpenByAddress(string query, string srs = null)
        {
            return await SearchRecordingAsync("openByAddress", query.ToQuote(), srs);
        }

        public async Task<IRecording> OpenByCoordinate(ICoordinate coordinate, string srs = null)
        {
            return await SearchRecordingAsync("openByCoordinate", coordinate.ToString(), srs);
        }

        public async Task<IRecording> OpenByImageId(string imageId, string srs = null)
        {
            return await SearchRecordingAsync("openByImageId", imageId.ToQuote(), srs);
        }

        public void RotateDown(double deltaPitch)
        {
            Browser.ExecuteScriptAsync($"{Name}.rotateDown({deltaPitch.ToString(ci)});");
        }

        public void RotateLeft(double deltaYaw)
        {
            Browser.ExecuteScriptAsync($"{Name}.rotateLeft({deltaYaw.ToString(ci)});");
        }

        public void RotateRight(double deltaYaw)
        {
            Browser.ExecuteScriptAsync($"{Name}.rotateRight({deltaYaw.ToString(ci)});");
        }

        public void RotateUp(double deltaPitch)
        {
            Browser.ExecuteScriptAsync($"{Name}.rotateUp({deltaPitch.ToString(ci)});");
        }

        public void SetElevationSliderLevel(double elevationLevel)
        {
            Browser.ExecuteScriptAsync($"{Name}.setElevationSliderLevel({elevationLevel.ToString(ci)});");
        }

        public void SetOrientation(IOrientation orientation)
        {
            Browser.ExecuteScriptAsync($"{Name}.setOrientation({orientation});");
        }

        public void ShowAttributePanelOnFeatureClick()
        {
            Browser.ExecuteScriptAsync($"{Name}.showAttributePanelOnFeatureClick();");
        }

        public void ShowAttributePanelOnFeatureClick(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.showAttributePanelOnFeatureClick({visible.ToJsBool()});");
        }

        public void Toggle3DCursor(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggle3DCursor({visible.ToJsBool()});");
        }

        public void ToggleLinkedViewers()
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleLinkedViewers();");
        }

        public void ToggleAddressesVisible(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleAddressesVisible({visible.ToJsBool()});");
        }

        public void ToggleButtonEnabled(PanoramaViewerButtons buttonId, bool enabled)
        {
            base.ToggleButtonEnabled(buttonId, enabled);
        }

        public void ToggleRecordingsVisible(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleRecordingsVisible({visible.ToJsBool()});");
        }

        public void ToggleSidebarExpanded(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleSidebarExpanded({visible.ToJsBool()});");
        }

        public void ToggleSidebarVisible(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleSidebarVisible({visible.ToJsBool()});");
        }

        public void ToggleSidebarEnabled(bool visible)
        {
            Browser.ExecuteScriptAsync($"{Name}.toggleSidebarEnabled({visible.ToJsBool()});");
        }

        #endregion

        #region Events from StreetSmartAPI

        public void OnElevationChange(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            ElevationChange?.Invoke(this, new EventArgs<ElevationInfo>(new ElevationInfo(detail)));
        }

        public void OnImageChange(ExpandoObject args)
        {
            ImageChange?.Invoke(this, EventArgs.Empty);
        }

        public void OnRecordingClick(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            Dictionary<string, object> recording = GetDictValue(detail, "recording");
            Dictionary<string, object> eventData = GetDictValue(detail, "eventData");
            RecordingClick?.Invoke(this, new EventArgs<RecordingClickInfo>(new RecordingClickInfo(recording, eventData)));
        }

        public void OnFeatureClick(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            FeatureClick?.Invoke(this, new EventArgs<IFeatureInfo>(new FeatureInfo(detail)));
        }

        public void OnTileLoadError(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            TileLoadError?.Invoke(this, new EventArgs<Dictionary<string, object>>
              (GetDictValue(detail, "request")));
        }

        public void OnViewChange(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            ViewChange?.Invoke(this, new EventArgs<Orientation>(new Orientation(detail)));
        }

        public void OnSurfaceCursorChange(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            SurfaceCursorChange?.Invoke(this, new EventArgs<IDepthInfo>(new DepthInfo(detail)));
        }

        public void OnViewLoadEnd(ExpandoObject args)
        {
            ViewLoadEnd?.Invoke(this, EventArgs.Empty);
        }

        public void OnTimeTravelChange(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            TimeTravelChange?.Invoke(this, new EventArgs<ITimeTravelInfo>(new TimeTravelInfo(detail)));
        }

        public void OnFeatureSelectionChange(ExpandoObject args)
        {
            Dictionary<string, object> detail = GetDictValue(args, "detail");
            FeatureSelectionChange?.Invoke(this, new EventArgs<IFeatureInfo>(new FeatureInfo(detail)));
        }

        #endregion

        #region Functions

        public override void ConnectEvents()
        {
            _panoramaViewerEventList = new ApiEventList
            {
                new PanoramaRecordingClickViewerEvent(this, "RECORDING_CLICK", JsRecClick),
                new PanoramaViewerEvent(this, "ELEVATION_CHANGE", JsElevationChange),
                new PanoramaViewerEvent(this, "FEATURE_CLICK", JsFeatureClick),
                new PanoramaViewerEvent(this, "IMAGE_CHANGE", JsImChange),
                new PanoramaViewerEvent(this, "SURFACE_CURSOR_CHANGE", JsSurfaceCursorChange),
                new PanoramaViewerEvent(this, "VIEW_CHANGE", JsViewChange),
                new PanoramaViewerEvent(this, "VIEW_LOAD_END", JsViewLoadEnd),
                new PanoramaViewerEvent(this, "TILE_LOAD_ERROR", JsTileLoadError),
                new PanoramaViewerEvent(this, "TIME_TRAVEL_CHANGE", JsTimeTravelChange),
                new PanoramaViewerEvent(this, "FEATURE_SELECTION_CHANGE", JsFeatureSelectionChange)
            };

            Browser.ExecuteScriptAsync($"{_panoramaViewerEventList}");
            base.ConnectEvents();
        }

        private Color GetColor(object[] color)
        {
            return Color.FromArgb((int)(ToDouble(color, 3) * 255), ToInt(color, 0), ToInt(color, 1), ToInt(color, 2));
        }

        public async Task<IRecording> SearchRecordingAsync(
            string func,
            string query,
            string srs,
            [CallerMemberName] string funcName = "")
        {
            int processId = GetProcessId;
            string funcId = $"{funcName}{processId}";
            string script = $@"{Name}.{func}({query}{srs.SrsComponent()}).catch
                      (function(e){{{JsThis}.{JsImNotFound}('{Name}',e.message,{funcId})}}).then
                      (function(r){{delete r.thumbs;{JsThis}.{JsResult}('{Name}',r,{funcId})}});";
            object result = await CallJsAsync(script, processId);

            if (result is Exception exception)
            {
                throw exception;
            }

            return new Recording(ToDictionary(result));
        }

        #endregion
    }
}
