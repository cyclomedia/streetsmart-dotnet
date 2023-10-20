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

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  internal class Recording : DataConvert, IRecording
  {
    private double? _groundLevelOffset;
    private double? _recorderDirection;
    private double? _orientation;
    private DateTime? _recordedAt;
    private string _id;
    private ICoordinate _xyz;
    private string _srs;
    private double? _orientationPrecision;
    private TileSchema _tileSchema;
    private double? _longitudePrecision;
    private double? _latitudePrecision;
    private double? _heightPrecision;
    private ProductType _productType;
    private string _heightSystem;
    private DateTime? _expiredAt;
    private int? _year;

    public Recording(Dictionary<string, object> recording)
    {
      var xyz = GetDictValue(recording, "xyz");
      double x = ToDouble(xyz, "0");
      double y = ToDouble(xyz, "1");
      double z = ToDouble(xyz, "2");
      XYZ = new Coordinate(x, y, z);

      GroundLevelOffset = ToNullDouble(recording, "groundLevelOffset");
      RecorderDirection = ToNullDouble(recording, "recorderDirection");
      Orientation = ToNullDouble(recording, "orientation");
      RecordedAt = ToNullDateTime(recording, "recordedAt");
      Id = ToString(recording, "id");
      SRS = ToString(recording, "srs");
      OrientationPrecision = ToNullDouble(recording, "orientationPrecision");
      TileSchema = (TileSchema) ToEnum(typeof(TileSchema), recording, "tileSchema");
      LongitudePrecision = ToNullDouble(recording, "longitudePrecision");
      LatitudePrecision = ToNullDouble(recording, "latitudePrecision");
      HeightPrecision = ToNullDouble(recording, "heightPrecision");
      ProductType = (ProductType) ToEnum(typeof(ProductType), recording, "productType");
      HeightSystem = ToString(recording, "heightSystem");
      ExpiredAt = ToNullDateTime(recording, "expiredAt");
      Year = ToNullInt(recording, "year");
    }

    public double? GroundLevelOffset
    {
      get => _groundLevelOffset;
      set
      {
        _groundLevelOffset = value;
        RaisePropertyChanged();
      }
    }

    public double? RecorderDirection
    {
      get => _recorderDirection;
      set
      {
        _recorderDirection = value;
        RaisePropertyChanged();
      }
    }

    public double? Orientation
    {
      get => _orientation;
      set
      {
        _orientation = value;
        RaisePropertyChanged();
      }
    }

    public DateTime? RecordedAt
    {
      get => _recordedAt;
      set
      {
        _recordedAt = value;
        RaisePropertyChanged();
      }
    }

    public string Id
    {
      get => _id;
      set
      {
        _id = value;
        RaisePropertyChanged();
      }
    }

    public ICoordinate XYZ
    {
      get => _xyz;
      set
      {
        _xyz = value;
        RaisePropertyChanged();
      }
    }

    public string SRS
    {
      get => _srs;
      set
      {
        _srs = value;
        RaisePropertyChanged();
      }
    }

    public double? OrientationPrecision
    {
      get => _orientationPrecision;
      set
      {
        _orientationPrecision = value;
        RaisePropertyChanged();
      }
    }

    public TileSchema TileSchema
    {
      get => _tileSchema;
      set
      {
        _tileSchema = value;
        RaisePropertyChanged();
      }
    }

    public double? LongitudePrecision
    {
      get => _longitudePrecision;
      set
      {
        _longitudePrecision = value;
        RaisePropertyChanged();
      }
    }

    public double? LatitudePrecision
    {
      get => _latitudePrecision;
      set
      {
        _latitudePrecision = value;
        RaisePropertyChanged();
      }
    }

    public double? HeightPrecision
    {
      get => _heightPrecision;
      set
      {
        _heightPrecision = value;
        RaisePropertyChanged();
      }
    }

    public ProductType ProductType
    {
      get => _productType;
      set
      {
        _productType = value;
        RaisePropertyChanged();
      }
    }

    public string HeightSystem
    {
      get => _heightSystem;
      set
      {
        _heightSystem = value;
        RaisePropertyChanged();
      }
    }

    public DateTime? ExpiredAt
    {
      get => _expiredAt;
      set
      {
        _expiredAt = value;
        RaisePropertyChanged();
      }
    }

    public int? Year
    {
      get => _year;
      set
      {
        _year = value;
        RaisePropertyChanged();
      }
    }
  }
}
