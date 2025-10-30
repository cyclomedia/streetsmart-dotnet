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
using CefSharp.Handler;

namespace StreetSmart.Common.Handlers
{
  public class CustomRequestHandler : RequestHandler
  {
    protected override bool OnBeforeBrowse(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      bool userGesture,
      bool isRedirect)
    {
      return false;
    }

    protected override IResourceRequestHandler GetResourceRequestHandler(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      bool isNavigation,
      bool isDownload,
      string requestInitiator,
      ref bool disableDefaultHandling)
    {
      return new CustomResourceRequestHandler();
    }

    protected override bool OnOpenUrlFromTab(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      string targetUrl,
      WindowOpenDisposition targetDisposition,
      bool userGesture)
    {
      return false;
    }

    protected override bool GetAuthCredentials(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      string originUrl,
      bool isProxy,
      string host,
      int port,
      string realm,
      string scheme,
      IAuthCallback callback)
    {
      callback.Dispose();
      return false;
    }

    protected override bool OnCertificateError(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      CefErrorCode errorCode,
      string requestUrl,
      ISslInfo sslInfo,
      IRequestCallback callback)
    {
      callback.Dispose();
      return false;
    }
  }
}
