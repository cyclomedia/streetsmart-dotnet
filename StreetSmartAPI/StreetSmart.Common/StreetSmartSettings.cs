namespace StreetSmart.Common
{
    public sealed class StreetSmartSettings
    {
        public string BrowserSubProcess { get; set; } = "CefSharp.BrowserSubprocess.exe";
        public string JsApi { get; set; } = "StreetSmartApi";
        public string LocalesPath { get; set; } = "locales";
        public string StreetSmartLocation { get; set; } = "https://streetsmart.cyclomedia.com/api/v24.1/api-dotnet.html";
    }
}
