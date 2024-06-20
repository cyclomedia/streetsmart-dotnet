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

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using StreetSmart.Common.Interfaces.GeoJson;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class FeatureCollection: DataConvert, IFeatureCollection//, IEquatable<IFeatureCollection>
  {
    public FeatureCollection(ExpandoObject featureCollection, bool measurementProperties)
    {
      GetFeatures(ToDictionary(featureCollection), measurementProperties);
    }

    public FeatureCollection(Dictionary<string, object> featureCollection, bool measurementProperties)
    {
      GetFeatures(featureCollection, measurementProperties);
    }

    private void GetFeatures(Dictionary<string, object> featureCollection, bool measurementProperties)
    {
      var features = GetListValue(featureCollection, "features");
      var crs = GetDictValue(featureCollection, "crs");

      Features = new List<IFeature>();
      CRS = new CRS(crs);

      try
      {
        Type = (FeatureType)ToEnum(typeof(FeatureType), featureCollection, "type");
      }
      catch (ArgumentException)
      {
        Type = FeatureType.Unknown;
      }

      foreach (var feature in features)
      {
        Features.Add(new Feature(feature, measurementProperties));
      }
    }

    public FeatureCollection(int wkid)
    {
      Type = FeatureType.FeatureCollection;
      Features = new List<IFeature>();
      CRS = new CRS(wkid);
    }

    public FeatureCollection(IFeatureCollection featureCollection)
    {
      if (featureCollection != null)
      {
        Type = featureCollection.Type;

        if (featureCollection.Features != null)
        {
          Features = new List<IFeature>();

          foreach (IFeature feature in featureCollection.Features)
          {
            Features.Add(new Feature(feature));
          }
        }

        CRS = new CRS(featureCollection.CRS);
      }
    }

    public FeatureType Type { get; private set; }

    public IList<IFeature> Features { get; private set; }

    // ReSharper disable once InconsistentNaming
    public ICRS CRS { get; private set; }
    public override string ToString()
    {
      var featuresBuilder = new StringBuilder();

      foreach (var feature in Features)
      {
        if (featuresBuilder.Length > 0) featuresBuilder.Append(",");
        featuresBuilder.Append(feature);
      }
      return $"{{\"type\":\"{Type.Description()}\",{CRS},\"features\": [{featuresBuilder}]}}";
    }


    //public override string ToString()
    //{
    //  string features = Features.Aggregate(string.Empty, (current, feature) => $"{current},{feature}");
    //  features = features.Substring(Math.Min(features.Length, 1));
    //  return $"{{\"type\":\"{Type.Description()}\",{CRS},\"features\": [{features}]}}";
    //}

    //public bool Equals(IFeatureCollection other)
    //{
    //  if (other == this)
    //  {
    //    return true;
    //  }

    //  if (other == null || other.Features.Count != this.Features.Count)
    //  {
    //    return false;
    //  }

    //  for(int i = 0; i < this.Features.Count; i++)
    //  {
    //    if (!this.Features[i].Equals(other.Features[i]))
    //    {
    //      return false;
    //    }
    //  }
    //  return true;
    //}

    //public override bool Equals(object obj)
    //{
    //  return Equals(obj as FeatureCollection);
    //}

    //public override int GetHashCode() => (Type, CRS, Features).GetHashCode();

  }
}
