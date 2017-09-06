/*
 * Street Smart .NET integration
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

using System.Collections.Generic;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data
{
  internal class RecordingClickInfo : NotifyPropertyChanged, IRecordingClickInfo
  {
    private IRecording _recording;
    private bool _ctrlKey;
    private bool _shiftKey;
    private bool _altKey;

    public RecordingClickInfo(Dictionary<string, object> recording, Dictionary<string, object> eventData)
    {
      Recording = new Recording(recording);
      ShiftKey = (bool) eventData["shiftKey"];
      AltKey = (bool) eventData["altKey"];
      CtrlKey = (bool) eventData["ctrlKey"];
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
