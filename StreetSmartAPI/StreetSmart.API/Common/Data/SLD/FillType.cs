using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal enum FillType
  {
    [XmlEnum("fill")] Fill,

    [XmlEnum("fill-opacity")] FillOpacity
  }
}
