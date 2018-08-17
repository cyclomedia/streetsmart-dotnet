using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal class SvgParameter<T> : NotifyPropertyChanged
  {
    private T _name;

    [XmlAttribute("name", Namespace = "http://www.opengis.net/se")]
    public T Name
    {
      get => _name;
      set
      {
        _name = value;
        RaisePropertyChanged();
      }
    }

    private string _value;

    [XmlText]
    public string Value
    {
      get => _value;
      set
      {
        _value = value;
        RaisePropertyChanged();
      }
    }
  }
}
