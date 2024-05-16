#if WPF
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Windows.Threading;
#else
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;
#endif

namespace StreetSmart.Common
{
    internal class StreetSmartBrowserAdapter : IStreetSmartBrowser
    {
        private readonly ChromiumWebBrowser _browser;

        public StreetSmartBrowserAdapter(ChromiumWebBrowser browser)
        {
            _browser = browser;
            _browser.FrameLoadEnd += (sender, args) => { FrameLoadEnd(sender, args); };
        }

        public void ExecuteScriptAsync(string script) => _browser.ExecuteScriptAsync(script);

        public IBrowser GetBrowser() => _browser.GetBrowser();

        public IJavascriptObjectRepository JavascriptObjectRepository => _browser.JavascriptObjectRepository;

        public bool IsDisposed => _browser.IsDisposed;

        public string Address
        { 
            get => _browser.Address;
#if WPF
            set => _browser.Address = value;
#endif
        }

        public bool IsBrowserInitialized => _browser.IsBrowserInitialized;

#if WPF
        public Dispatcher Dispatcher => _browser.Dispatcher;
#endif

        public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;

        public IDownloadHandler DownloadHandler { get => _browser.DownloadHandler; set => _browser.DownloadHandler = value; }

        public void ShowDevTools(IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0) 
        { 
            _browser.ShowDevTools(windowInfo, inspectElementAtX, inspectElementAtY);
        }

        public void CloseDevTools()
        {
            _browser.CloseDevTools();
        }

#if WINFORMS
        public DockStyle Dock { get => _browser.Dock; set => _browser.Dock = value; }

        public Control Control() => _browser;
#endif
    }
}
