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

using System;
using System.Collections.Generic;
using System.Linq;
using StreetSmart.Common.Interfaces.Data;

#if WINFORMS
using StreetSmart.WinForms.Properties;
#else
using StreetSmart.WPF.Properties;
#endif

namespace StreetSmart.Common.Data
{
  internal class PointCloudViewerOptions : BaseViewerOptions, IPointCloudViewerOptions
  {
    private PointCloudType _pointCloudType;

    public PointCloudViewerOptions(bool? closable, bool? maximizable, bool? navBarVisible,
      PointCloudType pointCloudType = PointCloudType.Street) : base(closable, maximizable, navBarVisible)
    {
      PointCloudType = pointCloudType;
    }

    public PointCloudType PointCloudType
    {
      get => _pointCloudType;
      set
      {
        _pointCloudType = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      List<string> options = new List<string> { $"pointCloudType:{Resources.JsApi}.{PointCloudType.Description()}" };

      string baseOptions = base.ToString();
      string result = options.Aggregate(baseOptions, (current, part) => $"{current},{part}");
      result = result.Length >= 1 && result.Substring(0, 1) == ","
        ? result.Substring(1, result.Length - 1) : result;
      return options.Count == 0 && string.IsNullOrEmpty(baseOptions)
        ? string.Empty
        : $",pointcloudViewer:{{{result}}}";
    }
  }
}
