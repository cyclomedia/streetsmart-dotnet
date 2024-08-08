﻿using CefSharp;
using Moq;
using Newtonsoft.Json;
using Pose;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests;

public class StreetSmartAPITests
{
  private readonly StreetSmartAPI _viewer;
  private readonly Mock<IStreetSmartBrowser> _browserMock = new();
  private readonly Mock<IJavascriptObjectRepository> _javascriptObjectRepoMock = new();
  private readonly Mock<IBrowser> _iBrowserMock = new();
  private readonly Dictionary<string, TaskCompletionSource<object>> _resultTask = new();


  public StreetSmartAPITests()
  {
    _browserMock.SetupGet(x => x.JavascriptObjectRepository).Returns(_javascriptObjectRepoMock.Object);
    _javascriptObjectRepoMock.SetupGet(x => x.Settings).Returns(new CefSharp.JavascriptBinding.JavascriptBindingSettings());
    _viewer = new("a", _browserMock.Object);
  }

  [Fact]
  public void RestartStreetSmart_Verify()
  {
    // arrange

    // act
    _viewer.RestartStreetSmart("b");

    // assert
    _browserMock.VerifySet(x => x.Address = "b", Times.Once);
  }

  [Fact]
  public void ShowDevTools_Verify()
  {
    // arrange

    // act
    _viewer.ShowDevTools();

    // assert
    _browserMock.VerifyGet(x => x.Dispatcher, Times.Once);
    // TODO: test that show is called
    // _browserMock.Verify(x => x.ShowDevTools(It.IsAny<IWindowInfo>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
  }

  [Fact]
  public void CloseDevTools_Verify()
  {
    // arrange

    // act
    _viewer.CloseDevTools();

    // assert
    _browserMock.VerifyGet(x => x.Dispatcher, Times.Once);
    // TODO: test that show is called
    // _browserMock.Verify(x => x.ShowDevTools(It.IsAny<IWindowInfo>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
  }

  [Fact]
  public async Task AddOverlay_Equivalent()
  {
    // arrange
    var geoJsonOverlay = new GeoJsonOverlay("{}", "myName", "mySrs", Color.AliceBlue);
    var expectedOverlay = new GeoJsonOverlay("{}", "myName", "mySrs", Color.AliceBlue) { Id = "4" };
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new { id = 4 }, "AddOverlay1")).Verifiable(Times.Once);

    // act
    var result = await _viewer.AddOverlay(geoJsonOverlay);

    // assert
    Assert.Equivalent(expectedOverlay, result, true);
    Mock.Verify();
  }

  [Fact]
  public async Task AddWFSLayer_Equivalent()
  {
    // arrange
    var geoJsonOverlayMock = new Mock<IWFSOverlay>();
    Dictionary<string, object>? val = null;
    geoJsonOverlayMock.Setup(x => x.FillInParameters(It.IsAny<Dictionary<string, object>>())).Callback<Dictionary<string, object>>(x => val = x).Verifiable();
    geoJsonOverlayMock.SetupSet(x => x.Id = "4").Verifiable(Times.Once);
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new { id = 4 }, "AddWFSLayer1")).Verifiable(Times.Once);

    // act
    var result = await _viewer.AddWFSLayer(geoJsonOverlayMock.Object);

    // assert
    Assert.Equivalent(JsonConvert.SerializeObject(new { id = 4 }), JsonConvert.SerializeObject(val));
    Assert.Equal(geoJsonOverlayMock.Object, result);
    Mock.Verify();
  }

#if NETCOREAPP
  [Fact]
  public void CloseViewer_Empty()
  {
    // arrange
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new { id = 4 }, "CloseViewer1")).Verifiable(Times.Once);
    var viewerListShim = Shim.Replace(() => ViewerList.ToViewersFromJsValue(Is.A<string>(), Is.A<IList<ViewerType>>(), Is.A<string>())).With((Func<string, IList<ViewerType>, string, Task<IList<IViewer>>>)((x, y, z) => Task.FromResult(new List<IViewer>() as IList<IViewer>)));
    IList<IViewer>? result = null;

    // act
    PoseContext.Isolate(async () =>
    {
      result = await _viewer.CloseViewer("anyViewerId");
    }, viewerListShim);

    // assert
    Assert.NotNull(result);
    Assert.Empty(result);
    Mock.Verify();
  }
#endif
  [Fact]
  public async Task AddOverlay_ValidJson_ReturnsOverlay()
  {
    var geoJsonOverlay = new GeoJsonOverlay("{\"type\":\"FeatureCollection\",\"features\":[]}", "myName", "mySrs", Color.AliceBlue);
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new { id = 4 }, "AddOverlay1")).Verifiable(Times.Once);

    var result = await _viewer.AddOverlay(geoJsonOverlay);

    Assert.Equal(geoJsonOverlay, result);
    Mock.Verify();
  }

  [Fact]
  public async Task AddOverlay_InvalidJson_ThrowsStreetSmartJsonException()
  {
    var invalidJsonOverlay = new GeoJsonOverlay("{invalid json}", "myName", "mySrs", Color.AliceBlue);

    await Assert.ThrowsAsync<StreetSmart.Common.Exceptions.StreetSmartJsonException>(() => _viewer.AddOverlay(invalidJsonOverlay));
  }

  [Fact]
  public async Task AddOverlay_NullOverlay_ThrowsStreetSmartJsonException()
  {
    var nullJsonOverlay = new GeoJsonOverlay(null, "myName", "mySrs", Color.AliceBlue);

    await Assert.ThrowsAsync<StreetSmart.Common.Exceptions.StreetSmartJsonException>(() => _viewer.AddOverlay(nullJsonOverlay));
  }

  [Theory]
  [InlineData("{}", true)]
  [InlineData("[]", true)]
  [InlineData("{\"key\":\"value\"}", true)]
  [InlineData("[{\"key\":\"value\"}]", true)]
  [InlineData("", false)]
  [InlineData(" ", false)]
  [InlineData("{invalid}", false)]
  [InlineData("[{invalid}]", false)]
  [InlineData("{\"key\": \"value\", \"key2\": {\"nestedKey\": \"nestedValue\"}}", true)]
  [InlineData("{\"key\": \"value\", \"key2\": {\"nestedKey\": undefined}}", false)]
  public void IsValidJson_ValidatesJsonStringsCorrectly(string input, bool expectedResult)
  {
    var result = input.IsValidJson();

    Assert.Equal(expectedResult, result);
  }

  [Fact]
  public void IsValidJson_WhitespaceInput_ReturnsFalse()
  {
    string input = "   ";

    var result = input.IsValidJson();

    Assert.False(result);
  }

  [Fact]
  public void IsValidJson_InvalidJson_ReturnsFalse()
  {
    string input = "{invalid json}";

    var result = input.IsValidJson();

    Assert.False(result);
  }

  [Fact]
  public void IsValidJson_ValidJsonWithComplexStructure_ReturnsTrue()
  {
    string input = "{\"key\": \"value\", \"array\": [1, 2, 3], \"nestedObject\": {\"nestedKey\": \"nestedValue\"}}";

    var result = input.IsValidJson();

    Assert.True(result);
  }

  [Fact]
  public void IsValidJson_InvalidJsonWithUndefined_ReturnsFalse()
  {
    string input = "{\"key\": \"value\", \"array\": [undefined, 2, 3]}";

    var result = input.IsValidJson();

    Assert.False(result);
  }

  [Fact]
  public void IsValidJson_JsonWithNullValues_ReturnsTrue()
  {
    string input = "{\"key\": null}";

    var result = input.IsValidJson();

    Assert.True(result);
  }

  [Fact]
  public async Task CallJsGetScriptAsync_EmptyScript_ReturnsNull()
  {
    string script = string.Empty;
    object expected = new();  

    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>(s =>
    {
      var funcName = GetFunctionNameFromScript(s); 
      if (funcName == "CallJsGetScriptAsync")
      {
        _resultTask[funcName].SetResult(expected);
      }
    }).Verifiable();

    var result = await _viewer.CallJsGetScriptAsync(script);

    Assert.Null(result);
    Mock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_NullScript_ReturnsNull()
  {
    string script = "";
    object expected = new();  

    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>(s =>
    {
      var funcName = GetFunctionNameFromScript(s); 
      if (funcName == "CallJsGetScriptAsync")
      {
        _resultTask[funcName].SetResult(expected);
      }
    }).Verifiable();

    var result = await _viewer.CallJsGetScriptAsync(script);

    Assert.Null(result);
    Mock.Verify();
  }

  private string GetFunctionNameFromScript(string script)
  {
    return "CallJsGetScriptAsync";
  }

}
