using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal enum VendorOptionType
  {
    [XmlEnum("excludeFromCyclorama")] ExcludeFromCyclorama,

    [XmlEnum("excludeFromMap")] ExcludeFromMap
  }
}
