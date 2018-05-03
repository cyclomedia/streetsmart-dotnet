using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal class PointSymbolizer : Symbolizer
  {
    private Graphic _graphic;

    [XmlElement("Graphic", Namespace = "http://www.opengis.net/se")]
    public Graphic Graphic
    {
      get => _graphic;
      set
      {
        _graphic = value;
        RaisePropertyChanged();
      }
    }
  }
}
