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

using StreetSmart.WinForms.Data;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Factories
{
  /// <summary>
  /// 
  /// </summary>
  public static class PanoramaViewerOptionsFactory
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="recordingsVisible"></param>
    /// <returns></returns>
    public static IPanoramaViewerOptions CreateRecordingsVisible(bool recordingsVisible)
      => new PanoramaViewerOptions(recordingsVisible, null, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeTravelVisible"></param>
    /// <returns></returns>
    public static IPanoramaViewerOptions CreateTimeTravelVisible(bool timeTravelVisible)
      => new PanoramaViewerOptions(null, timeTravelVisible, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="navBarVisible"></param>
    /// <returns></returns>
    public static IPanoramaViewerOptions CreateNavBarVisible(bool navBarVisible)
      => new PanoramaViewerOptions(null, null, navBarVisible);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IPanoramaViewerOptions Create() => new PanoramaViewerOptions(null, null, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="recordingsVisible"></param>
    /// <param name="timeTravelVisible"></param>
    /// <param name="navBarVisible"></param>
    /// <returns></returns>
    public static IPanoramaViewerOptions Create(bool recordingsVisible, bool timeTravelVisible, bool navBarVisible)
      => new PanoramaViewerOptions(recordingsVisible, timeTravelVisible, navBarVisible);
  }
}
