/*
 * Integration in ArcMap for Cycloramas
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class Coordinate : NotifyPropertyChanged, ICoordinate
  {
    private double _x;
    private double _y;
    private double? _z;

    public Coordinate(double x, double y)
    {
      X = x;
      Y = y;
      Z = null;
    }

    public Coordinate(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public double X
    {
      get { return _x; }
      set
      {
        _x = value;
        RaisePropertyChanged();
      }
    }

    public double Y
    {
      get { return _y; }
      set
      {
        _y = value;
        RaisePropertyChanged();
      }
    }

    public double? Z
    {
      get { return _z; }
      set
      {
        _z = value;
        RaisePropertyChanged();
      }
    }
  }
}
