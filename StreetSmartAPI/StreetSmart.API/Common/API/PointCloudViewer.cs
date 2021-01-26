/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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
using System.Globalization;
using System.Threading.Tasks;

using CefSharp;

using StreetSmart.Common.API.Events;
using StreetSmart.Common.Data;
using StreetSmart.Common.Events;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

namespace StreetSmart.Common.API
{
  internal sealed class PointCloudViewer : Viewer, IPointCloudViewer
  {
    #region Members

    private CultureInfo _ci;
    private ApiEventList _pointCloudViewerEventList;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<ICamera>> ViewChange;
    public event EventHandler<IEventArgs<bool>> EdgesChanged;
    public event EventHandler<IEventArgs<int>> PointSizeChanged;
    public event EventHandler<IEventArgs<PointStyle>> PointStyleChanged;
    public event EventHandler<IEventArgs<PointBudget>> PointBudgedChanged;

    #endregion

    #region Callback definitions

    public string JsViewChange => (ViewerList as PointCloudViewerList)?.JsViewChange;

    public string JsEdgesChanged => (ViewerList as PointCloudViewerList)?.JsEdgesChanged;

    public string JsPointSizeChanged => (ViewerList as PointCloudViewerList)?.JsPointSizeChanged;

    public string JsPointStyleChanged => (ViewerList as PointCloudViewerList)?.JsPointStyleChanged;

    public string JsPointBudgetChanged => (ViewerList as PointCloudViewerList)?.JsPointBudgetChanged;

    #endregion

    #region Constructors

    public PointCloudViewer(ChromiumWebBrowser browser, PointCloudViewerList pointCloudViewerList, string name)
      : base(browser, pointCloudViewerList, name)
    {
      _ci = CultureInfo.InvariantCulture;
      ConnectEvents();
    }

    #endregion

    #region Interface Functions

    public void FlyTo(ICoordinate position, ICoordinate lookAt)
    {
      Browser.ExecuteScriptAsync($"{Name}.flyTo({position},{lookAt});");
    }

    public async Task<bool> GetButtonEnabled(PointCloudViewerButtons buttonId)
    {
      return await base.GetButtonEnabled(buttonId);
    }

    public async Task<ICamera> GetCameraPosition()
    {
      return new Camera(ToDictionary(await CallJsGetScriptAsync("getCameraPosition()")));
    }

    public async Task<bool> GetEdgesVisibility()
    {
      return ToBool(await CallJsGetScriptAsync("getEdgesVisibility()"));
    }

    public async Task<PointBudget> GetPointBudget()
    {
      return (PointBudget) ToEnum(typeof(PointBudget), await CallJsGetScriptAsync("getPointBudget()"));
    }

    public async Task<int> GetPointSize()
    {
      return ToInt(await CallJsGetScriptAsync("getPointSize()"));
    }

    public async Task<PointStyle> GetPointStyle()
    {
      return (PointStyle) ToEnum(typeof(PointStyle), await CallJsGetScriptAsync("getPointStyle()"));
    }

    public void LookAtCoordinate(ICoordinate lookAt)
    {
      Browser.ExecuteScriptAsync($"{Name}.lookAtCoordinate({lookAt});");
    }

    public void RotateDown(double deg)
    {
      Browser.ExecuteScriptAsync($"{Name}.rotateDown({deg.ToString(_ci)});");
    }

    public void RotateLeft(double deg)
    {
      Browser.ExecuteScriptAsync($"{Name}.rotateLeft({deg.ToString(_ci)});");
    }

    public void RotateRight(double deg)
    {
      Browser.ExecuteScriptAsync($"{Name}.rotateRight({deg.ToString(_ci)});");
    }

    public void RotateUp(double deg)
    {
      Browser.ExecuteScriptAsync($"{Name}.rotateUp({deg.ToString(_ci)});");
    }

    public void SetPointBudget(PointBudget pointBudget)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointBudget({pointBudget.Description().ToQuote()});");
    }

    public void SetPointSize(int size)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointSize({size});");
    }

    public void SetPointStyle(PointStyle pointStyle)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointStyle({pointStyle.Description()});");
    }

    public void ToggleButtonEnabled(PointCloudViewerButtons buttonId, bool enabled)
    {
      base.ToggleButtonEnabled(buttonId, enabled);
    }

    public void ToggleEdges(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleEdges({visible.ToJsBool()});");
    }

    public void TogglePointCloudType()
    {
      Browser.ExecuteScriptAsync($"{Name}.TogglePointCloudType();");
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnViewChange(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      ViewChange?.Invoke(this, new EventArgs<ICamera>(new Camera(detail)));
    }

    public void OnEdgesChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      bool value = ToBool(detail, "value");
      EdgesChanged?.Invoke(this, new EventArgs<bool>(value));
    }

    public void OnPointSizeChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      int value = ToInt(detail, "value");
      PointSizeChanged?.Invoke(this, new EventArgs<int> (value));
    }

    public void OnPointStyleChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      PointStyle value = (PointStyle) ToEnum(typeof(PointStyle), detail, "value");
      PointStyleChanged?.Invoke(this, new EventArgs<PointStyle>(value));
    }

    public void OnPointBudgedChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      PointBudget value = (PointBudget) ToEnum(typeof(PointBudget), detail, "value");
      PointBudgedChanged?.Invoke(this, new EventArgs<PointBudget>(value));
    }

    #endregion

    #region Functions

    public void ConnectEvents()
    {
      _pointCloudViewerEventList = new ApiEventList
      {
        new PointCloudViewerEvent(this, "VIEW_CHANGE", JsViewChange),
        new PointCloudViewerEvent(this, "EDGES_CHANGED", JsEdgesChanged),
        new PointCloudViewerEvent(this, "POINT_SIZE_CHANGED", JsPointSizeChanged),
        new PointCloudViewerEvent(this, "POINT_STYLE_CHANGED", JsPointStyleChanged),
        new PointCloudViewerEvent(this, "POINT_BUDGET_CHANGED", JsPointBudgetChanged),
      };

      Browser.ExecuteScriptAsync($"{_pointCloudViewerEventList}");
    }

    #endregion
  }
}
