/*
 * Integration in ArcMap for Cycloramas
 * Copyright (c) 2016, CycloMedia, All rights reserved.
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
using System.Threading.Tasks;

namespace StreetSmart.WinForms.Interfaces
{
  // ReSharper disable InconsistentNaming

  /// <summary>
  /// API used to use and modify various StreetSmart components.
  /// </summary>
  public interface IStreetSmartAPI
  {
    /// <summary>
    /// Triggers when the frame is loaded.
    /// After this trigger, you can login in the the API.
    /// </summary>
    event EventHandler APIReady;

    /// <summary>
    /// The GUI of StreetSmart
    /// </summary>
    StreetSmartGUI GUI { get; }

    /// <summary>
    /// Adds a PanoramaViewer to a default DOM-element.
    /// </summary>
    /// <param name="viewerObjectName">The name of the panorama viewer.</param>
    /// <returns></returns>
    IPanoramaViewer AddPanoramaViewer(string viewerObjectName);

    /// <summary>
    /// Adds a PanoramaViewer to a specified DOM-element.
    /// </summary>
    /// <param name="viewerObjectName">The name of the panorama viewer.</param>
    /// <param name="domElementName">The name of the domElement.</param>
    /// <param name="domElementScript">The javascript for create a domElement.</param>
    /// <returns></returns>
    IPanoramaViewer AddPanoramaViewer(string viewerObjectName, string domElementName, string domElementScript);

    /// <summary>
    /// Adds a PanoramaViewer to a default DOM-element.
    /// </summary>
    /// <param name="viewerObjectName">The name of the panorama viewer.</param>
    /// <param name="recordingsVisible">If recordings should be visible.</param>
    /// <param name="timeTravelEnabled">If time travel is enabled.</param>
    /// <returns></returns>
    IPanoramaViewer AddPanoramaViewer(string viewerObjectName, bool recordingsVisible, bool timeTravelEnabled);

    /// <summary>
    /// Adds a PanoramaViewer to a specified DOM-element.
    /// </summary>
    /// <param name="viewerObjectName">The name of the panorama viewer.</param>
    /// <param name="recordingsVisible">If recordings should be visible.</param>
    /// <param name="timeTravelEnabled">If time travel is enabled.</param>
    /// <param name="domElementName">The name of the domElement.</param>
    /// <param name="domElementScript">The javascript for create a domElement.</param>
    /// <returns></returns>
    IPanoramaViewer AddPanoramaViewer(string viewerObjectName, bool recordingsVisible, bool timeTravelEnabled,
      string domElementName, string domElementScript);

    /// <summary>
    /// Destroys panorama viewer
    /// </summary>
    /// <param name="panoramaViewer">Instance of the PanoramaViewer you want to destroy.</param>
    void DestroyPanoramaViewer(IPanoramaViewer panoramaViewer);

    /// <summary>
    /// Returns the object containing the address search settings
    /// </summary>
    /// <returns>Object containing the address settings</returns>
    Task<IAddressSettings> GetAddressSettingsAsync();

    /// <summary>
    /// Returns the current 'ready'-state of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The current 'ready'-state of the API.</returns>
    Task<bool> GetAPIReadyStateAsync();

    /// <summary>
    /// Returns the application name of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns>The application name of the API.</returns>
    Task<string> GetApplicationNameAsync();

    /// <summary>
    /// Returns the used version of the API.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns></returns>
    Task<string> GetApplicationVersionAsync();

    /// <summary>
    /// Returns the object containing functionalities that are currently permitted to use by the user.
    /// This is an asynchronous function.
    /// </summary>
    /// <returns></returns>
    Task<string[]> GetPermissionsAsync();

    /// <summary>
    /// Initializes the API using the inserted values. Required to use functional PanoramaViewers.
    /// </summary>
    /// <param name="options">Object containing the options used for initializing the API.</param>
    Task Init(IOptions options);
  }

  // ReSharper restore InconsistentNaming
}
