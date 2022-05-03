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
    public event EventHandler<IEventArgs<PointSize>> PointSizeChanged;
    public event EventHandler<IEventArgs<ColorizationMode>> PointStyleChanged;
    public event EventHandler<IEventArgs<Quality>> PointBudgedChanged;
    public event EventHandler<IEventArgs<BackgroundPreset>> BackGroundChanged;

    #endregion

    #region Callback definitions

    public string JsViewChange => (ViewerList as PointCloudViewerList)?.JsViewChange;

    public string JsEdgesChanged => (ViewerList as PointCloudViewerList)?.JsEdgesChanged;

    public string JsPointSizeChanged => (ViewerList as PointCloudViewerList)?.JsPointSizeChanged;

    public string JsPointStyleChanged => (ViewerList as PointCloudViewerList)?.JsPointStyleChanged;

    public string JsPointBudgetChanged => (ViewerList as PointCloudViewerList)?.JsPointBudgetChanged;

    public string JsBackGroundChanged => (ViewerList as PointCloudViewerList)?.JsBackGroundChanged;

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

    public async Task<BackgroundPreset> GetBackgroundPreset()
    {
      return (BackgroundPreset)ToEnum(typeof(BackgroundPreset), await CallJsGetScriptAsync("getBackgroundPreset()"));
    }

    public async Task<bool> GetButtonEnabled(PointCloudViewerButtons buttonId)
    {
      return await base.GetButtonEnabled(buttonId);
    }

    public async Task<bool> GetEdgesVisibility()
    {
      return ToBool(await CallJsGetScriptAsync("getEdgesVisibility()"));
    }

    public async Task<double> GetMaxHeightColorization()
    {
      return ToDouble(await CallJsGetScriptAsync("getMaxHeightColorization()"));
    }

    public async Task<double> GetMinHeightColorization()
    {
      return ToDouble(await CallJsGetScriptAsync("getMinHeightColorization()"));
    }

    public async Task<Quality> GetPointAmount()
    {
      return (Quality)ToEnum(typeof(Quality), await CallJsGetScriptAsync("getPointAmount()"));
    }

    public async Task<PointSize> GetPointSize()
    {
      return (PointSize)ToEnum(typeof(PointSize), await CallJsGetScriptAsync("getPointSize()"));
    }

    public async Task<ColorizationMode> GetPointStyle()
    {
      return (ColorizationMode)ToEnum(typeof(ColorizationMode), await CallJsGetScriptAsync("getPointStyle()"));
    }

    public void SetBackgroundPreset(BackgroundPreset background)
    {
      Browser.ExecuteScriptAsync($"{Name}.setBackgroundPreset({background.Description().ToQuote()});");
    }

    public void SetMaxHeightColorization(double heightColorization)
    {
      Browser.ExecuteScriptAsync($"{Name}.setMaxHeightColorization({heightColorization.ToString(_ci)});");
    }

    public void SetMinHeightColorization(double heightColorization)
    {
      Browser.ExecuteScriptAsync($"{Name}.setMinHeightColorization({heightColorization.ToString(_ci)});");
    }

    public void SetPointAmount(Quality amount)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointAmount({amount.Description().ToQuote()});");
    }

    public void SetPointSize(PointSize size)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointSize({size.Description().ToQuote()});");
    }

    public void SetPointStyle(ColorizationMode style)
    {
      Browser.ExecuteScriptAsync($"{Name}.setPointStyle({style.Description().ToQuote()});");
    }

    public void ToggleButtonEnabled(PointCloudViewerButtons buttonId, bool enabled)
    {
      base.ToggleButtonEnabled(buttonId, enabled);
    }

    public void ToggleEdges(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleEdges({visible.ToJsBool()});");
    }

    public void TogglePointCloudType(PointCloudType? value)
    {
      Browser.ExecuteScriptAsync($"{Name}.TogglePointCloudType({value?.Description().ToQuote() ?? string.Empty});");
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
      PointSize value = (PointSize)ToEnum(typeof(PointSize), detail, "value");
      PointSizeChanged?.Invoke(this, new EventArgs<PointSize> (value));
    }

    public void OnPointStyleChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      ColorizationMode value = (ColorizationMode)ToEnum(typeof(ColorizationMode), detail, "value");
      PointStyleChanged?.Invoke(this, new EventArgs<ColorizationMode>(value));
    }

    public void OnPointBudgedChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      Quality value = (Quality)ToEnum(typeof(Quality), detail, "value");
      PointBudgedChanged?.Invoke(this, new EventArgs<Quality>(value));
    }

    public void OnBackGroundChanged(Dictionary<string, object> args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      BackgroundPreset value = (BackgroundPreset)ToEnum(typeof(BackgroundPreset), detail, "value");
      BackGroundChanged?.Invoke(this, new EventArgs<BackgroundPreset>(value));
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
        new PointCloudViewerEvent(this, "BACKGROUND_CHANGED", JsBackGroundChanged)
      };

      Browser.ExecuteScriptAsync($"{_pointCloudViewerEventList}");
    }

    #endregion
  }
}
