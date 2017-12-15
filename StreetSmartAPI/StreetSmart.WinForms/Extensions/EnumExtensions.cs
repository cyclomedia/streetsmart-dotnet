/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
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

using System.ComponentModel;

// ReSharper disable once CheckNamespace
namespace System
{
  internal static class EnumExtensions
  {
    public static string Description(this Enum value)
    {
      var fi = value.GetType().GetField(value.ToString());
      var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }
  }
}
