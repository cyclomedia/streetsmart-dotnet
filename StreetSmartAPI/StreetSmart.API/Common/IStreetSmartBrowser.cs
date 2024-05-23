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
    void ExecuteScriptAsync(string script);
    IJavascriptObjectRepository JavascriptObjectRepository { get; }
    bool IsDisposed { get; }
    IBrowser GetBrowser();
    string Address
    {
      get;
#if WPF
      set;
#endif
    }
    bool IsBrowserInitialized { get; }
#if WPF
    Dispatcher Dispatcher { get; }
#endif
    event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;
    IDownloadHandler DownloadHandler { get; set; }
    void ShowDevTools(IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0);
    void CloseDevTools();
#if WINFORMS
        DockStyle Dock { get; set; }

        Control Control();
#endif

  }
}
