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
using System.Globalization;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class DetailsSmartClick: DetailsForwardIntersection, IDetailsSmartClick
  {
    public DetailsSmartClick(Dictionary<string, object> detailsSmartClick)
    : base(detailsSmartClick)
    {
      Confidence = ToInt(detailsSmartClick, "Confidence");
      Depth = ToDouble(detailsSmartClick, "Depth");
    }

    public DetailsSmartClick(IDetailsSmartClick detailsSmartClick)
      : base(detailsSmartClick)
    {
      if (detailsSmartClick != null)
      {
        Confidence = detailsSmartClick.Confidence;
        Depth = detailsSmartClick.Depth;
      }
    }

    public int Confidence { get; }

    public double Depth { get; }

    public override string ToString()
    {
      CultureInfo ci = CultureInfo.InvariantCulture;
      string baseStr = base.ToString();
      string subStr = baseStr.Substring(0, Math.Max(baseStr.Length - 1, 1));
      string comma = subStr.Length >= 1 ? "," : string.Empty;
      return $"{subStr}{comma}\"Confidence\":{Confidence},\"Depth\":{Depth.ToString(ci)}}}";
    }
  }
}
