
using Microsoft.Extensions.Configuration;
using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.Tests.NET6
{
    public enum State
    {
        ApiReady = 0,
        ApiInitialized = 1,
        PanoramaOpened = 2,
        PointCloudOpened = 3,
        ObliqueOpened = 4,
        MeshOpened = 5,
        ViewerNotReady = 6
    }
    public class ApiFixture
    {
        private const string _srs = "EPSG:28992";
        private const string _language = "nl";
        private const string _database = "CMDatabase";

        private readonly IStreetSmartAPI _api;
        private IOptions? _options;
        private IConfiguration Configuration { get; set; }

        public State ApiState { get; private set; }

        public ApiFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the path to your appsettings.json file
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            _api = StreetSmartAPIFactory.Create();
            _api.APIReady += OnApiReady;
        }
        private void OnApiReady(object? sender, EventArgs args)
        {
            SetApiState(State.ApiReady);
        }
        public State SetApiState(State state)
        {
            return ApiState = state;
        }
        public async Task<State> InitWithBasicAuth()
        {
            string username = Configuration["TestData:ApiUsername"]!;
            string password = Configuration["TestData:ApiPassword"]!;
            string apiKey = Configuration["TestData:ApiKey"]!;

            IAddressSettings addressSettings = AddressSettingsFactory.Create(_language, _database);
            IDomElement element = DomElementFactory.Create();
            _options = OptionsFactory.Create(username, password, apiKey, _srs, _language, addressSettings, element);
            await _api.Init(_options);
            return SetApiState(State.ApiInitialized);
        }
        public async Task<State> Destroy()
        {
            await _api.Destroy(_options);
            return SetApiState(State.ApiReady);
        }

        public async Task<State> OpenViewer(string query, IViewerOptions options)
        {
            var viewerState = State.ViewerNotReady;
            var openedViewers = await _api.Open(query, options);

            foreach (var viewer in openedViewers)
            {
                if (viewer is IPanoramaViewer)
                {
                    viewerState = State.PanoramaOpened;
                }
                else if (viewer is IObliqueViewer)
                {
                    viewerState = State.ObliqueOpened;
                }
                else if (viewer is IPointCloudViewer)
                {
                    viewerState = State.PointCloudOpened;
                }
                else if (viewer is IMeshViewer)
                {
                    viewerState = State.MeshOpened;
                }
            }

            return viewerState;
        }
    }
}