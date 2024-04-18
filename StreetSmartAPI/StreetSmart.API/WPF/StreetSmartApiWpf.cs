using CefSharp;
using StreetSmart.Common.API;
using StreetSmart.Wpf.Properties;
using System.Threading;

namespace StreetSmart.WPF
{
    internal class StreetSmartApiWpf : StreetSmartApiBase
    {
        public StreetSmartAPI(string streetSmartLocation)
        {
            InitApi(streetSmartLocation);
        }

        public void InitBrowser(IChromiumWebBrowserBase browser)
        {
            Browser = browser;
            Browser.Address = _streetSmartLocation;
            RegisterBrowser();
        }

        /*
    public bool BrowserIsDisposed => Browser?.IsDisposed ?? true;

    public void CreateBrowser(HwndSource parentWindowHwndSource, Size initialSize)
    {
      Browser.CreateBrowser(parentWindowHwndSource, initialSize);
    }
*/

        public void ShowDevTools()
        {
            Browser?.Dispatcher?.BeginInvoke(new ThreadStart(ShowDeveloperTools));
        }

        public void CloseDevTools()
        {
            Browser?.Dispatcher?.BeginInvoke(new ThreadStart(CloseDeveloperTools));
        }

        public void RestartStreetSmart()
        {
            RestartStreetSmart(Resources.StreetSmartLocation);
        }

        public void RestartStreetSmart(string streetSmartLocation)
        {
            _streetSmartLocation = streetSmartLocation;
            Browser.Address = streetSmartLocation;
        }
    }
}
