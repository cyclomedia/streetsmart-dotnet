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

using System.Xml.Serialization;

using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Data.SLD
{
  #pragma warning disable 1591
  public class Rule : NotifyPropertyChanged, IRule
  {
    public Rule()
    {
    }

    public Rule(VendorOption vendorOption, Graphic graphic)
    {
      VendorOption = vendorOption;

      Symbolizer = new PointSymbolizer
      {
        Graphic = graphic
      };
    }

    public Rule(VendorOption vendorOption, Symbolizer symbolizer)
    {
      VendorOption = vendorOption;
      Symbolizer = symbolizer;
    }

    private VendorOption _vendorOption;

    [XmlElement("VendorOption", Namespace = "http://www.opengis.net/se")]
    public VendorOption VendorOption
    {
      get => _vendorOption;
      set
      {
        _vendorOption = value;
        RaisePropertyChanged();
      }
    }

    private Symbolizer _symbolizer;

    [XmlElement("PointSymbolizer", typeof(PointSymbolizer), Namespace = "http://www.opengis.net/se")]
    [XmlElement("LineSymbolizer", typeof(LineSymbolizer), Namespace = "http://www.opengis.net/se")]
    [XmlElement("PolygonSymbolizer", typeof(PolygonSymbolizer), Namespace = "http://www.opengis.net/se")]
    public Symbolizer Symbolizer
    {
      get => _symbolizer;
      set
      {
        _symbolizer = value;
        RaisePropertyChanged();
      }
    }
  }
  #pragma warning restore 1591
}
