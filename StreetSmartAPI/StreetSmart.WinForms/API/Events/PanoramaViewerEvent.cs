using StreetSmart.WinForms.Properties;

namespace StreetSmart.WinForms.API.Events
{
  internal class PanoramaViewerEvent
  {
    private readonly PanoramaViewer _viewer;

    protected string Name => _viewer.Name;

    protected string JsThis => _viewer.JsThis;

    protected string JsApi => Resources.JsApi;

    protected string Type { get; }

    protected string FuncName { get; }

    protected string Events => "Events.panoramaViewer";

    public string Destroy => $@"{Name}.off({JsApi}.{Events}.{Type},{FuncName}{Name});";

    public PanoramaViewerEvent(PanoramaViewer viewer, string type, string funcName)
    {
      _viewer = viewer;
      Type = type;
      FuncName = funcName;
    }

    public override string ToString()
    {
      return $@"{Name}.on({JsApi}.{Events}.{Type},{FuncName}{Name}=function(e)
             {{{JsThis}.{FuncName}('{Name}',e);}});";
    }
  }
}
