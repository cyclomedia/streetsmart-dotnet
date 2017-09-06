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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class ObliqueViewerList: ViewerList
  {
    #region Members

    private ChromiumWebBrowser _browser;
    private readonly Dictionary<string, ObliqueViewer> _viewers;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Properties

    public static string Type => "@@ViewerType/OBLIQUE";

    public string JsThis => $"{GetType().Name}Events";

    public string JsThisResult => $"{nameof(OnThisResult).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public ObliqueViewerList()
    {
      _viewers = new Dictionary<string, ObliqueViewer>();
    }

    #endregion

    #region Functions

    public override void RegisterJsObject(ChromiumWebBrowser browser)
    {
      _browser = browser;
      browser.RegisterJsObject(JsThis, this);
    }

    public override IViewer AddViewer(string name)
    {
      ObliqueViewer viewer = new ObliqueViewer(_browser, this, name);

      if (!_viewers.ContainsKey(name))
      {
        _viewers.Add(name, viewer);
      }

      return viewer;
    }

    public override void DestroyViewer(IViewer viewer)
    {
      ObliqueViewer obliqueViewer = viewer as ObliqueViewer;

      if (_viewers.ContainsKey(obliqueViewer?.Name ?? string.Empty))
      {
        _viewers.Remove(obliqueViewer?.Name ?? string.Empty);
      }
    }

    protected override async Task<IViewer> RemoveViewerFromJsValue(string jsValue)
    {
      IViewer result = null;
      string key = null;

      foreach (var viewer in _viewers)
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
        _viewers.Remove(key);
      }

      return result;
    }

    protected override async Task<IList<IViewer>> GetViewersFromJsValue(string jsValue)
    {
      IList<IViewer> result = new List<IViewer>();

      foreach (var viewer in _viewers)
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

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    #endregion

    #region Callbacks ObliqueViewer

    public void OnThisResult(bool result)
    {
      _resultTask.TrySetResult(result);
    }

    #endregion
  }
}
