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
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class LineString : List<ICoordinate>, ILineString, IEquatable<LineString>
  {
    public LineString(IDictionary<string, object> lineString)
    {
      DataConvert converter = new DataConvert();
      var coordinates = converter.GetListValue(lineString, "coordinates");

      try
      {
        Type = (GeometryType)converter.ToEnum(typeof(GeometryType), lineString, "type");
      }
      catch (ArgumentException)
      {
        Type = GeometryType.Unknown;
      }

      foreach (var coordinate in coordinates)
      {
        Add(new Coordinate(coordinate as IList<object>));
      }
    }

    public LineString(IList<ICoordinate> coordinates)
    {
      Type = GeometryType.LineString;

      foreach (ICoordinate coordinate in coordinates)
      {
        Add(coordinate);
      }
    }

    public GeometryType Type { get; }

    public override string ToString()
    {
      var coordinates = new StringBuilder();

      foreach (ICoordinate coordinate in this)
      {
        if (coordinates.Length > 0)
        {
          coordinates.Append(",");
        }

        coordinates.Append(coordinate);
      }

      return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":[{coordinates}]}}";
    }

    public bool Equals(LineString other)
    {
      if (other == null)
      {
        return false;
      }

      if (Count != other.Count)
      {
        return false;
      }

      for (int i = 0; i < Count; i++)
      {
        if (!this[i].Equals(other[i]))
        {
          return false;
        }

      }
      return Type.Equals(other.Type);

    }

    public override bool Equals(object obj)
    {
      return Equals(obj as LineString);
    }

    public override int GetHashCode() => (Type, this).GetHashCode();
  }
}
