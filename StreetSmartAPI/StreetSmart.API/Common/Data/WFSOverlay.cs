/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2020, CycloMedia, All rights reserved.
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
using System.Drawing;

using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.Data
{
  // ReSharper disable once InconsistentNaming
  internal class WFSOverlay : Overlay, IWFSOverlay
  {
    private Uri _url;
    private string _typeName;
    private string _version;
    private bool _authRequired;
    private ICredentials _credentials;

    public WFSOverlay(string name, Uri url, string typeName, string version, string sld, bool authRequired,
      ICredentials credentials)
      : base(name, sld)
    {      
      Url = url;
      TypeName = typeName;
      Version = version;
      AuthRequired = authRequired;
      Credentials = credentials;
    }

    public WFSOverlay(string name, Uri url, string typeName, string version, Color color, bool authRequired,
      ICredentials credentials)
      : base(name, color)
    {
      Url = url;
      TypeName = typeName;
      Version = version;
      AuthRequired = authRequired;
      Credentials = credentials;
    }

    public Uri Url
    {
      get => _url;
      set
      {
        _url = value;
        RaisePropertyChanged();
      }
    }

    public string TypeName
    {
      get => _typeName;
      set
      {
        _typeName = value;
        RaisePropertyChanged();
      }
    }

    public string Version
    {
      get => _version;
      set
      {
        _version = value;
        RaisePropertyChanged();
      }
    }

    public bool AuthRequired
    {
      get => _authRequired;
      set
      {
        _authRequired = value;
        RaisePropertyChanged();
      }
    }

    public ICredentials Credentials
    {
      get => _credentials;
      set
      {
        _credentials = value;
        RaisePropertyChanged();
      }
    }

    public override string ToString()
    {
      string overlay = base.ToString();
      string credentials = Credentials == null ? string.Empty : $",credentials:{Credentials}";
      return
        $"{overlay.Substring(0, overlay.Length - 1)},url:'{Url}',typeName:{TypeName.ToQuote()},version:{Version.ToQuote()},authRequired:{AuthRequired.ToJsBool()}{credentials}}}";
    }
  }
}
