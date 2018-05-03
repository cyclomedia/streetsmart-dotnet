using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal enum VendorOptionType
  {
    [XmlEnum("excludeFromCyclorama")] ExcludeFromCyclorama,

    [XmlEnum("excludeFromMap")] ExcludeFromMap
  }
}
