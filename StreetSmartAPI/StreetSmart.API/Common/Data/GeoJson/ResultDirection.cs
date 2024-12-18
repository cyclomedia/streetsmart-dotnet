﻿/*
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
using System.Drawing;
using System.IO;

namespace StreetSmart.Common.Data.GeoJson
{
  internal class ResultDirection : DataConvert, IResultDirection, IEquatable<ResultDirection>
  {
    private readonly string _matchImage;

    public ResultDirection(IDictionary<string, object> resultDirection)
    {
      Id = ToString(resultDirection, "Id");
      _matchImage = ToString(resultDirection, "MatchImage");

      if (!string.IsNullOrEmpty(_matchImage))
      {
        byte[] bytes = Convert.FromBase64String(_matchImage);
        MatchImage = new Bitmap(new MemoryStream(bytes));
      }
    }

    public ResultDirection(IResultDirection resultDirection)
    {
      if (resultDirection != null)
      {
        Id = resultDirection.Id;
        MatchImage = (Image)MatchImage?.Clone();
        _matchImage = (resultDirection as ResultDirection)?._matchImage;
      }
    }

    public string Id { get; }

    public Image MatchImage { get; }

    public bool Equals(ResultDirection other)
    {
      if (other == null)
      {
        return false;
      }

      if (MatchImage == null != (other.MatchImage == null))
      {
        return false;
      }

      if (MatchImage != null && other.MatchImage != null)
      {
        if (!MatchImage.Equals(other.MatchImage))
        {
          return false;
        }
      }

      return Id.Equals(other.Id);
    }
    public override bool Equals(object obj)
    {
      return Equals(obj as ResultDirection);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
    {
      return $"{{\"Id\":\"{Id}\",\"MatchImage\":\"{_matchImage}\"}}";
    }


  }
}
