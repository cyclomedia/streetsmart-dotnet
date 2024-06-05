using Moq;
using Pose;
using StreetSmart.Common.API;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests
{
  public sealed class PanoramaViewerListTests
  {
    private readonly PanoramaViewerList _panoramaViewerList;

    public PanoramaViewerListTests()
    {
      _panoramaViewerList = new PanoramaViewerList();
    }

    [Fact]
    public void OnElevationChange_Empty()
    {
      // arrange
      //_browserMock.Setup(x => x.IsDisposed).Returns(false);
      //_browserMock.Setup(x => x.GetBrowser()).Returns(_iBrowserMock.Object);
      //_browserMock.Setup(x => x.ExecuteScriptAsync(It.IsAny<string>())).Callback(() => _viewer.OnResult(new { id = 4 }, "CloseViewer1")).Verifiable(Times.Once);
      //var viewerListShim = Shim.Replace(() => ViewerList.Viewers).With((Func<string, IList<ViewerType>, string, Task<IList<IViewer>>>)((x, y, z) => Task.FromResult(new List<IViewer>() as IList<IViewer>)));
      //IList<IViewer>? result = null;

      //// act
      //PoseContext.Isolate(() =>
      //{
      //  _panoramaViewerList.OnElevationChange("anyViewerId", null);
      //}, viewerListShim);

      //// assert
      //Assert.NotNull(result);
      //Assert.Empty(result);
      //Mock.Verify();

      //_panoramaViewerList.Viewers

      _panoramaViewerList.OnElevationChange("anyViewerId", null);
    }
  }
}
