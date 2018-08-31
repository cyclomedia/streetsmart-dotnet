using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal class VendorOption : NotifyPropertyChanged
  {
    public VendorOption()
    {
    }

    public VendorOption(VendorOptionType name)
    {
      _name = name;
    }

    private VendorOptionType _name;

    [XmlAttribute("name", Namespace = "http://www.opengis.net/se")]
    public VendorOptionType Name
    {
      get => _name;
      set
      {
        _name = value;
        RaisePropertyChanged();
      }
    }
  }
}
