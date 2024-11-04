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
using System.Globalization;
using System.Linq;

namespace StreetSmart.Common.Data
{
  internal class DataConvert : NotifyPropertyChanged
  {
    protected static CultureInfo CI => CultureInfo.InvariantCulture;

    public double ToDouble(object value)
    {
      return double.TryParse(value?.ToString(), out var outValue) ? outValue : 0.0;
    }

    public double ToDouble(IDictionary<string, object> details, string value)
    {
      return ToDouble(GetValue(details, value));
    }

    public double ToDouble(object[] array, int nr)
    {
      return array.Length > nr ? ToDouble(array[nr]) : 0.0;
    }

    public double? ToNullDouble(object value)
    {
      if (double.TryParse(value?.ToString(), out var outValue))
      {
        return double.IsNaN(outValue) ? null : outValue;
      }

      return null;
    }

    public double? ToNullDouble(IDictionary<string, object> details, string value)
    {
      return ToNullDouble(GetValue(details, value));
    }

    public int ToInt(object value)
    {
      return int.TryParse(value?.ToString(), out var outValue) ? outValue : 0;
    }

    public int ToInt(object[] array, int nr)
    {
      return array.Length > nr ? ToInt(array[nr]) : 0;
    }

    public int ToInt(IDictionary<string, object> details, string value)
    {
      return ToInt(GetValue(details, value));
    }

    public int? ToNullInt(object value)
    {
      return int.TryParse(value?.ToString(), out var outValue) ? (int?)outValue : null;
    }

    public int? ToNullInt(IDictionary<string, object> details, string value)
    {
      return ToNullInt(GetValue(details, value));
    }

    public string ToNullString(object value)
    {
      return value?.ToString();
    }

    public string ToNullString(IDictionary<string, object> details, string value)
    {
      return ToNullString(GetValue(details, value));
    }

    public string ToString(object value)
    {
      return value?.ToString() ?? string.Empty;
    }

    public string ToString(IDictionary<string, object> details, string value)
    {
      return ToString(GetValue(details, value));
    }

    public DateTime? ToNullDateTime(object value)
    {
      return value == null ? null : (DateTime?)DateTime.Parse(value.ToString());
    }

    public DateTime? ToNullDateTime(IDictionary<string, object> details, string value)
    {
      return ToNullDateTime(GetValue(details, value));
    }

    public DateTime ToDateTime(object value)
    {
      return DateTime.Parse(value?.ToString());
    }

    public DateTime ToDateTime(IDictionary<string, object> details, string value)
    {
      return ToDateTime(GetValue(details, value));
    }

    public object ToEnum(Type type, object value)
    {
      return Enum.Parse(type, ToString(value));
    }

    public object ToEnum(Type type, IDictionary<string, object> details, string value)
    {
      return ToEnum(type, GetValue(details, value));
    }

    public object ToNullEnum(Type type, IDictionary<string, object> details, string value)
    {
      var v = GetValue(details, value);
      return v == null ? null : ToEnum(type, v);
    }

    public bool ToBool(object value)
    {
      return (bool)(value ?? false);
    }

    public bool ToBool(IDictionary<string, object> details, string value)
    {
      return ToBool(GetValue(details, value));
    }

    public Dictionary<string, object> ToDictionary(object value, bool nullable = false)
    {
      if (value == null)
      {
        return nullable ? null : [];
      }

      try
      {
        if (value is Dictionary<string, object> objects)
        {
          return objects;
        }
        else if (value is IDictionary<string, object> dict)
        {
          return dict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        else
        {
          return value.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(value, null));
        }
      }
      catch
      {
        return nullable ? null : [];
      }
    }

    public static IList<object> ToList(object value, bool nullable = false)
    {
      return value as IList<object> ?? (nullable ? null : new List<object>());
    }

    public object[] ToArray(object value)
    {
      if (value is IList<object>)
      {
        return (value as IList<object>)?.ToArray() ?? [];
      }

      return [];
    }

    public object[] GetArrayValue(IDictionary<string, object> details, string value)
    {
      return ToArray(GetValue(details, value));
    }

    public object GetValue(IDictionary<string, object> details, string value)
    {
      return details?.ContainsKey(value) ?? false ? details[value] : null;
    }

    public Dictionary<string, object> GetDictValue(IDictionary<string, object> details, string value)
    {
      return ToDictionary(GetValue(details, value));
    }

    public Dictionary<string, object> GetNullDictValue(IDictionary<string, object> details, string value)
    {
      return ToDictionary(GetValue(details, value), true);
    }

    public IList<object> GetListValue(IDictionary<string, object> details, string value)
    {
      return ToList(GetValue(details, value), false);
    }

    public IList<object> GetNullListValue(IDictionary<string, object> details, string value)
    {
      return ToList(GetValue(details, value), true);
    }
  }
}
