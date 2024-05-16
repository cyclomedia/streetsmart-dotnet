using CefSharp;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
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
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "Get3DCursorVisible1"));

            // act
            var result = await _viewer.Get3DCursorVisible();

            // assert
            Assert.True(result);
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
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetButtonEnabled1"));

            // act
            var result = await _viewer.GetButtonEnabled(button);

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetSidebarVisible_True()
        {
            // arrange
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarVisible1"));

            // act
            var result = await _viewer.GetSidebarVisible();

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetSidebarEnabled_True()
        {
            // arrange
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarEnabled1"));

            // act
            var result = await _viewer.GetSidebarEnabled();

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetSidebarExpanded_True()
        {
            // arrange
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetSidebarExpanded1"));

            // act
            var result = await _viewer.GetSidebarExpanded();

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetOrientation_Equivalent()
        {
            // arrange
            var orientation = new { Yaw = 2, Pitch = 3, HFov = 50.2211112 };
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(orientation, "GetOrientation1"));

            // act
            var result = await _viewer.GetOrientation();

            // assert
            Assert.Equivalent(orientation, result, true);
        }

        [Fact]
        public async Task GetRecording_Equivalent()
        {
            // arrange
            var recording = new { groundLevelOffset = 5d, xyz = new { }, tileSchema = TileSchema.Dcr9Tiling, productType = ProductType.Cyclorama, id="1", srs="2" };
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(recording, "GetRecording1"));

            // act
            var result = await _viewer.GetRecording();

            // assert
            Assert.Equal(recording.id, result.Id);
            Assert.Equal(recording.groundLevelOffset, result.GroundLevelOffset);
        }

        [Fact]
        public async Task GetRecordingsVisible_True()
        {
            // arrange
            _browserMock.Setup(x => x.IsDisposed).Returns(false);
            _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
            _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(true, "GetRecordingsVisible1"));

            // act
            var result = await _viewer.GetRecordingsVisible();

            // assert
            Assert.True(result);
        }
    }
}
