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
  internal class ResultDirection : NotifyPropertyChanged, IResultDirection
  {
    private readonly string _matchImage;

    public ResultDirection(Dictionary<string, object> resultDirection)
    {
      RecordedAt = (resultDirection?.ContainsKey("RecordedAt") ?? false)
        ? (DateTime?) DateTime.Parse(resultDirection["RecordedAt"]?.ToString())
        : null;

      double directionX = resultDirection?["DirectionX"] as double? ?? 0.0;
      double directionY = resultDirection?["DirectionY"] as double? ?? 0.0;
      double directionZ = resultDirection?["DirectionZ"] as double? ?? 0.0;
      GroundLevelOffset = resultDirection?["GroundLevelOffset"] as double? ?? 0.0;
      Id = resultDirection?["Id"]?.ToString() ?? string.Empty;
      _matchImage = resultDirection?["MatchImage"]?.ToString() ?? string.Empty;
      double orientation = resultDirection?["Orientation"] as double? ?? 0.0;
      double positionX = resultDirection?["PositionX"] as double? ?? 0.0;
      double positionY = resultDirection?["PositionY"] as double? ?? 0.0;
      double positionZ = resultDirection?["PositionZ"] as double? ?? 0.0;
      double stdOrientation = resultDirection?["StdOrientation"] as double? ?? 0.0;
      double stdX = resultDirection?["StdX"] as double? ?? 0.0;
      double stdY = resultDirection?["StdY"] as double? ?? 0.0;
      double stdZ = resultDirection?["StdZ"] as double? ?? 0.0;
      string calculationMethod = resultDirection?["calculationMethod"]?.ToString() ?? string.Empty;

      try
      {
        CalculatedMethod = (CalculatedMethod) Enum.Parse(typeof(CalculatedMethod), calculationMethod);
      }
      catch (ArgumentException)
      {
        CalculatedMethod = CalculatedMethod.NotDefined;
      }

      Direction = new Direction(directionX, directionY, directionZ);
      Orientation = new Property(orientation, stdOrientation);
      Position = new PositionStdev(positionX, positionY, positionZ, stdX, stdY, stdZ);

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
