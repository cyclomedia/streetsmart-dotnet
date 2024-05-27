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
  internal sealed class ObliqueViewer : ImageViewer, IObliqueViewer
  {
    #region Members

    private ApiEventList _obliqueViewerEventList;

    #endregion

    #region Events

    public event EventHandler<IEventArgs<IDirectionInfo>> SwitchViewingDir;
    public event EventHandler<IEventArgs<IFeatureInfo>> FeatureClick;
    public event EventHandler<IEventArgs<IFeatureInfo>> FeatureSelectionChange;
    public event EventHandler<IEventArgs<IObliqueImageInfo>> ImageChange;
    public event EventHandler<IEventArgs<IObliqueOrientation>> ViewChange;
    public event EventHandler<EventArgs> ViewLoadEnd;
    public event EventHandler<IEventArgs<ITimeTravelInfo>> TimeTravelChange;

    #endregion

    #region Callback definitions

    public string JsSwitchViewingDirection => (ViewerList as ObliqueViewerList)?.JsSwitchViewingDirection;

    public string JsFeatureClick => (ViewerList as ObliqueViewerList)?.JsFeatureClick;

    public string JsFeatureSelectionChange => (ViewerList as ObliqueViewerList)?.JsFeatureSelectionChange;

    public string JsImChange => (ViewerList as ObliqueViewerList)?.JsImChange;

    public string JsViewChange => (ViewerList as ObliqueViewerList)?.JsViewChange;

    public string JsViewLoadEnd => (ViewerList as ObliqueViewerList)?.JsViewLoadEnd;

    public string JsTimeTravelChange => (ViewerList as ObliqueViewerList)?.JsTimeTravelChange;

    #endregion

    #region Constructors

    public ObliqueViewer(IStreetSmartBrowser browser, ObliqueViewerList obliqueViewerList, string name)
      : base(browser, obliqueViewerList, name)
    {
      ConnectEvents();
    }

    #endregion

    #region Interface Functions

    public async Task<bool> GetButtonEnabled(ObliqueViewerButtons buttonId)
    {
      return await base.GetButtonEnabled(buttonId);
    }

    public void SwitchViewingDirection(double deltaDegrees)
    {
      Browser.ExecuteScriptAsync($"{Name}.switchViewingDirection({deltaDegrees});");
    }

    public void ToggleButtonEnabled(ObliqueViewerButtons buttonId, bool enabled)
    {
      base.ToggleButtonEnabled(buttonId, enabled);
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnSwitchViewingDirection(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      SwitchViewingDir?.Invoke(this, new EventArgs<IDirectionInfo>(new DirectionInfo(detail)));
    }

    public void OnFeatureClick(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      FeatureClick?.Invoke(this, new EventArgs<IFeatureInfo>(new FeatureInfo(detail)));
    }

    public void OnFeatureSelectionChange(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      FeatureSelectionChange?.Invoke(this, new EventArgs<IFeatureInfo>(new FeatureInfo(detail)));
    }

    public void OnImageChange(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      ImageChange?.Invoke(this, new EventArgs<ObliqueImageInfo>(new ObliqueImageInfo(detail)));
    }

    public void OnViewChange(ExpandoObject args)
    {
      Dictionary<string, object> detail = GetDictValue(args, "detail");
      ViewChange?.Invoke(this, new EventArgs<ObliqueOrientation>(new ObliqueOrientation(detail)));
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

    #endregion

    #region Functions

    public override void ConnectEvents()
    {
      _obliqueViewerEventList = new ApiEventList
      {
        new ObliqueViewerEvent(this, "SWITCH_VIEWING_DIRECTION", JsSwitchViewingDirection),
        new ObliqueViewerEvent(this, "FEATURE_CLICK", JsFeatureClick),
        new ObliqueViewerEvent(this, "FEATURE_SELECTION_CHANGE", JsFeatureSelectionChange),
        new ObliqueViewerEvent(this, "IMAGE_CHANGE", JsImChange),
        new ObliqueViewerEvent(this, "VIEW_CHANGE", JsViewChange),
        new ObliqueViewerEvent(this, "VIEW_LOAD_END", JsViewLoadEnd),
        new ObliqueViewerEvent(this, "TIME_TRAVEL_CHANGE", JsTimeTravelChange)
      };

      Browser.ExecuteScriptAsync($"{_obliqueViewerEventList}");
      base.ConnectEvents();
    }

    #endregion
  }
}
