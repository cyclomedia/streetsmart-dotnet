using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal enum StrokeType
  {
    [XmlEnum("stroke")] Stroke,

    [XmlEnum("stroke-width")] StrokeWidth
  }
}
