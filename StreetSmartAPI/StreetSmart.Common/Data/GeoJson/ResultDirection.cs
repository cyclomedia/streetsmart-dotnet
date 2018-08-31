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
using System.IO;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class ResultDirection : NotifyPropertyChanged, IResultDirection
  {
    public ResultDirection(Dictionary<string, object> resultDirection)
    {
      double directionX = resultDirection?["DirectionX"] as double? ?? 0.0;
      double directionY = resultDirection?["DirectionY"] as double? ?? 0.0;
      double directionZ = resultDirection?["DirectionZ"] as double? ?? 0.0;
      GroundLevelOffset = resultDirection?["GroundLevelOffset"] as double? ?? 0.0;
      Id = resultDirection?["Id"]?.ToString() ?? string.Empty;
      string matchImage = resultDirection?["MatchImage"]?.ToString() ?? string.Empty;
      double orientation = resultDirection?["Orientation"] as double? ?? 0.0;
      double positionX = resultDirection?["PositionX"] as double? ?? 0.0;
      double positionY = resultDirection?["PositionY"] as double? ?? 0.0;
      double positionZ = resultDirection?["PositionZ"] as double? ?? 0.0;
      RecordedAt = DateTime.Parse(resultDirection?["RecordedAt"]?.ToString());
      double stdOrientation = resultDirection?["StdOrientation"] as double? ?? 0.0;
      double stdX = resultDirection?["StdX"] as double? ?? 0.0;
      double stdY = resultDirection?["StdY"] as double? ?? 0.0;
      double stdZ = resultDirection?["StdZ"] as double? ?? 0.0;

      Direction = new Direction(directionX, directionY, directionZ);
      Orientation = new Property(orientation, stdOrientation);
      Position = new PositionStdev(positionX, positionY, positionZ, stdX, stdY, stdZ);

      byte[] bytes = Convert.FromBase64String(matchImage);
      MatchImage = new Bitmap(new MemoryStream(bytes));
    }

    public IDirection Direction { get; }

    public double GroundLevelOffset { get; }

    public string Id { get; }

    public Image MatchImage { get; }

    public IProperty Orientation { get; }

    public IPositionStdev Position { get; }

    public DateTime? RecordedAt { get; }
  }
}
