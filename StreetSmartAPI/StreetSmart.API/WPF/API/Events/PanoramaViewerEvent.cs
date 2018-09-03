/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

namespace StreetSmart.Wpf.API.Events
{
  internal class PanoramaViewerEvent: ApiEvent
  {
    private readonly PanoramaViewer _viewer;

    protected string Name => _viewer.Name;

    protected string JsThis => _viewer.JsThis;

    protected override string Events => "Events.panoramaViewer";

    public override string Destroy => $@"{Name}.off({JsApi}.{Events}.{Type},{FuncName}{Name});";

    public PanoramaViewerEvent(PanoramaViewer viewer, string type, string funcName)
      : base(type, funcName)
    {
      _viewer = viewer;
    }

    public override string ToString()
    {
      return $@"{Name}.on({JsApi}.{Events}.{Type},{FuncName}{Name}=function(e)
             {{{JsThis}.{FuncName}('{Name}',e);}});";
    }
  }
}
