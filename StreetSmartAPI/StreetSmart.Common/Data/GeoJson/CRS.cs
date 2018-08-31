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
  internal class CRS : NotifyPropertyChanged, ICRS
  {
    public CRS(Dictionary<string, object> crs)
    {
      string type = crs?["type"]?.ToString() ?? string.Empty;
      object properties = crs?["properties"];

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
          Dictionary<string, object> props = properties as Dictionary<string, object>;
          Properties = props?["name"] as string ?? string.Empty;
          break;
        case CRSType.Epsg:
        case CRSType.NotDefined:
          Properties = properties as string ?? string.Empty;
          break;
      }
    }

    public CRSType Type { get; }

    public string Properties { get; }
  }
}
