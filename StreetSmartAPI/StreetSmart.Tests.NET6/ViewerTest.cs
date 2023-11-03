using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;


namespace StreetSmart.Tests.NET6
{
    public class ViewerTest : IClassFixture<ApiFixture>
    {
        private const string _srs = "EPSG:28992";

        private ApiFixture _fixture;

        public ViewerTest(ApiFixture fixture)
        {
            this._fixture = fixture;
        }

        [Theory]
        [InlineData(ViewerType.Oblique, "Lange Haven 145, Schiedam", State.ObliqueOpened)]
        [InlineData(ViewerType.Panorama, "Lange Haven 145, Schiedam", State.PanoramaOpened)]
        [InlineData(ViewerType.PointCloud, "Lange Haven 145, Schiedam", State.PointCloudOpened)]
        [InlineData(ViewerType.MeshViewer, "Lange Haven 145, Schiedam", State.MeshOpened)]
        public async Task ViewerTestByTypeAndAddress(ViewerType viewerType, string address, State expectedViewerState)
        {
            IList<ViewerType> viewerTypes = new List<ViewerType>();
            IViewerOptions viewerOptions = null;
            IPanoramaViewerOptions panoramaViewerOptions = null;
            IObliqueViewerOptions obliqueViewerOptions = null;
            IPointCloudViewerOptions pointCloudViewerOptions = null;

            if (viewerType.Equals(ViewerType.Oblique))
            {
                obliqueViewerOptions = ObliqueViewerOptionsFactory.Create(true, true, true, true);
            }
            else if (viewerType.Equals(ViewerType.Panorama))
            {
                panoramaViewerOptions = PanoramaViewerOptionsFactory.Create(true, true, true, true, true, true);
            }
            else if (viewerType.Equals(ViewerType.PointCloud))
            {
                pointCloudViewerOptions = PointCloudViewerOptionsFactory.Create(true, true, true, PointCloudType.Aerial);
            }

            viewerTypes.Add(viewerType);

            viewerOptions = ViewerOptionsFactory.Create(viewerTypes, _srs, panoramaViewerOptions, obliqueViewerOptions, pointCloudViewerOptions);
            var viewerState = await _fixture.OpenViewer(address, viewerOptions);

            Assert.Equal(expectedViewerState, viewerState);
        }
    }
}
