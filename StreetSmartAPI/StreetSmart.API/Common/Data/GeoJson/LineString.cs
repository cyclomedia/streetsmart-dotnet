/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class LineString : List<ICoordinate>, ILineString
  {
    public LineString(Dictionary<string, object> lineString)
    {
      string type = lineString?["type"]?.ToString() ?? string.Empty;
      IList<object> coordinates = lineString?["coordinates"] as IList<object> ?? new List<object>();

      try
      {
        Type = (GeometryType) Enum.Parse(typeof(GeometryType), type);
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
      string coordinates = string.Empty;

      foreach (ICoordinate coordinate in this)
      {
        coordinates = $"{coordinates},{coordinate}";
      }

      coordinates = coordinates.Substring(Math.Min(coordinates.Length, 1));
      return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":[{coordinates}]}}";
    }
  }
}
