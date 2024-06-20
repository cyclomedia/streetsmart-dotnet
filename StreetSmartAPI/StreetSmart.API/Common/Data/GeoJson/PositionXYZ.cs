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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class PositionXYZ : Coordinate, IPositionXYZ//,IEquatable<PositionXYZ>
  {
    public PositionXYZ(Dictionary<string, object> position)
      : base(position)
    {
      double? x = ToNullDouble(position, "x");
      double? y = ToNullDouble(position, "y");
      double? z = ToNullDouble(position, "z");

      XYZ = new Coordinate(x, y, z);
    }

    public PositionXYZ(IPositionXYZ positionXyz)
      : base(positionXyz)
    {
      if (positionXyz != null)
      {
        XYZ = new Coordinate(positionXyz.XYZ);
      }
    }

    // ReSharper disable once InconsistentNaming
    public ICoordinate XYZ { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      var sb = new StringBuilder();

      sb.Append("{");
      sb.Append($"\"x\":{(XYZ?.X?.ToString(ci) ?? "null")},");
      sb.Append($"\"y\":{(XYZ?.Y?.ToString(ci) ?? "null")},");
      sb.Append($"\"z\":{(XYZ?.Z?.ToString(ci) ?? "null")},");
      sb.Append($"\"0\":{(X?.ToString(ci) ?? "null")},");
      sb.Append($"\"1\":{(Y?.ToString(ci) ?? "null")},");
      sb.Append($"\"2\":{(Z?.ToString(ci) ?? "null")}");
      sb.Append("}");

      return $"{sb}";
    }


    //public bool Equals(PositionXYZ other)
    //{
    //  if (other == null) return false;
    //  return XYZ.Equals(other.XYZ) &&
    //         X.Equals(other.X) &&
    //         Y.Equals(other.Y) &&
    //         Z.Equals(other.Z);
    //}

    //public override bool Equals(object obj)
    //{
    //  return Equals(obj as PositionXYZ);
    //}

    //public override int GetHashCode() => (XYZ, X, Y, Z).GetHashCode();

    //public override string ToString()
    //{
    //  CultureInfo ci = CultureInfo.InvariantCulture;
    //  return $"{{\"x\":{XYZ?.X?.ToString(ci) ?? "null"},\"y\":{XYZ?.Y?.ToString(ci) ?? "null"},\"z\":{XYZ?.Z?.ToString(ci) ?? "null"}," +
    //         $"\"0\":{X?.ToString(ci)},\"1\":{Y?.ToString(ci)},\"2\":{Z?.ToString(ci)}}}";
    //}
  }
}
