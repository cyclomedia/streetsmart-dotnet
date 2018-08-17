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

namespace StreetSmart.Wpf.Exceptions
{
  /// <inheritdoc />
  /// <summary>
  /// This exception is thrown when loggin fails.
  /// </summary>
  /// <example>
  /// This sample shows how to use the <see cref="StreetSmartLoginFailedException"/> Exception.
  /// <code>
  /// using System;
  /// using StreetSmart.Wpf.Exceptions;
  /// using StreetSmart.Wpf.Factories;
  /// using StreetSmart.Wpf.Interfaces;
  ///
  /// namespace Demo
  /// {
  ///   public class Example
  ///   {
  ///     private IStreetSmartAPI _api;
  ///     private System.Windows.Forms.Panel plStreetSmart = new System.Windows.Forms.Panel();
  ///
  ///     public void StartAPI()
  ///     {
  ///       _api = StreetSmartAPIFactory.Create();
  ///       _api.APIReady += OnAPIReady;
  ///       plStreetSmart.Controls.Add(_api.GUI);
  ///     }
  ///
  ///     private async void OnAPIReady(object sender, EventArgs args)
  ///     {
  ///       // The dom element within the api must be rendered.
  ///       IDomElement element = DomElementFactory.Create();
  ///
  ///       // The initialisation options of the api.
  ///       IOptions options = OptionsFactory.Create("myUsername", "myPassword", "myAPIKey", "EPSG:28992", element);
  ///
  ///       try
  ///       {
  ///         // Initialize the api.
  ///         await _api.Init(options);
  ///         // Todo: add functionality
  ///       }
  ///       catch (StreetSmartLoginFailedException ex)
  ///       {
  ///         // login failed exception (ex)
  ///       }
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public class StreetSmartLoginFailedException : Exception
  {
    internal StreetSmartLoginFailedException(string message) : base(message)
    {
    }

    internal StreetSmartLoginFailedException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
