namespace StreetSmart.Common.Interfaces.API
{
    /// <summary>
    /// Extension of the interface
    /// </summary>
    public partial interface IStreetSmartAPI
    {
        /// <summary>
        /// Restarts streetsmart
        /// </summary>
        void RestartStreetSmart();

        /// <summary>
        /// Restarts streetsmart
        /// </summary>
        /// <param name="streetSmartLocation">The location of Street Smart</param>
        void RestartStreetSmart(string streetSmartLocation);
        /*
            /// <summary>
            /// Returns true if the browser object is disposed
            /// </summary>
            bool BrowserIsDisposed { get; }

            /// <summary>
            /// Create a new webbrowser
            /// </summary>
            /// <param name="parentWindowHwndSource"><reference to the window/param>
            /// <param name="initialSize">initial size</param>
            void CreateBrowser(HwndSource parentWindowHwndSource, Size initialSize);
        */
    }
}
