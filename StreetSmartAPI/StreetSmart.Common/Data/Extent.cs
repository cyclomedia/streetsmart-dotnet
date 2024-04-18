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
  internal class Extent : DataConvert, IExtent
  {
    private double _x1;
    private double _x2;
    private double _y1;
    private double _y2;

    public Extent(IList<object> extent)
    {
      X1 = extent?.Count >= 1 ? (double) extent[0] : 0.0;
      Y1 = extent?.Count >= 2 ? (double) extent[1] : 0.0;
      X2 = extent?.Count >= 3 ? (double) extent[2] : 0.0;
      Y2 = extent?.Count >= 4 ? (double) extent[3] : 0.0;
    }

    public double X1
    {
      get => _x1;
      set
      {
        _x1 = value;
        RaisePropertyChanged();
      }
    }

    public double X2
    {
      get => _x2;
      set
      {
        _x2 = value;
        RaisePropertyChanged();
      }
    }

    public double Y1
    {
      get => _y1;
      set
      {
        _y1 = value;
        RaisePropertyChanged();
      }
    }

    public double Y2
    {
      get => _y2;
      set
      {
        _y2 = value;
        RaisePropertyChanged();
      }
    }
  }
}
