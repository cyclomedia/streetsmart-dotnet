/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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

using System.Drawing;
using System.Xml.Serialization;

using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Data.SLD
{
  #pragma warning disable 1591
  public class Mark : NotifyPropertyChanged, IMark
  {
    public Mark()
    {
    }

    public Mark(SymbolizerType type, SvgParameterCollection<FillType> fill, SvgParameterCollection<StrokeType> stroke)
    {
      WellKnownName = type;
      Fill = fill;
      Stroke = stroke;
    }

    public Mark(SymbolizerType? type, Color fillColor, double? fillOpacity, Color? strokeColor, double? strokeWidth)
    {

      WellKnownName = type;

      Fill = SvgParameterCollection<FillType>.GetFillObject(fillColor, fillOpacity);

      if (strokeColor != null)
      {
        Stroke = SvgParameterCollection<StrokeType>.GetStrokeObject((Color) strokeColor, strokeWidth, null);
      }
    }

    private SymbolizerType? _wellKnownName;

    [XmlElement("WellKnownName", Namespace = "http://www.opengis.net/se")]
    public SymbolizerType? WellKnownName
    {
      get => _wellKnownName;
      set
      {
        _wellKnownName = value;
        RaisePropertyChanged();
      }
    }

    private SvgParameterCollection<FillType> _fill;

    [XmlElement("Fill", Namespace = "http://www.opengis.net/se")]
    public SvgParameterCollection<FillType> Fill
    {
      get => _fill;
      set
      {
        _fill = value;
        RaisePropertyChanged();
      }
    }

    private SvgParameterCollection<StrokeType> _stroke;

    [XmlElement("Stroke", Namespace = "http://www.opengis.net/se")]
    public SvgParameterCollection<StrokeType> Stroke
    {
      get => _stroke;
      set
      {
        _stroke = value;
        RaisePropertyChanged();
      }
    }

    public bool ShouldSerializeWellKnownName()
    {
      return WellKnownName.HasValue;
    }
  }

  #pragma warning restore 1591
}
