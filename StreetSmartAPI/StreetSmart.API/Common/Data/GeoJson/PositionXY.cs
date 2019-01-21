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
using System.Globalization;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class PositionXY: IPositionXY
  {
    public PositionXY(IList<object> value, double? stdev)
    {
      X = value.Count >= 1 ? value[0] as double? : null;
      Y = value.Count >= 2 ? value[1] as double? : null;
      Stdev = stdev;
    }

    public PositionXY(IPositionXY position)
    {
      if (position != null)
      {
        X = position.X;
        Y = position.Y;
        Stdev = position.Stdev;
      }
    }

    public double? X { get; }

    public double? Y { get; }

    public double? Stdev { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string xy = X != null && Y != null ? $"\"value\":[{X?.ToString(ci)},{Y?.ToString(ci)}]" : string.Empty;
      string stdef = Stdev != null ? $"\"stdev\":{Stdev?.ToString(ci)}" : string.Empty;
      string comma = !string.IsNullOrEmpty(xy) && !string.IsNullOrEmpty(stdef) ? "," : string.Empty;
      bool empty = string.IsNullOrEmpty(xy) && string.IsNullOrEmpty(stdef);
      return empty ? string.Empty : $"\"positionXY\":{{{xy}{comma}{stdef}}},";
    }
  }
}
