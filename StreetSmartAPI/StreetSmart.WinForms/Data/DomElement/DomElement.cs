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

using System;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.Data.DomElement
{
  internal class DomElement : NotifyPropertyChanged, IDomElement
  {
    private string _id;
    private IStyle _style;

    public DomElement(Style style)
    {
      Guid guid = Guid.NewGuid();
      Id = guid.ToString();
      Style = style;
      Name = $"dom{guid:N}";
    }

    public DomElement(string id, Style style)
    {
      Id = id;
      Style = style;
      Name = $"dom{Guid.NewGuid():N}";
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

    public IStyle Style
    {
      get => _style;
      set
      {
        _style = value;
        RaisePropertyChanged();
      }
    }

    public string Name { get; }

    public override string ToString()
    {
      return $@"var {Name}=document.createElement('div');{Name}.setAttribute('id','{Id}');
             {Name}.setAttribute('style','{Style}');document.body.appendChild({Name});";
    }
  }
}
