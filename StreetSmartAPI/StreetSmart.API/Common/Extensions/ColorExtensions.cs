/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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

// ReSharper disable once CheckNamespace

using System.Drawing;
using System.Globalization;

namespace System
{
  internal static class ColorExtensions
  {
    public static string ToJsColor(this Color value)
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      double alpha = (double) value.A / 255;
      return $"[{value.R},{value.G},{value.B},{alpha.ToString("0.00", ci)}]";
    }

    public static string ToHexColor(this Color value)
    {
      return $"#{value.R:x2}{value.G:x2}{value.B:x2}";
    }
  }
}
