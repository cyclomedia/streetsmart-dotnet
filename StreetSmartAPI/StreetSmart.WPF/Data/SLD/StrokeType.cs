using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal enum StrokeType
  {
    [XmlEnum("stroke")] Stroke,

    [XmlEnum("stroke-width")] StrokeWidth
  }
}
