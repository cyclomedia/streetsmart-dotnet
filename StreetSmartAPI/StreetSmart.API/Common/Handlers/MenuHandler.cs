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
  internal class CustomMenuHandler : IContextMenuHandler
  {
    public void OnBeforeContextMenu(
      IWebBrowser browserControl,
      IBrowser browser,
      IFrame frame,
      IContextMenuParams parameters,
      IMenuModel model)
    {
      // Clear the context menu
      model.Clear();
    }

    public bool OnContextMenuCommand(
      IWebBrowser browserControl,
      IBrowser browser,
      IFrame frame,
      IContextMenuParams parameters,
      CefMenuCommand commandId,
      CefEventFlags eventFlags)
    {
      return false;
    }

    public void OnContextMenuDismissed(
      IWebBrowser browserControl,
      IBrowser browser,
      IFrame frame)
    {
    }

    public bool RunContextMenu(
      IWebBrowser browserControl,
      IBrowser browser,
      IFrame frame,
      IContextMenuParams parameters,
      IMenuModel model,
      IRunContextMenuCallback callback)
    {
      return false;
    }
  }
}