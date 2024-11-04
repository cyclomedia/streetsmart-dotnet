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

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create Json objects
  /// </summary>
  public static class JsonFactory
  {
    /// <summary>
    /// Create JSON object with given properties
    /// </summary>
    /// <param name="properties">The properties of the JSON object</param>
    /// <returns>JSon object, which contains the specified properties</returns>
    public static IJson Create(Dictionary<string, string> properties) => new Json(properties);

    /// <summary>
    /// create a JSON object
    /// </summary>
    /// <returns>JSon object</returns>
    public static IJson Create() => new Json();
  }
}
