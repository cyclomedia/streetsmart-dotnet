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
using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class PositionStdev : Coordinate, IPositionStdev, IEquatable<PositionStdev>
  {
    public PositionStdev(IDictionary<string, object> position, IList<object> coordinateStdDev)
      : base(position)
    {
      StdDev = new Coordinate(coordinateStdDev);
    }

    public PositionStdev(IDictionary<string, object> position, Dictionary<string, object> coordinateStdev)
      : base(new DataConvert().GetListValue(position, "value"))
    {
      StdDev = new Coordinate(coordinateStdev);
    }

    public PositionStdev(double x, double y, double z, double stdX, double stdY, double stdZ)
      : base(x, y, z)
    {
      StdDev = new Coordinate(stdX, stdY, stdZ);
    }

    public PositionStdev(IPositionStdev position)
      : base(position)
    {
      if (position != null)
      {
        StdDev = new Coordinate(position.StdDev);
      }
    }

    // ReSharper disable once InconsistentNaming
    public ICoordinate StdDev { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      var sb = new StringBuilder();
      sb.Append($"\"xyz\":{{\"0\":{X?.ToString(ci) ?? "null"},\"1\":{Y?.ToString(ci) ?? "null"},\"2\":{Z?.ToString(ci) ?? "null"}}},");
      sb.Append($"\"xyzStdev\":[{StdDev?.X?.ToString(ci) ?? "null"},{StdDev?.Y?.ToString(ci) ?? "null"},{StdDev?.Z?.ToString(ci) ?? "null"}]");
      return sb.ToString();
    }

    public bool Equals(PositionStdev other)
    {
      if (other == null)
      {
        return false;
      }

      return StdDev.Equals(other.StdDev) &&
             X.Equals(other.X) &&
             Y.Equals(other.Y) &&
             Z.Equals(other.Z);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as PositionStdev);
    }

    public override int GetHashCode() => (StdDev, X, Y, Z).GetHashCode();
  }
}
