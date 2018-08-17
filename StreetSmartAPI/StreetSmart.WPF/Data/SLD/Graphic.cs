using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal class Graphic : NotifyPropertyChanged
  {
    public Graphic()
    {
    }

    public Graphic(Mark mark, double size)
    {
      Mark = mark;
      Size = size;
    }

    private Mark _mark;

    [XmlElement("Mark", Namespace = "http://www.opengis.net/se")]
    public Mark Mark
    {
      get => _mark;
      set
      {
        _mark = value;
        RaisePropertyChanged();
      }
    }

    private double _size;

    [XmlElement("Size", Namespace = "http://www.opengis.net/se")]
    public double Size
    {
      get => _size;
      set
      {
        _size = value;
        RaisePropertyChanged();
      }
    }
  }
}
