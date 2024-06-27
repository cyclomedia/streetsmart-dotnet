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
  internal class MeasurementProperties : Properties, IMeasurementProperties, IEquatable<MeasurementProperties>
  {
    public MeasurementProperties(Dictionary<string, object> properties, GeometryType geometryType)
    {
      DataConvert converter = new DataConvert();
      Id = converter.ToString(properties, "id");
      Name = converter.ToString(properties, "name");
      Group = converter.ToString(properties, "group");
      var measureDetails = converter.GetListValue(properties, "measureDetails");
      FontSize = converter.ToNullInt(properties, "fontsize");
      Dimension = converter.ToInt(properties, "dimension");
      var derivedData = converter.GetDictValue(properties, "derivedData");
      string measureReliability = converter.ToString(properties, "measureReliability");
      string measurementTool = converter.ToString(properties, "measurementTool");
      var pointsWithErrors = converter.GetListValue(properties, "pointsWithErrors");
      ValidGeometry = converter.ToBool(properties, "validGeometry");
      var observationLines = converter.GetDictValue(properties, "observationLines");

      MeasureDetails = new List<IMeasureDetails>();
      PointsWithErrors = new List<int>();
      ObservationLines = new ObservationLines(observationLines);
      var wgsGeometry = converter.GetDictValue(properties, "wgsGeometry");

      if (wgsGeometry != null)
      {
        switch (geometryType)
        {
          case GeometryType.Point:
            WgsGeometry = new Point(wgsGeometry);
            break;
          case GeometryType.LineString:
            WgsGeometry = new LineString(wgsGeometry);
            break;
          case GeometryType.Polygon:
            WgsGeometry = new Polygon(wgsGeometry);
            break;
          case GeometryType.Unknown:
            WgsGeometry = null;
            break;
        }

        Add("WgsGeometry", WgsGeometry);
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
        case "OBLIQUE":
          MeasurementTool = MeasurementTools.Oblique;
          break;
      }

      foreach (var measureDetail in measureDetails)
      {
        MeasureDetails.Add(new MeasureDetails(converter.ToDictionary(measureDetail), MeasurementTool));
      }

      try
      {
        CustomGeometryType =
          (CustomGeometryType)converter.ToEnum(typeof(CustomGeometryType), properties, "customGeometryType");
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
      Add("MeasurementTool", MeasurementTool);

      if (FontSize != null)
      {
        Add("FontSize", FontSize);
      }
    }

    public MeasurementProperties(IMeasurementProperties properties)
    {
      if (properties != null)
      {
        Id = properties.Id;
        Name = properties.Name;
        Group = properties.Group;
        MeasurementTool = properties.MeasurementTool;

        if (properties.MeasureDetails != null)
        {
          MeasureDetails = new List<IMeasureDetails>();

          foreach (var measureDetail in properties.MeasureDetails)
          {
            MeasureDetails.Add(new MeasureDetails(measureDetail, MeasurementTool));
          }
        }

        Dimension = properties.Dimension;
        FontSize = properties.FontSize;
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
        IGeometry wgsGeometry = properties.WgsGeometry;

        switch (wgsGeometry)
        {
          case IPoint point:
            WgsGeometry = new Point(point);
            break;
          case ILineString lineString:
            WgsGeometry = new LineString(lineString);
            break;
          case IPolygon polygon:
            WgsGeometry = new Polygon(polygon);
            break;
        }

        if (WgsGeometry != null)
        {
          Add("WgsGeometry", WgsGeometry);
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
        Add("MeasurementTool", MeasurementTool);

        if (FontSize != null)
        {
          Add("FontSize", FontSize);
        }
      }
    }

    public string Id { get; }

    public string Name { get; set; }

    public string Group { get; }

    public IList<IMeasureDetails> MeasureDetails { get; }

    public int? FontSize { get; }

    public int Dimension { get; }

    public CustomGeometryType CustomGeometryType { get; }

    public IDerivedData DerivedData { get; }

    public Reliability MeasureReliability { get; }

    public IList<int> PointsWithErrors { get; }

    public bool ValidGeometry { get; }

    public IObservationLines ObservationLines { get; }

    public MeasurementTools MeasurementTool { get; }

    public IGeometry WgsGeometry { get; }

    public override string ToString()
    {
      var pointsWithErrorsBuilder = new StringBuilder("[");
      foreach (var point in PointsWithErrors)
      {
        if (pointsWithErrorsBuilder.Length > 1) pointsWithErrorsBuilder.Append(",");
        pointsWithErrorsBuilder.Append(point);
      }
      pointsWithErrorsBuilder.Append("]");
      string pointsWithErrorsStr = pointsWithErrorsBuilder.ToString();

      var measureDetailsBuilder = new StringBuilder("[");
      foreach (var detail in MeasureDetails)
      {
        if (measureDetailsBuilder.Length > 1) measureDetailsBuilder.Append(",");
        measureDetailsBuilder.Append(detail);
      }
      measureDetailsBuilder.Append("]");
      string measureDetailsStr = MeasureDetails.Count >= 1 || MeasurementTool == MeasurementTools.Oblique
          ? $",\"measureDetails\":{measureDetailsBuilder}"
          : string.Empty;

      string fontSize = FontSize == null ? string.Empty : $",\"fontSize\": {FontSize}";
      string customGeometryType = MeasurementTool == MeasurementTools.Oblique ? string.Empty : $",\"customGeometryType\":\"{CustomGeometryType.Description()}\"";
      string strGeometry = WgsGeometry == null ? string.Empty : $",{WgsGeometry.ToString().Replace("geometry", "wgsGeometry")}";

      var propertiesBuilder = new StringBuilder();
      propertiesBuilder.Append($"\"id\":\"{Id}\",\"name\":\"{Name}\",\"group\":\"{Group}\"{measureDetailsStr}{fontSize},\"dimension\":{Dimension}");
      propertiesBuilder.Append($"{customGeometryType},\"derivedData\":{DerivedData}");
      propertiesBuilder.Append($",\"measureReliability\":\"{MeasureReliability.Description()}\",\"pointsWithErrors\":{pointsWithErrorsStr}");
      propertiesBuilder.Append($",\"validGeometry\":{ValidGeometry.ToJsBool()},\"observationLines\":{ObservationLines}");
      propertiesBuilder.Append($"{strGeometry},\"measurementTool\":\"{MeasurementTool.Description()}\"");

      return $"\"properties\":{{{propertiesBuilder}}}";
    }

    public bool Equals(MeasurementProperties other)
    {
      if (other == null) return false;

      if ((MeasureDetails == null) != (other.MeasureDetails == null)) return false;

      if (MeasureDetails != null && other.MeasureDetails != null)
        if (MeasureDetails.Count == other.MeasureDetails.Count)
          for (int i = 0; i < MeasureDetails.Count; i++)
          {
            if (!MeasureDetails[i].Equals(other.MeasureDetails[i]))
              return false;
          }
        else
          return false;

      if ((PointsWithErrors == null) != (other.PointsWithErrors == null)) return false;
      
      if (PointsWithErrors != null && other.PointsWithErrors != null)
        if (PointsWithErrors.Count == other.PointsWithErrors.Count)
          for (int i = 0; i < PointsWithErrors.Count; i++)
          {
            if (!PointsWithErrors[i].Equals(other.PointsWithErrors[i]))
              return false;
          }
        else
          return false;

      return Id == other.Id &&
             Name == other.Name &&
             Group == other.Group &&
             Dimension == other.Dimension &&
             DerivedData.Equals(other.DerivedData) &&
             MeasureReliability.Equals(other.MeasureReliability) &&
             ValidGeometry == other.ValidGeometry &&
             ObservationLines.Equals(other.ObservationLines) &&
             MeasurementTool.Equals(other.MeasurementTool) &&
             (FontSize == other.FontSize || (FontSize != null && FontSize.Equals(other.FontSize))) &&
             (CustomGeometryType == other.CustomGeometryType || CustomGeometryType.Equals(other.CustomGeometryType)) &&
               (WgsGeometry == other.WgsGeometry || (WgsGeometry != null && WgsGeometry.Equals(other.WgsGeometry)));
    }
    public override bool Equals(object obj)
    {
      return Equals(obj as MeasurementProperties);
    }

    public override int GetHashCode() => (Id, Name, Group, Dimension, DerivedData, MeasureReliability, ValidGeometry, ObservationLines, MeasurementTool, FontSize, CustomGeometryType, WgsGeometry, PointsWithErrors, MeasureDetails).GetHashCode();
    //public override string ToString()
    //{
    //  string pointsWithErrors = PointsWithErrors.Aggregate("[", (current, point) => $"{current}{point},");
    //  string pointsWithErrorsStr = $"{pointsWithErrors.Substring(0, Math.Max(pointsWithErrors.Length - 1, 1))}]";

    //  string measureDetails = MeasureDetails.Aggregate("[", (current, detail) => $"{current}{detail},");
    //  string measureDetailsStr = MeasureDetails.Count >= 1 || MeasurementTool == MeasurementTools.Oblique
    //    ? $",\"measureDetails\":{measureDetails.Substring(0, Math.Max(measureDetails.Length - 1, 1))}]"
    //    : string.Empty;

    //  string fontSize = FontSize == null ? string.Empty : $",\"fontSize\": {FontSize}";
    //  string customGeometryType = MeasurementTool == MeasurementTools.Oblique ? string.Empty : $",\"customGeometryType\":\"{CustomGeometryType.Description()}\"";
    //  string strGeometry = WgsGeometry == null ? string.Empty : $",{WgsGeometry.ToString().Replace("geometry", "wgsGeometry")}";

    //  string properties = $"\"id\":\"{Id}\",\"name\":\"{Name}\",\"group\":\"{Group}\"{measureDetailsStr}{fontSize},\"dimension\":{Dimension}" +
    //                      $"{customGeometryType},\"derivedData\":{DerivedData}" +
    //                      $",\"measureReliability\":\"{MeasureReliability.Description()}\",\"pointsWithErrors\":{pointsWithErrorsStr}" +
    //                      $",\"validGeometry\":{ValidGeometry.ToJsBool()},\"observationLines\":{ObservationLines}" +
    //                      $"{strGeometry},\"measurementTool\":\"{MeasurementTool.Description()}\"";

    //  return $"\"properties\":{{{properties}}}";
    //}


  }
}
