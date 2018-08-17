using StreetSmart.Wpf.Data;
using StreetSmart.Wpf.Interfaces.API;

namespace StreetSmart.WPF.Example
{
  /// <summary>
  /// 
  /// </summary>
  public class MainWindowModel: NotifyPropertyChanged
  {
    private string _streetSmartLocation;
    private IStreetSmartAPI _api;

    /// <summary>
    /// 
    /// </summary>
    public string StreetSmartLocation
    {
      get => "https://streetsmart.cyclomedia.com/api/v18.7/api-dotnet.html"; // _streetSmartLocation;
      set
      {
        _streetSmartLocation = value;
        RaisePropertyChanged();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public IStreetSmartAPI Api
    {
      get => _api;
      set
      {
        _api = value;
        RaisePropertyChanged();
      }
    }
  }
}
