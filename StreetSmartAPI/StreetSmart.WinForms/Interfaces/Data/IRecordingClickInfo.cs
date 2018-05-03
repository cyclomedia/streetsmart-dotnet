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

namespace StreetSmart.WinForms.Interfaces.Data
{
  /// <summary>
  /// Triggers when a recording is clicked inside the PanoramaViewer.
  /// </summary>
  public interface IRecordingClickInfo
  {
    /// <summary>
    /// The Recording clicked
    /// </summary>
    IRecording Recording { get; set; }

    /// <summary>
    /// If ctrl-key is pressed
    /// </summary>
    bool CtrlKey { get; set; }

    /// <summary>
    /// If shift-key is pressed
    /// </summary>
    bool ShiftKey { get; set; }

    /// <summary>
    /// If alt-key is pressed
    /// </summary>
    bool AltKey { get; set; }
  }
}
