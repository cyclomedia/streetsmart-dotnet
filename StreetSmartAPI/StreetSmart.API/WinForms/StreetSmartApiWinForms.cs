using CefSharp.WinForms;
using CefSharp;
using StreetSmart.Common.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetSmart.WinForms
{
    /// <summary>
    /// WinForms implementation for the street smart API
    /// </summary>
    public sealed class StreetSmartApiWinForms : StreetSmartApiBase
    {
        public StreetSmartGUI GUI { get; }

        public StreetSmartApiWinForms(string streetSmartLocation)
        {
            InitApi(streetSmartLocation);
            Browser = new ChromiumWebBrowser(streetSmartLocation) { Dock = DockStyle.Fill };
            RegisterBrowser();
            GUI = new StreetSmartGUI(Browser);
        }
    }
}
