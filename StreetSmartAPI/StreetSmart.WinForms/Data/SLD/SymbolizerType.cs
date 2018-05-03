using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal enum SymbolizerType
  {
    [XmlEnum("square")] Square,

    [XmlEnum("circle")] Circle,

    [XmlEnum("cross")] Cross
  }
}
