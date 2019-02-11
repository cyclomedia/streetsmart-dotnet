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

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class CRS : DataConvert, ICRS
  {
    public CRS(Dictionary<string, object> crs)
    {
      string type = ToString(crs, "type");
      var properties = GetDictValue(crs, "properties");

      switch (type)
      {
        case "name":
          Type = CRSType.Name;
          break;
        case "epsg":
          Type = CRSType.Epsg;
          break;
        default:
          Type = CRSType.NotDefined;
          break;
      }

      switch (Type)
      {
        case CRSType.Name:
        case CRSType.Epsg:
          Properties = ToString(properties, Type == CRSType.Name ? "name" : "code");
          break;
        case CRSType.NotDefined:
          Properties = string.Empty;
          break;
      }
    }

    public CRS(int wkid)
    {
      Type = CRSType.Epsg;
      Properties = wkid.ToString();
    }

    public CRS(ICRS crs)
    {
      if (crs != null)
      {
        Type = crs.Type;
        Properties = crs.Properties != null ? string.Copy(crs.Properties): null;
      }
    }

    public CRSType Type { get; }

    public string Properties { get; }

    public override string ToString()
    {
      string properties = Type == CRSType.Epsg ? "code" : "name";
      return $"\"crs\":{{\"type\":\"{Type.Description()}\",\"properties\":{{\"{properties}\":\"{Properties}\"}}}}";
    }
  }
}
