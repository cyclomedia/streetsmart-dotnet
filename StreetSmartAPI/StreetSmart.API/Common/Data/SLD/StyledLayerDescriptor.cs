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

using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Data.SLD
{
  [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/sld")]
  [XmlRoot(Namespace = "http://www.opengis.net/sld", IsNullable = false)]
  #pragma warning disable 1591
  public class StyledLayerDescriptor : NotifyPropertyChanged, IStyledLayerDescriptor
  {
    // ReSharper disable once InconsistentNaming
    const string VersionNumber = "1.1.0";

    public StyledLayerDescriptor()
    {
    }

    public StyledLayerDescriptor(Rule rule)
    {
      Version = VersionNumber;

      UserLayer = new UserLayer
      {
        UserStyle = new UserStyle
        {
          FeatureTypeStyle = new FeatureTypeStyle
          {
            Rules = new ObservableCollection<Rule> {rule}
          }
        }
      };
    }

    public StyledLayerDescriptor(ObservableCollection<Rule> rules)
    {
      Version = VersionNumber;

      UserLayer = new UserLayer
      {
        UserStyle = new UserStyle
        {
          FeatureTypeStyle = new FeatureTypeStyle
          {
            Rules = rules
          }
        }
      };
    }

    private string _version;

    [XmlAttribute("version", Namespace = "http://www.opengis.net/sld")]
    public string Version
    {
      get => _version;
      set
      {
        _version = value;
        RaisePropertyChanged();
      }
    }

    private UserLayer _userLayer;

    [XmlElement("UserLayer", Namespace = "http://www.opengis.net/sld")]
    public UserLayer UserLayer
    {
      get => _userLayer;
      set
      {
        _userLayer = value;
        RaisePropertyChanged();
      }
    }

    // ReSharper disable once InconsistentNaming
    [XmlIgnore]
    public string SLD
    {
      get
      {
        XmlSerializer serializer = new XmlSerializer(typeof(StyledLayerDescriptor));
        string result;

        using (MemoryStream stream = new MemoryStream())
        {
          serializer.Serialize(stream, this);
          stream.Flush();
          stream.Position = 0;

          TextReader textReader = new StreamReader(stream);
          result = textReader.ReadToEnd();
        }

        return result;
      }
    }
  }
  #pragma warning restore 1591
}
