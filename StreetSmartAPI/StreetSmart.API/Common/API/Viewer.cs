/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using StreetSmart.Common.API.Events;
using StreetSmart.Common.Data;
using StreetSmart.Common.Events;

using CefSharp;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

namespace StreetSmart.Common.API
{
  internal class Viewer : APIBase, IViewer
  {
    #region Members

    private ApiEventList _viewerEventList;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<ILayerInfo>> LayerVisibilityChange;

    #endregion

    #region Properties

    protected ViewerList ViewerList { get; }

    public string Name { get; protected set; }

    protected override string CallFunctionBase => $"'{Name}',{Name}";

    public bool Destroyed { private get; set; }

    public override string JsThis => ViewerList.JsThis;

    public virtual string DisconnectEventsScript => $"{_viewerEventList.Destroy}";

    public virtual string ConnectEventsScript => $"{_viewerEventList}";

    #endregion

    #region Callback definitions

    public override string JsResult => ViewerList.JsResult;

    public override string JsImNotFound => (ViewerList as PanoramaViewerList)?.JsImNotFound;

    private string JsLayerVisibilityChange => ViewerList.JsLayerVisibilityChange;

    #endregion

    #region Constructors

    public Viewer(ChromiumWebBrowser browser, ViewerList viewerList)
      : base(browser)
    {
      ViewerList = viewerList;
      Destroyed = false;
    }

    public Viewer(ChromiumWebBrowser browser, ViewerList viewerList, string name)
      : this(browser, viewerList)
    {
      Name = name;
    }

    #endregion

    #region Interface Functions

    public async Task<string> GetId()
    {
      return ToString(await CallJsGetScriptAsync("getId()"));
    }

    public async Task<bool> GetNavbarExpanded()
    {
      return ToBool(await CallJsGetScriptAsync("getNavbarExpanded()"));
    }

    public async Task<bool> GetNavbarVisible()
    {
      return ToBool(await CallJsGetScriptAsync("getNavbarVisible()"));
    }

    public async Task<bool> GetTimeTravelExpanded()
    {
      return ToBool(await CallJsGetScriptAsync("getTimeTravelExpanded()"));
    }

    public async Task<bool> GetTimeTravelVisible()
    {
      return ToBool(await CallJsGetScriptAsync("getTimeTravelVisible()"));
    }

    public new async Task<ViewerType> GetType()
    {
      string type = ToString(await CallJsGetScriptAsync("getType()"));
      ViewerType viewerType = ViewerType.Panorama;

      switch (type)
      {
        case "@@ViewerType/PANORAMA":
          viewerType = ViewerType.Panorama;
          break;
        case "@@ViewerType/OBLIQUE":
          viewerType = ViewerType.Oblique;
          break;
      }

      return viewerType;
    }

    public void SaveImage()
    {
      Browser.ExecuteScriptAsync($"{Name}.saveImage();");
    }

    public void SetBrightness(double value)
    {
      Browser.ExecuteScriptAsync($"{Name}.setBrightness({value});");
    }

    public void SetContrast(double value)
    {
      Browser.ExecuteScriptAsync($"{Name}.setContrast({value});");
    }

    public void ToggleNavbarExpanded(bool expanded)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleNavbarExpanded({expanded.ToJsBool()});");
    }

    public void ToggleNavbarVisible(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleNavbarVisible({visible.ToJsBool()});");
    }

    public void ToggleOverlay(IOverlay overlay)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleOverlay({overlay});");
      overlay.Visible = !overlay.Visible;
    }

    public void ToggleTimeTravelExpanded(bool expanded)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleTimeTravelExpanded({expanded.ToJsBool()});");
    }

    public void ToggleTimeTravelVisible(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleTimeTravelVisible({visible.ToJsBool()});");
    }

    public void ZoomIn()
    {
      Browser.ExecuteScriptAsync($"{Name}.zoomIn();");
    }

    public void ZoomOut()
    {
      Browser.ExecuteScriptAsync($"{Name}.zoomOut();");
    }

    #endregion

    #region Callbacks viewer

    public void OnLayerVisibilityChange(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      LayerVisibilityChange?.Invoke(this, new EventArgs<ILayerInfo>(new LayerInfo(detail)));
    }

    #endregion

    #region Functions

    protected async Task<bool> GetButtonEnabled(Enum buttonId)
    {
      return ToBool(await CallJsGetScriptAsync($"getButtonEnabled({buttonId.Description()})"));
    }

    protected void ToggleButtonEnabled(Enum buttonId, bool enabled)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleButtonEnabled({buttonId.Description()},{enabled.ToJsBool()})");
    }

    protected override async Task<object> CallJsAsync(string script, int processId, [CallerMemberName] string memberName = "")
    {
      if (!Destroyed)
      {
        return await base.CallJsAsync(script, processId, memberName);
      }

      throw new StreetSmartViewerDoesNotExistException();
    }

    public virtual void ConnectEvents()
    {
      _viewerEventList = new ApiEventList
      {
        new PanoramaObliqueViewerEvent(this, "LAYER_VISIBILITY_CHANGE", JsLayerVisibilityChange),
      };

      Browser.ExecuteScriptAsync($"{_viewerEventList}");
    }

    #endregion
  }
}
