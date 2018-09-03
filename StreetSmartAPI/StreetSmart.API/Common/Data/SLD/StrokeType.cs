using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal enum StrokeType
  {
    [XmlEnum("stroke")] Stroke,

    [XmlEnum("stroke-width")] StrokeWidth
  }
}
