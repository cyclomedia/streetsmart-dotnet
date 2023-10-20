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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using CefSharp;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.API
{
  internal class Viewer : APIBase, IViewer
  {
    #region Properties

    protected ViewerList ViewerList { get; }

    public string Name { get; set; }

    public string JsObjectCollection { set; private get; }

    protected override string CallFunctionBase => $"'{Name}',{Name}";

    public bool Destroyed { private get; set; }

    public override string JsThis => ViewerList.JsThis;

    #endregion

    #region Callback definitions

    public override string JsResult => ViewerList.JsResult;

    public override string JsImNotFound => (ViewerList as PanoramaViewerList)?.JsImNotFound;

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
        case "@@ViewerType/POINTCLOUD":
          viewerType = ViewerType.PointCloud;
          break;
      }

      return viewerType;
    }

    public void ToggleNavbarExpanded(bool expanded)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleNavbarExpanded({expanded.ToJsBool()});");
    }

    public void ToggleNavbarVisible(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleNavbarVisible({visible.ToJsBool()});");
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

    public virtual void DisConnectEvents()
    {
      // override
    }

    public virtual void ReConnectEvents()
    {
      // override
    }

    public async Task DeleteJsObject()
    {
      string id = await GetId();
      Browser.ExecuteScriptAsync($"delete {JsObjectCollection}['{id}'];");
    }

    #endregion
  }
}
