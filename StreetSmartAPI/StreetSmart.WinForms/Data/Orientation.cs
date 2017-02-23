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
using System.Globalization;
using System.Linq;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class Orientation : NotifyPropertyChanged, IOrientation
  {
    private double? _yaw;
    private double? _pitch;
    private double? _hFov;

    public Orientation(double? yaw, double? pitch, double? hFov)
    {
      Yaw = yaw;
      Pitch = pitch;
      HFov = hFov;
    }

    public Orientation(Dictionary<string, object> orientation)
    {
      Yaw = double.Parse(orientation["yaw"].ToString());
      Pitch = double.Parse(orientation["pitch"].ToString());
      HFov = double.Parse(orientation["hFov"].ToString());
    }

    public double? Yaw
    {
      get { return _yaw; }
      set
      {
        _yaw = value;
        RaisePropertyChanged();
      }
    }

    public double? Pitch
    {
      get { return _pitch; }
      set
      {
        _pitch = value;
        RaisePropertyChanged();
      }
    }

    public double? HFov
    {
      get { return _hFov; }
      set
      {
        _hFov = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      List<string> orientation = new List<string>();
      CultureInfo ci = CultureInfo.InvariantCulture;

      if (Yaw != null)
      {
        orientation.Add($"yaw:{((double) Yaw).ToString(ci)}");
      }

      if (Pitch != null)
      {
        orientation.Add($"pitch:{((double) Pitch).ToString(ci)}");
      }

      if (HFov != null)
      {
        orientation.Add($"hFov:{((double) HFov).ToString(ci)}");
      }

      string result = orientation.Aggregate(string.Empty, (current, part) => $"{current},{part}");
      return $"{{{result.Substring(Math.Min(result.Length, 1))}}}";
    }
  }
}
