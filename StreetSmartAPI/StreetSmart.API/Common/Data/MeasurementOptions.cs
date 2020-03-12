/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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

using StreetSmart.Common.Interfaces.Data;

#if WINFORMS
using StreetSmart.WinForms.Properties;
#else
using StreetSmart.Wpf.Properties;
#endif

namespace StreetSmart.Common.Data
{
  internal class MeasurementOptions : NotifyPropertyChanged, IMeasurementOptions
  {
    private MeasurementGeometryType? _geometryType;
    private MeasureMethods? _measureMethods;

    public MeasurementOptions()
    {
      _geometryType = null;
      _measureMethods = null;
    }

    public MeasurementOptions(MeasurementGeometryType? geometryType, MeasureMethods? measureMethods)
    {
      _geometryType = geometryType;
      _measureMethods = measureMethods;
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

    public MeasureMethods? MeasureMethods
    {
      get => _measureMethods;
      set
      {
        _measureMethods = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      string result = string.Empty;

      if (GeometryType != null || MeasureMethods != null)
      {
        string geometryPart = string.Empty;
        string measureMethodPart = string.Empty;
        string midPart = GeometryType != null && MeasureMethods != null ? "," : string.Empty;

        if (GeometryType != null)
        {
          geometryPart = $"geometry:{Resources.JsApi}.{((MeasurementGeometryType) GeometryType).Description()}";
        }

        if (MeasureMethods != null)
        {
          measureMethodPart = $"measureMethod:{Resources.JsApi}.{((MeasureMethods) MeasureMethods).Description()}";
        }

        result = $",{{{geometryPart}{midPart}{measureMethodPart}}}";
      }

      return result;
    }
  }
}
