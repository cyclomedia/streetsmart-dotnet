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
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using StreetSmart.WinForms.Events;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms
{
  // ReSharper disable InconsistentNaming
  internal class StreetSmartAPI : IStreetSmartAPI
  {
    private readonly ChromiumWebBrowser _browser;
    private readonly CycloramaViewerEvents _cycloramaViewerEvents;

    public event EventHandler FrameLoaded;
    public event EventHandler<EventInitArgs> InitComplete;
    public event EventHandler<EventLoginArgs> LoginComplete;

    public StreetSmartGUI GUI { get; set; }

    public StreetSmartAPI(string streetSmartLocation)
    {
      _browser = new ChromiumWebBrowser(streetSmartLocation) {Dock = DockStyle.Fill};
      _browser.RegisterJsObject("streetSmartAPIEvents", this);
      _cycloramaViewerEvents = new CycloramaViewerEvents(_browser);
      _browser.FrameLoadEnd += OnFrameLoadEnd;
      GUI = new StreetSmartGUI(_browser);
    }

    public ICycloramaViewer CreateCycloramaViewer(string viewerObjectName)
    {
      return new CycloramaViewer(_browser, _cycloramaViewerEvents, viewerObjectName);
    }

    public void Login(string username, string password)
    {
      _browser.ExecuteScriptAsync($"StreetSmartApi.init({{username:'{username}', password:'{password}'}});");
    }

    #region event handling ChromiumWebBrowser

    public void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
    {
      if (e.Frame.IsMain)
      {
        _browser.ExecuteScriptAsync(
          @"window.addEventListener(StreetSmartApi.Events.stage.INIT, function(e) {streetSmartAPIEvents.onInit(e.detail);});
            window.addEventListener(StreetSmartApi.Events.login.LOGIN, function(e) {streetSmartAPIEvents.onLogin(e.detail);});");
        _cycloramaViewerEvents.RegisterEventHandlers();
        FrameLoaded?.Invoke(this, EventArgs.Empty);
      }
    }

    #endregion

    #region event handling StreetSmart

    public void OnInit(Dictionary<string, object> args)
    {
      EventInitArgs initArgs = new EventInitArgs();

      if (args.ContainsKey("success"))
      {
        initArgs.Success = (bool) args["success"];
      }

      InitComplete?.Invoke(this, initArgs);
    }

    public void OnLogin(Dictionary<string, object> args)
    {
      EventLoginArgs loginArgs = new EventLoginArgs();

      if (args.ContainsKey("success"))
      {
        loginArgs.Success = (bool) args["success"];
      }

      LoginComplete?.Invoke(this, loginArgs);
    }

    #endregion
  }

  // ReSharper restore InconsistentNaming
}
