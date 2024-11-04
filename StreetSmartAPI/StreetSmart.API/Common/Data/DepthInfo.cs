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
using System.Collections.Generic;

namespace StreetSmart.Common.Data
{
  internal class DepthInfo : DataConvert, IDepthInfo
  {
    private double _depth;
    private double _depthInMeters;
    private ICoordinate _xyz;
    private string _srs;

    public DepthInfo(IDictionary<string, object> depthInfo)
    {
      Depth = ToDouble(depthInfo, "depth");
      DepthInMeters = ToDouble(depthInfo, "depthInMeters");
      XYZ = new Coordinate(GetDictValue(depthInfo, "xyz"));
      SRS = ToString(depthInfo, "srs");
    }

    public double Depth
    {
      get => _depth;
      set
      {
        _depth = value;
        RaisePropertyChanged();
      }
    }

    public double DepthInMeters
    {
      get => _depthInMeters;
      set
      {
        _depthInMeters = value;
        RaisePropertyChanged();
      }
    }

    public ICoordinate XYZ
    {
      get => _xyz;
      set
      {
        _xyz = value;
        RaisePropertyChanged();
      }
    }

    public string SRS
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
