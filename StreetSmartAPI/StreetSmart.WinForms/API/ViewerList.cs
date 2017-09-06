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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  abstract class ViewerList
  {
    private static readonly Dictionary<string, ViewerList> Viewers = new Dictionary<string, ViewerList>
    {
      {PanoramaViewerList.Type, new PanoramaViewerList()},
      {ObliqueViewerList.Type, new ObliqueViewerList()}
    };

    private static readonly Dictionary<ViewerType, string> ToViewerTypes = new Dictionary<ViewerType, string>
    {
      { ViewerType.Panorama, PanoramaViewerList.Type },
      { ViewerType.Oblique, ObliqueViewerList.Type }
    };

    public static PanoramaViewerList PanoramaViewerList => (PanoramaViewerList) Viewers[PanoramaViewerList.Type];

    public static void RegisterJsObjects(ChromiumWebBrowser browser)
    {
      foreach (var viewerList in Viewers)
      {
        viewerList.Value.RegisterJsObject(browser);
      }
    }

    public static async Task<IViewer> RemoveViewerFromJsValue(string viewerType, string jsValue)
    {
      return await Viewers[viewerType].RemoveViewerFromJsValue(jsValue);
    }

    public static async Task<IList<IViewer>> ToViewersFromJsValue(IList<ViewerType> viewerTypes, string jsValue)
    {
      List<IViewer> result = new List<IViewer>();

      foreach (var viewerType in viewerTypes)
      {
        result.AddRange(await Viewers[ToViewerTypes[viewerType]].GetViewersFromJsValue(jsValue));
      }

      return result;
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

    public static IViewer ToViewer(string type, string name)
    {
      return Viewers[type].AddViewer(name);
    }

    public abstract void RegisterJsObject(ChromiumWebBrowser browser);

    public abstract void DestroyViewer(IViewer viewer);

    public abstract IViewer AddViewer(string name);

    public virtual IViewer AddViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return null;
    }

    protected abstract Task<IList<IViewer>> GetViewersFromJsValue(string jsValue);

    protected abstract Task<IViewer> RemoveViewerFromJsValue(string jsValue);
  }
}
