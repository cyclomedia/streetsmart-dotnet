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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Properties: Dictionary<string, object>, IProperties
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public Properties()
    {
    }

    public Properties(Dictionary<string, object> properties)
    {
      foreach (var property in properties)
      {
        Add(property.Key, property.Value);
      }
    }

    public Properties(IProperties properties)
    {
      if (properties != null)
      {
        foreach (var property in properties)
        {
          Add(property.Key, property.Value);
        }
      }
    }

    public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
      string properties = string.Empty;

      foreach (var property in this)
      {
        properties = $"{properties},\"{property.Key}\":\"{property.Value}\"";
      }

      properties = properties.Substring(Math.Min(properties.Length, 1));
      return $"\"properties\":{{{properties}}}";
    }
  }
}
