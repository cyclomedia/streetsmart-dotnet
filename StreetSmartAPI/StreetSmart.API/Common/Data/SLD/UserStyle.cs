using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal class UserStyle : NotifyPropertyChanged
  {
    private FeatureTypeStyle _featureTypeStyle;

    [XmlElement("FeatureTypeStyle", Namespace = "http://www.opengis.net/se")]
    public FeatureTypeStyle FeatureTypeStyle
    {
      get => _featureTypeStyle;
      set
      {
        _featureTypeStyle = value;
        RaisePropertyChanged();
      }
    }
  }
}
