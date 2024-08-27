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
using StreetSmart.Common.Data;
using StreetSmart.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StreetSmart.Common.API
{
  // ReSharper disable once InconsistentNaming
  internal abstract class APIBase : DataConvert
  {
    #region Tasks

    private readonly Dictionary<string, TaskCompletionSource<object>> _resultTask;

    #endregion

    #region Members

    private int _processId;

    #endregion

    #region Properties

    protected int GetProcessId => _processId = (_processId + 1) % 10000;

    protected IStreetSmartBrowser Browser { get; set; }

    protected virtual string CallFunctionBase => string.Empty;

    public virtual string JsThis => $"{GetType().Name}Events";

    #endregion

    #region Callback definitions

    public virtual string JsResult => $"{nameof(OnResult).FirstCharacterToLower()}";

    public string JsThisResult => $"{nameof(OnThisResult).FirstCharacterToLower()}";

    protected string JsLoginSuccess => $"{nameof(OnLoginSuccess).FirstCharacterToLower()}";

    protected string JsLoginFailed => $"{nameof(OnLoginFailedException).FirstCharacterToLower()}";

    protected string JsMeasurementFailed => $"{nameof(OnMeasurementException).FirstCharacterToLower()}";

    public virtual string JsImNotFound => $"{nameof(OnImageNotFoundException).FirstCharacterToLower()}";

    protected string JsCloseViewerException => $"{nameof(OnViewerCloseException).FirstCharacterToLower()}";

    protected string JsStreetSmartException => $"{nameof(OnStreetSmartException).FirstCharacterToLower()}";

    #endregion

    #region Constructors

    protected APIBase()
    {
      _processId = 0;
      _resultTask = new Dictionary<string, TaskCompletionSource<object>>();
    }

    protected APIBase(IStreetSmartBrowser browser)
      : this()
    {
      Browser = browser;
    }

    #endregion

    #region Callbacks

    public void OnResult(object result, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(result);
    }

    public void OnThisResult(bool result, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(result);
    }

    public void OnLoginSuccess(string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(true);
    }

    public void OnMeasurementException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartMeasurementException(message));
    }

    public void OnLoginFailedException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartLoginFailedException(message));
    }

    public void OnImageNotFoundException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartImageNotFoundException(message));
    }

    public void OnViewerCloseException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartCloseViewerException(message));
    }

    public void OnStreetSmartException(string message, string funcName)
    {
      CheckResultTask(funcName);
      _resultTask[funcName].TrySetResult(new StreetSmartException(message));
    }

    #endregion

    #region Functions

    protected void RegisterThisJsObject()
    {
      Browser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;

#if WINFORMS
#if NETCOREAPP
      Browser.JavascriptObjectRepository.Register(JsThis, this);
#else
      Browser.JavascriptObjectRepository.Register(JsThis, this, true);
#endif
#else
      Browser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
      {
        var repo = e.ObjectRepository;

        if (e.ObjectName == "Legacy")
        {
#if NETCOREAPP
          repo.Register(JsThis, this);
#else
          repo.Register(JsThis, this, false);
#endif
        }
      };
#endif
    }

    protected bool CheckResultTask(string funcName)
    {
      bool result = true;

      if (!_resultTask.ContainsKey(funcName))
      {
        _resultTask.Add(funcName, new TaskCompletionSource<object>());
        result = false;
      }

      return result;
    }

    protected string GetScript(string funcName, int processId = 0, [CallerMemberName] string memberName = "")
    {
      var sb = new StringBuilder();
      sb.Append(JsThis)
        .Append('.')
        .Append(JsResult)
        .Append('(')
        .Append(CallFunctionBase)
        .Append('.')
        .Append(funcName)
        .Append(",'")
        .Append(memberName)
        .Append(processId)
        .Append("');");
      return sb.ToString();
    }

    internal async Task<object> CallJsGetScriptAsync(string script, [CallerMemberName] string memberName = "")
    {
      int processId = GetProcessId;

      string fullScript = GetScriptWithTryCatch(script, processId, memberName);
      object result = await CallJsAsync(fullScript, processId, memberName);
      if (result is Exception exception)
      {
        throw exception;
      }

      return result;
    }
    protected string GetScriptWithTryCatch(string funcName, int processId, string memberName)
    {
      var sb = new StringBuilder();
      sb.Append("try{")
        .Append(JsThis).Append('.').Append(JsResult).Append('(')
        .Append(CallFunctionBase).Append('.').Append(funcName).Append(", '")
        .Append(memberName).Append(processId).Append("');")
        .Append("}catch(e){")
        .Append(JsThis).Append('.').Append(JsStreetSmartException).Append("(e.message, ")
        .Append(memberName).Append(processId).Append(");}");
      return sb.ToString();
    }

    protected virtual async Task<object> CallJsAsync(string script, int processId, [CallerMemberName] string memberName = "")
    {
      object funcResult = null;
      IBrowser myBrowser = !(Browser?.IsDisposed ?? true) ? Browser?.GetBrowser() : null;

      if (myBrowser != null)
      {
        string funcName = $"{memberName}{processId}";

        if (CheckResultTask(funcName))
        {
          _resultTask[funcName] = new TaskCompletionSource<object>();
        }

        Browser.ExecuteScriptAsync(script);
        await _resultTask[funcName].Task;
        TaskCompletionSource<object> result = _resultTask[funcName];
        _resultTask.Remove(funcName);
        funcResult = result.Task.Result;
      }

      return funcResult;
    }

    #endregion
  }
}
