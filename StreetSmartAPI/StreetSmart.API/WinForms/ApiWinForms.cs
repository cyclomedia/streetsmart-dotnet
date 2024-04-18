using CefSharp;
using CefSharp.WinForms;
using StreetSmart.Common.API;

namespace StreetSmart.WinForms
{
    public sealed class ApiWinForms : APIBase
    {
        public ApiWinForms(IChromiumWebBrowserBase browser, string callFunctionBase)
            : base(browser, callFunctionBase)
        { }

        protected override IBrowser GetBrowser()
        {
            return ((ChromiumWebBrowser)Browser)?.GetBrowser();
        }

        public override void RegisterThisJsObject()
        {
            var chromium = (ChromiumWebBrowser)Browser;
            chromium.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;

#if NETCOREAPP
            chromium.JavascriptObjectRepository.Register(JsThis, this);
#else
            chromium.JavascriptObjectRepository.Register(JsThis, this, true);
#endif
        }
    }
}
