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

using StreetSmart.WinForms.Interfaces.Data;
using StreetSmart.WinForms.Interfaces.GeoJson;

namespace StreetSmart.WinForms.Data.GeoJson
{
  internal class Feature : NotifyPropertyChanged, IFeature
  {
    public Feature(Dictionary<string, object> feature)
    {
      string type = feature?["type"]?.ToString() ?? string.Empty;
      Dictionary<string, object> geometry = feature?["geometry"] as Dictionary<string, object>;
      Dictionary<string, object> properties = feature?["properties"] as Dictionary<string, object>;

      Geometry geom = new Geometry(geometry);
      Properties = new Properties(properties, geom.Type);

      try
      {
        Type = (FeatureType) Enum.Parse(typeof(FeatureType), type);
      }
      catch (ArgumentException)
      {
        Type = FeatureType.Unknown;
      }

      switch (geom.Type)
      {
        case MeasurementGeometryType.Point:
          Geometry = new Point(geometry);
          break;
        case MeasurementGeometryType.LineString:
          Geometry = new LineString(geometry);
          break;
        case MeasurementGeometryType.Polygon:
          Geometry = new Polygon(geometry);
          break;
        case MeasurementGeometryType.Unknown:
          Geometry = null;
          break;
      }
    }

    public FeatureType Type { get; }

    public IGeometry Geometry { get; set; }

    public IProperties Properties { get; }
  }
}
