using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal enum VendorOptionType
  {
    [XmlEnum("excludeFromCyclorama")] ExcludeFromCyclorama,

    [XmlEnum("excludeFromMap")] ExcludeFromMap
  }
}
