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
      get { return _recordingsVisible; }
      set
      {
        _recordingsVisible = value;
        RaisePropertyChanged();
      }
    }

    public bool? TimeTravelVisible
    {
      get { return _timeTravelVisible; }
      set
      {
        _timeTravelVisible = value;
        RaisePropertyChanged();
      }
    }

    public bool? NavbarVisible
    {
      get { return _navBarVisible; }
      set
      {
        _navBarVisible = value;
        RaisePropertyChanged();
      }
    }
  }
}
