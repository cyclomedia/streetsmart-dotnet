/*
 * Integration in ArcMap for Cycloramas
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
using System.Collections.Generic;
using System.Linq;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class PanoramaViewerOptions : NotifyPropertyChanged, IPanoramaViewerOptions
  {
    private bool? _recordingsVisible;
    private bool? _timeTravelVisible;
    private bool? _navBarVisible;

    public PanoramaViewerOptions(bool? recordingsVisible, bool? timeTravelVisible, bool? navBarVisible)
    {
      RecordingsVisible = recordingsVisible;
      TimeTravelVisible = timeTravelVisible;
      NavbarVisible = navBarVisible;
    }

    public bool? RecordingsVisible
    {
      get => _recordingsVisible;
      set
      {
        _recordingsVisible = value;
        RaisePropertyChanged();
      }
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

    public bool? NavbarVisible
    {
      get => _navBarVisible;
      set
      {
        _navBarVisible = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      List<string> options = new List<string>();

      if (RecordingsVisible != null)
      {
        options.Add($"recordingsVisible:{RecordingsVisible.ToString().ToLower()}");
      }

      if (TimeTravelVisible != null)
      {
        options.Add($"timeTravelVisible:{TimeTravelVisible.ToString().ToLower()}");
      }

      if (NavbarVisible != null)
      {
        options.Add($"navbarVisible:{NavbarVisible.ToString().ToLower()}");
      }

      string result = options.Aggregate(string.Empty, (current, part) => $"{current},{part}");
      return (options.Count == 0) ? string.Empty : $"{{{result.Substring(Math.Min(result.Length, 1))}}}";
    }
  }
}
