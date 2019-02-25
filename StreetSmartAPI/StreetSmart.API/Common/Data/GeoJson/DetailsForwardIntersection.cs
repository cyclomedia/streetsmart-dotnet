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
using System.Globalization;
using System.Linq;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DetailsForwardIntersection : Details, IDetailsForwardIntersection
  {
    public DetailsForwardIntersection(Dictionary<string, object> detailsForwardIntersection)
    {
      double? positionX = ToNullDouble(detailsForwardIntersection, "PositionX");
      double? positionY = ToNullDouble(detailsForwardIntersection, "PositionY");
      double? positionZ = ToNullDouble(detailsForwardIntersection, "PositionZ");
      var resultDirections = GetDictValue(detailsForwardIntersection, "ResultDirections");
      var resultDirection = GetListValue(resultDirections, "ResultDirection");

      Position = new Position(positionX, positionY, positionZ);
      ResultDirections = new List<IResultDirection>();

      foreach (var intResultDirection in resultDirection)
      {
        ResultDirections.Add(new ResultDirection(intResultDirection as Dictionary<string, object>));
      }
    }

    public DetailsForwardIntersection(IDetailsForwardIntersection detailsForwardIntersection)
    {
      if (detailsForwardIntersection != null)
      {
        Position = new Position(detailsForwardIntersection.Position);

        if (detailsForwardIntersection.ResultDirections != null)
        {
          ResultDirections = new List<IResultDirection>();

          foreach (IResultDirection resultDirection in detailsForwardIntersection.ResultDirections)
          {
            ResultDirections.Add(new ResultDirection(resultDirection));
          }
        }
      }
    }

    public IPosition Position { get; }

    public IList<IResultDirection> ResultDirections { get; }

    public override string ToString()
    {
      string resultDirections = ResultDirections.Aggregate("[", (current, resultDirection) => $"{current}{resultDirection},");
      string resultDirectionsStr = $"{resultDirections.Substring(0, Math.Max(resultDirections.Length - 1, 1))}]";

      CultureInfo ci = CultureInfo.InvariantCulture;
      return $"{{\"PositionX\":{Position?.X?.ToString(ci)},\"PositionY\":{Position?.Y?.ToString(ci)},\"PositionZ\":{Position?.Z?.ToString(ci)}," +
             $"\"ResultDirections\":{{\"ResultDirection\":{resultDirectionsStr}}}}}";
    }
  }
}
