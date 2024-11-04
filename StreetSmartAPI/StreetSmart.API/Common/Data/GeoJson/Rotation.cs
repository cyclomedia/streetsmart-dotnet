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
using System;
using System.Collections.Generic;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Rotation : DataConvert, IRotation, IEquatable<Rotation>
  {
    private readonly Matrix _rotation;

    public Rotation(IDictionary<string, object> rotationValues)
    {
      var rotation = GetDictValue(rotationValues, "m");
      var shape = GetArrayValue(rotation, "shape");
      var data = GetDictValue(rotation, "data");

      int width = shape.Length >= 1 ? (int)shape[0] : 0;
      int height = shape.Length >= 2 ? (int)shape[1] : 0;

      _rotation = new Matrix(data, width, height);
    }

    public Rotation(IRotation rotation)
    {
      _rotation = new Matrix(((Rotation)rotation)._rotation);
    }

    public List<int> Shape => new List<int> { _rotation.Width, _rotation.Height };

    public IList<double> Data => _rotation.Values;

    public bool Equals(Rotation other)
    {
      if (other == null)
        return false;
      return _rotation.Equals(other._rotation);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Rotation);
    }
    public override int GetHashCode() => (_rotation).GetHashCode();

    public override string ToString()
    {
      return $"{{\"m\":{{\"shape\":[{_rotation.Width},{_rotation.Height}],\"data\":{_rotation}}}}}";
    }
  }
}
