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

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class FeatureInfo : DataConvert, IFeatureInfo
  {
    private string _layerName;
    private string _layerId;
    private IJson _featureProperties;

    public FeatureInfo(Dictionary<string, object> featureInfo)
    {
      LayerName = ToString(featureInfo, "layerName");
      LayerId = ToString(featureInfo, "layerId");
      FeatureProperties = new Json(GetDictValue(featureInfo, "featureProperties"));
    }

    public string LayerName
    {
      get => _layerName;
      set
      {
        _layerName = value;
        RaisePropertyChanged();
      }
    }

    public string LayerId
    {
      get => _layerId;
      set
      {
        _layerId = value;
        RaisePropertyChanged();
      }
    }

    public IJson FeatureProperties
    {
      get => _featureProperties;
      set
      {
        _featureProperties = value;
        RaisePropertyChanged();
      }
    }
  }
}
