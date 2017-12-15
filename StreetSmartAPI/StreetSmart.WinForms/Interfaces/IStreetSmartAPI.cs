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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSmart.WinForms.Interfaces
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// API used to use and modify various StreetSmart components.
  /// </summary>
  public interface IStreetSmartAPI
  {
    #region API events

    /// <summary>
    /// Triggers when the frame is loaded.
    /// After this trigger, you can login in the the API.
    /// </summary>
    event EventHandler APIReady;

    #endregion

    #region Interface events

    /// <summary>
    /// Measurement changed or added.
    /// </summary>
    event EventHandler<IEventArgs<IDictionary<string, object>>> MeasurementChanged;

    /// <summary>
    /// Viewer is added (panoramic or oblique)
    /// </summary>
    event EventHandler<IEventArgs<IViewer>> ViewerAdded;

    /// <summary>
    /// Viewer is removed (panoramic of oblique)
    /// </summary>
    event EventHandler<IEventArgs<IViewer>> ViewerRemoved;

    #endregion

    #region StreetSmartAPI

    /// <summary>
    /// The GUI of StreetSmart
    /// </summary>
    StreetSmartGUI GUI { get; }

    #endregion

    #region CefSharp functions

    /// <summary>
    /// Show the developer tools
    /// </summary>
    void ShowDefTools();

    /// <summary>
    /// Close the developer tools
    /// </summary>
    void CloseDefTools();

    #endregion

    #region Interface functions

    /// <summary>
    /// Add a GeoJSON overlay to the panorama viewer. SRS of API initialisation is used.
    /// Use overload with sourceSrs parameter if provided GeoJSON is in a different coordinate system.
    /// </summary>
    /// <param name="overlay">The overlay to add</param>
    /// <returns>the overlay object</returns>
    Task<IOverlay> AddOverlay(IOverlay overlay);

    /// <summary>
    /// Adds a PanoramaViewer to a specified DOM-element
    /// </summary>
    /// <param name="element">DOM-element the PanoramaViewer gets rendered to.</param>
    /// <param name="options">Options to initialize the panorama viewer with.</param>
    /// <returns></returns>
    [Obsolete("Obsolete. Use StreetSmartApi.open instead.", true)]
    IPanoramaViewer AddPanoramaViewer(IDomElement element, IPanoramaViewerOptions options);

    /// <summary>
    /// Destroys the API. Cleans up its event handlers and makes used memory available for garbage collection.
    /// </summary>
    /// <param name="options">Object containing the options used for destroying the API.</param>
    void Destroy(IOptions options);

    /// <summary>
    /// Destroys panorama viewer
    /// </summary>
    /// <param name="viewer">Instance of the PanoramaViewer you want to destroy.</param>
    [Obsolete("", true)]
    void DestroyPanoramaViewer(IPanoramaViewer viewer);

    /// <summary>
    /// Returns the active measurement in GeoJSON format
    /// </summary>
    Task<dynamic> GetActiveMeasurement();

    /// <summary>
    /// Returns the object containing the address search settings
    /// </summary>
    /// <returns>Object containing the address settings</returns>
    Task<IAddressSettings> GetAddressSettings();

    /// <summary>
    /// Returns the current 'ready'-state of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The current 'ready'-state of the API.</returns>
    Task<bool> GetApiReadyState();

    /// <summary>
    /// Returns the application name of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The application name of the API.</returns>
    Task<string> GetApplicationName();

    /// <summary>
    /// Returns the used version of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>API version number.</returns>
    Task<string> GetApplicationVersion();

    /// <summary>
    /// Returns all logs, including ones invisible to integrators.
    /// </summary>
    /// <returns>Array of console logs.</returns>
    Task<string[]> GetDebugLogs();

    /// <summary>
    /// Returns the object containing functionalities that are currently permitted to use by the user.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>Array containing the permissions</returns>
    Task<string[]> GetPermissions();

    /// <summary>
    /// Initializes the API using the inserted values. Required to use functional PanoramaViewers.
    /// </summary>
    /// <param name="options">Object containing the options used for initializing the API.</param>
    Task Init(IOptions options);

    /// <summary>
    /// Open a panorama and/or oblique viewer using a query. The query can be a coordinate,
    /// an extent, an address or a panorama/oblique ID.
    /// </summary>
    /// <param name="query">query for open a panoramic image</param>
    /// <param name="options">viewer options for open the panoramic image</param>
    /// <returns></returns>
    Task<IList<IViewer>> Open(string query, IViewerOptions options);

    /// <summary>
    /// Removes a GeoJSON overlay from the panorama viewer.
    /// </summary>
    /// <param name="id">The id of the overlay</param>
    void RemoveOverlay(string id);

    /// <summary>
    /// Starts the measurement
    /// </summary>
    /// <param name="viewer">Panorama viewer for start the measurement inside</param>
    /// <param name="options">Measurement options</param>
    void StartMeasurementMode(IPanoramaViewer viewer, IMeasurementOptions options);

    /// <summary>
    /// Stops the measurement
    /// </summary>
    void StopMeasurementMode();

    #endregion
  }

  // ReSharper restore InconsistentNaming
}
