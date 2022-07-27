using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.WPF
{
  /// <summary>
  /// object what contains the wpf api
  /// </summary>
  public class WpfApi : NotifyPropertyChanged
  {
    private IStreetSmartAPI _api;

    /// <summary>
    /// returns the api
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
