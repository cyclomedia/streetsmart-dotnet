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

using System.Threading.Tasks;

using StreetSmart.Common.Interfaces.API;

namespace Demo.WinForms
{
  class ViewerElement
  {
    public IViewer Viewer { get; set; }

    private string _id;

    public async Task AddViewer(IViewer viewer)
    {
      Viewer = viewer;
      _id = await viewer.GetId();
    }

    public override string ToString()
    {
      string type = Viewer is IObliqueViewer ? "O" : Viewer is IPanoramaViewer ? "P" : "C";
      return $"({type}):{_id}";
    }
  }
}
