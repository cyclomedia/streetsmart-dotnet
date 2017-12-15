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

using System.Threading.Tasks;

namespace StreetSmart.WinForms.Interfaces
{
  /// <inheritdoc />
  /// <summary>
  /// ObliqueViewer component. Gets created by the StreetSmartAPI.
  /// </summary>
  public interface IObliqueViewer : IViewer
  {
    /// <summary>
    /// Get the visibility of a button
    /// </summary>
    /// <param name="buttonId"></param>
    /// <returns></returns>
    Task<bool> GetButtonEnabled(ObliqueViewerButtons buttonId);

    /// <summary>
    /// Toggle the visibility of a button.
    /// </summary>
    /// <param name="buttonId"></param>
    /// <param name="enabled">if available, sets enabled to this value</param>
    void ToggleButtonEnabled(ObliqueViewerButtons buttonId, bool enabled);
  }
}
