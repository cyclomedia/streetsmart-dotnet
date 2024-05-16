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

using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class Resolution : DataConvert, IResolution
  {
    public Resolution(Dictionary<string, object> info)
    {
      Dictionary<string, object> resolution = GetDictValue(info, "resolutionOfImage");
      Width = ToInt(resolution, "width");
      Stdev = ToInt(resolution, "stdev");
      Error = ToInt(resolution, "error");
    }

    public Resolution(IResolution resolution)
    {
      if (resolution != null)
      {
        Width = resolution.Width;
        Stdev = resolution.Stdev;
        Error = resolution.Error;
      }
    }

    public int Width { get; }

    public int Stdev { get; }

    public int Error { get; }

    public override string ToString()
    {
      return $"\"resolutionOfImage\":{{\"width\":\"{Width}\",\"stdev\":{Stdev},\"error\":{Error}}}";
    }
  }
}
