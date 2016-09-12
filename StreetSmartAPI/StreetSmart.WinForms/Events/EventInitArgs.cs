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

using System;

namespace StreetSmart.WinForms.Events
{
  /// <summary>
  /// Triggers when the init of the API is complete.
  /// </summary>
  public class EventInitArgs : EventArgs
  {
    /// <summary>
    /// true = login success
    /// false = login failed
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Error message in case of login is failed.
    /// </summary>
    public string ErrorMessage { get; set; }
  }
}
