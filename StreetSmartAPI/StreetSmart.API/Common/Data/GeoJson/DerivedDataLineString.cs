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
  // ReSharper disable once InconsistentNaming
  internal class DerivedDataLineString : DerivedData, IDerivedDataLineString
  {
    public DerivedDataLineString(Dictionary<string, object> derivedData)
      : base(derivedData)
    {
      // ReSharper disable InconsistentNaming
      IList<object> coordinateStdevs = derivedData?["coordinateStdevs"] as IList<object> ?? new List<object>();
      TotalLength = getStdValue(derivedData, "totalLength");
      SegmentLengths = GetStdValueList(derivedData, "segmentLengths");
      SegmentsDeltaXY = GetStdValueList(derivedData, "segmentsDeltaXY");
      SegmentsDeltaZ = GetStdValueList(derivedData, "segmentsDeltaZ");
      SegmentSlopePercentage = GetStdValueList(derivedData, "segmentsSlopePercentage");
      SegmentsSlopeAngle = GetStdValueList(derivedData, "segmentsSlopeAngle");
      DeltaXY = getStdValue(derivedData, "deltaXY");
      DeltaZ = getStdValue(derivedData, "deltaZ");
      // ReSharper restore InconsistentNaming

      CoordinateStdev = new List<IStdev>();

      foreach (var coordinateStdev in coordinateStdevs)
      {
        CoordinateStdev.Add(new Stdev(coordinateStdev as Dictionary<string, object>));
      }
    }

    public IList<IStdev> CoordinateStdev { get; }

    public IProperty TotalLength { get; }

    public IList<IProperty> SegmentLengths { get; }

    // ReSharper disable once InconsistentNaming
    public IList<IProperty> SegmentsDeltaXY { get; }

    public IList<IProperty> SegmentsDeltaZ { get; }

    public IList<IProperty> SegmentSlopePercentage { get; }

    public IList<IProperty> SegmentsSlopeAngle { get; }

    public IProperty DeltaXY { get; }

    public IProperty DeltaZ { get; }

    private IList<IProperty> GetStdValueList(Dictionary<string, object> derivedData, string key)
    {
      object input = derivedData?.ContainsKey(key) ?? false ? derivedData[key] : null;
      List<IProperty> result = null;

      if (input != null)
      {
        Dictionary<string, object> dictInput = input as Dictionary<string, object>;

        if (dictInput?["value"] is IList<object> value)
        {
          IList<object> stdevstList = dictInput["stdev"] as IList<object>;
          result = new List<IProperty>();

          for (int i = 0; i < value.Count; i++)
          {
            result.Add(new Property(value[i], stdevstList != null && i < stdevstList.Count ? stdevstList[i] : null));
          }
        }
      }

      return result;
    }

    protected IProperty getStdValue(Dictionary<string, object> derivedData, string key)
    {
      object input = derivedData?.ContainsKey(key) ?? false ? derivedData[key] : null;
      IProperty result = null;

      if (input != null)
      {
        Dictionary<string, object> dictInput = input as Dictionary<string, object>;
        double? stdev = dictInput?.ContainsKey("stdev") ?? false ? dictInput["stdev"] as double? : null;
        result = new Property(dictInput?["value"], stdev);
      }

      return result;
    }
  }
}
