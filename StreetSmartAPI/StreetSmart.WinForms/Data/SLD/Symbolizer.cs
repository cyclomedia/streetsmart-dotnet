using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  [XmlInclude(typeof(PolygonSymbolizer))]
  [XmlInclude(typeof(PointSymbolizer))]
  internal abstract class Symbolizer : NotifyPropertyChanged
  {
  }
}
