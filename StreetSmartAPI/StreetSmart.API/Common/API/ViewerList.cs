﻿/*
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
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.API
{
  abstract class ViewerList: APIBase
  {
    #region Tasks

    private readonly EventWaitHandle _waitTask;

    #endregion

    #region Constants

    private int MaxWaitTime = 1000;

    #endregion

    #region Properties

    protected Dictionary<string, Viewer> Viewers { get; }

    #endregion

    #region Callback definitions

    public string JsLayerVisibilityChange => $"{nameof(OnLayerVisibilityChange).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    protected ViewerList()
    {
      _waitTask = new AutoResetEvent(true);
      Viewers = new Dictionary<string, Viewer>();
    }

    #endregion

    #region Functions

    public void RegisterJsObject(ChromiumWebBrowser browser)
    {
      Browser = browser;
      browser.RegisterJsObject(JsThis, this);
    }

    public abstract IViewer AddViewer(string name);

    protected async Task<IViewer> RemoveViewerFromJsValue(string jsValue)
    {
      _waitTask.WaitOne(MaxWaitTime);
      _waitTask.Reset();
      Viewer result = null;
      string key = null;
      int processId = GetProcessId;
      string funcName = $"{nameof(RemoveViewerFromJsValue)}{processId}".ToQuote();

      foreach (var viewer in Viewers)
      {
        string script = $@"{{let result=false;if({jsValue}==={viewer.Key})
                        {{result=true;}};{JsThis}.{JsThisResult}(result,{funcName});}}";
        bool exists = ToBool(await CallJsAsync(script, processId));

        if (exists)
        {
          result = viewer.Value;
          key = viewer.Key;
        }
      }

      if (key != null)
      {
        result.Destroyed = true;
        Viewers.Remove(key);
      }

      _waitTask.Set();
      return result;
    }

    protected async Task<IList<IViewer>> GetViewersFromJsValue(string jsValue)
    {
      _waitTask.WaitOne(MaxWaitTime);
      _waitTask.Reset();
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

      _waitTask.Set();
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

    #endregion

    #region Callbacks

    public void OnResult(string name, object result, string funcName)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnResult(result, funcName);
      }
    }

    public void OnLayerVisibilityChange(string name, Dictionary<string, object> args)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name]?.OnLayerVisibilityChange(args);
      }
    }

    #endregion

    #region Viewer lists / types

    private static readonly Dictionary<string, Dictionary<string, ViewerList>> ViewerLists =
      new Dictionary<string, Dictionary<string, ViewerList>>();

    private static readonly Dictionary<ViewerType, string> ToViewerTypes = new Dictionary<ViewerType, string>
    {
      { ViewerType.Panorama, PanoramaViewerList.Type },
      { ViewerType.Oblique, ObliqueViewerList.Type }
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
          {ObliqueViewerList.Type, new ObliqueViewerList()}
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

    public static void RegisterJsObjects(string apiId, ChromiumWebBrowser browser)
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

    public static IViewer ToViewer(string apiId, string type, string name)
    {
      return ViewerLists[apiId][type].AddViewer(name);
    }

    public void Clear()
    {
      Viewers.Clear();
    }

    #endregion
  }
}