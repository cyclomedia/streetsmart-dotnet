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

using CefSharp;

namespace StreetSmart.Common.Handlers
{
  public class LifeSpanHandler : ILifeSpanHandler
  {
    public bool OnBeforePopup(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      string targetUrl,
      string targetFrameName,
      WindowOpenDisposition targetDisposition,
      bool userGesture,
      IPopupFeatures popupFeatures,
      IWindowInfo windowInfo,
      IBrowserSettings browserSettings,
      ref bool noJavascriptAccess,
      out IWebBrowser newBrowser)
    {
      newBrowser = null;
      return false;
    }

    public void OnAfterCreated(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser)
    {
    }

    public bool DoClose(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser)
    {
      return false;
    }

    public void OnBeforeClose(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser)
    {
    }
  }
}
