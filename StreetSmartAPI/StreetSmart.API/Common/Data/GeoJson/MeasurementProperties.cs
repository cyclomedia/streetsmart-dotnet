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
  internal class MeasurementProperties: Properties, IMeasurementProperties
  {
    public MeasurementProperties(Dictionary<string, object> properties, GeometryType geometryType)
    {
      Id = properties?["id"]?.ToString() ?? string.Empty;
      Name = properties?["name"]?.ToString() ?? string.Empty;
      Group = properties?["group"]?.ToString() ?? string.Empty;
      IList<object> measureDetails = properties?["measureDetails"] as IList<object> ?? new List<object>();
      Dimension = properties?["dimension"] as int? ?? 0;
      string customGeometryType = properties?["customGeometryType"]?.ToString() ?? string.Empty;
      Dictionary<string, object> derivedData = properties?["derivedData"] as Dictionary<string, object>;
      string measureReliability = properties?["measureReliability"]?.ToString() ?? string.Empty;
      IList<object> pointsWithErrors = properties?["pointsWithErrors"] as IList<object> ?? new List<object>();
      ValidGeometry = properties?["validGeometry"] as bool? ?? false;
      Dictionary<string, object> observationLines = properties?.ContainsKey("observationLines") ?? false
        ? properties["observationLines"] as Dictionary<string, object>
        : null;

      MeasureDetails = new List<IMeasureDetails>();
      PointsWithErrors = new List<int>();
      ObservationLines = new ObservationLines(observationLines);

      foreach (var measureDetail in measureDetails)
      {
        MeasureDetails.Add(new MeasureDetails(measureDetail as Dictionary<string, object>));
      }

      try
      {
        CustomGeometryType = (CustomGeometryType) Enum.Parse(typeof(CustomGeometryType), customGeometryType);
      }
      catch (ArgumentException)
      {
        CustomGeometryType = CustomGeometryType.NotDefined;
      }

      switch (geometryType)
      {
        case GeometryType.Point:
          DerivedData = new DerivedDataPoint(derivedData);
          break;
        case GeometryType.LineString:
          DerivedData = new DerivedDataLineString(derivedData);
          break;
        case GeometryType.Polygon:
          DerivedData = new DerivedDataPolygon(derivedData);
          break;
        case GeometryType.Unknown:
          DerivedData = null;
          break;
      }

      switch (measureReliability)
      {
        case "RELIABLE":
          MeasureReliability = Reliability.Reliable;
          break;
        case "ACCEPTABLE":
          MeasureReliability = Reliability.Acceptable;
          break;
        case "UNRELIABLE":
          MeasureReliability = Reliability.Unreliable;
          break;
      }

      foreach (var pointsWithError in pointsWithErrors)
      {
        PointsWithErrors.Add(pointsWithError as int? ?? 0);
      }

      Add("Id", Id);
      Add("Name", Name);
      Add("Group", Group);
      Add("MeasureDetails", MeasureDetails);
      Add("Dimension", Dimension);
      Add("CustomGeometryType", CustomGeometryType);
      Add("DerivedData", DerivedData);
      Add("MeasureReliability", MeasureReliability);
      Add("PointsWithErrors", PointsWithErrors);
      Add("ValidGeometry", ValidGeometry);
      Add("ObservationLines", ObservationLines);
    }

    public string Id { get; }

    public string Name { get; set; }

    public string Group { get; }

    public IList<IMeasureDetails> MeasureDetails { get; }

    public int Dimension { get; }

    public CustomGeometryType CustomGeometryType { get; }

    public IDerivedData DerivedData { get; }

    public Reliability MeasureReliability { get; }

    public IList<int> PointsWithErrors { get; }

    public bool ValidGeometry { get; }

    public IObservationLines ObservationLines { get; }
  }
}
