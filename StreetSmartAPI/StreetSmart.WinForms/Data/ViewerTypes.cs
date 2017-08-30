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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Properties;

namespace StreetSmart.WinForms.Data
{
  internal class ViewerTypes : ObservableCollection<ViewerType>, IViewerTypes
  {
    public ViewerTypes(IList<ViewerType> viewerTypes)
    {
      foreach (var viewerType in viewerTypes)
      {
        Add(viewerType);
      }
    }

    public IList<ViewerType> GetTypes()
    {
      return this.ToList();
    }

    public void AddType(ViewerType type)
    {
      if (!Contains(type))
      {
        Add(type);
      }
    }

    public void RemoveType(ViewerType type)
    {
      if (Contains(type))
      {
        Remove(type);
      }
    }

    public override string ToString()
    {
      string viewerTypes = this.Aggregate("[", (current, type) => $"{current}{Resources.JsApi}.{type.Description()},");
      return $"{viewerTypes.Substring(0, Math.Max((viewerTypes.Length - 1), 1))}]";
    }
  }
}
