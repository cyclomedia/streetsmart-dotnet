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

#if WINFORMS
using StreetSmart.WinForms.Properties;
#else
using StreetSmart.Wpf.Properties;
#endif

namespace StreetSmart.Common.API.Events
{
  internal class ApiEvent
  {
    protected string JsApi => Resources.JsApi;

    protected string Type { get; }

    protected string FuncName { get; }

    protected virtual string Events => "Events";

    public virtual string Destroy => string.Empty;

    public ApiEvent(string type, string funcName)
    {
      Type = type;
      FuncName = funcName;
    }

    public override string ToString()
    {
      return string.Empty;
    }
  }
}
