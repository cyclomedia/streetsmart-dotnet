using CefSharp.Wpf;

using StreetSmart.Wpf.Data;

namespace StreetSmart.Wpf
{
  /// <summary>
  /// 
  /// </summary>
  public class StreetSmartGUIModel: NotifyPropertyChanged
  {
    private string _address;
    private IWpfWebBrowser _webBrowser;

    /// <summary>
    /// 
    /// </summary>
    public string Address
    {
      get => _address;
      set
      {
        _address = value;
        RaisePropertyChanged();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public IWpfWebBrowser WebBrowser
    {
      get => _webBrowser;
      set
      {
        _webBrowser = value;
        RaisePropertyChanged();
      }
    }
  }
}
