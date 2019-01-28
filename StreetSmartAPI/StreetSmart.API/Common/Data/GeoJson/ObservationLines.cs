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
      ActiveObservation = GetValue(observationLines, "activeObservation") as int? ?? 0;
      RecordingId = GetValue(observationLines, "recordingId")?.ToString() ?? string.Empty;
      IList<object> color = GetValue(observationLines, "color") as IList<object> ?? new List<object>();
      string selectedMeasureMethod = GetValue(observationLines, "selectedMeasureMethod")?.ToString() ?? string.Empty;

      if (color.Count >= 4)
      {
        int color0 = int.Parse(color[0].ToString());
        int color1 = int.Parse(color[1].ToString());
        int color2 = int.Parse(color[2].ToString());
        double color3 = double.Parse(color[3].ToString());
        Color = Color.FromArgb((int) (color3 * 255), color0, color1, color2);
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

    public ObservationLines(IObservationLines observationLines)
    {
      if (observationLines != null)
      {
        ActiveObservation = observationLines.ActiveObservation;
        RecordingId = observationLines.RecordingId != null ? string.Copy(observationLines.RecordingId) : null;
        Color obsColor = observationLines.Color;
        Color = Color.FromArgb(obsColor.A, obsColor);
        SelectedMeasureMethod = observationLines.SelectedMeasureMethod;
      }
    }

    public int ActiveObservation { get; }

    public string RecordingId { get; }

    public Color Color { get; }

    public MeasureMethod SelectedMeasureMethod { get; }

    public object GetValue(Dictionary<string, object> measureDetails, string value)
    {
      return measureDetails?.ContainsKey(value) ?? false ? measureDetails[value] : null;
    }

    public override string ToString()
    {
      return $"{{\"activeObservation\":{ActiveObservation},\"recordingId\":\"{RecordingId}\",\"color\":{Color.ToJsColor()}," +
             $"\"selectedMeasureMethod\":\"{SelectedMeasureMethod.Description()}\"}}";
    }
  }
}
