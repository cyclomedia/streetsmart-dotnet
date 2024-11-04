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
using System.Globalization;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Property : NotifyPropertyChanged, IProperty, IEquatable<Property>
  {
    public Property(object value, object stdev)
    {
      if (value != null)
      {
        double.TryParse(value.ToString(), out var valueOut);
        Value = valueOut;
      }
      else
      {
        Value = null;
      }

      if (stdev != null)
      {
        double.TryParse(stdev.ToString(), out var stdevOut);
        Stdev = stdevOut;
      }
      else
      {
        Stdev = null;
      }
    }

    public Property(IProperty property)
    {
      if (property != null)
      {
        Value = property.Value;
        Stdev = property.Stdev;
      }
    }

    public double? Value { get; }

    public double? Stdev { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      return $"{{\"value\":{Value?.ToString(ci)},\"stdev\":{Stdev?.ToString(ci)}}}";
    }

    public bool Equals(Property other)
    {
      if (other == null)
        return false;
      return Value.Equals(other.Value) && Stdev.Equals(other.Stdev);
    }
    public override bool Equals(object obj)
    {
      return Equals(obj as Property);
    }

    public override int GetHashCode() => (Value, Stdev).GetHashCode();
  }
}
