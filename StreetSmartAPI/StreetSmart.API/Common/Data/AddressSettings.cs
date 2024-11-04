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

using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;

namespace StreetSmart.Common.Data
{
  internal class AddressSettings : DataConvert, IAddressSettings
  {
    private string _locale;
    private string _database;

    public AddressSettings(string locale, string database)
    {
      Locale = locale;
      Database = database;
    }

    public AddressSettings(IDictionary<string, object> addressSettings)
    {
      Locale = ToString(addressSettings, "locale");
      Database = ToString(addressSettings, "database");
    }

    public string Locale
    {
      get => _locale;
      set
      {
        _locale = value;
        RaisePropertyChanged();
      }
    }

    public string Database
    {
      get => _database;
      set
      {
        _database = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      return $",addressSettings:{{locale:'{Locale}',database:'{Database}'}}";
    }
  }
}
