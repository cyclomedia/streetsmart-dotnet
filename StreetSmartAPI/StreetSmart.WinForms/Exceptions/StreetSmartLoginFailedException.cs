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

namespace StreetSmart.WinForms.Exceptions
{
  /// <inheritdoc />
  /// <summary>
  /// Exception when Login failed
  /// </summary>
  public class StreetSmartLoginFailedException : Exception
  {
    /// <inheritdoc />
    /// <summary>
    /// Create StreetSmartLoginFailedException class
    /// </summary>
    /// <param name="message">The message of the exception</param>
    public StreetSmartLoginFailedException(string message) : base(message)
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Create StreetSmartLoginFailedException class
    /// </summary>
    /// <param name="message">The message of the exception</param>
    /// <param name="inner">The inner exception</param>
    public StreetSmartLoginFailedException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
