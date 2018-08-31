using System.Drawing;
using System.Xml.Serialization;

namespace StreetSmart.Common.Data.SLD
{
  internal class PolygonSymbolizer : Symbolizer
  {
    public PolygonSymbolizer()
    {
    }

    public PolygonSymbolizer(SvgParameterCollection<FillType> fill, SvgParameterCollection<StrokeType> stroke)
    {
      Fill = fill;
      Stroke = stroke;
    }

    public PolygonSymbolizer(Color? fillColor, double? opacity, Color? strokeColor, double? width)
    {
      if ((fillColor != null) && (opacity != null))
      {
        Fill = SvgParameterCollection<FillType>.GetFillObject((Color) fillColor, (double) opacity);
      }

      if ((strokeColor != null) && (width != null))
      {
        Stroke = SvgParameterCollection<StrokeType>.GetStrokeObject((Color) strokeColor, (double) width);
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
