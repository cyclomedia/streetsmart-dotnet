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

using StreetSmart.Common.Data.SLD;
using System.Collections.ObjectModel;

namespace StreetSmart.Common.Interfaces.SLD
{
  /// <summary>
  /// Feature type style
  /// </summary>
  public interface IFeatureTypeStyle
  {
    /// <summary>
    /// Rules of the style
    /// </summary>
    ObservableCollection<Rule> Rules { get; set; }
  }
}
