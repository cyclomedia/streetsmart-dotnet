using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/sld")]
  [XmlRoot(Namespace = "http://www.opengis.net/sld", IsNullable = false)]
  internal class StyledLayerDescriptor : NotifyPropertyChanged
  {
    // ReSharper disable once InconsistentNaming
    const string VersionNumber = "1.1.0";

    public StyledLayerDescriptor()
    {
    }

    public StyledLayerDescriptor(Rule rule)
    {
      Version = VersionNumber;

      UserLayer = new UserLayer
      {
        UserStyle = new UserStyle
        {
          FeatureTypeStyle = new FeatureTypeStyle
          {
            Rules = new ObservableCollection<Rule> {rule}
          }
        }
      };
    }

    public StyledLayerDescriptor(ObservableCollection<Rule> rules)
    {
      Version = VersionNumber;

      UserLayer = new UserLayer
      {
        UserStyle = new UserStyle
        {
          FeatureTypeStyle = new FeatureTypeStyle
          {
            Rules = rules
          }
        }
      };
    }

    private string _version;

    [XmlAttribute("version", Namespace = "http://www.opengis.net/sld")]
    public string Version
    {
      get => _version;
      set
      {
        _version = value;
        RaisePropertyChanged();
      }
    }

    private UserLayer _userLayer;

    [XmlElement("UserLayer", Namespace = "http://www.opengis.net/sld")]
    public UserLayer UserLayer
    {
      get => _userLayer;
      set
      {
        _userLayer = value;
        RaisePropertyChanged();
      }
    }

    // ReSharper disable once InconsistentNaming
    [XmlIgnore]
    public string SLD
    {
      get
      {
        XmlSerializer serializer = new XmlSerializer(typeof(StyledLayerDescriptor));
        string result;

        using (MemoryStream stream = new MemoryStream())
        {
          serializer.Serialize(stream, this);
          stream.Flush();
          stream.Position = 0;

          TextReader textReader = new StreamReader(stream);
          result = textReader.ReadToEnd();
        }

        return result;
      }
    }
  }
}
