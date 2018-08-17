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

using StreetSmart.Wpf.Interfaces.Data;
using StreetSmart.Wpf.Interfaces.GeoJson;

namespace StreetSmart.Wpf.Data.GeoJson
{
  internal class LineString : List<ICoordinate>, ILineString
  {
    public LineString(Dictionary<string, object> lineString)
    {
      string type = lineString?["type"]?.ToString() ?? string.Empty;
      IList<object> coordinates = lineString?["coordinates"] as IList<object> ?? new List<object>();

      try
      {
        Type = (MeasurementGeometryType) Enum.Parse(typeof(MeasurementGeometryType), type);
      }
      catch (ArgumentException)
      {
        Type = MeasurementGeometryType.Unknown;
      }

      foreach (var coordinate in coordinates)
      {
        Add(new Coordinate(coordinate as IList<object>));
      }
    }

    public MeasurementGeometryType Type { get; }
  }
}
