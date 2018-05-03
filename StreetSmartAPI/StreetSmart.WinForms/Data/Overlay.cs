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

using System;
using System.Collections.Generic;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class Overlay : NotifyPropertyChanged, IOverlay
  {
    private string _id;
    private string _geoJson;
    private string _name;
    private string _srs;
    private string _sld;

    public Overlay(string geoJson, string name, string srs, string sld)
    {
      GeoJson = geoJson;
      Name = name;
      Srs = srs;
      Sld = sld;
    }

    public void FillInParameters(Dictionary<string, object> overlay)
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

    public string GeoJson
    {
      get => _geoJson;
      set
      {
        _geoJson = value;
        RaisePropertyChanged();
      }
    }

    public string Name
    {
      get => _name;
      set
      {
        _name = value;
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

    public string Sld
    {
      get => _sld;
      set
      {
        _sld = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      if (!Sld?.Contains("\\\"") ?? false)
      {
        Sld = Sld.Replace("\"", "\\\"");
      }

      Sld = Sld?.Replace(Environment.NewLine, " ");
      Sld = Sld?.Replace("\t", " ");
      Sld = Sld?.Replace("\"x", "\" x");

      string srs = Srs == null ? string.Empty : $",sourceSrs:{Srs.ToQuote()}";
      string sld = Sld == null ? string.Empty : $",sldXMLtext:{Sld.ToQuote()}";
      return $"{{name:{Name.ToQuote()},geojson:{GeoJson}{srs}{sld}}}";
    }
  }
}
