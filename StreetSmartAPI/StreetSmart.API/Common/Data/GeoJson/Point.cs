/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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
  internal class Point: Coordinate, IPoint
  {
    public Point(Dictionary<string, object> point)
      : base(new DataConvert().GetListValue(point, "coordinates"))
    {
      try
      {
        Type = (GeometryType) ToEnum(typeof(GeometryType), point, "type");
      }
      catch (ArgumentException)
      {
        Type = GeometryType.Unknown;
      }
    }

    public Point(double x, double y, double z)
      : base(x, y, z)
    {
      Type = GeometryType.Point;
    }

    public Point(double x, double y)
      : base(x, y)
    {
      Type = GeometryType.Point;
    }

    public Point(ICoordinate coordinate)
      : base(coordinate)
    {
      Type = GeometryType.Point;
    }

    public GeometryType Type { get; }

    public override string ToString()
    {
      return $"\"geometry\":{{\"type\":\"{Type.Description()}\",\"coordinates\":{base.ToString()}}}";
    }
  }
}
