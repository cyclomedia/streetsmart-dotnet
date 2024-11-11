using StreetSmart.Common.Data.GeoJson;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class PropertyTests
  {
    [Fact]
    public void Property_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Property(1, 1);
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
