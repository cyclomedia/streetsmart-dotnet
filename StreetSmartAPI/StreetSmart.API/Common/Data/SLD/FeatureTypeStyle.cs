/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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

using System.Collections.ObjectModel;
using System.Xml.Serialization;

using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Data.SLD
{
  #pragma warning disable 1591
  /// <exclude/>
  public class FeatureTypeStyle : NotifyPropertyChanged, IFeatureTypeStyle
  {
    private ObservableCollection<Rule> _rule;

    [XmlElement("Rule", Namespace = "http://www.opengis.net/se")]
    public ObservableCollection<Rule> Rules
    {
      get => _rule;
      set
      {
        _rule = value;
        RaisePropertyChanged();
      }
    }
  }
  #pragma warning restore 1591
}
