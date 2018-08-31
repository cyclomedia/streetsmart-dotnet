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

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DetailsDepth: Details, IDetailsDepth
  {
    public DetailsDepth(Dictionary<string, object> details)
    {
      Dictionary<string, object> position = details?["position"] as Dictionary<string, object>;
      Dictionary<string, object> direction = details?["direction"] as Dictionary<string, object>;
      DepthInMeters = details?["depthInMeters"] as double? ?? 0.0;
      Depth = details?["depth"] as double? ?? 0.0;
      Dictionary<string, object> recordingInfo = details?["recordingInfo"] as Dictionary<string, object>;

      Position = new PositionXYZ(position);
      Direction = new Direction(direction);
      RecordingInfo = new RecordingInfo(recordingInfo);
    }

    public IPositionXYZ Position { get; }

    public IDirection Direction { get; }

    public double DepthInMeters { get; }

    public double Depth { get; }

    public IRecordingInfo RecordingInfo { get; }
  }
}
