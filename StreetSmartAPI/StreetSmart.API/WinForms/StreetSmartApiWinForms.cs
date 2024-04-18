using CefSharp;
using CefSharp.WinForms;
using StreetSmart.Common.API;
using StreetSmart.WinForms.Properties;
using System.Windows.Forms;

namespace StreetSmart.WinForms
{
    /// <summary>
    /// WinForms implementation for the street smart API
    /// </summary>
    public sealed class StreetSmartApiWinForms : StreetSmartApiBase
    {
        public StreetSmartGUI GUI { get; }
        private readonly ChromiumWebBrowser Browser;

        public StreetSmartApiWinForms(string streetSmartLocation)
            : base(streetSmartLocation)
        {
            Browser = new ChromiumWebBrowser(streetSmartLocation) { Dock = DockStyle.Fill };
            //
            Settings = new Settings(Browser);
            Shortcuts = new ShortcutsWinForms(Browser);
            RegisterThisJsObject();
            ViewerList.CreateViewerList(ApiId);
            ViewerList.RegisterJsObjects(ApiId, Browser);
            Browser.FrameLoadEnd += OnFrameLoadEnd;
            Browser.DownloadHandler = new DownloadHandler();
            GUI = new StreetSmartGUI(Browser);
        }

        public override void ShowDevTools()
        {
            ShowDeveloperTools();
        }

        public override void CloseDevTools()
        {
            CloseDeveloperTools();
        }

        protected override bool IsBrowserInitialized() => Browser.IsBrowserInitialized;

        protected override void BrowserExecuteScriptAsync(string script) => Browser.ExecuteScriptAsync(script);
    }
}
