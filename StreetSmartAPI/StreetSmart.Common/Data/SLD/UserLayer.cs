using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal class UserLayer : NotifyPropertyChanged
  {
    private UserStyle _userStyle;

    [XmlElement("UserStyle", Namespace = "http://www.opengis.net/sld")]
    public UserStyle UserStyle
    {
      get => _userStyle;
      set
      {
        _userStyle = value;
        RaisePropertyChanged();
      }
    }
  }
}
