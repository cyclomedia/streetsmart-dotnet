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
using System.Dynamic;
using System.Threading.Tasks;
using StreetSmart.Common.API.Events;
using StreetSmart.Common.Data;
using StreetSmart.Common.Events;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;

namespace StreetSmart.Common.API
{
  internal class ImageViewer : Viewer, IImageViewer
  {
    #region Members

    private ApiEventList _viewerEventList;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<ILayerInfo>> LayerVisibilityChange;

    #endregion

    #region Properties

    public virtual string DisconnectEventsScript => $"{_viewerEventList.Destroy}";

    public virtual string ConnectEventsScript => $"{_viewerEventList}";

    #endregion

    #region Callback definitions

    private string JsLayerVisibilityChange => ViewerList.JsLayerVisibilityChange;

    #endregion

    #region Constructors

    public ImageViewer(IStreetSmartBrowser browser, ViewerList viewerList)
      : base(browser, viewerList)
    {
    }

    public ImageViewer(IStreetSmartBrowser browser, ViewerList viewerList, string name)
      : base(browser, viewerList, name)
    {
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetTimeTravelExpanded()
    {
      return ToBool(await CallJsGetScriptAsync("getTimeTravelExpanded()"));
    }

    public void ToggleCompass(bool visible)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleCompass({visible.ToJsBool()});");
    }

    public void ToggleCompass()
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleCompass();");
    }

    public async Task<bool> GetTimeTravelVisible()
    {
      return ToBool(await CallJsGetScriptAsync("getTimeTravelVisible()"));
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

    public void ToggleOverlay(IOverlay overlay)
    {
      Browser.ExecuteScriptAsync($"{Name}.toggleOverlay({overlay});");
      overlay.Visible = !overlay.Visible;
    }

    public void SetSelectedFeatureByProperties(IJson properties, string layerId)
    {
      Browser.ExecuteScriptAsync($"{Name}.setSelectedFeatureByProperties({properties},{layerId.ToQuote()});");
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

    public void OnLayerVisibilityChange(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      LayerVisibilityChange?.Invoke(this, new EventArgs<ILayerInfo>(new LayerInfo(detail)));
    }

    #endregion

    #region Functions

    public override void DisConnectEvents()
    {
      Browser.ExecuteScriptAsync(DisconnectEventsScript);
    }

    public override void ReConnectEvents()
    {
      Browser.ExecuteScriptAsync(ConnectEventsScript);
    }

    public virtual void ConnectEvents()
    {
      _viewerEventList = new ApiEventList
      {
        new ViewerEvent(this, "LAYER_VISIBILITY_CHANGE", JsLayerVisibilityChange),
      };

      Browser.ExecuteScriptAsync($"{_viewerEventList}");
    }

    #endregion
  }
}
