﻿/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2021, CycloMedia, All rights reserved.
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

using CefSharp;
using System.Collections.Generic;

namespace StreetSmart.Common.Handlers
{
  internal class BrowserProcessHandler : IBrowserProcessHandler
  {
    public virtual void Dispose()
    {
    }

    public virtual void OnContextInitialized()
    {
    }

    public virtual void OnScheduleMessagePumpWork(long delay)
    {
    }

    public bool OnAlreadyRunningAppRelaunch(IReadOnlyDictionary<string, string> commandLine, string currentDirectory)
    {
      return true;
    }
  }
}
