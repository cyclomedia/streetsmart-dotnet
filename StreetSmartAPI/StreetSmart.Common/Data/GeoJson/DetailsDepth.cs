/*
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

using System.Collections.Generic;
using System.Globalization;

using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DetailsDepth: Details, IDetailsDepth
  {
    public DetailsDepth(Dictionary<string, object> details)
    {
      var position = GetDictValue(details, "position");
      var direction = GetDictValue(details, "direction");
      DepthInMeters = ToDouble(details, "depthInMeters");
      Depth = ToDouble(details, "depth");
      var recordingInfo = GetDictValue(details, "recordingInfo");

      Position = new PositionXYZ(position);
      Direction = new Direction(direction);
      RecordingInfo = new RecordingInfo(recordingInfo);
    }

    public DetailsDepth(IDetailsDepth detailsDepth)
    {
      if (detailsDepth != null)
      {
        Position = new PositionXYZ(detailsDepth.Position);
        Direction = new Direction(detailsDepth.Direction);
        DepthInMeters = detailsDepth.DepthInMeters;
        Depth = detailsDepth.Depth;
        RecordingInfo = new RecordingInfo(detailsDepth.RecordingInfo);
      }
    }

    public IPositionXYZ Position { get; }

    public IDirection Direction { get; }

    public double DepthInMeters { get; }

    public double Depth { get; }

    public IRecordingInfo RecordingInfo { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      return $"{{\"position\":{Position},\"direction\":{Direction},\"depthInMeters\":{DepthInMeters.ToString(ci)},\"depth\":{Depth.ToString(ci)},\"recordingInfo\":{RecordingInfo}}}";
    }
  }
}
