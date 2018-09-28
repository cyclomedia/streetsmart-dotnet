/*
 * Street Smart .NET integration
 * Copyright (c) 2016 - 2018, CycloMedia, All rights reserved.
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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;

using CefSharp;

#if WINFORMS
using CefSharp.WinForms;
#else
using CefSharp.Wpf;
#endif

using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;

namespace StreetSmart.Common.API
{
  abstract class ViewerList
  {
    #region Tasks

    private readonly Dictionary<string, TaskCompletionSource<object>> _resultTask;
    private readonly EventWaitHandle _waitTask;

    #endregion

    #region Constants

    private int MaxWaitTime = 1000;

    #endregion

    #region Properties

    protected ChromiumWebBrowser Browser { get; set; }

    protected Dictionary<string, Viewer> Viewers { get; }

    public string JsThis => $"{GetType().Name}Events";

    public string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    public string JsThisResult => $"{nameof(OnThisResult).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    protected ViewerList()
    {
      _waitTask = new AutoResetEvent(true);
      Viewers = new Dictionary<string, Viewer>();
      _resultTask = new Dictionary<string, TaskCompletionSource<object>>();
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
      string funcName = $"{nameof(RemoveViewerFromJsValue).ToQuote()}";

      foreach (var viewer in Viewers)
      {
        string script = $@"{{let result=false;if({jsValue}==={viewer.Key})
                        {{result=true;}};{JsThis}.{JsThisResult}(result,{funcName});}}";
        bool exists = (bool) await CallJsAsync(script);

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
      string funcName = $"{nameof(GetViewersFromJsValue).ToQuote()}";

      foreach (var viewer in Viewers)
      {
        string script = $@"{{let result=false;{jsValue}.forEach((elem)=>{{if(elem==={viewer.Key})
                        {{result=true;}}}});{JsThis}.{JsThisResult}(result,{funcName});}}";
        bool exists = (bool) await CallJsAsync(script);

        if (exists)
        {
          result.Add(viewer.Value);
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

    private bool CheckResultTask(string funcName)
    {
      bool result = true;

      if (!_resultTask.ContainsKey(funcName))
      {
        _resultTask.Add(funcName, new TaskCompletionSource<object>());
        result = false;
      }

      return result;
    }

    private async Task<object> CallJsAsync(string script, [CallerMemberName] string memberName = "")
    {
      if (CheckResultTask(memberName))
      {
        _resultTask[memberName] = new TaskCompletionSource<object>();
      }

      Browser.ExecuteScriptAsync(script);
      await _resultTask[memberName].Task;
      return _resultTask[memberName].Task.Result;
    }

    #endregion

    #region Callbacks viewer

    public void OnResult(string name, object result, string funcName)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnResult(result, funcName);
      }
    }

    public void OnThisResult(bool result, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(result);
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

    #region Viewer functions

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
