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

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Geometry : DataConvert, IGeometry, IEquatable<Geometry>
  {
    public Geometry(IDictionary<string, object> geometry)
    {
      try
      {
        Type = (GeometryType)ToEnum(typeof(GeometryType), geometry, "type");
      }
      catch (ArgumentException)
      {
        Type = GeometryType.Unknown;
      }
    }

    public GeometryType Type { get; }

    public override string ToString()
    {
      return $"\"geometry\":{{\"type\":\"{Type.Description()}\"}}";
    }

    public bool Equals(Geometry other)
    {
      if (other == null)
      {
        return false;
      }

      return Type.Equals(other.Type);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Geometry);
    }

    public override int GetHashCode()
    {
      return Type.GetHashCode();
    }
  }
}
