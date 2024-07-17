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

using System;
using System.Collections.Generic;
#if NETCOREAPP
using System.Dynamic;
#endif
using System.Linq;
using System.Threading.Tasks;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.API
{
  internal abstract class ViewerList: APIBase
  {
    #region Properties

    protected Dictionary<string, Viewer> Viewers { get; }

    #endregion

    #region Callback definitions

    public string JsLayerVisibilityChange => $"{nameof(OnLayerVisibilityChange).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    protected ViewerList()
    {
      Viewers = [];
    }

    #endregion

    #region Functions

    public void RegisterJsObject(IStreetSmartBrowser browser)
    {
      Browser = browser;
      RegisterThisJsObject();
    }

    public abstract IViewer AddViewer(string name);

    protected async Task<IViewer> RemoveViewerFromJsValue(string jsValue)
    {
      Viewer result = null;
      string key = null;
      int processId = GetProcessId;
      string funcName = $"{nameof(RemoveViewerFromJsValue)}{processId}".ToQuote();
      int nrViewers = Viewers.Count;
      int i = -1;

      while (++i < Viewers.Count || nrViewers != Viewers.Count)
      {
        if (nrViewers != Viewers.Count)
        {
          i = -1;
          nrViewers = Viewers.Count;
        }
        else
        {
          var viewer = Viewers.ElementAt(i);
          string script = $@"{{let result=false;if('{jsValue}'==={viewer.Key}.getId())
                        {{result=true;}};{JsThis}.{JsThisResult}(result,{funcName});}}";
          bool exists = ToBool(await CallJsAsync(script, processId));

          if (exists)
          {
            result = viewer.Value;
            key = viewer.Key;
          }
        }
      }

      if (key != null)
      {
        await result.DeleteJsObject();
        result.Destroyed = true;
        Viewers.Remove(key);
      }

      return result;
    }

    protected async Task<IList<IViewer>> GetViewersFromJsValue(string jsValue)
    {
      IList<IViewer> result = new List<IViewer>();
      int processId = GetProcessId;
      string funcName = $"{nameof(GetViewersFromJsValue)}{processId}".ToQuote();
      int nrViewers = Viewers.Count;
      int i = -1;

      while(++i < Viewers.Count || nrViewers != Viewers.Count)
      {
        if (nrViewers != Viewers.Count)
        {
          i = -1;
          nrViewers = Viewers.Count;
          result.Clear();
        }
        else
        {
          var viewer = Viewers.ElementAt(i);
          string script = $@"{{let result=false;{jsValue}.forEach((elem)=>{{if(elem.getId()==={viewer.Key}.getId())
                          {{result=true;}}}});{JsThis}.{JsThisResult}(result,{funcName});}}";
          bool exists = ToBool(await CallJsAsync(script, processId));

          if (exists)
          {
            result.Add(viewer.Value);
          }
        }
      }

      return result;
    }

    public IViewer RegisterViewer(Viewer viewer)
    {
      if (!Viewers.ContainsKey(viewer.Name))
      {
        Viewers.Add(viewer.Name, viewer);
      }

      return viewer;
    }

    public IViewer ReRegisterViewer(string oldName, Viewer viewer)
    {
      if (Viewers.ContainsKey(oldName))
      {
        Viewers.Remove(oldName);
      }

      return RegisterViewer(viewer);
    }

    #endregion

    #region Callbacks

    public void OnResult(string name, object result, string funcName)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnResult(result, funcName);
      }
    }

#if NETCOREAPP
    public void OnLayerVisibilityChange(string name, ExpandoObject args)
#else
    public void OnLayerVisibilityChange(string name, Dictionary<string, object> args)
#endif
    {
      if (Viewers.ContainsKey(name))
      {
        (Viewers[name] as ImageViewer)?.OnLayerVisibilityChange(args);
      }
    }

    #endregion

    #region Viewer lists / types

    private static readonly Dictionary<string, Dictionary<string, ViewerList>> ViewerLists = [];

    private static readonly Dictionary<ViewerType, string> ToViewerTypes = new Dictionary<ViewerType, string>
    {
      { ViewerType.Panorama, PanoramaViewerList.Type },
      { ViewerType.Oblique, ObliqueViewerList.Type },
      { ViewerType.PointCloud, PointCloudViewerList.Type },
      { ViewerType.MeshViewer, MeshViewerList.Type }
    };

    public static PanoramaViewerList GetPanoramaViewerList(string apiId)
    {
      return (PanoramaViewerList) ViewerLists[apiId][PanoramaViewerList.Type];
    }

    public static void CreateViewerList(string apiId)
    {
      if (!ViewerLists.ContainsKey(apiId))
      {
        ViewerLists.Add(apiId, new Dictionary<string, ViewerList>
        {
          {PanoramaViewerList.Type, new PanoramaViewerList()},
          {ObliqueViewerList.Type, new ObliqueViewerList()},
          {PointCloudViewerList.Type, new PointCloudViewerList()},
          {MeshViewerList.Type, new MeshViewerList()}
        });
      }
    }

    public static void DeleteViewerList(string apiId)
    {
      if (ViewerLists.ContainsKey(apiId))
      {
        ViewerLists.Remove(apiId);
      }
    }

    #endregion

    #region Functions

    public static void RegisterJsObjects(string apiId, IStreetSmartBrowser browser)
    {
      foreach (var viewerList in ViewerLists[apiId])
      {
        viewerList.Value.RegisterJsObject(browser);
      }
    }

    public static void ClearViewers(string apiId)
    {
      foreach (var viewerList in ViewerLists[apiId])
      {
        viewerList.Value.Clear();
      }
    }

    public static async Task<IViewer> RemoveViewerFromJsValue(string apiId, string viewerType, string jsValue)
    {
      return await ViewerLists[apiId][viewerType].RemoveViewerFromJsValue(jsValue);
    }

    public static async Task<IList<IViewer>> ToViewersFromJsValue(string apiId, IList<ViewerType> viewerTypes, string jsValue)
    {
      List<IViewer> result = new List<IViewer>();

      foreach (var viewerType in viewerTypes)
      {
        result.AddRange(await ViewerLists[apiId][ToViewerTypes[viewerType]].GetViewersFromJsValue(jsValue));
      }

      return result;
    }

    public static async Task<IViewer> ToViewerFromJsValue(string apiId, string viewerType, string jsValue)
    {
      string viewerList = $"[{jsValue}]";
      IList<IViewer> viewers = await ViewerLists[apiId][viewerType].GetViewersFromJsValue(viewerList);
      return viewers.Count >= 1 ? viewers[0] : null;
    }

    public static IViewer ToViewer(string apiId, string type, string name)
    {
      return ViewerLists[apiId][type].AddViewer(name);
    }

    public static IViewer ReRegisterViewer(string apiId, string type, string oldName, Viewer viewer)
    {
      return ViewerLists[apiId][type].ReRegisterViewer(oldName, viewer);
    }

    public void Clear()
    {
      Viewers.Clear();
    }

    #endregion
  }
}
