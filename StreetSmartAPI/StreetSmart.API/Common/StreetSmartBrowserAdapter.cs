using CefSharp;
using System;

#if WPF
using CefSharp.Wpf;
using System.Windows.Threading;
#else
using CefSharp.WinForms;
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

    public bool IsBrowserInitialized => _browser.IsBrowserInitialized;

    public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;

    public IDownloadHandler DownloadHandler { get => _browser.DownloadHandler; set => _browser.DownloadHandler = value; }

    public ILifeSpanHandler LifeSpanHandler { get => _browser.LifeSpanHandler; set => _browser.LifeSpanHandler = value; }

    public IRequestHandler RequestHandler { get => _browser.RequestHandler; set => _browser.RequestHandler = value; }

    public IContextMenuHandler MenuHandler { get => _browser.MenuHandler; set => _browser.MenuHandler = value; }

    public void ShowDevTools(IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0)
    {
      _browser.ShowDevTools(windowInfo, inspectElementAtX, inspectElementAtY);
    }

    public void CloseDevTools()
    {
      _browser.CloseDevTools();
    }

#if WPF
    public string Address { get => _browser.Address; set => _browser.Address = value; }

    public Dispatcher Dispatcher => _browser.Dispatcher;
#elif WINFORMS
    public string Address { get => _browser.Address; }

    public DockStyle Dock { get => _browser.Dock; set => _browser.Dock = value; }

    public Control Control() => _browser;
#endif
  }
}
