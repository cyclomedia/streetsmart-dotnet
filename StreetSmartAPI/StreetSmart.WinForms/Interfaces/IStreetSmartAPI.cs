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
using StreetSmart.WinForms.Events;

namespace StreetSmart.WinForms.Interfaces
{
  // ReSharper disable InconsistentNaming
  public interface IStreetSmartAPI
  {
    /// <summary>
    /// 
    /// </summary>
    event EventHandler FrameLoaded;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler<EventInitArgs> InitComplete;

    /// <summary>
    /// 
    /// </summary>
    event EventHandler<EventLoginArgs> LoginComplete;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    void Login(string username, string password);

    /// <summary>
    /// 
    /// </summary>
    StreetSmartGUI GUI { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewerObjectName"></param>
    /// <returns></returns>
    ICycloramaViewer CreateCycloramaViewer(string viewerObjectName);
  }

  // ReSharper restore InconsistentNaming
}
