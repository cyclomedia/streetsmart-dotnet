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

using System.Collections.Generic;

using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class PositionStdev : Coordinate, IPositionStdev
  {
    public PositionStdev(Dictionary<string, object> position, IList<object> coordinateStdDev)
      : base(position)
    {
      StdDev = new Coordinate(coordinateStdDev);
    }

    public PositionStdev(Dictionary<string, object> position, Dictionary<string, object> coordinateStdev)
      : base(position?["value"] as IList<object>)
    {
      StdDev = new Coordinate(coordinateStdev);
    }

    public PositionStdev(double x, double y, double z, double stdX, double stdY, double stdZ)
      : base(x, y, z)
    {
      StdDev = new Coordinate(stdX, stdY, stdZ);
    }

    // ReSharper disable once InconsistentNaming
    public ICoordinate StdDev { get; }
  }
}
