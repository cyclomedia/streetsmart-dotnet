/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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

namespace StreetSmart.WinForms.Interfaces
{
  /// <summary>
  /// Name of the style element
  /// </summary>
  public enum StyleElementName
  {
    /// <summary>
    /// Width valueof the style element
    /// </summary>
    [Description("width")]
    Width = 1,

    /// <summary>
    /// Height value of the style element
    /// </summary>
    [Description("height")]
    Height = 2,

    /// <summary>
    /// Position of the style element
    /// </summary>
    [Description("position")]
    Position = 3,

    /// <summary>
    /// Top value of the style element
    /// </summary>
    [Description("top")]
    Top = 4,

    /// <summary>
    /// Left value of the style element
    /// </summary>
    [Description("left")]
    Left = 5
  }
}
