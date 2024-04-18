using CefSharp;
using CefSharp.Wpf;
using StreetSmart.Common.API;

namespace StreetSmart.WPF
{
    public sealed class ApiWpf : APIBase
    {
        public ApiWpf(IChromiumWebBrowserBase browser, string callFunctionBase)
            : base(browser, callFunctionBase)
        {

        }

        protected override IBrowser GetBrowser()
        {
            return ((ChromiumWebBrowser)Browser)?.GetBrowser();
        }

        public override void RegisterThisJsObject()
        {
            var chromium = (ChromiumWebBrowser) Browser;
            chromium.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            chromium.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;

                if (e.ObjectName == "Legacy")
                {
#if NETCOREAPP
                    repo.Register(JsThis, this);
#else
                    repo.Register(JsThis, this, false);
#endif
                }
            };
        }
    }
}
