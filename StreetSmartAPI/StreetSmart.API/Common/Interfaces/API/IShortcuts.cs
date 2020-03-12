/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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

namespace StreetSmart.Common.Interfaces.API
{
  /// <summary>
  /// API used to use and modify various StreetSmart components.
  /// </summary>
  public interface IShortcuts
  {
    #region Interface functions

    /// <summary>
    /// Removes a shortcut from the list of enabledShortcuts. Can be added with enableShortcut
    /// </summary>
    /// <param name="shortcutNames"> The name of the shortcut</param>
    /// <returns>
    /// - true : if shortcut has been disabled.
    /// - false: if unknown shortcut or already disallowed.
    /// </returns>
    Task<bool> DisableShortcut(ShortcutNames shortcutNames);

    /// <summary>
    /// Add a shortcut to the list of enabledShortcuts. Can be removed with disableShortcut
    /// </summary>
    /// <param name="shortcutNames">The name of the shortcut</param>
    /// <returns>
    /// - true : true if shortcut has been enabled.
    /// - false: if unknown shortcut or already allowed.
    /// </returns>
    Task<bool> EnableShortcut(ShortcutNames shortcutNames);

    #endregion
  }
}
