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
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// Triggers when a recording is clicked inside the PanoramaViewer.
  /// </summary>
  public class EventRecordingClickArgs : EventArgs
  {
    /// <summary>
    /// The Recording clicked
    /// </summary>
    public Recording Recording { get; set; }

    /// <summary>
    /// If ctrl-key is pressed
    /// </summary>
    public bool ctrlKey { get; set; }

    /// <summary>
    /// If shift-key is pressed
    /// </summary>
    public bool shiftKey { get; set; }

    /// <summary>
    /// If alt-key is pressed
    /// </summary>
    public bool altKey { get; set; }
  }

  // ReSharper restore InconsistentNaming
}
