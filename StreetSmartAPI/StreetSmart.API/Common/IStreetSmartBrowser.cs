using CefSharp;
using System;

#if WPF
using System.Windows.Threading;
#else
using System.Windows.Forms;
#endif

namespace StreetSmart.Common
{
  public interface IStreetSmartBrowser
  {
    event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;
    IDownloadHandler DownloadHandler { get; set; }
    ILifeSpanHandler LifeSpanHandler { get; set; }
    IRequestHandler RequestHandler { get; set; }
    IContextMenuHandler MenuHandler { get; set; }
    void ShowDevTools(IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0);
    void CloseDevTools();
    void ExecuteScriptAsync(string script);
    IJavascriptObjectRepository JavascriptObjectRepository { get; }
    bool IsDisposed { get; }
    IBrowser GetBrowser();
    bool IsBrowserInitialized { get; }

#if WPF
    string Address { get; set; }
    Dispatcher Dispatcher { get; }
# elif WINFORMS
    string Address { get; }
    DockStyle Dock { get; set; }
    Control Control();
#endif
  }
}
