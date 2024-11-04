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

using StreetSmart.Common.Interfaces.SLD;
using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
#pragma warning disable 1591
  /// <exclude/>
  public class Graphic : NotifyPropertyChanged, IGraphic
  {
    public Graphic()
    {
    }

    public Graphic(Mark mark, double size)
    {
      Mark = mark;
      Size = size;
    }

    public Graphic(ExternalGraphic externalGraphic, double size)
    {
      ExternalGraphic = externalGraphic;
      Size = size;
    }

    private ExternalGraphic _externalGraphic;

    [XmlElement("ExternalGraphic", Namespace = "http://www.opengis.net/se")]
    public ExternalGraphic ExternalGraphic
    {
      get => _externalGraphic;
      set
      {
        _externalGraphic = value;
        RaisePropertyChanged();
      }
    }

    private Mark _mark;

    [XmlElement("Mark", Namespace = "http://www.opengis.net/se")]
    public Mark Mark
    {
      get => _mark;
      set
      {
        _mark = value;
        RaisePropertyChanged();
      }
    }

    private double _size;

    [XmlElement("Size", Namespace = "http://www.opengis.net/se")]
    public double Size
    {
      get => _size;
      set
      {
        _size = value;
        RaisePropertyChanged();
      }
    }
  }
#pragma warning restore 1591
}
