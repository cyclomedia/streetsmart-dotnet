using CefSharp;
using StreetSmart.Common.API;

namespace StreetSmart.WinForms.Properties
{
    public sealed class ShortcutsWinForms : ShortcutsBase
    {
        public ShortcutsWinForms(IChromiumWebBrowserBase browser)
            : base(new ApiWinForms(browser, $"{JsApi}.ShortCuts"))
        { }
    }
}
