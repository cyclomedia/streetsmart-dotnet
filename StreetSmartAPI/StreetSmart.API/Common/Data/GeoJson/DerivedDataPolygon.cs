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
using System.Linq;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataPolygon : DerivedDataLineString, IDerivedDataPolygon
  {
    public DerivedDataPolygon(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      IList<object> triangles = GetValue(derivedData, "triangles") as IList<object> ?? new List<object>();
      Area = getStdValue(derivedData, "area");

      Triangles = new List<ITriangle>();

      for (int i = 0; i < triangles.Count; i++)
      {
        Triangles.Add(new Triangle(triangles[i] as IList<object> ?? new List<object>()));
      }
    }

    public DerivedDataPolygon(IDerivedDataPolygon derivedData)
      : base(derivedData)
    {
      if (derivedData != null)
      {
        if (derivedData.Triangles != null)
        {
          Triangles = new List<ITriangle>();

          foreach (ITriangle triangle in derivedData.Triangles)
          {
            Triangles.Add(new Triangle(triangle));
          }
        }

        Area = new Property(derivedData.Area);
      }
    }

    public IList<ITriangle> Triangles { get; }

    public IProperty Area { get; }

    public override string ToString()
    {
      string baseStr = base.ToString();
      string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));
      string comma = subStr.Length >= 2 ? "," : string.Empty;
      subStr = $"{subStr}{comma}";
      string triangles = Triangles.Aggregate("[", (current, triangle) => $"{current}{triangle},");
      return $"{subStr}{GetValueString(Area, "area")}\"triangles\":{triangles.Substring(0, Math.Max(triangles.Length - 1, 1))}]}}";
    }
  }
}
