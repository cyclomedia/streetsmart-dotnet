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

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DerivedDataPoint : DerivedData, IDerivedDataPoint
  {
    public DerivedDataPoint(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      // ReSharper disable InconsistentNaming
      Dictionary<string, object> positionXY = GetProperty(derivedData, "positionXY");
      Dictionary<string, object> positionZ = GetProperty(derivedData, "positionZ");
      IList<object> coordinateStdevs = derivedData?["coordinateStdevs"] as IList<object> ?? new List<object>();
      Dictionary<string, object> position = GetProperty(derivedData, "position");

      if (coordinateStdevs.Count >= 1)
      {
        Position = new PositionStdev(position, coordinateStdevs[0] as Dictionary<string, object>);
      }

      if (positionXY?["value"] is IList<object> valueXY)
      {
        double? stdevXY = positionXY.ContainsKey("stdev") ? positionXY["stdev"] as double? : null;
        PositionXY = new PositionXY(valueXY, stdevXY);
      }

      if (positionZ?["value"] is double valueZ)
      {
        double? stdevZ = positionZ.ContainsKey("stdev") ? positionZ["stdev"] as double? : null;
        PositionZ = new Property(valueZ, stdevZ);
      }

      // ReSharper restore InconsistentNaming
    }

    public IPositionStdev Position { get; }

    // ReSharper disable once InconsistentNaming
    public IPositionXY PositionXY { get; }

    public IProperty PositionZ { get; }

    public Dictionary<string, object> GetProperty(Dictionary<string, object> derivedData, string key)
    {
      return derivedData?.ContainsKey(key) ?? false ? derivedData[key] as Dictionary<string, object> : null;
    }
  }
}
