using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal enum FillType
  {
    [XmlEnum("fill")] Fill,

    [XmlEnum("fill-opacity")] FillOpacity
  }
}
