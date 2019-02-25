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

using System.Drawing;

using StreetSmart.Common.Data.SLD;
using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create SLD objects
  /// </summary>
  // ReSharper disable once InconsistentNaming
  public static class SLDFactory
  {
    /// <summary>
    /// Returns a polygon style
    /// </summary>
    /// <param name="fillColor">The fill color of the polygon</param>
    /// <param name="fillOpacity">The fill opacity of thye polygon</param>
    /// <param name="strokeColor">The stroke color of the polygon</param>
    /// <param name="strokeWidth">The stroke width of the polygon</param>
    /// <returns>Styled layer description of the polygon symbolizer</returns>
    public static IStyledLayerDescriptor CreateStylePolygon(Color fillColor, double? fillOpacity = null,
      Color? strokeColor = null, double? strokeWidth = null) => new StyledLayerDescriptor(new Rule(null,
      new PolygonSymbolizer(fillColor, fillOpacity, strokeColor, strokeWidth)));

    /// <summary>
    /// Returns a line style
    /// </summary>
    /// <param name="color">The color of the line</param>
    /// <param name="width">The width of the line</param>
    /// <param name="opacity">The opacity of the line</param>
    /// <returns>Styled layer description of the line symbolizer</returns>
    public static IStyledLayerDescriptor CreateStyleLine(Color color, double? width = null, double? opacity = null) =>
      new StyledLayerDescriptor(new Rule(null, new LineSymbolizer(color, width, opacity)));

    /// <summary>
    /// Returns a point style
    /// </summary>
    /// <param name="type">Well known name of the point objects</param>
    /// <param name="size">Size of the point objects</param>
    /// <param name="fillColor">The fill color of the point objects</param>
    /// <param name="fillOpacity">The fill opacity of the point objects</param>
    /// <param name="strokeColor">The stroke color of the point objects</param>
    /// <param name="strokeWidth">The stroke width of the point objects</param>
    /// <returns>Styled layer description of the point symbolizer</returns>
    public static IStyledLayerDescriptor CreateStylePoint(SymbolizerType? type, double size, Color fillColor, double? fillOpacity = null,
      Color? strokeColor = null, double? strokeWidth = null) => new StyledLayerDescriptor(new Rule(null,
      new Graphic(new Mark(type, fillColor, fillOpacity, strokeColor, strokeWidth), size)));
  }
}
