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

using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Data.SLD
{
  #pragma warning disable 1591
  /// <exclude/>
  public class InlineContent : NotifyPropertyChanged, IInlineContent
  {
    public InlineContent()
    {
    }

    public InlineContent(Encoding encoding, string value)
    {
      Encoding = encoding;
      Value = value;
    }

    public InlineContent(Encoding encoding, Image image)
    {
      Encoding = encoding;

      if (encoding == Encoding.Base64)
      {
        using (MemoryStream stream = new MemoryStream())
        {
          image.Save(stream, image.RawFormat);
          byte[] imageBytes = stream.ToArray();
          Value = Convert.ToBase64String(imageBytes);
        }
      }
    }

    private Encoding _encoding;

    [XmlAttribute("encoding", Namespace = "http://www.opengis.net/se")]
    public Encoding Encoding
    {
      get => _encoding;
      set
      {
        _encoding = value;
        RaisePropertyChanged();
      }
    }

    private string _value;

    [XmlText]
    public string Value
    {
      get => _value;
      set
      {
        _value = value;
        RaisePropertyChanged();
      }
    }
  }

  #pragma warning restore 1591
}
