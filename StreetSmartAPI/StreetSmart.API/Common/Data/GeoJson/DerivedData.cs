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
using System.Text;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedData : DataConvert, IDerivedData,IEquatable<DerivedData>
  {
    public DerivedData(Dictionary<string, object> derivedData)
    {
      string unit = ToString(derivedData, "unit");
      Precision = ToInt(derivedData, "precision");

      switch (unit)
      {
        case "m":
          Unit = Unit.Meters;
          break;
        case "ft":
          Unit = Unit.Feet;
          break;
        case "us-ft":
          Unit = Unit.UsFeet;
          break;
        case "degrees":
          Unit = Unit.Degrees;
          break;
        case "?":
          Unit = Unit.Unknown;
          break;
        default:
          Unit = Unit.Unknown;
          break;
      }
    }

    public DerivedData(IDerivedData derivedData)
    {
      if (derivedData != null)
      {
        Unit = derivedData.Unit;
        Precision = derivedData.Precision;
      }
    }

    public Unit Unit { get; }

    public int Precision { get; }

    public override string ToString()
    {
      var sb = new StringBuilder();

      sb.Append("{");
      sb.Append($"\"unit\":\"{Unit.Description()}\",");
      sb.Append($"\"precision\":{Precision}");
      sb.Append("}");

      return $"{sb}";
    }

    public bool Equals(DerivedData other)
    {
      if (other == null) return false;
      return Unit.Equals(other.Unit) && Precision == other.Precision;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as DerivedData);
    }

    public override int GetHashCode() => (Unit, Precision).GetHashCode();
    //public override string ToString()
    //{
    //  return $"{{\"unit\":\"{Unit.Description()}\",\"precision\":{Precision}}}";
    //}
  }
}
