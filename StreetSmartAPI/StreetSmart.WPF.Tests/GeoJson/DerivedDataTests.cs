using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json;
using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJson
{
  public class DerivedDataTests
  {
    [Fact]
    public void DerivedData_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "unit",  "m" },
        { "precision", 2 }
      };
      var derivedData = new DerivedData(data);

      // act
      var result = derivedData.ToString();

      // assert
      var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

      Assert.Equivalent(data, obj, true);
    }

    [Fact]
    public void DerivedDataLineString_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 1.1 }, { "1", 2.3 }, {"2", 3.4 } } } },
        { "unit", "m" },
        { "precision", 2 },
        { "totalLength", new { stdev= 1.234, value = 3456 } }
      };
      var expected = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data));

      // act
      var ddls = new DerivedDataLineString(data);
      var result = ddls.ToString();

      // assert
      JsonConvert.DeserializeObject(result).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void DerivedDataPolygon_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "triangles", new List<object> { new List<object> {1, 2, 3 } } },
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 1.1 }, { "1", 2.3 }, {"2", 3.4 } } } },
        { "totalLength", new { stdev= 1.234, value = 3456 } },
        { "unit", "m" },
        { "precision", 2 }
      };
      var expected = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data));

      // act
      var ddp = new DerivedDataPolygon(data);
      var result = ddp.ToString();

      // assert
      JsonConvert.DeserializeObject(result).Should().BeEquivalentTo(expected);
    }
  }
}
