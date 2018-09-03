using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal class Rule : NotifyPropertyChanged
  {
    public Rule()
    {
    }

    public Rule(VendorOption vendorOption, Graphic graphic)
    {
      VendorOption = vendorOption;

      Symbolizer = new PointSymbolizer
      {
        Graphic = graphic
      };
    }

    public Rule(VendorOption vendorOption, Symbolizer symbolizer)
    {
      VendorOption = vendorOption;
      Symbolizer = symbolizer;
    }

    private VendorOption _vendorOption;

    [XmlElement("VendorOption", Namespace = "http://www.opengis.net/se")]
    public VendorOption VendorOption
    {
      get => _vendorOption;
      set
      {
        _vendorOption = value;
        RaisePropertyChanged();
      }
    }

    private Symbolizer _symbolizer;

    [XmlElement("PointSymbolizer", typeof(PointSymbolizer), Namespace = "http://www.opengis.net/se")]
    [XmlElement("PolygonSymbolizer", typeof(PolygonSymbolizer), Namespace = "http://www.opengis.net/se")]
    public Symbolizer Symbolizer
    {
      get => _symbolizer;
      set
      {
        _symbolizer = value;
        RaisePropertyChanged();
      }
    }
  }
}
