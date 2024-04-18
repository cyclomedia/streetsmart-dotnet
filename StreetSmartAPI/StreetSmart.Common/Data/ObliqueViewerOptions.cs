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

using System.Collections.Generic;
using System.Linq;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class ObliqueViewerOptions : BaseViewerOptions, IObliqueViewerOptions
  {
    private bool? _timeTravelVisible;

    public ObliqueViewerOptions(bool? closable, bool? maximizable, bool? timeTravelVisible, bool? navBarVisible) :
      base(closable, maximizable, navBarVisible)
    {
      TimeTravelVisible = timeTravelVisible;
    }

    public bool? TimeTravelVisible
    {
      get => _timeTravelVisible;
      set
      {
        _timeTravelVisible = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      List<string> options = new List<string>();

      if (TimeTravelVisible != null)
      {
        options.Add($"timeTravelVisible:{TimeTravelVisible.ToString().ToLower()}");
      }

      string baseOptions = base.ToString();
      string result = options.Aggregate(baseOptions, (current, part) => $"{current},{part}");
      return options.Count == 0 && string.IsNullOrEmpty(baseOptions)
        ? string.Empty
        : $",obliqueViewer:{{{result}}}";
    }
  }
}
