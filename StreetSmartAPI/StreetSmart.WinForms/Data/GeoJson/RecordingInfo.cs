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

using System.Collections.Generic;

using StreetSmart.WinForms.Interfaces.GeoJson;

namespace StreetSmart.WinForms.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class RecordingInfo : NotifyPropertyChanged, IRecordingInfo
  {
    public RecordingInfo(Dictionary<string, object> recordingInfo)
    {
      Id = recordingInfo?["id"]?.ToString() ?? string.Empty;
      Dictionary<string, object> xyz = recordingInfo?["xyz"] as Dictionary<string, object>;
      SRS = recordingInfo?["srs"]?.ToString() ?? string.Empty;
      double yaw = recordingInfo?["yaw"] as double? ?? 0.0;
      IList<object> xyzStdev = recordingInfo?["xyzStdev"] as IList<object> ?? new List<object>();
      double yawStdev = recordingInfo?["yawStdev"] as double? ?? 0.0;
      DepthStdev = recordingInfo?["depthStdev"] as double? ?? 0.0;

      Position = new PositionStdev(xyz, xyzStdev);
      Yaw = new Property(yaw, yawStdev);
    }

    public string Id { get; }

    public IPositionStdev Position { get; }

    // ReSharper disable once InconsistentNaming
    public string SRS { get; }

    public IProperty Yaw { get; }

    public double DepthStdev { get; }
  }
}
