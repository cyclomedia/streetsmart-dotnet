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

using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetSmart.Common.Data
{
  internal class Json : Dictionary<string, string>, IJson
  {
    public Json()
    {
    }

    public Json(IDictionary<string, object> properties)
    {
      foreach (var property in properties)
      {
        Add(property.Key, property.Value.ToString());
      }
    }

    public Json(Dictionary<string, string> properties)
    {
      foreach (var property in properties)
      {
        Add(property.Key, property.Value);
      }
    }

    public override string ToString()
    {
      List<string> properies = new List<string>();

      foreach (KeyValuePair<string, string> keyValue in this)
      {
        properies.Add($"{keyValue.Key.ToQuote()}:{keyValue.Value.ToQuote()}");
      }

      string result = properies.Aggregate(string.Empty, (current, part) => $"{current},{part}");
      return $"{{{result.Substring(Math.Min(result.Length, 1))}}}";
    }
  }
}
