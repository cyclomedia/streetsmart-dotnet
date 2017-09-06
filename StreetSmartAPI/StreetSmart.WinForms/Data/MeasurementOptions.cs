/*
 * Street Smart .NET integration
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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

using StreetSmart.WinForms.Interfaces;
using StreetSmart.WinForms.Properties;

namespace StreetSmart.WinForms.Data
{
  internal class MeasurementOptions : NotifyPropertyChanged, IMeasurementOptions
  {
    private MeasurementGeometryType? _geometryType;

    public MeasurementOptions()
    {
      _geometryType = null;
    }

    public MeasurementOptions(MeasurementGeometryType geometryType)
    {
      _geometryType = geometryType;
    }

    public MeasurementGeometryType? GeometryType
    {
      get => _geometryType;
      set
      {
        _geometryType = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      return (GeometryType == null)
        ? string.Empty
        : $",{{geometry:{Resources.JsApi}.{((MeasurementGeometryType) GeometryType).Description()}}}";
    }
  }
}
