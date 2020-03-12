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

using System.Collections.Generic;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class ImageCoordinate : DataConvert, IImageCoordinate
  {
    private double? _x;
    private double? _y;

    public ImageCoordinate(IList<object> coordinate)
    {
      X = coordinate?.Count >= 1 ? ToNullDouble(coordinate[0]) : null;
      Y = coordinate?.Count >= 2 ? ToNullDouble(coordinate[1]) : null;
    }

    public double? X
    {
      get => _x;
      set
      {
        _x = value;
        RaisePropertyChanged();
      }
    }

    public double? Y
    {
      get => _y;
      set
      {
        _y = value;
        RaisePropertyChanged();
      }
    }
  }
}
