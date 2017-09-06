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
using System.Linq;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using StreetSmart.WinForms.Interfaces;

namespace StreetSmart.WinForms.API
{
  internal class PanoramaViewerList: ViewerList
  {
    #region Members

    private ChromiumWebBrowser _browser;
    private readonly Dictionary<string, PanoramaViewer> _viewers;

    #endregion

    #region Tasks

    private TaskCompletionSource<object> _resultTask;

    #endregion

    #region Properties

    public static string Type => "@@ViewerType/PANORAMA";

    public string JsThis => $"{GetType().Name}Events";

    public string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    public string JsThisResult => $"{nameof(OnThisResult).FirstCharacterToLower()}";

    public string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    public string JsImChange => $"{nameof(OnImageChange).FirstCharacterToLower()}";

    public string JsRecClick => $"{nameof(OnRecordingClick).FirstCharacterToLower()}";

    public string JsTileLoadError => $"{nameof(OnTileLoadError).FirstCharacterToLower()}";

    public string JsViewChange => $"{nameof(OnViewChange).FirstCharacterToLower()}";

    public string JsViewLoadEnd => $"{nameof(OnViewLoadEnd).FirstCharacterToLower()}";

    public string JsViewLoadStart => $"{nameof(OnViewLoadStart).FirstCharacterToLower()}";

    public string JsTimeTravelChange => $"{nameof(OnTimeTravelChange).FirstCharacterToLower()}";

    #endregion

    #region Constructor

    public PanoramaViewerList()
    {
      _viewers = new Dictionary<string, PanoramaViewer>();
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
      return RegisterViewer(new PanoramaViewer(_browser, this, name));
    }

    public override IViewer AddViewer(IDomElement element, IPanoramaViewerOptions options)
    {
      return RegisterViewer(new PanoramaViewer(_browser, this, element, options));
    }

    public string ReAssignPanoramaViewer(string newViewer)
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.Name}={newViewer};");
    }

    public string DisconnectEvents()
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.DisconnectEventsScript}");
    }

    public string ConnectEvents()
    {
      return _viewers.Aggregate(string.Empty, (current, viewer) => $"{current}{viewer.Value.ConnectEventsScript}");
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

    public IViewer RegisterViewer(PanoramaViewer viewer)
    {
      if (!_viewers.ContainsKey(viewer.Name))
      {
        _viewers.Add(viewer.Name, viewer);
      }

      return viewer;
    }

    public override void DestroyViewer(IViewer viewer)
    {
      PanoramaViewer panoramaViewer = (PanoramaViewer) viewer;

      if (_viewers.ContainsKey(panoramaViewer?.Name ?? string.Empty))
      {
        _viewers.Remove(panoramaViewer?.Name ?? string.Empty);
        panoramaViewer?.DestroyViewer();
      }
    }

    private async Task<object> CallJsAsync(string script)
    {
      _resultTask = new TaskCompletionSource<object>();
      _browser.ExecuteScriptAsync(script);
      await _resultTask.Task;
      return _resultTask.Task.Result;
    }

    #endregion

    #region Events from StreetSmartAPI

    public void OnImageChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnImageChange(args);
      }
    }

    public void OnRecordingClick(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnRecordingClick(args);
      }
    }

    public void OnTileLoadError(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnTileLoadError(args);
      }
    }

    public void OnViewChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewChange(args);
      }
    }

    public void OnViewLoadEnd(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewLoadEnd(args);
      }
    }

    public void OnViewLoadStart(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnViewLoadStart(args);
      }
    }

    public void OnTimeTravelChange(string name, Dictionary<string, object> args)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnTimeTravelChange(args);
      }
    }

    #endregion

    #region Callbacks PanoramaViewer

    public void OnResult(string name, object result)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnResult(result);
      }
    }

    public void OnThisResult(bool result)
    {
      _resultTask.TrySetResult(result);
    }

    public void OnImageNotFoundException(string name, string message)
    {
      if (_viewers.ContainsKey(name))
      {
        _viewers[name].OnImageNotFoundException(message);
      }
    }

    #endregion
  }
}
