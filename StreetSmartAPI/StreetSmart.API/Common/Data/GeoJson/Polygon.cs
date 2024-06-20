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
using System.Linq;
using System.Text;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Polygon : List<IList<ICoordinate>>, IPolygon, IEquatable<Polygon>
  {
    public Polygon(Dictionary<string, object> polygon)
    {
      DataConvert converter = new DataConvert();
      var coordinates = converter.GetListValue(polygon, "coordinates");

      try
      {
        Type = (GeometryType) converter.ToEnum(typeof(GeometryType), polygon, "type");
      }
      catch (ArgumentException)
      {
        Type = GeometryType.Unknown;
      }

      foreach (var ring in coordinates)
      {
        List<ICoordinate> coordinateList = new List<ICoordinate>();

        foreach (var coordinate in ring as IList<object> ?? new List<object>())
        {
          coordinateList.Add(new Coordinate(coordinate as IList<object>));
        }

        Add(coordinateList);
      }
    }

    public Polygon(IList<IList<ICoordinate>> coordinates)
    {
      Type = GeometryType.Polygon;

      foreach (var ring in coordinates)
      {
        List<ICoordinate> coordinateList = new List<ICoordinate>();

        foreach (var coordinate in ring)
        {
          coordinateList.Add(coordinate);
        }

        Add(coordinateList);
      }
    }

    public Polygon(IList<object> coordinates)
    {
      Type = GeometryType.Polygon;

      foreach (var ring in coordinates)
      {
        List<ICoordinate> coordinateList = new List<ICoordinate>();

        foreach (IList<object> coordinate in ring as IList<object> ?? new List<object>())
        {
          coordinateList.Add(new Coordinate(coordinate));
        }

        Add(coordinateList);
      }
    }

    public GeometryType Type { get; }

    public override string ToString()
    {
      var coordinatesList = new StringBuilder();

      foreach (IList<ICoordinate> coordinateList in this)
      {
        var coordinates = new StringBuilder();

        foreach (ICoordinate coordinate in coordinateList)
        {
          if (coordinates.Length > 0)
            coordinates.Append(",");
          coordinates.Append(coordinate);
        }

        if (coordinatesList.Length > 0)
          coordinatesList.Append(",");
        coordinatesList.Append($"[{coordinates}]");
      }

      return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":[{coordinatesList}]}}";
    }

    public bool Equals(Polygon other)
    {
      if (other == null) return false;
      return Type.Equals(other.Type) &&
             this.SelectMany(x => x).SequenceEqual(other.SelectMany(x => x));
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Polygon);
    }

    public override int GetHashCode() => (Type, this).GetHashCode();

    //public override string ToString()
    //{
    //  var coordinatesList = this.Select(coordinateList =>
    //      $"[{string.Join(",", coordinateList)}]"
    //  );

    //  return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":[{string.Join(",", coordinatesList)}]}}";
    //}


    /*
    public override string ToString()
    {
      string coordinatesList = string.Empty;

      foreach (IList<ICoordinate> coordinateList in this)
      {
        string coordinates = string.Empty;

        foreach (ICoordinate coordinate in coordinateList)
        {
          coordinates = $"{coordinates},{coordinate}";
        }

        coordinates = coordinates.Substring(Math.Min(coordinates.Length, 1));
        coordinatesList = $"{coordinatesList},[{coordinates}]";
      }

      coordinatesList = coordinatesList.Substring(Math.Min(coordinatesList.Length, 1));
      return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":[{coordinatesList}]}}";
    }*/
  }
}
