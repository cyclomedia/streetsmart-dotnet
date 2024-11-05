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
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataPolygon : DerivedDataLineString, IDerivedDataPolygon, IEquatable<DerivedDataPolygon>
  {
    public DerivedDataPolygon(IDictionary<string, object> derivedData)
      : base(derivedData)
    {
      var triangles = GetListValue(derivedData, "triangles");
      Area = GetStdValue(derivedData, "area");
      Triangles = new List<ITriangle>(triangles.Count);
      for (int i = 0; i < triangles.Count; i++)
      {
        Triangles.Add(new Triangle(triangles[i] as IList<object> ?? []));
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
      string baseSubStr = base.ToString().TrimEnd('}');
      var sb = new StringBuilder();
      sb.Append(baseSubStr);
      if (baseSubStr.Length >= 1)
      {
        sb.Append(',');
      }
      
      if (Triangles.Count > 0)
      {
        sb.Append("\"triangles\":[");
        sb.Append(string.Join(",", Triangles.Select(t => t.ToString())));
        sb.Append(']');
      }
      else
      {
        sb.Append("\"triangles\":null");
      }

      sb.Append(GetValueString(Area, "area"));
      sb.Append('}');

      return sb.ToString();
    }

    public bool Equals(DerivedDataPolygon other)
    {
      if (other == null)
      {
        return false;
      }

      if (Triangles == null != (other.Triangles == null))
      {
        return false;
      }

      if (Triangles != null && other.Triangles != null)
      {
        if (Triangles.Count == other.Triangles.Count)
        {
          for (int i = 0; i < Triangles.Count; i++)
          { if (!Triangles[i].Equals(other.Triangles[i]))
            {
              return false;
            }
          }
        }
        else
        {
          return false;
        }
      }

      if (Area == null != (other.Area == null))
      {
        return false;
      }

      if (Area != null && other.Area != null && !Area.Equals(other.Area))
      {
        return false;
      }

      return other.Unit.Equals(Unit) && other.Precision.Equals(Precision);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as DerivedDataPolygon);
    }

    public override int GetHashCode() => (Triangles, Area).GetHashCode();
  }
}
