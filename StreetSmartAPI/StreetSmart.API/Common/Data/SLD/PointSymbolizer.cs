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

using StreetSmart.Common.Interfaces.SLD;
using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
#pragma warning disable 1591

  /// <exclude/>
  public class PointSymbolizer : Symbolizer, IPointSymbolizer
  {
    private Graphic _graphic;

    public PointSymbolizer()
    {
    }

    public PointSymbolizer(Graphic graphic)
    {
      Graphic = graphic;
    }

    [XmlElement("Graphic", Namespace = "http://www.opengis.net/se")]
    public Graphic Graphic
    {
      get => _graphic;
      set
      {
        _graphic = value;
        RaisePropertyChanged();
      }
    }
  }

#pragma warning restore 1591
}
