/*
 * Street Smart .NET integration
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

namespace StreetSmart.WinForms.API.Events
{
  internal class MeasurementEvent: ApiEvent
  {
    private readonly StreetSmartAPI _api;

    protected string JsThis => _api.JsThis;

    protected override string Events => "Events.measurement";

    public override string Destroy => $@"{JsApi}.off({JsApi}.{Events}.{Type},{FuncName}measurement);";

    public MeasurementEvent(StreetSmartAPI api, string type, string funcName)
      : base(type, funcName)
    {
      _api = api;
    }

    public override string ToString()
    {
      PanoramaViewerList panViewerList = ViewerList.PanoramaViewerList;
      string reAssignPanoramaViewer = panViewerList.ReAssignPanoramaViewer("e.detail.panoramaViewer");
      string disconnectScript = panViewerList.DisconnectEvents();
      string connectScript = panViewerList.ConnectEvents();

      return $@"{JsApi}.on({JsApi}.{Events}.{Type},{FuncName}measurement=function(e)
             {{{disconnectScript}{reAssignPanoramaViewer}{connectScript}
             {JsThis}.{FuncName}(e.detail.activeMeasurement);}});";
    }
  }
}
