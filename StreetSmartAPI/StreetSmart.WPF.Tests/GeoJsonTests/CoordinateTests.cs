using StreetSmart.Common.Data;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class CoordinateTests
  {
    [Fact]
    public void Direction_WhenSecondIsNull_ReturnFalse()
    {
      var direction1 = new Direction(1.0, 2.0, 3.0);

      Assert.False(direction1.Equals(null));
    }

    [Fact]
    public void Point_Equals_ShouldReturnTrueForEqualObjects()
    {
      var point1 = new Point(new Dictionary<string, object>
            {
                { "coordinates", new List<object> { 1.0, 2.0 } },
                { "type", GeometryType.Point }
            });

      var point2 = new Point(new Dictionary<string, object>
            {
                { "coordinates", new List<object> { 1.0, 2.0 } },
                { "type", GeometryType.Point }
            });

      Assert.True(point1.Equals(point2));
    }

    [Fact]
    public void Point_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var point1 = new Point(new Dictionary<string, object>
        {
            { "coordinates", new List<object> { 1.0, 2.0 } },
            { "type", GeometryType.Point }
        });

      var point2 = new Point(new Dictionary<string, object>
        {
            { "coordinates", new List<object> { 3.0, 4.0 } },
            { "type", GeometryType.Point }
        });

      Assert.False(point1.Equals(point2));
    }

    [Fact]
    public void Coordinate_InitializationWithDictionary_ShouldSetCorrectValues()
    {
      var coordinateDict = new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            };

      var coordinate = new Coordinate(coordinateDict);

      Assert.True(coordinate.X.Equals(1.0));
      Assert.True(coordinate.Y.Equals(2.0));
      Assert.True(coordinate.Z.Equals(3.0));
    }

    [Fact]
    public void Coordinate_InitializationWithList_ShouldSetCorrectValues()
    {
      var coordinateList = new List<object> { 4.0, 5.0, 6.0 };

      var coordinate = new Coordinate(coordinateList);

      Assert.True(coordinate.X.Equals(4.0));
      Assert.True(coordinate.Y.Equals(5.0));
      Assert.True(coordinate.Z.Equals(6.0));
    }

    [Fact]
    public void Coordinate_Equals_ShouldReturnFalseForDifferentCoordinates()
    {
      var coordinate1 = new Coordinate(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            });

      var coordinate2 = new Coordinate(new Dictionary<string, object>
            {
                { "0", 4.0 },
                { "1", 5.0 },
                { "2", 6.0 }
            });

      Assert.False(coordinate1.Equals(coordinate2));
    }

    [Fact]
    public void Coordinate_Equals_ShouldReturnTrueForSameCoordinates()
    {
      var coordinate = new Coordinate(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            });

      Assert.True(coordinate.Equals(coordinate));
    }

    [Fact]
    public void Point_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Point(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Polygon_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Polygon(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Coordinate_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Coordinate(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
