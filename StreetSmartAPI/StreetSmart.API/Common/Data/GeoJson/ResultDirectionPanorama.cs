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
  internal class ResultDirectionPanorama : ResultDirection, IResultDirectionPanorama,IEquatable<ResultDirectionPanorama>
  {
    public ResultDirectionPanorama(Dictionary<string, object> resultDirection)
      : base(resultDirection)
    {
      RecordedAt = ToNullDateTime(resultDirection, "RecordedAt");
      GroundLevelOffset = ToDouble(resultDirection, "GroundLevelOffset");

      try
      {
        CalculatedMethod = (CalculatedMethod) ToEnum(typeof(CalculatedMethod), resultDirection, "calculationMethod");
      }
      catch (ArgumentException)
      {
        CalculatedMethod = CalculatedMethod.NotDefined;
      }

      double directionX = ToDouble(resultDirection, "DirectionX");
      double directionY = ToDouble(resultDirection, "DirectionY");
      double directionZ = ToDouble(resultDirection, "DirectionZ");
      Direction = new Direction(directionX, directionY, directionZ);

      double orientation = ToDouble(resultDirection, "Orientation");
      double stdOrientation = ToDouble(resultDirection, "StdOrientation");
      Orientation = new Property(orientation, stdOrientation);

      double positionX = ToDouble(resultDirection, "PositionX");
      double positionY = ToDouble(resultDirection, "PositionY");
      double positionZ = ToDouble(resultDirection, "PositionZ");
      double stdX = ToDouble(resultDirection, "StdX");
      double stdY = ToDouble(resultDirection, "StdY");
      double stdZ = ToDouble(resultDirection, "StdZ");
      Position = new PositionStdev(positionX, positionY, positionZ, stdX, stdY, stdZ);
      Resolution = new Resolution(resultDirection);
    }

    public ResultDirectionPanorama(IResultDirectionPanorama resultDirection)
      : base(resultDirection)
    {
      if (resultDirection != null)
      {
        Direction = new Direction(resultDirection.Direction);
        GroundLevelOffset = resultDirection.GroundLevelOffset;
        Orientation = new Property(resultDirection.Orientation);
        Position = new PositionStdev(resultDirection.Position);
        CalculatedMethod = resultDirection.CalculatedMethod;
        Resolution = new Resolution(resultDirection.Resolution);

        if (resultDirection.RecordedAt != null)
        {
          DateTime recordedAt = (DateTime) resultDirection.RecordedAt;
          RecordedAt = DateTime.FromBinary(recordedAt.ToBinary());
        }
      }
    }

    public IDirection Direction { get; }

    public double GroundLevelOffset { get; }

    public IProperty Orientation { get; }

    public IPositionStdev Position { get; }

    public CalculatedMethod CalculatedMethod { get; }

    public DateTime? RecordedAt { get; }

    public IResolution Resolution { get; }

    public bool Equals(ResultDirectionPanorama other)
    {
      if (other == null) return false;
      return Direction.Equals(other.Direction) &&
        GroundLevelOffset.Equals(other.GroundLevelOffset) &&
        Orientation.Stdev.Equals(other.Orientation.Stdev) &&
        Position.Equals(other.Position) &&
        CalculatedMethod.Equals(other.CalculatedMethod) &&
        Resolution.Equals(other.Resolution);
    }
    public override bool Equals(object obj)
    {
      return Equals(obj as ResultDirectionPanorama);
    }
    public override int GetHashCode() => (Direction,GroundLevelOffset,Orientation,Position,CalculatedMethod,Resolution).GetHashCode();

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string jsDate = RecordedAt.ToJsDateTime();
      string dateString = string.IsNullOrEmpty(jsDate) ? string.Empty : $",\"RecordedAt\":\"{jsDate}\"";
      string baseStr = base.ToString();
      string inputStr = baseStr.Substring(1, baseStr.Length - 2);

      return
        $"{{\"DirectionX\":{Direction?.X?.ToString(ci)},\"DirectionY\":{Direction?.Y?.ToString(ci)},\"DirectionZ\":{Direction?.Z?.ToString(ci)}," +
        $"\"GroundLevelOffset\":{GroundLevelOffset.ToString(ci)},{inputStr},\"Orientation\":{Orientation?.Value?.ToString(ci)}," +
        $"\"StdOrientation\":{Orientation?.Stdev?.ToString(ci)},\"PositionX\":{Position?.X?.ToString(ci)},\"PositionY\":{Position?.Y?.ToString(ci)}," +
        $"\"PositionZ\":{Position?.Z?.ToString(ci)},\"StdX\":{Position?.StdDev?.X?.ToString(ci)},\"StdY\":{Position?.StdDev?.Y?.ToString(ci)}," +
        $"\"StdZ\":{Position?.StdDev?.Z?.ToString(ci)},\"calculationMethod\":\"{CalculatedMethod.Description()}\",{Resolution}{dateString}}}";
    }
  }
}
