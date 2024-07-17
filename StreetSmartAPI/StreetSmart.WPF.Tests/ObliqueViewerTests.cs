using CefSharp;
using Moq;
using StreetSmart.Common;
using StreetSmart.Common.API;
using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
#if NETCOREAPP
using System.Dynamic;
#endif
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests;

public sealed class ObliqueViewerTests
{
  private readonly ObliqueViewer _viewer;
  private readonly Mock<IStreetSmartBrowser> _browserMock = new();
  private readonly Mock<ObliqueViewerList> _obliqueViewerListMock = new();
  private readonly Mock<IBrowser> _iBrowserMock = new();

  public ObliqueViewerTests()
  {
    _viewer = new ObliqueViewer(_browserMock.Object, _obliqueViewerListMock.Object, "ObliqueViewerTest");
  }

  [Theory]
  [InlineData(ObliqueViewerButtons.Measure)]
  [InlineData(ObliqueViewerButtons.Overlays)]
  [InlineData(ObliqueViewerButtons.SwitchDirection)]
  [InlineData(ObliqueViewerButtons.ImageInformation)]
  [InlineData(ObliqueViewerButtons.ToggleNadir)]
  [InlineData(ObliqueViewerButtons.SaveImage)]
  [InlineData(ObliqueViewerButtons.ZoomIn)]
  [InlineData(ObliqueViewerButtons.ZoomOut)]
  [InlineData(ObliqueViewerButtons.SaveMeasurement)]
  public async Task GetButtonEnabled_True(ObliqueViewerButtons button)
  {
    // arrange
    string? script = null;
    _browserMock.Setup(x => x.IsDisposed).Returns(false);
    _browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => { _viewer.OnResult(true, "GetButtonEnabled1"); script = x; }).Verifiable(Times.Once);

    // act
    var result = await _viewer.GetButtonEnabled(button);

    // assert
    Assert.True(result);
    Assert.Contains(button.Description(), script, StringComparison.InvariantCulture);
    Mock.Verify();
  }

  [Fact]
  public void SwitchViewingDirection_Contains()
  {
    // arrange
    string? script = null;
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

    // act
    _viewer.SwitchViewingDirection(54d);

    // assert
    Assert.Contains(".switchViewingDirection(", script, StringComparison.InvariantCulture);
    Assert.Contains(54.ToString(), script, StringComparison.InvariantCulture);
    Mock.Verify();
  }

  [Theory]
  [InlineData(ObliqueViewerButtons.Measure, true)]
  [InlineData(ObliqueViewerButtons.Overlays, true)]
  [InlineData(ObliqueViewerButtons.SwitchDirection, true)]
  [InlineData(ObliqueViewerButtons.ImageInformation, true)]
  [InlineData(ObliqueViewerButtons.ToggleNadir, true)]
  [InlineData(ObliqueViewerButtons.SaveImage, true)]
  [InlineData(ObliqueViewerButtons.ZoomIn, true)]
  [InlineData(ObliqueViewerButtons.ZoomOut, true)]
  [InlineData(ObliqueViewerButtons.SaveMeasurement, true)]
  [InlineData(ObliqueViewerButtons.Measure, false)]
  [InlineData(ObliqueViewerButtons.Overlays, false)]
  [InlineData(ObliqueViewerButtons.SwitchDirection, false)]
  [InlineData(ObliqueViewerButtons.ImageInformation, false)]
  [InlineData(ObliqueViewerButtons.ToggleNadir, false)]
  [InlineData(ObliqueViewerButtons.SaveImage, false)]
  [InlineData(ObliqueViewerButtons.ZoomIn, false)]
  [InlineData(ObliqueViewerButtons.ZoomOut, false)]
  [InlineData(ObliqueViewerButtons.SaveMeasurement, false)]
  public void ToggleButtonEnabled_Contains(ObliqueViewerButtons button, bool enabled)
  {
    // arrange
    string? script = null;
    _browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback<string>((x) => script = x).Verifiable(Times.Once);

    // act
    _viewer.ToggleButtonEnabled(button, enabled);

    // assert
    Assert.Contains(".toggleButtonEnabled(", script, StringComparison.InvariantCulture);
    Assert.Contains(button.Description(), script, StringComparison.InvariantCulture);
    Assert.Contains(enabled.ToString(), script, StringComparison.InvariantCultureIgnoreCase);
    Mock.Verify();
  }

  [Fact]
  public void OnSwitchViewingDirection_Equal()
  {
    // arrange
    var directionInfo = DataHelper.DirectionInfo;
    IDirectionInfo? receivedEvent = null;
    object? sender = null;
    _viewer.SwitchViewingDir += (s, e) => { receivedEvent = e.Value; sender = s; };
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", directionInfo);

    // act
    _viewer.OnSwitchViewingDirection(obj);

    // assert
    Assert.Equivalent(new DirectionInfo(directionInfo), receivedEvent);
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
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", featureInfo);

    // act
    _viewer.OnFeatureClick(obj);

    // assert
    Assert.Equivalent(new FeatureInfo(featureInfo), receivedEvent);
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
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", featureInfo);

    // act
    _viewer.OnFeatureSelectionChange(obj);

    // assert
    Assert.Equivalent(new FeatureInfo(featureInfo), receivedEvent, true);
    Assert.Equal(_viewer, sender);
  }

  [Fact]
  public void OnImageChange_Equivalent()
  {
    // arrange
    var imageInfo = DataHelper.ObliqueImageInfo;
    IObliqueImageInfo? receivedEvent = null;
    object? sender = null;
    _viewer.ImageChange += (s, e) => { receivedEvent = e.Value; sender = s; };
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", imageInfo);

    // act
    _viewer.OnImageChange(obj);

    // assert
    Assert.Equivalent(new ObliqueImageInfo(imageInfo), receivedEvent);
    Assert.Equal(_viewer, sender);
  }

  [Fact]
  public void OnViewChange_Equivalent()
  {
    // arrange
    var orientation = DataHelper.ObliqueOrientation;
    IObliqueOrientation? receivedEvent = null;
    object? sender = null;
    _viewer.ViewChange += (s, e) => { receivedEvent = e.Value; sender = s; };
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", orientation);

    // act
    _viewer.OnViewChange(obj);

    // assert
    Assert.Equivalent(new ObliqueOrientation(orientation), receivedEvent, true);
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
#if NETCOREAPP
    var obj = new ExpandoObject();
#else
    var obj = new Dictionary<string, object>();
#endif
    (obj as IDictionary<string, object>).Add("detail", timeTravelInfo);

    // act
    _viewer.OnTimeTravelChange(obj);

    // assert
    Assert.Equivalent(new TimeTravelInfo(timeTravelInfo), receivedEvent, true);
    Assert.Equal(_viewer, sender);
  }

}
