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
using System.Threading.Tasks;

using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  abstract class ViewerList
  {
    #region Tasks

    private TaskCompletionSource<object> _resultTask;

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
      IViewer result = null;
      string key = null;

      foreach (var viewer in Viewers)
      {
        string script = $@"{{let result=false;if({jsValue}==={viewer.Key})
                        {{result=true;}};{JsThis}.{JsThisResult}(result);}}";
        bool exists = (bool) await CallJsAsync(script);

        if (exists)
        {
          result = viewer.Value;
          key = viewer.Key;
        }
      }

      if (key != null)
      {
        Viewers.Remove(key);
      }

      return result;
    }

    protected async Task<IList<IViewer>> GetViewersFromJsValue(string jsValue)
    {
      IList<IViewer> result = new List<IViewer>();

      foreach (var viewer in Viewers)
      {
        string script = $@"{{let result=false;{jsValue}.forEach((elem)=>{{if(elem==={viewer.Key})
                        {{result=true;}}}});{JsThis}.{JsThisResult}(result);}}";
        bool exists = (bool) await CallJsAsync(script);

        if (exists)
        {
          result.Add(viewer.Value);
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

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      Browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    #endregion

    #region Callbacks viewer

    public void OnResult(string name, object result)
    {
      if (Viewers.ContainsKey(name))
      {
        Viewers[name].OnResult(result);
      }
    }

    public void OnThisResult(bool result)
    {
      _resultTask.TrySetResult(result);
    }

    #endregion

    #region Viewer lists / types

    private static readonly Dictionary<string, ViewerList> ViewerLists = new Dictionary<string, ViewerList>
    {
      {PanoramaViewerList.Type, new PanoramaViewerList()},
      {ObliqueViewerList.Type, new ObliqueViewerList()}
    };

    private static readonly Dictionary<ViewerType, string> ToViewerTypes = new Dictionary<ViewerType, string>
    {
      { ViewerType.Panorama, PanoramaViewerList.Type },
      { ViewerType.Oblique, ObliqueViewerList.Type }
    };

    public static PanoramaViewerList PanoramaViewerList => (PanoramaViewerList) ViewerLists[PanoramaViewerList.Type];

    #endregion

    #region Viewer functions

    public static void RegisterJsObjects(ChromiumWebBrowser browser)
    {
      foreach (var viewerList in ViewerLists)
      {
        viewerList.Value.RegisterJsObject(browser);
      }
    }

    public static void ClearViewers()
    {
      foreach (var viewerList in ViewerLists)
      {
        viewerList.Value.Clear();
      }
    }

    public static async Task<IViewer> RemoveViewerFromJsValue(string viewerType, string jsValue)
    {
      return await ViewerLists[viewerType].RemoveViewerFromJsValue(jsValue);
    }

    public static async Task<IList<IViewer>> ToViewersFromJsValue(IList<ViewerType> viewerTypes, string jsValue)
    {
      List<IViewer> result = new List<IViewer>();

      foreach (var viewerType in viewerTypes)
      {
        result.AddRange(await ViewerLists[ToViewerTypes[viewerType]].GetViewersFromJsValue(jsValue));
      }

      return result;
    }

    public static IViewer ToViewer(string type, string name)
    {
      return ViewerLists[type].AddViewer(name);
    }

    public void Clear()
    {
      Viewers.Clear();
    }

    #endregion
  }
}
