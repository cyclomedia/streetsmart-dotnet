using System.Drawing;
using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal class Mark : NotifyPropertyChanged
  {
    public Mark()
    {
    }

    public Mark(SymbolizerType type, SvgParameterCollection<FillType> fill, SvgParameterCollection<StrokeType> stroke)
    {
      WellKnownName = type;
      Fill = fill;
      Stroke = stroke;
    }

    public Mark(SymbolizerType type, Color fillColor, double opacity, Color strokeColor, double width)
    {
      WellKnownName = type;
      Fill = SvgParameterCollection<FillType>.GetFillObject(fillColor, opacity);
      Stroke = SvgParameterCollection<StrokeType>.GetStrokeObject(strokeColor, width);
    }

    private SymbolizerType _wellKnownName;

    [XmlElement("WellKnownName", Namespace = "http://www.opengis.net/se")]
    public SymbolizerType WellKnownName
    {
      get => _wellKnownName;
      set
      {
        _wellKnownName = value;
        RaisePropertyChanged();
      }
    }

    private SvgParameterCollection<FillType> _fill;

    [XmlElement("Fill", Namespace = "http://www.opengis.net/se")]
    public SvgParameterCollection<FillType> Fill
    {
      get => _fill;
      set
      {
        _fill = value;
        RaisePropertyChanged();
      }
    }

    private SvgParameterCollection<StrokeType> _stroke;

    [XmlElement("Stroke", Namespace = "http://www.opengis.net/se")]
    public SvgParameterCollection<StrokeType> Stroke
    {
      get => _stroke;
      set
      {
        _stroke = value;
        RaisePropertyChanged();
      }
    }
  }
}
