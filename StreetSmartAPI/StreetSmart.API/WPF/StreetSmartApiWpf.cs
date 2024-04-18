using CefSharp;
using StreetSmart.Common.API;

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
    }
}
