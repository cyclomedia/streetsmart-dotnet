using CefSharp;
using Moq;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests.NET6
{
  public sealed class PanoramaViewerTests
  {
    private readonly PanoramaViewer _viewer;
    private readonly Mock<IStreetSmartBrowser> _browserMock = new();
    private readonly Mock<PanoramaViewerList> _panoramaViewerListMock = new();
    private readonly Mock<IBrowser> _iBrowserMock = new();

    public PanoramaViewerTests()
    {
      _viewer = new PanoramaViewer(_browserMock.Object, _panoramaViewerListMock.Object, "PanoramaViewerTest");
    }

    [Fact]
    public void JsThis_IsNull()
    {
      Assert.Null(_viewer.JsThis);
    }

    [Fact]
    public async Task Get3DCursorVisible_True()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "Get3DCursorVisible1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.Get3DCursorVisible();

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Theory]
    [InlineData(PanoramaViewerButtons.Elevation)]
    [InlineData(PanoramaViewerButtons.Overlays)]
    [InlineData(PanoramaViewerButtons.OpenOblique)]
    [InlineData(PanoramaViewerButtons.ReportBlurring)]
    [InlineData(PanoramaViewerButtons.ImageInformation)]
    [InlineData(PanoramaViewerButtons.Measure)]
    [InlineData(PanoramaViewerButtons.SaveImage)]
    [InlineData(PanoramaViewerButtons.ZoomIn)]
    [InlineData(PanoramaViewerButtons.ZoomOut)]
    [InlineData(PanoramaViewerButtons.ZoomWindow)]
    public async Task GetButtonEnabled_True(PanoramaViewerButtons button)
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetButtonEnabled1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetButtonEnabled(button);

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetSidebarVisible_True()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarVisible1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetSidebarVisible();

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetSidebarEnabled_True()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarEnabled1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetSidebarEnabled();

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetSidebarExpanded_True()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarExpanded1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetSidebarExpanded();

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetOrientation_Equivalent()
    {
      // arrange
      var orientation = DataHelper.Orientation;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(orientation, "GetOrientation1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetOrientation();

      // assert
      Assert.Equivalent(new Orientation(orientation), result, true);
      Mock.Verify();
    }

    [Fact]
    public async Task GetRecording_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "GetRecording1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetRecording();

      // assert
      Assert.Equivalent(new Recording(recording), result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetRecordingsVisible_True()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetRecordingsVisible1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetRecordingsVisible();

      // assert
      Assert.True(result);
      Mock.Verify();
    }

    [Fact]
    public async Task GetViewerColor_Equal()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new List<object> { 4, 5, 6, 0.5 }, "GetViewerColor1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetViewerColor();

      // assert
      Assert.Equal(Color.FromArgb(127, 4, 5, 6), result);
      Mock.Verify();
    }

    [Fact]
    public async Task LookAtCoordinate_Throws()
    {
      // arrange
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnStreetSmartException("test exception", "LookAtCoordinate1")).Verifiable(Times.Once);

      // act and assert
      await Assert.ThrowsAsync<StreetSmartException>(() => _viewer.LookAtCoordinate(new Coordinate()));
      Mock.Verify();
    }

    [Fact]
    public async Task OpenByAddress_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByAddress("test");

      // assert
      Assert.Equivalent(new Recording(recording), result, true);
      Mock.Verify();
    }

    [Fact]
    public async Task OpenByCoordinate_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByCoordinate(new Coordinate());

      // assert
      Assert.Equivalent(new Recording(recording), result, true);
      Mock.Verify();
    }

    [Fact]
    public async Task OpenByImageId_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByImageId("test_image_id");

      // assert
      Assert.Equivalent(new Recording(recording), result, true);
      Mock.Verify();
    }

    [Fact]
    public async Task SearchRecordingAsync_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.SearchRecordingAsync(null, null, null);

      // assert
      Assert.Equivalent(new Recording(recording), result, true);
      Mock.Verify();
    }

    [Fact]
    public void RotateDown_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.RotateDown(54d);

      // assert
      Assert.Contains(".rotateDown", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void RotateUp_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.RotateUp(54d);

      // assert
      Assert.Contains(".rotateUp", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void RotateLeft_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.RotateLeft(54d);

      // assert
      Assert.Contains(".rotateLeft", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void RotateRight_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.RotateRight(54d);

      // assert
      Assert.Contains(".rotateRight", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void SetElevationSliderLevel_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.SetElevationSliderLevel(54d);

      // assert
      Assert.Contains(".setElevationSliderLevel", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void SetOrientation_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.SetOrientation(new Orientation(3d, 4d, 6d));

      // assert
      Assert.Contains(".setOrientation", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void ShowAttributePanelOnFeatureClick_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ShowAttributePanelOnFeatureClick();

      // assert
      Assert.Contains(".showAttributePanelOnFeatureClick", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ShowAttributePanelOnFeatureClick_Bool_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ShowAttributePanelOnFeatureClick(visible);

      // assert
      Assert.Contains(".showAttributePanelOnFeatureClick", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Toggle3DCursor_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.Toggle3DCursor(visible);

      // assert
      Assert.Contains(".toggle3DCursor", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void ToggleLinkedViewers_Contains()
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleLinkedViewers();

      // assert
      Assert.Contains(".toggleLinkedViewers", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToggleAddressesVisible_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleAddressesVisible(visible);

      // assert
      Assert.Contains(".toggleAddressesVisible", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(PanoramaViewerButtons.Elevation, true)]
    [InlineData(PanoramaViewerButtons.Overlays, true)]
    [InlineData(PanoramaViewerButtons.OpenOblique, true)]
    [InlineData(PanoramaViewerButtons.ReportBlurring, true)]
    [InlineData(PanoramaViewerButtons.ZoomIn, true)]
    [InlineData(PanoramaViewerButtons.ZoomOut, true)]
    [InlineData(PanoramaViewerButtons.ZoomWindow, true)]
    [InlineData(PanoramaViewerButtons.Measure, true)]
    [InlineData(PanoramaViewerButtons.SaveImage, true)]
    [InlineData(PanoramaViewerButtons.SaveMeasurement, true)]
    [InlineData(PanoramaViewerButtons.ImageInformation, true)]
    [InlineData(PanoramaViewerButtons.Elevation, false)]
    [InlineData(PanoramaViewerButtons.Overlays, false)]
    [InlineData(PanoramaViewerButtons.OpenOblique, false)]
    [InlineData(PanoramaViewerButtons.ReportBlurring, false)]
    [InlineData(PanoramaViewerButtons.ZoomIn, false)]
    [InlineData(PanoramaViewerButtons.ZoomOut, false)]
    [InlineData(PanoramaViewerButtons.ZoomWindow, false)]
    [InlineData(PanoramaViewerButtons.Measure, false)]
    [InlineData(PanoramaViewerButtons.SaveImage, false)]
    [InlineData(PanoramaViewerButtons.SaveMeasurement, false)]
    [InlineData(PanoramaViewerButtons.ImageInformation, false)]
    public void ToggleButtonEnabled_Contains(PanoramaViewerButtons buttonId, bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleButtonEnabled(buttonId, visible);

      // assert
      Assert.Contains(".toggleButtonEnabled", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToggleRecordingsVisible_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleRecordingsVisible(visible);

      // assert
      Assert.Contains(".toggleRecordingsVisible", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToggleSidebarExpanded_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleSidebarExpanded(visible);

      // assert
      Assert.Contains(".toggleSidebarExpanded", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToggleSidebarVisible_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleSidebarVisible(visible);

      // assert
      Assert.Contains(".toggleSidebarVisible", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToggleSidebarEnabled_Contains(bool visible)
    {
      // arrange
      string? script = null;
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

      // act
      _viewer.ToggleSidebarEnabled(visible);

      // assert
      Assert.Contains(".toggleSidebarEnabled", script, StringComparison.InvariantCulture);
      Mock.Verify();
    }

    [Fact]
    public void OnElevationChange_Equal()
    {
      // arrange
      IElevationInfo? receivedEvent = null;
      object? sender = null;
      _viewer.ElevationChange += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", new { level = 5, groundLevel = 6 });
      
      // act
      _viewer.OnElevationChange(obj);

      // assert
      Assert.Equal(5, receivedEvent?.Level);
      Assert.Equal(6, receivedEvent?.GroundLevel);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnImageChange_Equal()
    {
      // arrange
      EventArgs? receivedEvent = null;
      object? sender = null;
      _viewer.ImageChange += (s, e) => { receivedEvent = e; sender = s; };

      // act
      _viewer.OnImageChange(null);

      // assert
      Assert.Equal(EventArgs.Empty, receivedEvent);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnRecordingClick_Equivalent()
    {
      // arrange
      var recording = DataHelper.Recording;
      IRecordingClickInfo? receivedEvent = null;
      object? sender = null;
      _viewer.RecordingClick += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", new { recording, eventData = new { shiftKey = false, altKey = false, ctrlKey = true } });

      // act
      _viewer.OnRecordingClick(obj);

      // assert
      Assert.Equivalent(new Recording(recording), receivedEvent?.Recording);
      Assert.Equal(false, receivedEvent?.ShiftKey);
      Assert.Equal(false, receivedEvent?.AltKey);
      Assert.Equal(true, receivedEvent?.CtrlKey);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnFeatureClick_Equal()
    {
      // arrange
      var featureInfo = DataHelper.FeatureInfo;
      IFeatureInfo? receivedEvent = null;
      object? sender = null;
      _viewer.FeatureClick += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", featureInfo);

      // act
      _viewer.OnFeatureClick(obj);

      // assert
      Assert.Equivalent(new FeatureInfo(featureInfo), receivedEvent);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnTileLoadError_Equal()
    {
      // arrange
      var detail = new { request = new Dictionary<string, object> { { "a", "c" } } };
      IDictionary<string, object>? receivedEvent = null;
      object? sender = null;
      _viewer.TileLoadError += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", detail);

      // act
      _viewer.OnTileLoadError(obj);

      // assert
      Assert.Equal(detail.request, receivedEvent);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnViewChange_Equivalent()
    {
      // arrange
      var orientation = DataHelper.Orientation;
      IOrientation? receivedEvent = null;
      object? sender = null;
      _viewer.ViewChange += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", orientation);

      // act
      _viewer.OnViewChange(obj);

      // assert
      Assert.Equivalent(new Orientation(orientation), receivedEvent, true);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnSurfaceCursorChange_Equivalent()
    {
      // arrange
      var depthInfo = DataHelper.DepthInfo;
      IDepthInfo? receivedEvent = null;
      object? sender = null;
      _viewer.SurfaceCursorChange += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", depthInfo);

      // act
      _viewer.OnSurfaceCursorChange(obj);

      // assert
      Assert.Equivalent(new DepthInfo(depthInfo), receivedEvent, true);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnViewLoadEnd_Equal()
    {
      // arrange
      EventArgs? receivedEvent = null;
      object? sender = null;
      _viewer.ViewLoadEnd += (s, e) => { receivedEvent = e; sender = s; };

      // act
      _viewer.OnViewLoadEnd(null);

      // assert
      Assert.Equal(EventArgs.Empty, receivedEvent);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnTimeTravelChange_Equivalent()
    {
      // arrange
      var timeTravelInfo = DataHelper.TimeTravelInfo;
      ITimeTravelInfo? receivedEvent = null;
      object? sender = null;
      _viewer.TimeTravelChange += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", timeTravelInfo);

      // act
      _viewer.OnTimeTravelChange(obj);

      // assert
      Assert.Equivalent(new TimeTravelInfo(timeTravelInfo), receivedEvent, true);
      Assert.Equal(_viewer, sender);
    }

    [Fact]
    public void OnFeatureSelectionChange_Equivalent()
    {
      // arrange
      var featureInfo = DataHelper.FeatureInfo;
      IFeatureInfo? receivedEvent = null;
      object? sender = null;
      _viewer.FeatureSelectionChange += (s, e) => { receivedEvent = e.Value; sender = s; };
      var obj = new ExpandoObject();
      obj.TryAdd("detail", featureInfo);

      // act
      _viewer.OnFeatureSelectionChange(obj);

      // assert
      Assert.Equivalent(new FeatureInfo(featureInfo), receivedEvent, true);
      Assert.Equal(_viewer, sender);
    }
  }
}
