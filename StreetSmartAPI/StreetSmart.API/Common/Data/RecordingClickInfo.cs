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

using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;

namespace StreetSmart.Common.Data
{
  internal class RecordingClickInfo : DataConvert, IRecordingClickInfo
  {
    private IRecording _recording;
    private bool _ctrlKey;
    private bool _shiftKey;
    private bool _altKey;

    public RecordingClickInfo(IDictionary<string, object> recording, Dictionary<string, object> eventData)
    {
      Recording = new Recording(recording);
      ShiftKey = ToBool(eventData, "shiftKey");
      AltKey = ToBool(eventData, "altKey");
      CtrlKey = ToBool(eventData, "ctrlKey");
    }

    public IRecording Recording
    {
      get => _recording;
      set
      {
        _recording = value;
        RaisePropertyChanged();
      }
    }

    public bool CtrlKey
    {
      get => _ctrlKey;
      set
      {
        _ctrlKey = value;
        RaisePropertyChanged();
      }
    }

    public bool ShiftKey
    {
      get => _shiftKey;
      set
      {
        _shiftKey = value;
        RaisePropertyChanged();
      }
    }

    public bool AltKey
    {
      get => _altKey;
      set
      {
        _altKey = value;
        RaisePropertyChanged();
      }
    }
  }
}
