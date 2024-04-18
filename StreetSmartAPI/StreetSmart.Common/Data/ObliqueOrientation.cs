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

using System.Collections.Generic;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class ObliqueOrientation : DataConvert, IObliqueOrientation
  {
    private IImageCoordinate _center;
    private IExtent _extent;
    private int _resolution;
    private double _rotation;
    private string _srs;

    public ObliqueOrientation(Dictionary<string, object> orientation)
    {
      Center = new ImageCoordinate(GetListValue(orientation, "center"));
      Extent = new Extent(GetListValue(orientation, "extent"));
      Resolution = ToInt(orientation, "resolution");
      Rotation = ToDouble(orientation, "rotation");
      Srs = ToString(orientation, "srs");
    }

    public IImageCoordinate Center
    {
      get => _center;
      set
      {
        _center = value;
        RaisePropertyChanged();
      }
    }

    public IExtent Extent
    {
      get => _extent;
      set
      {
        _extent = value;
        RaisePropertyChanged();
      }
    }

    public int Resolution
    {
      get => _resolution;
      set
      {
        _resolution = value;
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
