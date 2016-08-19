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

namespace StreetSmart.WinForms.Interfaces
{
  // ReSharper disable InconsistentNaming
  public interface ICycloramaViewer
  {
    /// <summary>
    /// 
    /// </summary>
    event EventHandler RecordingClick;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler ImageChanged;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler ViewChanged;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler ViewLoadStarted;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler ViewLoaded;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler TileLoadError;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageId"></param>
    /// <param name="srsName"></param>
    void OpenByImageId(string imageId, string srsName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deltaYaw"></param>
    void RotateLeft(double deltaYaw);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deltaYaw"></param>
    void RotateRight(double deltaYaw);

    /// <summary>
    /// 
    /// </summary>
    void GetRecording();
  }

  // ReSharper restore InconsistentNaming
}
