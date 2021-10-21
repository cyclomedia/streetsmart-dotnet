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
using System.Globalization;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class Coordinate : DataConvert, ICoordinate
  {
    private double? _x;
    private double? _y;
    private double? _z;

    public Coordinate()
    {
    }

    public Coordinate(Dictionary<string, object> coordinate)
    {
      X = ToNullDouble(coordinate, "0");
      Y = ToNullDouble(coordinate, "1");
      Z = ToNullDouble(coordinate, "2");
    }

    public Coordinate(IList<object> coordinate)
    {
      X = coordinate?.Count >= 1 ? ToNullDouble(coordinate[0]) : null;
      Y = coordinate?.Count >= 2 ? ToNullDouble(coordinate[1]) : null;
      Z = coordinate?.Count >= 3 ? ToNullDouble(coordinate[2]) : null;
    }

    public Coordinate(ICoordinate coordinate)
    {
      if (coordinate != null)
      {
        X = coordinate.X;
        Y = coordinate.Y;
        Z = coordinate.Z;
      }
    }

    public Coordinate(double? x, double? y)
    {
      X = x;
      Y = y;
      Z = null;
    }

    public Coordinate(double? x, double? y, double? z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public double? X
    {
      get => _x;
      set
      {
        _x = value;
        RaisePropertyChanged();
      }
    }

    public double? Y
    {
      get => _y;
      set
      {
        _y = value;
        RaisePropertyChanged();
      }
    }

    public double? Z
    {
      get => _z;
      set
      {
        _z = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string zComponent = Z == null ? string.Empty : $",{((double) Z).ToString(ci)}";
      return X == null || Y == null ? "null" : $"[{X?.ToString(ci)},{Y?.ToString(ci)}{zComponent}]";
    }
  }
}
