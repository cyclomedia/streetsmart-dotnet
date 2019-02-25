/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2019, CycloMedia, All rights reserved.
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

using StreetSmart.Common.Data.DomElement;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory that creates a dom element where inside the api runs.
  /// </summary>
  /// <example>
  /// This sample shows how to use the <see cref="DomElementFactory"/>.
  /// <code>
  /// using System;
  /// using StreetSmart.Common.Factories;
  /// using StreetSmart.Common.Interfaces;
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
  ///       // Initialize the api.
  ///       await _api.Init(options);
  ///     }
  ///   }
  /// }
  /// </code>
  /// </example>
  public static class DomElementFactory
  {
    /// <summary>
    /// Creates a default dom element
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="DomElementFactory.Create()"/> method.
    /// <code>
    /// // Create a dom element
    /// IDomElement element = DomElementFactory.Create();
    /// </code>
    /// </example>
    /// <returns>Represents a dom element.</returns>
    public static IDomElement Create()
    {
      Style style = new Style();
      style.AddStyle(StyleElementName.Width, 100, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Height, 100, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Position, "absolute");
      style.AddStyle(StyleElementName.Top, 0, StyleElementNumberType.Pixels);
      style.AddStyle(StyleElementName.Left, 0, StyleElementNumberType.Pixels);
      return new DomElement(style);
    }

    /// <summary>
    /// Creates a dom element with a width and height in percents and a top and a left in pixels
    /// </summary>
    /// <example> 
    /// This sample shows how to use the <see cref="DomElementFactory.Create(int, int, int, int)"/> method.
    /// <code>
    /// // Create a dom element
    /// int width = 75; // width in percents
    /// int height = 75; // height in percents
    /// int top = 50; // 50 pixels from top
    /// int left = 50; // 50 pixels from left
    /// IDomElement element = DomElementFactory.Create(width, height, top, left);
    /// </code>
    /// </example>
    /// <param name="width">Width in percent</param>
    /// <param name="height">Height in percent</param>
    /// <param name="top">Top in pixels</param>
    /// <param name="left">Left in pixels</param>
    /// <returns>Represents a dom element.</returns>
    public static IDomElement Create(int width, int height, int top, int left)
    {
      Style style = new Style();
      style.AddStyle(StyleElementName.Width, width, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Height, height, StyleElementNumberType.Percent);
      style.AddStyle(StyleElementName.Position, "absolute");
      style.AddStyle(StyleElementName.Top, top, StyleElementNumberType.Pixels);
      style.AddStyle(StyleElementName.Left, left, StyleElementNumberType.Pixels);
      return new DomElement(style);
    }
  }
}
