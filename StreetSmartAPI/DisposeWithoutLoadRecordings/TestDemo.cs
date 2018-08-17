using System;
using System.Collections.Generic;
using System.Windows.Forms;

using StreetSmart.WinForms.Factories;
using StreetSmart.WinForms.Interfaces.API;
using StreetSmart.WinForms.Interfaces.Data;
using StreetSmart.WinForms.Interfaces.DomElement;

using static TestDemo.Properties.Resources;

namespace TestDemo
{
  enum State
  {
    ApiReady = 0,
    ApiInitialized = 1,
    PanoramaOpened = 2
  }

  public partial class TestDemo : Form
  {
    private const string Srs = "EPSG:28992";
    private const string Language = "nl";
    private const string Database = "CMDatabase";

    private readonly IStreetSmartAPI _api;
    private IOptions _options;

    public TestDemo()
    {
      InitializeComponent();
      _api = StreetSmartAPIFactory.Create();
      _api.APIReady += OnApiReady;
      plStreetSmart.Controls.Add(_api.GUI);
    }

    private void OnApiReady(object sender, EventArgs args)
    {
//      SetApiState(State.ApiReady);
    }

    private async void btnInit_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create(Language, Database);
      IDomElement element = DomElementFactory.Create();
      _options = OptionsFactory.Create(Username, Password, APIKey, Srs, Language, addressSettings, element);
      await _api.Init(_options);
//      SetApiState(State.ApiInitialized);
    }

    private void btnDestroy_Click(object sender, EventArgs e)
    {
      _api.Destroy(_options);
//      SetApiState(State.ApiReady);
    }

    private async void btnOpen_Click(object sender, EventArgs e)
    {
      IList<ViewerType> viewerTypes = new List<ViewerType> { ViewerType.Panorama };
      IPanoramaViewerOptions panoramaOptions = PanoramaViewerOptionsFactory.Create(false, false, true, true, true, true);
      IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, Srs, panoramaOptions);
      await _api.Open(txtSearch.Text, viewerOptions);
//      SetApiState(State.PanoramaOpened);
    }

    private void btnDevTools_Click(object sender, EventArgs e)
    {
      _api.ShowDevTools();
    }

    private void SetApiState(State state)
    {
      if (btnOpen.InvokeRequired)
      {
        btnOpen.Invoke(new MethodInvoker(() => btnOpen.Enabled = state == State.ApiInitialized));
      }
      else
      {
        btnOpen.Enabled = state == State.ApiInitialized;
      }

      if (btnDestroy.InvokeRequired)
      {
        btnDestroy.Invoke(new MethodInvoker(() => btnDestroy.Enabled = state == State.PanoramaOpened));
      }
      else
      {
        btnDestroy.Enabled = state == State.PanoramaOpened;
      }

      if (btnInit.InvokeRequired)
      {
        btnInit.Invoke(new MethodInvoker(() => btnInit.Enabled = state == State.ApiReady));
      }
      else
      {
        btnInit.Enabled = state == State.ApiReady;
      }
    }
  }
}
