/*
 * Street Smart .NET integration
 * Copyright (c) 2017, CycloMedia, All rights reserved.
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

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class Overlay : NotifyPropertyChanged, IOverlay
  {
    private string _id;

    public Overlay(Dictionary<string, object> overlay)
    {
      Id = (string) overlay["id"];
    }

    public string Id
    {
      get => _id;
      set
      {
        _id = value;
        RaisePropertyChanged();
      }
    }
  }
}
