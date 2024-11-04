using CefSharp;
using Moq;
using Newtonsoft.Json;
using Pose;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Exceptions;
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
    IDictionary<string, object>? val = null;
    geoJsonOverlayMock.Setup(x => x.FillInParameters(It.IsAny<IDictionary<string, object>>())).Callback<IDictionary<string, object>>(x => val = x).Verifiable();
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
    var expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.addOverlay({name:'myName',visible:true,id:'',color:'#f0f8ff',geojson:{\"type\":\"FeatureCollection\",\"features\":[]},sourceSrs:'mySrs'}), 'AddOverlay1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, AddOverlay1);}";
    var expectedGeoJsonOverlay = new GeoJsonOverlay("{\"type\":\"FeatureCollection\",\"features\":[]}", "myName", "mySrs", Color.AliceBlue) { Id="4"};
    var geoJsonOverlay = new GeoJsonOverlay("{\"type\":\"FeatureCollection\",\"features\":[]}", "myName", "mySrs", Color.AliceBlue);
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Callback(() => _viewer.OnResult(new { id = 4 }, "AddOverlay1")).Verifiable(Times.Once);

    var result = await _viewer.AddOverlay(geoJsonOverlay);

    Assert.Equivalent(expectedGeoJsonOverlay, result, true);
    _browserMock.Verify();
  }

  [Fact]
  public async Task AddOverlay_InvalidJson_ThrowsStreetSmartJsonException()
  {
    var invalidJsonOverlay = new GeoJsonOverlay("{invalid json}", "myName", "mySrs", Color.AliceBlue);

    await Assert.ThrowsAsync<StreetSmartJsonException>(() => _viewer.AddOverlay(invalidJsonOverlay));
  }

  [Fact]
  public async Task AddOverlay_NullOverlay_ThrowsStreetSmartJsonException()
  {
    var nullJsonOverlay = new GeoJsonOverlay(null, "myName", "mySrs", Color.AliceBlue);

    await Assert.ThrowsAsync<StreetSmartJsonException>(() => _viewer.AddOverlay(nullJsonOverlay));
  }

  [Fact]
  public async Task AddOverlay_AllNullParameters_ThrowsStreetSmartJsonException()
  {
    var nullJsonOverlay = new GeoJsonOverlay(null, null, null, null);

    await Assert.ThrowsAsync<StreetSmartJsonException>(() => _viewer.AddOverlay(nullJsonOverlay));
  }

  [Fact]
  public async Task AddOverlay_NullGeoJsonObject_ThrowsStreetSmartJsonException()
  {
    GeoJsonOverlay? nullGeoJsonOverlay = null;

    await Assert.ThrowsAsync<StreetSmartJsonException>(() => _viewer.AddOverlay(nullGeoJsonOverlay));
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
  [InlineData("{invalid json}", false)]
  [InlineData("{\"key\": \"value\", \"array\": [1, 2, 3], \"nestedObject\": {\"nestedKey\": \"nestedValue\"}}", true)]
  [InlineData("{\"key\": \"value\", \"array\": [undefined, 2, 3]}", false)]
  [InlineData("{\"key\": null}", true)]

  public void IsValidJson_ValidatesJsonStringsCorrectly(string input, bool expectedResult)
  {
    var result = input.IsValidJson();

    Assert.Equal(expectedResult, result);
  }

  [Fact]
  public async Task CallJsGetScriptAsync_EmptyResult_ReturnEmptyString()
  {
    string expectedResult = "";
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.script, 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Callback(() => _viewer.OnResult(string.Empty, "CallJsGetScriptAsync1")).Verifiable(Times.Once);

    var result = await _viewer.CallJsGetScriptAsync("script", "CallJsGetScriptAsync");

    Assert.Equal(result, expectedResult);
    _browserMock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_NullResult_ReturnsNull()
  {
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.script, 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Callback(() => _viewer.OnResult(null, "CallJsGetScriptAsync1")).Verifiable(Times.Once);

    var result = await _viewer.CallJsGetScriptAsync("script", "CallJsGetScriptAsync");

    Assert.Null(result);
    _browserMock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_ExceptionThrown()
  {
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.script, 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Callback(() => _viewer.OnResult(new Exception(), "CallJsGetScriptAsync1")).Verifiable(Times.Once);

    await Assert.ThrowsAsync<Exception>(() => _viewer.CallJsGetScriptAsync("script", "CallJsGetScriptAsync"));

    _browserMock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_NullResultEmptyScript_ReturnsNull()
  {
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi., 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Callback(() => _viewer.OnResult(null, "CallJsGetScriptAsync1")).Verifiable(Times.Once);

    var result = await _viewer.CallJsGetScriptAsync("", "CallJsGetScriptAsync");

    Assert.Null(result);
    _browserMock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_IsDisposedIsTrue_ReturnsNull()
  {
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.script, 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(true);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Verifiable(Times.Never);

    var result = await _viewer.CallJsGetScriptAsync("script", "CallJsGetScriptAsync");

    Assert.Null(result);
    _browserMock.Verify();
  }

  [Fact]
  public async Task CallJsGetScriptAsync_GetBrowserReturnsNull_ResultNull()
  {
    string expectedScript = "try{StreetSmartAPIEvents.onResult(StreetSmartApi.script, 'CallJsGetScriptAsync1');}catch(e){StreetSmartAPIEvents.onStreetSmartException(e.message, CallJsGetScriptAsync1);}";
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns((IBrowser?)null);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.Is<string>(s => s == expectedScript))).Verifiable(Times.Never);

    var result = await _viewer.CallJsGetScriptAsync("script", "CallJsGetScriptAsync");

    Assert.Null(result);
    _browserMock.Verify();
  }

}