using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal enum FillType
  {
    [XmlEnum("fill")] Fill,

    [XmlEnum("fill-opacity")] FillOpacity
  }
}
