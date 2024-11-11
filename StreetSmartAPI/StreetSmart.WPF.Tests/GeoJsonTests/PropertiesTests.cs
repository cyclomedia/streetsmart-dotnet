using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class PropertiesTests
  {
    [Fact]
    public void Properties_WhenACountHasDifferentValue_ReturnFalse()
    {
      var element1 = new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" },
                    { "measureDetails", new List<object>() },
                    { "fontsize", 12 },
                    { "dimension", 2 }
                };
      var element2 = new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" },
                    { "measureDetails", new List<object>() },
                    { "fontsize", 12 },
                    { "dimension", 2 },
                    { "derivedData", new Dictionary<string, object>() },
                    { "measureReliability", "RELIABLE" },
                    { "measurementTool", "MAP" },
                    { "pointsWithErrors", new List<int> { 1, 2, 3 } },
                    { "validGeometry", true },
                    { "observationLines", new Dictionary<string, object>() },
                    { "wgsGeometry", new Dictionary<string, object>
                        {
                            { "type", "Point" },
                            { "coordinates", new List<double> { 3.0, 4.0 } }
                        }
                    }
                };
      var properties1 = new Common.Data.GeoJson.Properties(element1);
      var properties2 = new Common.Data.GeoJson.Properties(element2);

      Assert.False(properties1.Equals(properties2));
    }

    [Fact]
    public void Properties_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Common.Data.GeoJson.Properties(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Properties_ShouldInitializeCorrectly()
    {
      var propertiesData = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var properties = new Common.Data.GeoJson.Properties(propertiesData);

      Assert.Equal("1", properties["id"]);
      Assert.Equal("Test Feature", properties["name"]);
      Assert.Equal("Test Group", properties["group"]);
    }

    [Fact]
    public void Properties_EqualsMethod_ShouldReturnTrueForEqualProperties()
    {
      var propertiesData = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var properties1 = new Common.Data.GeoJson.Properties(propertiesData);
      var properties2 = new Common.Data.GeoJson.Properties(propertiesData);

      var areEqual = properties1.Equals(properties2);

      Assert.True(areEqual);
    }

    [Fact]
    public void Properties_EqualsMethod_ShouldReturnFalseForDifferentProperties()
    {
      var propertiesData1 = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var propertiesData2 = new Dictionary<string, object>
        {
            { "id", "2" },
            { "name", "Test Feature 2" },
            { "group", "Test Group 2" }
        };

      var properties1 = new Common.Data.GeoJson.Properties(propertiesData1);
      var properties2 = new Common.Data.GeoJson.Properties(propertiesData2);

      var areEqual = properties1.Equals(properties2);

      Assert.False(areEqual);
    }
  }
}
