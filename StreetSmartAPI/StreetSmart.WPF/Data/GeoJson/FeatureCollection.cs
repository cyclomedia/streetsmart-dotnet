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

using StreetSmart.Wpf.Interfaces.GeoJson;

namespace StreetSmart.Wpf.Data.GeoJson
{
  internal class FeatureCollection: NotifyPropertyChanged, IFeatureCollection
  {
    public FeatureCollection(Dictionary<string, object> featureCollection)
    {
      string type = featureCollection?["type"]?.ToString() ?? string.Empty;
      IList<object> features = featureCollection?["features"] as IList<object> ?? new List<object>();
      Dictionary<string, object> crs = featureCollection?["crs"] as Dictionary<string, object>;

      Features = new List<IFeature>();
      CRS = new CRS(crs);

      try
      {
        Type = (FeatureType) Enum.Parse(typeof(FeatureType), type);
      }
      catch (ArgumentException)
      {
        Type = FeatureType.Unknown;
      }

      foreach (var feature in features)
      {
        Features.Add(new Feature(feature as Dictionary<string, object>));
      }
    }

    public FeatureType Type { get; }

    public IList<IFeature> Features { get; }

    // ReSharper disable once InconsistentNaming
    public ICRS CRS { get; }
  }
}
