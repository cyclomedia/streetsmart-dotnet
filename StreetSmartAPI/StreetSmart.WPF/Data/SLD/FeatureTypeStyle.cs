using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace StreetSmart.Wpf.Data.SLD
{
  internal class FeatureTypeStyle : NotifyPropertyChanged
  {
    private ObservableCollection<Rule> _rule;

    [XmlElement("Rule", Namespace = "http://www.opengis.net/se")]
    public ObservableCollection<Rule> Rules
    {
      get => _rule;
      set
      {
        _rule = value;
        RaisePropertyChanged();
      }
    }
  }
}
