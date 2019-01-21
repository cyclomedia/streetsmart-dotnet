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
      string measurementTool = properties?["measurementTool"]?.ToString() ?? string.Empty;
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

      switch (measurementTool)
      {
        case "MAP":
          MeasurementTool = MeasurementTools.Map;
          break;
        case "PANORAMA":
          MeasurementTool = MeasurementTools.Panorama;
          break;
        case "POINTCLOUD":
          MeasurementTool = MeasurementTools.PointCloud;
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
      Add("measurementTool", MeasurementTool);
    }

    public MeasurementProperties(IMeasurementProperties properties)
    {
      if (properties != null)
      {
        Id = properties.Id != null ? string.Copy(properties.Id) : null;
        Name = properties.Name != null ? string.Copy(properties.Name) : null;
        Group = properties.Group != null ? string.Copy(properties.Group) : null;

        if (properties.MeasureDetails != null)
        {
          MeasureDetails = new List<IMeasureDetails>();

          foreach (var measureDetail in properties.MeasureDetails)
          {
            MeasureDetails.Add(new MeasureDetails(measureDetail));
          }
        }

        Dimension = properties.Dimension;
        CustomGeometryType = properties.CustomGeometryType;
        IDerivedData derivedData = properties.DerivedData;

        switch (derivedData)
        {
          case IDerivedDataPoint point:
            DerivedData = new DerivedDataPoint(point);
            break;
          case IDerivedDataPolygon polygon:
            DerivedData = new DerivedDataPolygon(polygon);
            break;
          case IDerivedDataLineString lineString:
            DerivedData = new DerivedDataLineString(lineString);
            break;
        }

        MeasureReliability = properties.MeasureReliability;

        if (properties.PointsWithErrors != null)
        {
          PointsWithErrors = new List<int>();

          foreach (int pointWithError in properties.PointsWithErrors)
          {
            PointsWithErrors.Add(pointWithError);
          }
        }

        ValidGeometry = properties.ValidGeometry;
        ObservationLines = new ObservationLines(properties.ObservationLines);
        MeasurementTool = properties.MeasurementTool;

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
        Add("measurementTool", MeasurementTool);
      }
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

    public MeasurementTools MeasurementTool { get; }

    public override string ToString()
    {
      string pointsWithErrors = PointsWithErrors.Aggregate("[", (current, point) => $"{current}{point},");
      string pointsWithErrorsStr = $"{pointsWithErrors.Substring(0, Math.Max(pointsWithErrors.Length - 1, 1))}]";

      string measureDetails = MeasureDetails.Aggregate("[", (current, detail) => $"{current}{detail},");
      string measureDetailsStr = $"{measureDetails.Substring(0, Math.Max(measureDetails.Length - 1, 1))}]";

      string properties = $"\"id\":\"{Id}\",\"name\":\"{Name}\",\"group\":\"{Group}\",\"measureDetails\":{measureDetailsStr},\"dimension\":{Dimension}" +
                          $",\"customGeometryType\":\"{CustomGeometryType.Description()}\",\"derivedData\":{DerivedData}" +
                          $",\"measureReliability\":\"{MeasureReliability.Description()}\",\"pointsWithErrors\":{pointsWithErrorsStr}" +
                          $",\"validGeometry\":{ValidGeometry.ToJsBool()},\"observationLines\":{ObservationLines}" +
                          $",\"measurementTool\":\"{MeasurementTool.Description()}\"";

      return $"\"properties\":{{{properties}}}";
    }
  }
}
