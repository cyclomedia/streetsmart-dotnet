﻿/*
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

using System;
using System.Collections.Generic;
using System.Globalization;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Matrix : DataConvert, IMatrix, IEquatable<Matrix>
  {
    public Matrix(Dictionary<string, object> matrixValues, int width, int height)
    {
      Width = width;
      Height = height;
      Values = new List<double>();

      for (int i = 0; i < width * height; i++)
      {
        Values.Add(ToDouble(matrixValues, i.ToString()));
      }
    }

    public Matrix(IMatrix matrix)
    {
      Width = matrix.Width;
      Height = matrix.Height;
      Values = new List<double>();

      foreach (var t in matrix.Values)
      {
        Values.Add(t);
      }
    }

    public int Width { get; }

    public int Height { get; }

    public IList<double> Values { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string values = string.Empty;

      for(int i = 0; i < Values.Count; i++)
      {
        values = $"{values}{i.ToDoubleQuote()}:{Values[i].ToString(ci)},";
      }

      values = values.Substring(0, Math.Max(0, values.Length - 1));
      return values.Length == 0 ? "null" : $"{{{values}}}";
    }

    public bool Equals(Matrix other)
    {
      if(other == null) return false;
      if (Values.Count != other.Values.Count)
      {
        return false;
      }

      for (int i = 0; i < Values.Count; i++)
      {
        // Adjust this comparison based on the type of Values[i]
        if (!Values[i].Equals(other.Values[i]))
        {
          return false;
        }
      }
      return true;

    }
    public override bool Equals(object obj)
    {
      return Equals(obj as Matrix);
    }
    public override int GetHashCode() => (Values).GetHashCode();
  }
}
