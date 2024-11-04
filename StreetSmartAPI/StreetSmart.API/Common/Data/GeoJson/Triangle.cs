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
using System.Linq;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Triangle : NotifyPropertyChanged, ITriangle
  {
    public Triangle(IList<object> points)
    {
      Points = new List<int>();

      foreach (var point in points)
      {
        Points.Add(point as int? ?? 0);
      }
    }

    public Triangle(ITriangle triangle)
    {
      if (triangle?.Points != null)
      {
        Points = new List<int>();

        foreach (var point in triangle.Points)
        {
          Points.Add(point);
        }
      }
    }

    public IList<int> Points { get; }

    public override string ToString()
    {
      string result = Points.Aggregate("[", (current, point) => $"{current}{point},");
      return $"{result.Substring(0, Math.Max(result.Length - 1, 1))}]";
    }
  }
}
