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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class Properties : Dictionary<string, object>, IProperties, IEquatable<Properties>
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public Properties()
    {
    }

    public Properties(IDictionary<string, object> properties)
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
      var properties = new StringBuilder();

      foreach (var property in this)
      {
        string value = property.Value.ToString()?.Replace('\"', '\'');

        if (properties.Length > 0)
        {
          properties.Append(",");
        }

        properties.Append($"\"{property.Key}\":\"{value}\"");
      }

      return $"\"properties\":{{{properties}}}";
    }

    public bool Equals(Properties other)
    {
      if (other == null)
      {
        return false;
      }

      if (Count != other.Count)
      {
        return false;
      }

      foreach (var pair in this)
      {
        var key = pair.Key;
        if (!other.TryGetValue(key, out var otherValue))
        {
          return false;
        }

        if (!Equals(pair.Value, otherValue))
        {
          return false;
        }
      }

      return true;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Properties);
    }

    public override int GetHashCode() => (Keys, Values).GetHashCode();
  }
}
