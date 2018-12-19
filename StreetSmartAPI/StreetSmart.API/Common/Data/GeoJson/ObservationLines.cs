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

using System;
using System.Collections.Generic;
using System.Drawing;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class ObservationLines: NotifyPropertyChanged, IObservationLines
  {
    public ObservationLines(Dictionary<string, object> observationLines)
    {
      ActiveObservation = observationLines?["activeObservation"] as int? ?? 0;
      RecordingId = observationLines?["recordingId"]?.ToString() ?? string.Empty;
      IList<object> color = observationLines?["color"] as IList<object> ?? new List<object>();
      string selectedMeasureMethod = observationLines?["selectedMeasureMethod"]?.ToString() ?? string.Empty;

      if (color.Count >= 4)
      {
        Color = Color.FromArgb((int) ((double) color[3] * 255), (int) color[0], (int) color[1], (int) color[2]);
      }

      try
      {
        SelectedMeasureMethod = (MeasureMethod) Enum.Parse(typeof(MeasureMethod), selectedMeasureMethod);
      }
      catch (ArgumentException)
      {
        SelectedMeasureMethod = MeasureMethod.NotDefined;
      }
    }

    public int ActiveObservation { get; }

    public string RecordingId { get; }

    public Color Color { get; }

    public MeasureMethod SelectedMeasureMethod { get; }

    public override string ToString()
    {
      return $"{{\"activeObservation\":{ActiveObservation},\"recordingId\":\"{RecordingId}\",\"color\":{Color.ToJsColor()}," +
             $"\"selectedMeasureMethod\":\"{SelectedMeasureMethod.Description()}\"}}";
    }
  }
}
