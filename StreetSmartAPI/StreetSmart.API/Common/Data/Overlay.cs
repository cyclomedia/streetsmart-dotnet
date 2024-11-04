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

using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace StreetSmart.Common.Data
{
  internal class Overlay : DataConvert, IOverlay
  {
    private string _id;
    private string _name;
    private string _sld;
    private Color? _color;
    private bool _visible;

    public Overlay(string name, string sld, bool visible = true)
    {
      Name = name;
      Sld = sld;
      Visible = visible;
    }

    public Overlay(string name, Color color, bool visible = true)
    {
      Name = name;
      Color = color;
      Visible = visible;
    }

    public void FillInParameters(IDictionary<string, object> overlay)
    {
      Id = ToString(overlay, "id");
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

    public string Name
    {
      get => _name;
      set
      {
        _name = value;
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

    public Color? Color
    {
      get => _color;
      set
      {
        _color = value;
        RaisePropertyChanged();
      }
    }

    public bool Visible
    {
      get => _visible;
      set
      {
        _visible = value;
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

      string color = Color == null ? string.Empty : $",color:{((Color)Color).ToHexColor().ToQuote()}";
      string sld = Sld == null ? string.Empty : $",sldXMLtext:{Sld.ToQuote()}";
      return $"{{name:{Name.ToQuote()},visible:{Visible.ToJsBool()},id:{Id.ToQuote()}{sld}{color}}}";
    }
  }
}
