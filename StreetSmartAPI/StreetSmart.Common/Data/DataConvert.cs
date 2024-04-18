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
using System.Globalization;
using System.Linq;

namespace StreetSmart.Common.Data
{
  public static class DataConvert
  {
    public static CultureInfo CI => CultureInfo.InvariantCulture;

    public static double ToDouble(object value)
    {
      return double.TryParse(value?.ToString(), out var outValue) ? outValue : 0.0;
    }

    public static double ToDouble(Dictionary<string, object> details, string value)
    {
      return ToDouble(GetValue(details, value));
    }

    public static double ToDouble(object[] array, int nr)
    {
      return array.Length > nr ? ToDouble(array[nr]) : 0.0;
    }

    public static double? ToNullDouble(object value)
    {
      return double.TryParse(value?.ToString(), out var outValue) ? double.IsNaN(outValue) ? (double?) null : outValue : null;
    }

    public static double? ToNullDouble(Dictionary<string, object> details, string value)
    {
      return ToNullDouble(GetValue(details, value));
    }

    public static int ToInt(object value)
    {
      return int.TryParse(value?.ToString(), out var outValue) ? outValue : 0;
    }

    public static int? ToNullInt(object value)
    {
      return int.TryParse(value?.ToString(), out var outValue) ? (int?) outValue : null;
    }

    public static int ToInt(object[] array, int nr)
    {
      return array.Length > nr ? ToInt(array[nr]) : 0;
    }

    public static int ToInt(Dictionary<string, object> details, string value)
    {
      return ToInt(GetValue(details, value));
    }

    public static int? ToNullInt(Dictionary<string, object> details, string value)
    {
      return ToNullInt(GetValue(details, value));
    }

    public static string ToString(object value)
    {
      return value?.ToString() ?? string.Empty;
    }

    public static string ToString(Dictionary<string, object> details, string value)
    {
      return ToString(GetValue(details, value));
    }

    public static DateTime? ToNullDateTime(object value)
    {
      return value == null ? null : (DateTime?) DateTime.Parse(value.ToString());
    }

    public static DateTime? ToNullDateTime(Dictionary<string, object> details, string value)
    {
      return ToNullDateTime(GetValue(details, value));
    }

    public static DateTime ToDateTime(object value)
    {
      return DateTime.Parse(value?.ToString());
    }

    public static DateTime ToDateTime(Dictionary<string, object> details, string value)
    {
      return ToDateTime(GetValue(details, value));
    }

    public static object ToEnum(Type type, object value)
    {
      return Enum.Parse(type, ToString(value));
    }

    public static object ToEnum(Type type, Dictionary<string, object> details, string value)
    {
      return ToEnum(type, GetValue(details, value));
    }

    public static bool ToBool(object value)
    {
      return (bool) (value ?? false);
    }

    public static bool ToBool(Dictionary<string, object> details, string value)
    {
      return ToBool(GetValue(details, value));
    }

    public static Dictionary<string, object> ToDictionary(object value)
    {
      Dictionary<string, object> result;

      if (value is Dictionary<string, object> objects)
      {
        result = objects;
      }
      else if (value is ExpandoObject expandoObject)
      {
        result = expandoObject.ToDictionary(pair => pair.Key, pair => pair.Value);
      }
      else
      {
        result = new Dictionary<string, object>();
      }

      return result;
    }

    public static IList<object> ToList(object value)
    {
      return value as IList<object> ?? new List<object>();
    }

    public static object[] ToArray(object value)
    {
      if (value is IList<object>)
      {
        return (value as List<object>)?.ToArray() ?? Array.Empty<object>();
      }

      return Array.Empty<object>();
    }

    public static object[] GetArrayValue(Dictionary<string, object> details, string value)
    {
      return ToArray(GetValue(details, value));
    }

    public static object GetValue(ExpandoObject details, string value)
    {
      return GetValue(ToDictionary(details), value);
    }

    public static object GetValue(Dictionary<string, object> details, string value)
    {
      return details?.ContainsKey(value) ?? false ? details[value] : null;
    }

    public static Dictionary<string, object> GetDictValue(ExpandoObject details, string value)
    {
      return ToDictionary(GetValue(details, value));
    }

    public static Dictionary<string, object> GetDictValue(Dictionary<string, object> details, string value)
    {
      return ToDictionary(GetValue(details, value));
    }

    public static IList<object> GetListValue(Dictionary<string, object> details, string value)
    {
      return ToList(GetValue(details, value));
    }
  }
}
