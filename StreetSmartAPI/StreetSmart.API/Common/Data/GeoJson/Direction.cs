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

using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Direction : Coordinate, IDirection, IEquatable<Direction>
  {
    public Direction(IDictionary<string, object> direction)
      : base(direction)
    {
    }

    public Direction(double x, double y, double z)
      : base(x, y, z)
    {
    }

    public Direction(IDirection direction)
      : base(direction)
    {
    }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      var sb = new StringBuilder();

      sb.Append("{");
      sb.Append($"\"0\":{X?.ToString(ci)},");
      sb.Append($"\"1\":{Y?.ToString(ci)},");
      sb.Append($"\"2\":{Z?.ToString(ci)}");
      sb.Append("}");

      return $"{sb}";
    }
    public bool Equals(Direction other)
    {
      if (other == null) return false;
      return X.Equals(other.X) &&
             Y.Equals(other.Y) &&
             Z.Equals(other.Z);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Direction);
    }

    public override int GetHashCode() => (X, Y, Z).GetHashCode();
  }
}
