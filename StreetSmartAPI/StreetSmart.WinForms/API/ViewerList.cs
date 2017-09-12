/*
 * Street Smart .NET integration
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

using System.Collections.Generic;
using System.Linq;

using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  abstract class ViewerList
  {
    private static readonly Dictionary<string, ViewerList> Viewers = new Dictionary<string, ViewerList>()
    {
      {PanoramaViewerList.Type, new PanoramaViewerList()},
      {ObliqueViewerList.Type, new ObliqueViewerList()}
    };

    public static PanoramaViewerList PanoramaViewerList => (PanoramaViewerList) Viewers[PanoramaViewerList.Type];

    public static void RegisterJsObjects(ChromiumWebBrowser browser)
    {
      foreach (var viewerList in Viewers)
      {
        viewerList.Value.RegisterJsObject(browser);
      }
    }

    public static void ClearViewers()
    {
      foreach (var viewerList in Viewers)
      {
        viewerList.Value.Clear();
      }
    }

    public static void DestroyPanoramaViewer(IPanoramaViewer panoramaViewer)
    {
      Viewers[PanoramaViewerList.Type].DestroyViewer(panoramaViewer);
    }

    public static IPanoramaViewer AddPanoramaViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return (IPanoramaViewer) Viewers[PanoramaViewerList.Type].AddViewer(element, options);
    }

    public static IList<IViewer> ToViewerList(Dictionary<string, object> viewers)
    {
      return viewers.Select(viewer => Viewers[viewer.Key].AddViewer(viewer.Value.ToString())).ToList();
    }

    public abstract void RegisterJsObject(ChromiumWebBrowser browser);

    public abstract void Clear();

    public abstract void DestroyViewer(IViewer viewer);

    public abstract IViewer AddViewer(string name);

    public virtual IViewer AddViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return null;
    }
  }
}
