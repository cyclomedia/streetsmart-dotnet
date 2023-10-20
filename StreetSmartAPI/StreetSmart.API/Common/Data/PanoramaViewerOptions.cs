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
  internal class PanoramaViewerOptions : BaseViewerOptions, IPanoramaViewerOptions
  {
    private bool? _replace;
    private bool? _recordingsVisible;
    private bool? _measureTypeButtonVisible;
    private bool? _measureTypeButtonToggle;
    private bool? _measureTypeButtonStart;
    private bool? _timeTravelVisible;

    public PanoramaViewerOptions(bool? closable, bool? maximizable, bool? timeTravelVisible, bool? navBarVisible,
      bool? replace, bool? recordingsVisible) : base(closable, maximizable, navBarVisible)
    {
      Replace = replace;
      RecordingsVisible = recordingsVisible;
      TimeTravelVisible = timeTravelVisible;
    }

    public bool? Replace
    {
      get => _replace;
      set
      {
        _replace = value;
        RaisePropertyChanged();
      }
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

    public bool? MeasureTypeButtonVisible
    {
      get => _measureTypeButtonVisible;
      set
      {
        _measureTypeButtonVisible = value;
        RaisePropertyChanged();
      }
    }

    public bool? MeasureTypeButtonToggle
    {
      get => _measureTypeButtonToggle;
      set
      {
        _measureTypeButtonToggle = value;
        RaisePropertyChanged();
      }
    }

    public bool? MeasureTypeButtonStart
    {
      get => _measureTypeButtonStart;
      set
      {
        _measureTypeButtonStart = value;
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

    public override string ToString()
    {
      List<string> options = new List<string>();

      if (Replace != null)
      {
        options.Add($"replace:{Replace.ToString().ToLower()}");
      }

      if (RecordingsVisible != null)
      {
        options.Add($"recordingsVisible:{RecordingsVisible.ToString().ToLower()}");
      }

      if (MeasureTypeButtonVisible != null)
      {
        options.Add($"measureTypeButtonVisible:{MeasureTypeButtonVisible.ToString().ToLower()}");
      }

      if (MeasureTypeButtonToggle != null)
      {
        options.Add($"measureTypeButtonToggle:{MeasureTypeButtonToggle.ToString().ToLower()}");
      }

      if (MeasureTypeButtonStart != null)
      {
        options.Add($"measureTypeButtonStart:{MeasureTypeButtonStart.ToString().ToLower()}");
      }

      if (TimeTravelVisible != null)
      {
        options.Add($"timeTravelVisible:{TimeTravelVisible.ToString().ToLower()}");
      }

      string baseOptions = base.ToString();
      string result = options.Aggregate(baseOptions, (current, part) => $"{current},{part}");
      return options.Count == 0 && string.IsNullOrEmpty(baseOptions)
        ? string.Empty
        : $",panoramaViewer:{{{result}}}";
    }
  }
}
