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

// ReSharper disable once CheckNamespace

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace System
{
  internal static class StringExtensions
  {
    public static string FirstCharacterToLower(this string str)
    {
      return string.IsNullOrEmpty(str) || char.IsLower(str, 0)
        ? str : $"{char.ToLowerInvariant(str[0])}{str.Substring(1)}";
    }

    public static string SrsComponent(this string srs)
    {
      return string.IsNullOrEmpty(srs) ? string.Empty : $",'{srs}'";
    }

    public static string ToQuote(this string txt)
    {
      return $"'{txt}'";
    }

    public static string ToDoubleQuote(this string txt)
    {
      return $"\"{txt}\"";
    }

    public static bool IsValidJson(this string input)
    {
      input = input.Trim();

      if ((input.StartsWith("{") && input.EndsWith("}")) || (input.StartsWith("[") && input.EndsWith("]")))
      {
        try
        {
          JToken token = JToken.Parse(input);
          return IsValidToken(token);
        }
        catch (JsonReaderException)
        {
          return false;
        }
        catch (Exception)
        {
          return false;
        }
      }

      return false;
    }

    private static bool IsValidToken(JToken token)
    {
      if (token.Type == JTokenType.Undefined)
      {
        return false;
      }

      foreach (var child in token.Children())
      {
        if (!IsValidToken(child))
        {
          return false;
        }
      }

      return true;
    }
  }
}
