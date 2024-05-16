using CefSharp;
using Moq;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests.NET6
{
  public sealed class PanoramaViewerTest
  {
    private readonly PanoramaViewer _viewer;
    private readonly Mock<IStreetSmartBrowser> _browserMock = new();
    private readonly Mock<PanoramaViewerList> _panoramaViewerListMock = new();
    private readonly Mock<IBrowser> _iBrowserMock = new();

    public PanoramaViewerTest()
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
      var orientation = new { Yaw = 2, Pitch = 3, HFov = 50.2211112 };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(orientation, "GetOrientation1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetOrientation();

      // assert
      Assert.Equivalent(orientation, result, true);
      Mock.Verify();
    }

    [Fact]
    public async Task GetRecording_Equivalent()
    {
      // arrange
      var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id = "1", srs = "2" };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "GetRecording1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.GetRecording();

      // assert
      Assert.Equal(recording.id, result.Id);
      Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
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
      var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id = "1", srs = "2" };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByAddress("test");

      // assert
      Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
      Mock.Verify();
    }

    [Fact]
    public async Task OpenByCoordinate_Equivalent()
    {
      // arrange
      var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id = "1", srs = "2" };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByCoordinate(new Coordinate());

      // assert
      Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
      Mock.Verify();
    }

    [Fact]
    public async Task OpenByImageId_Equivalent()
    {
      // arrange
      var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id = "1", srs = "2" };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.OpenByImageId("test_image_id");

      // assert
      Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
      Mock.Verify();
    }

    [Fact]
    public async Task SearchRecordingAsync_Equivalent()
    {
      // arrange
      var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id = "1", srs = "2" };
      _browserMock.Setup(x => x.IsDisposed).Returns(false);
      _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "SearchRecordingAsync1")).Verifiable(Times.Once);

      // act
      var result = await _viewer.SearchRecordingAsync(null, null, null);

      // assert
      Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
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
      Assert.Contains(".rotateDown", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".rotateUp", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".rotateLeft", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".rotateRight", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".setElevationSliderLevel", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".setOrientation", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".showAttributePanelOnFeatureClick", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".showAttributePanelOnFeatureClick", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggle3DCursor", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleLinkedViewers", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleAddressesVisible", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleButtonEnabled", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleRecordingsVisible", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleSidebarExpanded", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleSidebarVisible", script, System.StringComparison.InvariantCulture);
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
      Assert.Contains(".toggleSidebarEnablede", script, System.StringComparison.InvariantCulture);
      Mock.Verify();
    }
  }
}
