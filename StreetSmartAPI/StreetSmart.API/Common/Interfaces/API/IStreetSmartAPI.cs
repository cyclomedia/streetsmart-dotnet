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
using System.Collections.Generic;
using System.Threading.Tasks;

using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.Events;
using StreetSmart.Common.Interfaces.GeoJson;

#if WINFORMS
using StreetSmart.WinForms;
#endif

namespace StreetSmart.Common.Interfaces.API
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
    event EventHandler<IEventArgs<IFeatureCollection>> MeasurementChanged;

    /// <summary>
    /// Viewer is added (panoramic or oblique)
    /// </summary>
    event EventHandler<IEventArgs<IViewer>> ViewerAdded;

    /// <summary>
    /// Viewer is removed (panoramic of oblique)
    /// </summary>
    event EventHandler<IEventArgs<IViewer>> ViewerRemoved;

    #endregion

    #if WINFORMS
    #region StreetSmartAPI

    /// <summary>
    /// The GUI of StreetSmart
    /// </summary>
    StreetSmartGUI GUI { get; }

    #endregion
    #endif

    #region CefSharp functions

    /// <summary>
    /// Show the developer tools
    /// </summary>
    void ShowDevTools();

    /// <summary>
    /// Close the developer tools
    /// </summary>
    void CloseDevTools();

    #endregion

    #region Interface functions

    #if WPF
    /// <summary>
    /// Restarts streetsmart
    /// </summary>
    void RestartStreetSmart();

    /// <summary>
    /// Restarts streetsmart
    /// </summary>
    /// <param name="streetSmartLocation">The location of Street Smart</param>
    void RestartStreetSmart(string streetSmartLocation);
    #endif

    /// <summary>
    /// Add a GeoJSON overlay to the panorama viewer. SRS of API initialisation is used.
    /// Use overload with sourceSrs parameter if provided GeoJSON is in a different coordinate system.
    /// </summary>
    /// <param name="overlay">The overlay to add</param>
    /// <returns>the overlay object</returns>
    Task<IGeoJsonOverlay> AddOverlay(IGeoJsonOverlay overlay);

    /// <summary>
    /// Add a WFS Layer as overlay to the panorama viewer. Can be removed with removeOverlay
    /// </summary>
    /// <param name="overlay">The WFS layer to add</param>
    /// <returns>the overlay object</returns>
    Task<IWFSOverlay> AddWFSLayer(IWFSOverlay overlay);

    /// <summary>
    /// Close a panorama or oblique viewer.
    /// </summary>
    /// <param name="viewerId">The viewer to remove</param>
    /// <returns>Returns an array with references to all viewers of type PanoramaViewer and/or ObliqueViewer</returns>
    Task<IList<IViewer>> CloseViewer(string viewerId);

    /// <summary>
    /// Destroys the API. Cleans up its event handlers and makes used memory available for garbage collection.
    /// </summary>
    /// <param name="options">Object containing the options used for destroying the API.</param>
    Task Destroy(IOptions options);

    /// <summary>
    /// Returns the active measurement in GeoJSON format
    /// </summary>
    Task<IFeatureCollection> GetActiveMeasurement();

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
    /// Return an array with references to all viewers.
    /// </summary>
    /// <returns>Returns an array with references to all viewers of type PanoramaViewer and/or ObliqueViewer</returns>
    Task<IList<IViewer>> GetViewers();

    /// <summary>
    /// Initializes the API using the inserted values. Required to use functional PanoramaViewers.
    /// </summary>
    /// <example>
    /// This sample shows how to use the <see cref="IStreetSmartAPI.Init"/> function.
    /// <code>
    /// using System;
    /// using StreetSmart.Common.Exceptions;
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
    /// <param name="options">Object containing the options used for initializing the API.</param>
    /// <exception cref="StreetSmartLoginFailedException">Thrown when the login is failed</exception>
    /// <returns>Asynchronous function</returns>
    Task Init(IOptions options);

    /// <summary>
    /// Open a panorama and/or oblique viewer using a query. The query can be a coordinate,
    /// an extent, an address or a panorama/oblique ID.
    /// </summary>
    /// <example>
    /// This sample shows how to use the <see cref="IStreetSmartAPI.Open"/> function.
    /// <code>
    /// using System;
    /// using System.Collections.Generic;
    /// using StreetSmart.Common.Exceptions;
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
    ///       // The initialisation options of the api
    ///       IOptions options = OptionsFactory.Create("myUsername", "myPassword", "myAPIKey", "EPSG:28992", element);
    ///
    ///       // Initialize the api.
    ///       await _api.Init(options);
    /// 
    ///       // The open viewer options for open a new panorama viewer in EPSG:28992.
    ///       IViewerOptions viewerOpt = ViewerOptionsFactory.Create(new List&lt;ViewerType&gt; {ViewerType.Panorama}, "EPSG:28992");
    ///
    ///       try
    ///       {
    ///         IList&lt;IViewer&gt; viewers = await _api.Open("Lange Haven 145, Schiedam", viewerOpt);
    ///         // Todo: add functionality
    ///       }
    ///       catch (StreetSmartImageNotFoundException ex)
    ///       {
    ///         // image not found exception (ex)
    ///       }
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    /// <param name="query">query for open a panoramic image</param>
    /// <param name="options">viewer options for open the panoramic image</param>
    /// <exception cref="StreetSmartImageNotFoundException">Thrown when no image is found</exception>
    /// <returns>Asynchronous function, A list of opened viewers</returns>
    Task<IList<IViewer>> Open(string query, IViewerOptions options);

    /// <summary>
    /// Removes a GeoJSON overlay from the panorama viewer.
    /// </summary>
    /// <param name="id">The id of the overlay</param>
    Task RemoveOverlay(string id);

    /// <summary>
    /// Set the active measurement in GeoJSON format
    /// </summary>
    /// <param name="measurement">The measurement in GeoJSON format</param>
    void SetActiveMeasurement(IFeatureCollection measurement);

    /// <summary>
    /// Set overlay draw distance
    /// </summary>
    /// <param name="distance">The overlay draw distance</param>
    void SetOverlayDrawDistance(int distance);

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
