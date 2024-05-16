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

using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;

namespace StreetSmart.Common.Data
{
  internal class ElevationInfo : DataConvert, IElevationInfo
  {
    private double _level;
    private Unit _heightUnit;
    private double _groundLevel;

    public ElevationInfo(Dictionary<string, object> elevationInfo)
    {
      string unit = ToString(elevationInfo, "heightUnits");

      switch (unit)
      {
        case "m":
          HeightUnit = Unit.Meters;
          break;
        case "ft":
          HeightUnit = Unit.Feet;
          break;
        case "us-ft":
          HeightUnit = Unit.UsFeet;
          break;
        case "degrees":
          HeightUnit = Unit.Degrees;
          break;
        case "?":
          HeightUnit = Unit.Unknown;
          break;
        default:
          HeightUnit = Unit.Unknown;
          break;
      }

      Level = ToDouble(elevationInfo, "level");
      GroundLevel = ToDouble(elevationInfo, "groundLevel");
    }

    public double Level
    {
      get => _level;
      set
      {
        _level = value;
        RaisePropertyChanged();
      }
    }

    public Unit HeightUnit
    {
      get => _heightUnit;
      set
      {
        _heightUnit = value;
        RaisePropertyChanged();
      }
    }

    public double GroundLevel
    {
      get => _groundLevel;
      set
      {
        _groundLevel = value;
        RaisePropertyChanged();
      }
    }
  }
}
