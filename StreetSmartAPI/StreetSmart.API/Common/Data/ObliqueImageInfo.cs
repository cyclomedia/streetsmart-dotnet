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

using System.Collections.Generic;

using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data
{
  internal class ObliqueImageInfo : DataConvert, IObliqueImageInfo
  {
    private IPolygon _footprint;
    private ICoordinate _footprintCentre;
    private double _rotation;
    private string _srs;

    public ObliqueImageInfo(Dictionary<string, object> obliqueImageInfo)
    {
      Footprint = new Polygon(GetListValue(obliqueImageInfo, "footprint"));
      FootprintCentre = new Coordinate(GetListValue(obliqueImageInfo, "footprintCentre"));
      Rotation = ToDouble(obliqueImageInfo, "rotation");
      Srs = ToString(obliqueImageInfo, "srs");
    }

    public IPolygon Footprint
    {
      get => _footprint;
      set
      {
        _footprint = value;
        RaisePropertyChanged();
      }
    }

    public ICoordinate FootprintCentre
    {
      get => _footprintCentre;
      set
      {
        _footprintCentre = value;
        RaisePropertyChanged();
      }
    }

    public double Rotation
    {
      get => _rotation;
      set
      {
        _rotation = value;
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
  }
}
