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

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class Camera : DataConvert, ICamera
  {
    private ICoordinate _position;
    private ICoordinate _target;

    public Camera(Dictionary<string, object> camera)
    {
      var position = GetDictValue(camera, "cameraPosition");
      var target = GetDictValue(camera, "cameraTarget");

      double? px = ToNullDouble(position, "x");
      double? py = ToNullDouble(position, "y");
      double? pz = ToNullDouble(position, "z");

      double? tx = ToNullDouble(target, "x");
      double? ty = ToNullDouble(target, "y");
      double? tz = ToNullDouble(target, "z");

      Position = new Coordinate(px, py, pz);
      Target = new Coordinate(tx, ty, tz);
    }

    public ICoordinate Position
    {
      get => _position;
      set
      {
        _position = value;
        RaisePropertyChanged();
      }
    }

    public ICoordinate Target
    {
      get => _target;
      set
      {
        _target = value;
        RaisePropertyChanged();
      }
    }
  }
}
