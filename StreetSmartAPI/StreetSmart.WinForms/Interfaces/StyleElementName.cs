/*
 * Integration in ArcMap for Cycloramas
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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
  /// 
  /// </summary>
  public enum StyleElementName
  {
    /// <summary>
    /// 
    /// </summary>
    [Description("width")]
    Width = 1,

    /// <summary>
    /// 
    /// </summary>
    [Description("height")]
    Height = 2,

    /// <summary>
    /// 
    /// </summary>
    [Description("position")]
    Position = 3,

    /// <summary>
    /// 
    /// </summary>
    [Description("top")]
    Top = 4,

    /// <summary>
    /// 
    /// </summary>
    [Description("left")]
    Left = 5
  }
}
