using System;
using System.Collections.Generic;
using System.Windows;
using CefSharp;
using StreetSmart.Wpf.API;
using StreetSmart.Wpf.Factories;
using StreetSmart.Wpf.Handlers;
using StreetSmart.Wpf.Interfaces.API;
using StreetSmart.Wpf.Interfaces.Data;
using StreetSmart.Wpf.Interfaces.DomElement;
using UserControl = System.Windows.Controls.UserControl;

namespace StreetSmart.Wpf
{
  /// <summary>
  /// Interaction logic for StreetSmartGUI.xaml
  /// </summary>
  public partial class StreetSmartGUI : UserControl
  {
    private const string Srs = "EPSG:28992";
    private const string Language = "nl";
    private const string Database = "CMDatabase";

    private IOptions _options;
    private IStreetSmartAPI _api;

    public readonly DependencyProperty ApiProperty =
      DependencyProperty.Register("Api", typeof(IStreetSmartAPI), typeof(StreetSmartGUI), new PropertyMetadata(null, null));

    public IStreetSmartAPI Api
    {
      get => (IStreetSmartAPI) GetValue(ApiProperty);
      private set
      {
        value.APIReady += Init;
        SetValue(ApiProperty, value);
      }
    }

    public readonly DependencyProperty StreetSmartLocationProperty =
      DependencyProperty.Register("StreetSmartLocation", typeof(string), typeof(StreetSmartGUI), new PropertyMetadata(null, OnStreetSmartLocationChanged));

    public string StreetSmartLocation
    {
      get => (string) GetValue(StreetSmartLocationProperty);
      set => SetValue(StreetSmartLocationProperty, value);
    }
    private static void OnStreetSmartLocationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
      if (sender is StreetSmartGUI view)
      {
        if (view != null)
        {
          view.Api = new StreetSmartAPI(view.StreetSmartLocation, view.Browser);
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public StreetSmartGUI()
    {
      Cef.Initialize(new CefSettings(), true, new BrowserProcessHandler());
      CefSharpSettings.LegacyJavascriptBindingEnabled = true;
      InitializeComponent();
    }

    private async void Init(object sender, EventArgs args)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create(Language, Database);
      IDomElement element = DomElementFactory.Create();
      _options = OptionsFactory.Create("hbr", "MJUygv01", "abcd", Srs, Language, addressSettings, element);
      await _api.Init(_options);

      IList<ViewerType> viewerTypes = new List<ViewerType> { ViewerType.Panorama };
      IPanoramaViewerOptions panoramaOptions = PanoramaViewerOptionsFactory.Create(false, false, true, true, true, true);
      IViewerOptions viewerOptions = ViewerOptionsFactory.Create(viewerTypes, Srs, panoramaOptions);
      await _api.Open("van voordenpark 1a, zaltbommel", viewerOptions);
    }
  }
}
