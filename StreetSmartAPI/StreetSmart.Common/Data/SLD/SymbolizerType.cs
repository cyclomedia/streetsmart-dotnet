using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal enum SymbolizerType
  {
    [XmlEnum("square")] Square,

    [XmlEnum("circle")] Circle,

    [XmlEnum("cross")] Cross
  }
}
