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
using System.Globalization;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataLineString : DerivedData, IDerivedDataLineString
  {
    public DerivedDataLineString(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      // ReSharper disable InconsistentNaming
      var coordinateStdevs = GetListValue(derivedData, "coordinateStdevs");
      TotalLength = getStdValue(derivedData, "totalLength");
      SegmentLengths = GetStdValueList(derivedData, "segmentLengths");
      SegmentsDeltaXY = GetStdValueList(derivedData, "segmentsDeltaXY");
      SegmentsDeltaZ = GetStdValueList(derivedData, "segmentsDeltaZ");
      SegmentsSlopePercentage = GetStdValueList(derivedData, "segmentsSlopePercentage");
      SegmentsSlopeAngle = GetStdValueList(derivedData, "segmentsSlopeAngle");
      DeltaXY = getStdValue(derivedData, "deltaXY");
      DeltaZ = getStdValue(derivedData, "deltaZ");
      // ReSharper restore InconsistentNaming

      CoordinateStdev = new List<IStdev>();

      foreach (var coordinateStdev in coordinateStdevs)
      {
        CoordinateStdev.Add(new Stdev(coordinateStdev as Dictionary<string, object>));
      }
    }

    public DerivedDataLineString(IDerivedDataLineString derivedData)
      : base(derivedData)
    {
      if (derivedData != null)
      {
        if (derivedData.CoordinateStdev != null)
        {
          CoordinateStdev = new List<IStdev>();

          foreach (IStdev stdev in derivedData.CoordinateStdev)
          {
            CoordinateStdev.Add(new Stdev(stdev));
          }
        }

        TotalLength = new Property(derivedData.TotalLength);
        SegmentLengths = GetStdValueList(derivedData.SegmentLengths);
        SegmentsDeltaXY = GetStdValueList(derivedData.SegmentsDeltaXY);
        SegmentsDeltaZ = GetStdValueList(derivedData.SegmentsDeltaZ);
        SegmentsSlopePercentage = GetStdValueList(derivedData.SegmentsSlopePercentage);
        SegmentsSlopeAngle = GetStdValueList(derivedData.SegmentsSlopeAngle);
        DeltaXY = new Property(derivedData.DeltaXY);
        DeltaZ = new Property(derivedData.DeltaZ);
      }
    }

    public IList<IStdev> CoordinateStdev { get; }

    public IProperty TotalLength { get; }

    public IList<IProperty> SegmentLengths { get; }

    // ReSharper disable once InconsistentNaming
    public IList<IProperty> SegmentsDeltaXY { get; }

    public IList<IProperty> SegmentsDeltaZ { get; }

    public IList<IProperty> SegmentsSlopePercentage { get; }

    public IList<IProperty> SegmentsSlopeAngle { get; }

    public IProperty DeltaXY { get; }

    public IProperty DeltaZ { get; }

    private IList<IProperty> GetStdValueList(Dictionary<string, object> derivedData, string key)
    {
      var input = GetDictValue(derivedData, key);
      List<IProperty> result = null;

      if (GetValue(input, "value") is IList<object> value)
      {
        var stdevstList = GetListValue(input, "stdev");
        result = new List<IProperty>();

        for (int i = 0; i < value.Count; i++)
        {
          result.Add(new Property(value[i], stdevstList != null && i < stdevstList.Count ? stdevstList[i] : null));
        }
      }

      return result;
    }

    private IList<IProperty> GetStdValueList(IList<IProperty> properties)
    {
      List<IProperty> result = null;

      if (properties != null)
      {
        result = new List<IProperty>();

        foreach (IProperty property in properties)
        {
          result.Add(new Property(property));
        }
      }

      return result;
    }

    protected IProperty getStdValue(Dictionary<string, object> derivedData, string key)
    {
      var input = GetDictValue(derivedData, key);
      IProperty result = null;

      if (input.Count >= 1)
      {
        double? stdev = ToNullDouble(input, "stdev");
        result = new Property(ToDouble(input, "value"), stdev);
      }

      return result;
    }

    private string GetValueString(IList<IProperty> propertyList, string propertyName)
    {
      string result = string.Empty;

      if (propertyList != null)
      {
        CultureInfo ci = CultureInfo.InvariantCulture;
        string value = "\"value\":[";
        string stdev = "\"stdev\":[";

        foreach (IProperty property in propertyList)
        {
          string valueStr = double.IsNaN(property?.Value ?? double.NaN) ? null : property?.Value?.ToString(ci);
          string stdevStr = double.IsNaN(property?.Stdev ?? double.NaN) ? null : property?.Stdev?.ToString(ci);
          valueStr = string.IsNullOrEmpty(valueStr) ? "null" : valueStr;
          stdevStr = string.IsNullOrEmpty(stdevStr) ? "null" : stdevStr;
          value = $"{value}{valueStr},";
          stdev = $"{stdev}{stdevStr},";
        }

        if (propertyList.Count >= 1)
        {
          value = value.Substring(0, value.Length - 1);
          stdev = stdev.Substring(0, stdev.Length - 1);
        }

        result = $"\"{propertyName}\":{{{value}],{stdev}]}},";
      }

      return result;
    }

    protected string GetValueString(IProperty property, string propertyName)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string value = property?.Value?.ToString(ci);
      string stdev = property?.Stdev?.ToString(ci);
      string valueStr = string.IsNullOrEmpty(value) ? string.Empty : $"\"value\":{property.Value?.ToString(ci)}";
      string stdevStr = string.IsNullOrEmpty(stdev) ? string.Empty : $"\"stdev\":{property.Stdev?.ToString(ci)}";
      string comma = !string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(stdev) ? "," : string.Empty;
      return property == null ? string.Empty : $"\"{propertyName}\":{{{valueStr}{comma}{stdevStr}}},";
    }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string stdevs = "[";

      foreach (IStdev stdev in CoordinateStdev)
      {
        string stdevX = stdev?.X?.ToString(ci);
        string stdevY = stdev?.Y?.ToString(ci);
        string stdevZ = stdev?.Z?.ToString(ci);
        bool noStdev = string.IsNullOrEmpty(stdevX) && string.IsNullOrEmpty(stdevY) && string.IsNullOrEmpty(stdevZ);
        stdevs = noStdev ? $"{stdevs}null," : $"{stdevs}{{\"0\":{stdevX},\"1\":{stdevY},\"2\":{stdevZ}}},";
      }

      stdevs = $"{stdevs.Substring(0, Math.Max(stdevs.Length - 1, 1))}]";
      string baseStr = base.ToString();
      string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));
      string comma = subStr.Length >= 2 ? "," : string.Empty;
      subStr = $"{subStr}{comma}";

      return
        $"{subStr}{GetValueString(TotalLength, "totalLength")}{GetValueString(SegmentLengths, "segmentLengths")}" +
        $"{GetValueString(SegmentsDeltaXY, "segmentsDeltaXY")}{GetValueString(SegmentsDeltaZ, "segmentsDeltaZ")}" +
        $"{GetValueString(SegmentsSlopePercentage, "segmentsSlopePercentage")}{GetValueString(SegmentsSlopeAngle, "segmentsSlopeAngle")}" +
        $"{GetValueString(DeltaXY, "deltaXY")}{GetValueString(DeltaZ, "deltaZ")}\"coordinateStdevs\":{stdevs}}}";
    }
  }
}
