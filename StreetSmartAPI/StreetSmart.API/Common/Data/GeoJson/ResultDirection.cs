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
using System.Drawing;
using System.Globalization;
using System.IO;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class ResultDirection : DataConvert, IResultDirection
  {
    private readonly string _matchImage;

    public ResultDirection(Dictionary<string, object> resultDirection)
    {
      RecordedAt = ToNullDateTime(resultDirection, "RecordedAt");
      GroundLevelOffset = ToDouble(resultDirection, "GroundLevelOffset");
      Id = ToString(resultDirection, "Id");

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

      _matchImage = ToString(resultDirection, "MatchImage");

      if (!string.IsNullOrEmpty(_matchImage))
      {
        byte[] bytes = Convert.FromBase64String(_matchImage);
        MatchImage = new Bitmap(new MemoryStream(bytes));
      }
    }

    public ResultDirection(IResultDirection resultDirection)
    {
      if (resultDirection != null)
      {
        Direction = new Direction(resultDirection.Direction);
        GroundLevelOffset = resultDirection.GroundLevelOffset;
        Id = resultDirection.Id != null ? string.Copy(resultDirection.Id) : null;
        MatchImage = (Image) MatchImage?.Clone();
        Orientation = new Property(resultDirection.Orientation);
        Position = new PositionStdev(resultDirection.Position);
        CalculatedMethod = resultDirection.CalculatedMethod;
        _matchImage = (resultDirection as ResultDirection)?._matchImage;

        if (resultDirection.RecordedAt != null)
        {
          DateTime recordedAt = (DateTime) resultDirection.RecordedAt;
          RecordedAt = DateTime.FromBinary(recordedAt.ToBinary());
        }
      }
    }

    public IDirection Direction { get; }

    public double GroundLevelOffset { get; }

    public string Id { get; }

    public Image MatchImage { get; }

    public IProperty Orientation { get; }

    public IPositionStdev Position { get; }

    public CalculatedMethod CalculatedMethod { get; }

    public DateTime? RecordedAt { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      DateTimeFormatInfo ff = new DateTimeFormatInfo();
      string dateString = RecordedAt == null
        ? string.Empty
        : $",\"RecordedAt\":\"{((DateTime) RecordedAt).ToString(ff.SortableDateTimePattern)}\"";

      return $"{{\"DirectionX\":{Direction?.X?.ToString(ci)},\"DirectionY\":{Direction?.Y?.ToString(ci)},\"DirectionZ\":{Direction?.Z?.ToString(ci)}," +
             $"\"GroundLevelOffset\":{GroundLevelOffset.ToString(ci)},\"Id\":\"{Id}\",\"MatchImage\":\"{_matchImage}\",\"Orientation\":{Orientation?.Value?.ToString(ci)}," +
             $"\"StdOrientation\":{Orientation?.Stdev?.ToString(ci)},\"PositionX\":{Position?.X?.ToString(ci)},\"PositionY\":{Position?.Y?.ToString(ci)}," +
             $"\"PositionZ\":{Position?.Z?.ToString(ci)},\"StdX\":{Position?.StdDev?.X?.ToString(ci)},\"StdY\":{Position?.StdDev?.Y?.ToString(ci)}," +
             $"\"StdZ\":{Position?.StdDev?.Z?.ToString(ci)},\"calculationMethod\":\"{CalculatedMethod.Description()}\"{dateString}}}";
    }
  }
}
