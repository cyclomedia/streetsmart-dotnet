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
  public class CustomResourceRequestHandler : ResourceRequestHandler
  {
    protected override CefReturnValue OnBeforeResourceLoad(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      IRequestCallback callback)
    {
      return CefReturnValue.Continue;
    }

    protected override void OnResourceRedirect(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      IResponse response,
      ref string newUrl)
    {
    }

    protected override void OnResourceLoadComplete(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      IResponse response,
      UrlRequestStatus status,
      long receivedContentLength)
    {
    }

    protected override bool OnResourceResponse(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      IResponse response)
    {
      return false;
    }

    protected override IResponseFilter GetResourceResponseFilter(
      IWebBrowser chromiumWebBrowser,
      IBrowser browser,
      IFrame frame,
      IRequest request,
      IResponse response)
    {
      return null;
    }
  }
}
