using StreetSmart.Common.Data.GeoJson;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class CRSTests
  {
    [Fact]
    public void CRS_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new CRS(123);
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
