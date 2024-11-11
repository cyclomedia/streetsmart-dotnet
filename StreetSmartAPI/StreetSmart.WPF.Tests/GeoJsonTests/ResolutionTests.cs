using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class ResolutionTests
  {
    [Fact]
    public void Resolution_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Resolution(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
