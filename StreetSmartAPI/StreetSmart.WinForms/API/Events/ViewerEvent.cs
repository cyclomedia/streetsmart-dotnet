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

namespace StreetSmart.WinForms.API.Events
{
  internal class ViewerEvent: StreetSmartApiEvent
  {
    private string TempType => $"temp{Type}";

    public ViewerEvent(StreetSmartAPI api, string type, string funcName)
      : base(api, type, funcName, "viewer")
    {
    }

    public override string ToString()
    {
      return $@"var {TempType};{JsApi}.on({JsApi}.{Events}.{Type},{FuncName}{Category}=function(e)
             {{{TempType} = e.detail.viewer;{JsThis}.{FuncName}('{TempType}', {TempType}.getType());}});";
    }
  }
}
