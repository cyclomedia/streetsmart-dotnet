using System.Collections.Generic;
using System.Linq;

namespace StreetSmart.WinForms.API.Events
{
  internal class PanoramaViewerEventList : List<PanoramaViewerEvent>
  {
    public string Destroy => this.Aggregate(string.Empty, (current, panEvent) => $"{current}{panEvent.Destroy}");

    public override string ToString()
    {
      return this.Aggregate(string.Empty, (current, panEvent) => $"{current}{panEvent}");
    }
  }
}
