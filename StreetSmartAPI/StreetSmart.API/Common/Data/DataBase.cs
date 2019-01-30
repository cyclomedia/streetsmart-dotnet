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

namespace StreetSmart.Common.Data
{
  class DataBase : NotifyPropertyChanged
  {
    protected double ToDouble(object oValue)
    {
      return double.TryParse(oValue?.ToString(), out var dValue) ? dValue : 0.0;
    }

    protected double ToDouble(Dictionary<string, object> measureDetails, string value)
    {
      return ToDouble(GetValue(measureDetails, value));
    }

    protected double? ToNullDouble(object oValue)
    {
      return double.TryParse(oValue?.ToString(), out var dValue) ? (double?) dValue : null;
    }

    protected double? ToNullDouble(Dictionary<string, object> measureDetails, string value)
    {
      return ToNullDouble(GetValue(measureDetails, value));
    }

    protected object GetValue(Dictionary<string, object> measureDetails, string value)
    {
      return measureDetails?.ContainsKey(value) ?? false ? measureDetails[value] : null;
    }
  }
}
