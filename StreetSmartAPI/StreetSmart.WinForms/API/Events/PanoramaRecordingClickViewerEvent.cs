namespace StreetSmart.WinForms.API.Events
{
  internal class PanoramaRecordingClickViewerEvent : PanoramaViewerEvent
  {
    public PanoramaRecordingClickViewerEvent(PanoramaViewer viewer, string type, string funcName)
      : base(viewer, type, funcName)
    {
    }

    public override string ToString()
    {
      return $@"{Name}.on({JsApi}.{Events}.{Type},{FuncName}{Name}=function(e)
             {{delete e.detail.recording.thumbs;{JsThis}.{FuncName}('{Name}',e);}});";
    }
  }
}
