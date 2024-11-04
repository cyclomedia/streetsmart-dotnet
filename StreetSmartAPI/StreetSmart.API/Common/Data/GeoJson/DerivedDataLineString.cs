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
using System.Globalization;
using System.Text;

#if NETCOREAPP
using System.Dynamic;
using System.Linq;
#endif

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataLineString : DerivedData, IDerivedDataLineString, IEquatable<DerivedDataLineString>
  {
    public DerivedDataLineString(IDictionary<string, object> derivedData)
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

      CoordinateStdev = new List<IStdev>(coordinateStdevs.Count);

      foreach (var coordinateStdev in coordinateStdevs)
      {
#if NETCOREAPP
        CoordinateStdev.Add(new Stdev((coordinateStdev as IDictionary<string, object>)?.ToDictionary(pair => pair.Key, pair => pair.Value)));
#else
        CoordinateStdev.Add(new Stdev(coordinateStdev as IDictionary<string, object>));
#endif
      }
    }

    public DerivedDataLineString(IDerivedDataLineString derivedData)
      : base(derivedData)
    {
      if (derivedData == null)
      {
        return;
      }

      if (derivedData.CoordinateStdev != null)
      {
        CoordinateStdev = new List<IStdev>(derivedData.CoordinateStdev.Count);

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

    private IList<IProperty> GetStdValueList(IDictionary<string, object> derivedData, string key)
    {
      var input = GetDictValue(derivedData, key);
      if (GetValue(input, "value") is not IList<object> value)
      {
        return null;
      }

      var stdevstList = GetListValue(input, "stdev");
      var result = new List<IProperty>(value.Count);
      for (int i = 0; i < value.Count; i++)
      {
        result.Add(new Property(value[i], stdevstList != null && i < stdevstList.Count ? stdevstList[i] : null));
      }

      return result;
    }

    private IList<IProperty> GetStdValueList(IList<IProperty> properties)
    {
      if (properties == null)
      {
        return null;
      }

      var result = new List<IProperty>(properties.Count);
      foreach (IProperty property in properties)
      {
        result.Add(new Property(property));
      }

      return result;
    }

    protected IProperty getStdValue(IDictionary<string, object> derivedData, string key)
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
      if (propertyList == null)
      {
        return string.Empty;
      }

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

      return $"\"{propertyName}\":{{{value}],{stdev}]}},";
    }

    protected string GetValueString(IProperty property, string propertyName)
    {
      if (property == null)
      {
        return string.Empty;
      }

      CultureInfo ci = CultureInfo.InvariantCulture;
      var sb = new StringBuilder();
      string value = property.Value?.ToString(ci);
      string stdev = property.Stdev?.ToString(ci);

      if (!string.IsNullOrEmpty(value) || !string.IsNullOrEmpty(stdev))
      {
        sb.Append($"\"{propertyName}\":{{");

        if (!string.IsNullOrEmpty(value))
        {
          sb.Append($"\"value\":{value}");
          if (!string.IsNullOrEmpty(stdev))
          {
            sb.Append(",");
          }
        }

        if (!string.IsNullOrEmpty(stdev))
        {
          sb.Append($"\"stdev\":{stdev}");
        }

        sb.Append("},");
      }

      return $"{sb}";
    }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      StringBuilder sb = new();

      sb.Append("[");

      foreach (IStdev stdev in CoordinateStdev)
      {
        string stdevX = stdev?.X?.ToString(ci);
        string stdevY = stdev?.Y?.ToString(ci);
        string stdevZ = stdev?.Z?.ToString(ci);
        bool noStdev = string.IsNullOrEmpty(stdevX) && string.IsNullOrEmpty(stdevY) && string.IsNullOrEmpty(stdevZ);

        sb.Append(noStdev ? "null," : $"{{\"0\":{stdevX},\"1\":{stdevY},\"2\":{stdevZ}}},");
      }

      if (sb.Length > 1)
      {
        sb.Length--;
      }

      sb.Append("]{");

      string baseStr = base.ToString();
      if (baseStr.Length > 0)
      {
        sb.Append(baseStr.Substring(0, baseStr.Length - 1));
      }

      sb.Append((sb.Length > 1) ? "," : string.Empty); // comma
      sb.Append(GetValueString(TotalLength, "totalLength"));
      sb.Append(GetValueString(SegmentLengths, "segmentLengths"));
      sb.Append(GetValueString(SegmentsDeltaXY, "segmentsDeltaXY"));
      sb.Append(GetValueString(SegmentsDeltaZ, "segmentsDeltaZ"));
      sb.Append(GetValueString(SegmentsSlopePercentage, "segmentsSlopePercentage"));
      sb.Append(GetValueString(SegmentsSlopeAngle, "segmentsSlopeAngle"));
      sb.Append(GetValueString(DeltaXY, "deltaXY"));
      sb.Append(GetValueString(DeltaZ, "deltaZ"));

      sb.Append($"\"coordinateStdevs\":{sb}}}");

      return sb.ToString();
    }

    public bool Equals(DerivedDataLineString other)
    {
      if (other == null)
      {
        return false;
      }

      if (!ListsEqual(CoordinateStdev, other.CoordinateStdev))
      {
        return false;
      }

      if (!ListsEqual(SegmentLengths, other.SegmentLengths))
      {
        return false;
      }

      if (!ListsEqual(SegmentsDeltaXY, other.SegmentsDeltaXY))
      {
        return false;
      }

      if (!ListsEqual(SegmentsDeltaZ, other.SegmentsDeltaZ))
      {
        return false;
      }

      if (!ListsEqual(SegmentsSlopePercentage, other.SegmentsSlopePercentage))
      {
        return false;
      }

      if (!ListsEqual(SegmentsSlopeAngle, other.SegmentsSlopeAngle))
      {
        return false;
      }

      if (TotalLength == null != (other.TotalLength == null))
      {
        return false;
      }

      if (DeltaXY == null != (other.DeltaXY == null))
      {
        return false;
      }

      if (TotalLength != null && other.TotalLength != null)
      {
        if (!TotalLength.Equals(other.TotalLength))
        {
          return false;
        }
      }

      if (DeltaXY != null && other.DeltaXY != null)
      {
        if (!DeltaXY.Equals(other.DeltaXY))
        {
          return false;
        }
      }

      return other.Unit == Unit &&
             other.Precision == Precision &&
             DeltaZ.Equals(other.DeltaZ);
    }

    private bool ListsEqual<T>(IList<T> a, IList<T> b)
    {
      if (a == null != (b == null))
      {
        return false;
      }

      if (a != null && b != null)
      {
        if (a.Count == b.Count)
        {
          for (int i = 0; i < a.Count; i++)
          {
            if (!a[i].Equals(b[i]))
            {
              return false;
            }
          }
        }
        else
        {
          return false;
        }
      }

      return true;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as DerivedDataLineString);
    }

    public override int GetHashCode() => (CoordinateStdev, TotalLength, SegmentLengths, SegmentsDeltaXY, SegmentsSlopePercentage, DeltaXY, DeltaZ, SegmentsDeltaZ, SegmentsSlopeAngle).GetHashCode();
  }
}
