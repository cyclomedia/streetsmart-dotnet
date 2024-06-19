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
using System.Text;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DerivedDataPoint : DerivedData, IDerivedDataPoint//,IEquatable<DerivedDataPoint>
  {
    public DerivedDataPoint(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      // ReSharper disable InconsistentNaming
      var positionXY = GetDictValue(derivedData, "positionXY");
      var positionZ = GetDictValue(derivedData, "positionZ");
      var coordinateStdevs = GetListValue(derivedData, "coordinateStdevs");
      var position = GetDictValue(derivedData, "position");

      if (coordinateStdevs.Count >= 1)
      {
        Position = new PositionStdev(position, ToDictionary(coordinateStdevs[0]));
      }

      if (GetValue(positionXY, "value") is IList<object> valueXY)
      {
        double? stdevXY = ToNullDouble(positionXY,"stdev");
        PositionXY = new PositionXY(valueXY, stdevXY);
      }

      if (GetValue(positionZ, "value") is double valueZ)
      {
        double? stdevZ = ToNullDouble(positionZ, "stdev");
        PositionZ = new Property(valueZ, stdevZ);
      }

      // ReSharper restore InconsistentNaming
    }

    public DerivedDataPoint(IDerivedDataPoint derivedData)
      : base(derivedData)
    {
      if (derivedData != null)
      {
        Position = new PositionStdev(derivedData.Position);
        PositionXY = new PositionXY(derivedData.PositionXY);
        PositionZ = new Property(derivedData.PositionZ);
      }
    }

    public IPositionStdev Position { get; }

    // ReSharper disable once InconsistentNaming
    public IPositionXY PositionXY { get; }

    public IProperty PositionZ { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string baseStr = base.ToString();
      string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));

      StringBuilder sb = new StringBuilder(subStr);

      StringBuilder derivedDataPoint = new StringBuilder();

      if (PositionZ?.Value != null && PositionZ?.Stdev != null)
      {
        derivedDataPoint.Append($"\"positionZ\":{PositionZ},");
      }

      if (Position?.X != null && Position?.Y != null && Position?.Z != null)
      {
        StringBuilder positionValue = new StringBuilder();
        positionValue.Append($"\"value\":[{Position.X?.ToString(ci)},{Position.Y?.ToString(ci)},{Position.Z?.ToString(ci)}]");

        if (Position?.StdDev?.X != null && Position?.StdDev?.Y != null && Position?.StdDev?.Z != null)
        {
          positionValue.Append($",\"stdev\":[{Position.StdDev.X?.ToString(ci)},{Position.StdDev.Y?.ToString(ci)},{Position.StdDev.Z?.ToString(ci)}]");
        }

        derivedDataPoint.Append($"\"position\":{{{positionValue}}},");
      }

      if (Position?.StdDev?.X != null && Position?.StdDev?.Y != null && Position?.StdDev?.Z != null)
      {
        derivedDataPoint.Append($"\"coordinateStdevs\":[{{\"0\":{Position.StdDev.X?.ToString(ci)},\"1\":{Position.StdDev.Y?.ToString(ci)},\"2\":{Position.StdDev.Z?.ToString(ci)}}}]");
      }

      if (derivedDataPoint.Length > 0)
      {
        string comma = (sb.Length >= 2 && derivedDataPoint.Length >= 1) ? "," : string.Empty;
        sb.Append(comma);
        sb.Append(derivedDataPoint);
      }

      sb.Append("}");

      return $"{sb}";
    }

    //public override string ToString()
    //{
    //  CultureInfo ci = CultureInfo.InvariantCulture;
    //  string baseStr = base.ToString();
    //  string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));

    //  string positionZ = PositionZ?.Value != null && PositionZ?.Stdev != null ? $"\"positionZ\":{PositionZ}," : string.Empty;
    //  string positionStdev = Position?.StdDev?.X != null && Position?.StdDev?.Y != null && Position?.StdDev?.Z != null
    //    ? $",\"stdev\":[{Position?.StdDev?.X?.ToString(ci)},{Position?.StdDev?.Y?.ToString(ci)},{Position?.StdDev?.Z?.ToString(ci)}]"
    //    : string.Empty;
    //  string position = Position?.X != null && Position?.Y != null && Position?.Z != null
    //    ? $"\"position\":{{\"value\":[{Position?.X?.ToString(ci)},{Position?.Y?.ToString(ci)},{Position?.Z?.ToString(ci)}]{positionStdev}}},"
    //    : string.Empty;
    //  string coordinateStdevs =
    //    Position?.StdDev?.X != null && Position?.StdDev?.Y != null && Position?.StdDev?.Z != null
    //      ? $"\"coordinateStdevs\":[{{\"0\":{Position?.StdDev?.X?.ToString(ci)},\"1\":{Position?.StdDev?.Y?.ToString(ci)},\"2\":{Position?.StdDev?.Z?.ToString(ci)}}}]"
    //      : string.Empty;

    //  string derivedDataPoint = $"{PositionXY}{positionZ}{position}{coordinateStdevs}";
    //  string comma = subStr.Length >= 2 && derivedDataPoint.Length >= 1 ? "," : string.Empty;
    //  return $"{subStr}{comma}{derivedDataPoint}}}";
    //}
    /*
    public bool Equals(DerivedDataPoint other)
    {
      if (other == null) return false;
      return (PositionZ?.Equals(other.PositionZ) ?? other.PositionZ == null) &&
             (Position?.Equals(other.Position) ?? other.Position == null);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as DerivedDataPoint);
    }

    public override int GetHashCode() => (PositionZ,Position).GetHashCode();
    */
  }
}
