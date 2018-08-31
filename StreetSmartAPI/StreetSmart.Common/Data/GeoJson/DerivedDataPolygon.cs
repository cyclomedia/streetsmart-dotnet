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

using System.Collections.Generic;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataPolygon : DerivedDataLineString, IDerivedDataPolygon
  {
    public DerivedDataPolygon(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      IList<object> triangles = derivedData?.ContainsKey("triangles") ?? false
        ? derivedData["triangles"] as IList<object> ?? new List<object>()
        : new List<object>();
      Area = getStdValue(derivedData, "area");

      Triangles = new List<ITriangle>();

      for (int i = 0; i < triangles.Count; i++)
      {
        Triangles.Add(new Triangle(triangles[i] as IList<object> ?? new List<object>()));
      }
    }

    public IList<ITriangle> Triangles { get; }

    public IProperty Area { get; }
  }
}
