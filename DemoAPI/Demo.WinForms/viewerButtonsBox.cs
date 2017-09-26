using StreetSmart.WinForms.Interfaces;

namespace Demo.WinForms
{
  class ViewerButtonsBox
  {
    public object ButtonId { get; }

    public ViewerButtonsBox(ObliqueViewerButtons buttonId)
    {
      ButtonId = buttonId;
    }

    public ViewerButtonsBox(PanoramaViewerButtons buttonId)
    {
      ButtonId = buttonId;
    }

    public override string ToString()
    {
      string type = ButtonId is ObliqueViewerButtons ? "oblique" : "panorama";
      return $"{type}:{ButtonId}";
    }
  }
}
