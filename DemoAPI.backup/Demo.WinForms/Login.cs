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

using System.IO;
using System.Xml.Serialization;

namespace Demo.WinForms
{
  public class Login
  {
    private static readonly XmlSerializer XmlLogin;

    private static Login _login;

    private const string FileName = "Login.xml";

    static Login()
    {
      XmlLogin = new XmlSerializer(typeof(Login));
    }

    public string Username { get; set; }

    public string Password { get; set; }

    public string ApiKey { get; set; }

    public static Login Instance => _login ?? (_login = Load());

    private static Login Load()
    {
      Login result;

      if (File.Exists(FileName))
      {
        var streamFile = new FileStream(FileName, FileMode.OpenOrCreate);
        result = (Login) XmlLogin.Deserialize(streamFile);
        streamFile.Close();
      }
      else
      {
        result = new Login();
      }

      return result;
    }

    public void Save()
    {
      FileStream streamFile = File.Open(FileName, FileMode.Create);
      XmlLogin.Serialize(streamFile, this);
      streamFile.Close();
    }
  }
}
