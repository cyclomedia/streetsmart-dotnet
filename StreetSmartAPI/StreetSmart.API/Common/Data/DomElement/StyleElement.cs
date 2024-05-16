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

using StreetSmart.Common.Interfaces.DomElement;
using System;

namespace StreetSmart.Common.Data.DomElement
{
  internal class StyleElement : NotifyPropertyChanged
  {
    private StyleElementName _name;
    private StyleElementValue _value;

    public StyleElement(StyleElementName name, StyleElementValue value)
    {
      Name = name;
      Value = value;
    }

    public StyleElement(StyleElementName name, int value, StyleElementNumberType type)
    {
      Name = name;
      Value = new StyleElementNumberValue(value, type);
    }

    public StyleElement(StyleElementName name, string value)
    {
      Name = name;
      Value = new StyleElementValue(value);
    }

    public StyleElementName Name
    {
      get => _name;
      set
      {
        _name = value;
        RaisePropertyChanged();
      }
    }

    public StyleElementValue Value
    {
      get => _value;
      set
      {
        _value = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      return $"{Name.Description()}:{Value}";
    }
  }
}
