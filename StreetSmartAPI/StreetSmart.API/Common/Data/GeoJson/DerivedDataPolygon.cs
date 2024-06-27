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
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  public class DerivedDataPolygon : DerivedDataLineString, IDerivedDataPolygon, IEquatable<DerivedDataPolygon>
  {
    public DerivedDataPolygon(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      var triangles = GetListValue(derivedData, "triangles");
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
      string subStr = baseStr.TrimEnd(',');
      string comma = subStr.Length >= 1 ? "," : string.Empty;

      var sb = new StringBuilder();
      sb.Append(subStr);
      sb.Append(comma);

      if (Triangles.Count > 0)
      {
        sb.Append("\"triangles\":[");
        sb.Append(string.Join(",", Triangles.Select(t => t.ToString())));
        sb.Append("]");
      }
      else
      {
        sb.Append("\"triangles\":null");
      }

      sb.Append(GetValueString(Area, "area"));

      sb.Insert(0, "{");
      sb.Append("}");

      return $"{sb}";
    }

    public bool Equals(DerivedDataPolygon other)
    {
      if (other == null) return false;

      if ((Triangles == null) != (other.Triangles == null)) return false;

      if (Triangles != null && other.Triangles != null)
        if (Triangles.Count == other.Triangles.Count)
          for (int i = 0; i < Triangles.Count; i++)
          {
            if (!Triangles[i].Equals(other.Triangles[i]))
              return false;
          }
        else
          return false;

      if ((Area == null) != (other.Area == null)) return false;

      if (Area != null && other.Area != null)
        if (!Area.Equals(other.Area)) return false;

      return other.Unit.Equals(this.Unit) &&
             other.Precision.Equals(this.Precision);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as DerivedDataPolygon);
    }

    public override int GetHashCode() => (Triangles, Area).GetHashCode();

    //public override string ToString()
    //{
    //  string baseStr = base.ToString();
    //  string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));
    //  string comma = subStr.Length >= 2 ? "," : string.Empty;
    //  subStr = $"{subStr}{comma}";
    //  string triangles = "null";

    //  if (Triangles.Count >= 1)
    //  {
    //    triangles = Triangles.Aggregate("[", (current, triangle) => $"{current}{triangle},");
    //    triangles = $"{triangles.Substring(0, Math.Max(triangles.Length - 1, 1))}]";
    //  }

    //  return $"{subStr}{GetValueString(Area, "area")}\"triangles\":{triangles}}}";
    //}

    /* private string GetValueString(object value, string propertyName)
     {
       if (value == null)
         return string.Empty;

       return $",\"{propertyName}\":{value}";
     }*/

  }
}
