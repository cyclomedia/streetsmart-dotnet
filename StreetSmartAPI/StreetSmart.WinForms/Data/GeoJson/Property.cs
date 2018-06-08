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

using StreetSmart.WinForms.Interfaces.GeoJson;

namespace StreetSmart.WinForms.Data.GeoJson
{
  internal class Property : NotifyPropertyChanged, IProperty
  {
    public Property(object value, object stdev)
    {
      Value = value as double?;
      Stdev = stdev as double?;
    }

    public double? Value { get; }

    public double? Stdev { get; }
  }
}
