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

using StreetSmart.Wpf.Interfaces.GeoJson;

namespace StreetSmart.Wpf.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class DerivedData : NotifyPropertyChanged, IDerivedData
  {
    public DerivedData(Dictionary<string, object> derivedData)
    {
      string unit = derivedData?["unit"]?.ToString() ?? string.Empty;
      Precision = derivedData?["precision"] as int? ?? 0;

      switch (unit)
      {
        case "m":
          Unit = Unit.Meters;
          break;
        case "ft":
          Unit = Unit.Feet;
          break;
        case "us-ft":
          Unit = Unit.UsFeet;
          break;
        case "degrees":
          Unit = Unit.Degrees;
          break;
        case "?":
          Unit = Unit.Unknown;
          break;
        default:
          Unit = Unit.Unknown;
          break;
      }
    }

    public Unit Unit { get; }

    public int Precision { get; }
  }
}
