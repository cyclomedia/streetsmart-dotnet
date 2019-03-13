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

using System;
using System.Drawing;
using System.Security;

using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;
using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.Common.Factories
{
  /// <summary>
  /// Factory for create a overlay
  /// </summary>
  public static class OverlayFactory
  {
    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(string geoJson, string name)
      => Create(geoJson, name, null, null);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">EPSG code (srs) for the source GeoJSON</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(string geoJson, string name, string srs)
      => Create(geoJson, name, srs, null);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="sld">Optional XML string for Styled Layer Descriptor</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(string geoJson, string name, string srs, string sld)
      => new GeoJsonOverlay(geoJson, name, srs, sld);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="geoJson">GeoJSON object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="color">Optional color for the layer</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(string geoJson, string name, string srs, Color color)
      => new GeoJsonOverlay(geoJson, name, srs, color);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="featureCollection">FeatureCollection object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="sld">Optional XML string for Styled Layer Descriptor</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(IFeatureCollection featureCollection, string name, string srs, string sld)
      => new GeoJsonOverlay(featureCollection.ToString(), name, srs, sld);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="featureCollection">FeatureCollection object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="color">Optional color for the layer</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(IFeatureCollection featureCollection, string name, string srs, Color color)
      => new GeoJsonOverlay(featureCollection.ToString(), name, srs, color);

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="featureCollection">FeatureCollection object containing the layer data</param>
    /// <param name="name">Name of the layer.</param>
    /// <param name="srs">Optional EPSG code (srs) for the source GeoJSON, if not provided, srs of API initialisation is used.</param>
    /// <param name="styledLayerDescriptor">StyledLayer descriptor contains the sld styling of the layer</param>
    /// <returns>Overlay object</returns>
    public static IGeoJsonOverlay Create(IFeatureCollection featureCollection, string name, string srs, IStyledLayerDescriptor styledLayerDescriptor)
      => new GeoJsonOverlay(featureCollection.ToString(), name, srs, styledLayerDescriptor.SLD);

    /// <summary>
    /// Create the wfs overlay object
    /// </summary>
    /// <param name="name">Name of the layer.</param>
    /// <param name="url">The url where the WFS is hosted</param>
    /// <param name="typeName">The type name of the layer</param>
    /// <param name="version">The WFS version to be used</param>
    /// <param name="color">Color for the layer</param>
    /// <param name="authRequired">Whether this layer requires authentication to access</param>
    /// <returns>Overlay object</returns>
    public static IWFSOverlay CreateWfsOverlay(string name, string url, string typeName, string version, Color color,
      bool authRequired)
    {
      return new WFSOverlay(name, new Uri(url), typeName, version, color, authRequired, null);
    }

    /// <summary>
    /// Create the wfs overlay object
    /// </summary>
    /// <param name="name">Name of the layer.</param>
    /// <param name="url">The url where the WFS is hosted</param>
    /// <param name="typeName">The type name of the layer</param>
    /// <param name="version">The WFS version to be used</param>
    /// <param name="color">Color for the layer</param>
    /// <param name="authRequired">Whether this layer requires authentication to access</param>
    /// <param name="username">Username of the user.</param>
    /// <param name="password">Password of the user.</param>
    /// <returns>Overlay object</returns>
    public static IWFSOverlay CreateWfsOverlay(string name, string url, string typeName, string version, Color color,
      bool authRequired, string username, string password)
    {
      SecureString Password = new SecureString();

      foreach (var character in password)
      {
        Password.AppendChar(character);
      }

      return new WFSOverlay(name, new Uri(url), typeName, version, color, authRequired, new Credentials(username, Password));
    }

    /// <summary>
    /// Create the wfs overlay object
    /// </summary>
    /// <param name="name">Name of the layer.</param>
    /// <param name="url">The url where the WFS is hosted</param>
    /// <param name="typeName">The type name of the layer</param>
    /// <param name="version">The WFS version to be used</param>
    /// <param name="sld">Optional XML string for Styled Layer Descriptor</param>
    /// <param name="authRequired">Whether this layer requires authentication to access</param>
    /// <returns>Overlay object</returns>
    public static IWFSOverlay CreateWfsOverlay(string name, string url, string typeName, string version, string sld,
      bool authRequired)
    {
      return new WFSOverlay(name, new Uri(url), typeName, version, sld, authRequired, null);
    }

    /// <summary>
    /// Create the overlay object
    /// </summary>
    /// <param name="name">Name of the layer.</param>
    /// <param name="url">The url where the WFS is hosted</param>
    /// <param name="typeName">The type name of the layer</param>
    /// <param name="version">The WFS version to be used</param>
    /// <param name="sld">Optional XML string for Styled Layer Descriptor</param>
    /// <param name="authRequired">Whether this layer requires authentication to access</param>
    /// <param name="username">Username of the user.</param>
    /// <param name="password">Password of the user.</param>
    /// <returns>Overlay object</returns>
    public static IWFSOverlay CreateWfsOverlay(string name, string url, string typeName, string version, string sld,
      bool authRequired, string username, string password)
    {
      SecureString Password = new SecureString();

      foreach (var character in password)
      {
        Password.AppendChar(character);
      }

      return new WFSOverlay(name, new Uri(url), typeName, version, sld, authRequired, new Credentials(username, Password));
    }
  }
}
