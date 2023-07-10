using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;

namespace StreetSmart.Winforms.Example
{
  public partial class Demo : Form
  {
    private readonly IStreetSmartAPI _api;

    public Demo()
    {
      InitializeComponent();

      IAPISettings apiSettings = CefSettingsFactory.Create(@"D:\StreetSmartAPI\Cache");

//      _api = string.IsNullOrEmpty(StreetSmartLocation)
//        ? StreetSmartAPIFactory.Create(apiSettings)
//        : StreetSmartAPIFactory.Create(StreetSmartLocation, apiSettings);

      plStreetSmart.Controls.Add(_api.GUI);
    }
  }
}
