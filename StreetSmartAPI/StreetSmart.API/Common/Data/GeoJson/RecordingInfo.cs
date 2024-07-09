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

using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace StreetSmart.Common.Data.GeoJson
{
  // ReSharper disable once InconsistentNaming
  internal class RecordingInfo : DataConvert, IRecordingInfo
  {
    public RecordingInfo(Dictionary<string, object> recordingInfo)
    {
      Id = ToString(recordingInfo, "id");
      var xyz = GetDictValue(recordingInfo, "xyz");
      SRS = ToString(recordingInfo, "srs");
      double yaw = ToDouble(recordingInfo, "yaw");
      var xyzStdev = GetListValue(recordingInfo, "xyzStdev");
      double yawStdev = ToDouble(recordingInfo, "yawStdev");
      DepthStdev = ToDouble(recordingInfo, "depthStdev");
      RecordedAt = ToNullDateTime(recordingInfo, "recordedAt");

      Resolution = new Resolution(recordingInfo);
      Position = new PositionStdev(xyz, xyzStdev);
      Yaw = new Property(yaw, yawStdev);
    }

    public RecordingInfo(IRecordingInfo recordingInfo)
    {
      if (recordingInfo != null)
      {
        Id = recordingInfo.Id;
        Position = new PositionStdev(recordingInfo.Position);
        SRS = recordingInfo.SRS;
        Yaw = new Property(recordingInfo.Yaw);
        DepthStdev = recordingInfo.DepthStdev;
        Resolution = new Resolution(recordingInfo.Resolution);

        if (recordingInfo.RecordedAt != null)
        {
          DateTime recordedAt = (DateTime)recordingInfo.RecordedAt;
          RecordedAt = DateTime.FromBinary(recordedAt.ToBinary());
        }
      }
    }

    public string Id { get; }

    public IPositionStdev Position { get; }

    // ReSharper disable once InconsistentNaming
    public string SRS { get; }

    public IProperty Yaw { get; }

    public double DepthStdev { get; }

    public DateTime? RecordedAt { get; }

    public IResolution Resolution { get; }

    public override string ToString()
    {
      string jsDate = RecordedAt.ToJsDateTime();
      string dateString = string.IsNullOrEmpty(jsDate) ? string.Empty : $",\"recordedAt\":\"{jsDate}\"";
      CultureInfo ci = CultureInfo.InvariantCulture;
      return
        $"{{\"id\":\"{Id}\",{Position},\"srs\":\"{SRS}\",\"yaw\":{Yaw?.Value?.ToString(ci)},\"yawStdev\":{Yaw?.Stdev?.ToString(ci)},\"depthStdev\":{DepthStdev.ToString(ci)},{Resolution}{dateString}}}";
    }
  }
}
