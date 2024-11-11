using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class GeometryTests
  {
    [Fact]
    public void Geometry_ConstructWithDictionary_ShouldSetTypeCorrectly()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };

      var geometry = new Geometry(geometryDict);

      Assert.True(geometryDict["type"].Equals(geometry.Type));
    }

    [Fact]
    public void Geometry_ConstructWithUnknownType_ShouldSetTypeToUnknown()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", "InvalidType" }
            };

      var geometry = new Geometry(geometryDict);

      Assert.Equal(GeometryType.Unknown, geometry.Type);
    }
    [Fact]
    public void Geometry_CheckingIfTwoSameGeometryAreTrue()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };

      var geometry = new Geometry(geometryDict);
      var geometry2 = new Geometry(geometryDict);

      Assert.True(geometry.Equals(geometry2));
    }

    [Fact]
    public void Geometry_CheckingIfTwoSameGeometryAreFalse()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };
      var geometryDict2 = new Dictionary<string, object>
            {
                { "type", GeometryType.LineString }
            };
      var geometry = new Geometry(geometryDict);
      var geometry2 = new Geometry(geometryDict2);

      Assert.False(geometry.Equals(geometry2));
    }

    [Fact]
    public void Geometry_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Geometry(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
