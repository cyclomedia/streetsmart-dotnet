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
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Feature : DataConvert, IFeature, IEquatable<IFeature>
  {
    public Feature(object feature, bool measurementProperties)
    {
      GetFeature(ToDictionary(feature), measurementProperties);
    }

    public void GetFeature(IDictionary<string, object> feature, bool measurementProperties)
    {
      var geometry = GetDictValue(feature, "geometry");
      var properties = GetDictValue(feature, "properties");

      Geometry geom = new(geometry);
      Properties = measurementProperties
        ? new MeasurementProperties(properties, geom.Type)
        : new Properties(properties);

      try
      {
        Type = (FeatureType)ToEnum(typeof(FeatureType), feature, "type");
      }
      catch (ArgumentException)
      {
        Type = FeatureType.Unknown;
      }

      switch (geom.Type)
      {
        case GeometryType.Point:
          Geometry = new Point(geometry);
          break;
        case GeometryType.LineString:
          Geometry = new LineString(geometry);
          break;
        case GeometryType.Polygon:
          Geometry = new Polygon(geometry);
          break;
        case GeometryType.Unknown:
          Geometry = null;
          break;
      }
    }

    public Feature(IGeometry geometry)
    {
      Type = FeatureType.Feature;
      Geometry = geometry;
      Properties = new Properties();
    }

    public Feature(IFeature feature)
    {
      if (feature != null)
      {
        Type = feature.Type;

        if (feature.Geometry != null)
        {
          switch (feature.Geometry.Type)
          {
            case GeometryType.Point:
              Geometry = new Point((IPoint)feature.Geometry);
              break;
            case GeometryType.LineString:
              Geometry = new LineString((ILineString)feature.Geometry);
              break;
            case GeometryType.Polygon:
              Geometry = new Polygon((IPolygon)feature.Geometry);
              break;
            case GeometryType.Unknown:
              Geometry = null;
              break;
          }
        }

        if (feature.Properties is IMeasurementProperties properties)
        {
          Properties = new MeasurementProperties(properties);
        }
        else
        {
          Properties = new Properties(feature.Properties);
        }
      }
    }

    public FeatureType Type { get; private set; }

    public IGeometry Geometry { get; set; }

    public IProperties Properties { get; private set; }
    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append($"{{\"type\":\"{Type.Description()}\",");
      sb.Append($"{Geometry},");
      sb.Append($"{Properties}");
      sb.Append("}");

      return $"{sb}";
    }
    public bool Equals(IFeature other)
    {
      if (other == null) return false;
      return Type.Equals(other.Type) &&
             Geometry.Equals(other.Geometry) &&
             Properties.Equals(other.Properties);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Feature);
    }

    public override int GetHashCode() => (Type, Geometry, Properties).GetHashCode();
  }
}
