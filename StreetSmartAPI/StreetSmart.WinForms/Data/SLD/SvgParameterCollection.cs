using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Xml.Serialization;

namespace StreetSmart.WinForms.Data.SLD
{
  internal class SvgParameterCollection<T> : NotifyPropertyChanged
  {
    private ObservableCollection<SvgParameter<T>> _svgParameter;

    [XmlElement("SvgParameter", Namespace = "http://www.opengis.net/se")]
    public ObservableCollection<SvgParameter<T>> SvgParameter
    {
      get => _svgParameter;
      set
      {
        _svgParameter = value;
        RaisePropertyChanged();
      }
    }

    public static SvgParameterCollection<FillType> GetFillObject(Color color, double opacity)
    {
      return new SvgParameterCollection<FillType>
      {
        SvgParameter = new ObservableCollection<SvgParameter<FillType>>
        {
          new SvgParameter<FillType>
          {
            Name = FillType.Fill,
            Value = $"#{color.ToArgb().ToString("X").Substring(2)}"
          },
          new SvgParameter<FillType>
          {
            Name = FillType.FillOpacity,
            Value = opacity.ToString(CultureInfo.InvariantCulture)
          }
        }
      };
    }

    public static SvgParameterCollection<StrokeType> GetStrokeObject(Color color, double width)
    {
      return new SvgParameterCollection<StrokeType>
      {
        SvgParameter = new ObservableCollection<SvgParameter<StrokeType>>
        {
          new SvgParameter<StrokeType>
          {
            Name = StrokeType.Stroke,
            Value = $"#{color.ToArgb().ToString("X").Substring(2)}"
          },
          new SvgParameter<StrokeType>
          {
            Name = StrokeType.StrokeWidth,
            Value = width.ToString(CultureInfo.InvariantCulture)
          }
        }
      };
    }
  }
}
