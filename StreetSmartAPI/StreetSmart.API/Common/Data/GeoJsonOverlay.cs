﻿/*
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

using StreetSmart.Common.Interfaces.Data;
using System;
using System.Drawing;

namespace StreetSmart.Common.Data
{
  internal class GeoJsonOverlay : Overlay, IGeoJsonOverlay
  {
    private string _geoJson;
    private string _srs;

    public GeoJsonOverlay(string geoJson, string name, string srs, string sld, bool visible = true)
      : base(name, sld, visible)
    {
      GeoJson = geoJson;
      Srs = srs;
    }

    public GeoJsonOverlay(string geoJson, string name, string srs, Color color, bool visible = true)
      : base(name, color, visible)
    {
      GeoJson = geoJson;
      Srs = srs;
    }

    public string GeoJson
    {
      get => _geoJson;
      set
      {
        _geoJson = value;
        RaisePropertyChanged();
      }
    }

    public string Srs
    {
      get => _srs;
      set
      {
        _srs = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      string overlay = base.ToString();
      string srs = Srs == null ? string.Empty : $",sourceSrs:{Srs.ToQuote()}";
      return $"{overlay.Substring(0, overlay.Length - 1)},geojson:{GeoJson}{srs}}}";
    }
  }
}
