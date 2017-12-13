/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2017, CycloMedia, All rights reserved.
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
using System.Collections.ObjectModel;
using System.Linq;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data.DomElement
{
  internal class Style : ObservableCollection<StyleElement>, IStyle
  {
    public void AddStyle(StyleElement element)
    {
      Add(element);
    }

    public void AddStyle(StyleElementName name, string value)
    {
      Add(new StyleElement(name, value));
    }

    public void AddStyle(StyleElementName name, int value, StyleElementNumberType type)
    {
      Add(new StyleElement(name, value, type));
    }

    public void RemoveStyle(StyleElementName name)
    {
      StyleElement styleElement = this.FirstOrDefault(element => element.Name == name);

      if (styleElement != null)
      {
        Remove(styleElement);
      }
    }

    public void UpdateStyle(StyleElementName name, string value)
    {
      StyleElement styleElement = this.FirstOrDefault(element => element.Name == name);

      if (styleElement != null)
      {
        styleElement.Value = new StyleElementValue(value);
      }
    }

    public void UpdateStyle(StyleElementName name, int value, StyleElementNumberType type)
    {
      StyleElement styleElement = this.FirstOrDefault(element => element.Name == name);

      if (styleElement != null)
      {
        styleElement.Value = new StyleElementNumberValue(value, type);
      }
    }

    public override string ToString()
    {
      string result = this.Aggregate(string.Empty, (current, element) => $"{current};{element}");
      return result.Substring(Math.Min(result.Length, 1));
    }
  }
}
