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
  // ReSharper disable once InconsistentNaming
  internal class PositionXY : IPositionXY, IEquatable<PositionXY>
  {
    public PositionXY(IList<object> value, double? stdev)
    {
      X = value.Count >= 1 ? value[0] as double? : null;
      Y = value.Count >= 2 ? value[1] as double? : null;
      Stdev = stdev;
    }

    public PositionXY(IPositionXY position)
    {
      if (position != null)
      {
        X = position.X;
        Y = position.Y;
        Stdev = position.Stdev;
      }
    }

    public double? X { get; }

    public double? Y { get; }

    public double? Stdev { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      StringBuilder sb = new StringBuilder();

      sb.Append("\"positionXY\":{");

      if (X != null && Y != null)
      {
        sb.Append($"\"value\":[{X?.ToString(ci)},{Y?.ToString(ci)}]");
      }

      if (Stdev != null)
      {
        if (sb.Length > 13)
        {
          sb.Append(",");
        }
        sb.Append($"\"stdev\":{Stdev?.ToString(ci)}");
      }

      sb.Append("}");

      return sb.Length > 14 ? $"{sb}," : string.Empty;
    }

    public bool Equals(PositionXY other)
    {
      if (other == null)
      {
        return false;
      }

      return X.Equals(other.X) &&
             Y.Equals(other.Y) &&
             Stdev.Equals(other.Stdev);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as PositionXY);
    }

    public override int GetHashCode() => (X, Y, Stdev).GetHashCode();
  }
}
