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
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetSmart.Common.Data
{
  internal class BaseViewerOptions : NotifyPropertyChanged, IBaseViewerOptions
  {
    private bool? _closable;
    private bool? _maximizable;
    private bool? _navBarVisible;

    public BaseViewerOptions(bool? closable, bool? maximizable, bool? navBarVisible)
    {
      Closable = closable;
      Maximizable = maximizable;
      NavbarVisible = navBarVisible;
    }

    public bool? Closable
    {
      get => _closable;
      set
      {
        _closable = value;
        RaisePropertyChanged();
      }
    }

    public bool? Maximizable
    {
      get => _maximizable;
      set
      {
        _maximizable = value;
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

      if (Closable != null)
      {
        options.Add($"closable:{Closable.ToString().ToLower()}");
      }

      if (Maximizable != null)
      {
        options.Add($"maximizable:{Maximizable.ToString().ToLower()}");
      }

      if (NavbarVisible != null)
      {
        options.Add($"navbarVisible:{NavbarVisible.ToString().ToLower()}");
      }

      string result = options.Aggregate(string.Empty, (current, part) => $"{current},{part}");
      return options.Count == 0 ? string.Empty : result.Substring(Math.Min(result.Length, 1));
    }
  }
}
