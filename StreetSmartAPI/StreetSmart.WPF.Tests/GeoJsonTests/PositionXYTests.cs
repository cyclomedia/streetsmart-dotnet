using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class PositionXYTests
  {
    [Fact]
    public void PositionXY_ConstructWithValueAndStdev_ShouldSetPropertiesCorrectly()
    {
      var value = new List<object> { 1.0, 2.0 };
      double stdev = 0.1;

      var positionXY = new PositionXY(value, stdev);

      Assert.Equal(value[0], positionXY.X);
      Assert.Equal(value[1], positionXY.Y);
      Assert.Equal(stdev, positionXY.Stdev);
    }

    [Fact]
    public void PositionXY_Equals_ShouldReturnTrueForEqualObjects()
    {
      var value1 = new List<object> { 1.0, 2.0 };
      var value2 = new List<object> { 1.0, 2.0 };

      var positionXY1 = new PositionXY(value1, 0.1);
      var positionXY2 = new PositionXY(value2, 0.1);
      var isEqual = positionXY1.Equals(positionXY2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionXY_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var value1 = new List<object> { 1.0, 2.0 };
      var value2 = new List<object> { 2.0, 3.0 };

      var positionXY1 = new PositionXY(value1, 0.1);
      var positionXY2 = new PositionXY(value2, 0.1);
      var isEqual = positionXY1.Equals(positionXY2);

      Assert.False(isEqual);
    }

    [Fact]
    public void PositionXYZ_ConstructWithCoordinates_ShouldSetPropertiesCorrectly()
    {
      var positionDict = new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            };

      var positionXYZ = new PositionXYZ(positionDict);

      Assert.True(positionXYZ.XYZ.X.Equals((double)positionDict["x"]));
      Assert.True(positionXYZ.XYZ.Y.Equals((double)positionDict["y"]));
      Assert.True(positionXYZ.XYZ.Z.Equals((double)positionDict["z"]));
    }

    [Fact]
    public void PositionXYZ_Equals_ShouldReturnTrueForEqualObjects()
    {
      var position1 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var position2 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var isEqual = position1.Equals(position2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionXYZ_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var position1 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var position2 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 4.0 },
                { "y", 5.0 },
                { "z", 6.0 }
            });

      var isEqual = position1.Equals(position2);

      Assert.False(isEqual);
    }

    [Fact]
    public void PositionXY_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionXY(new List<object>(), 1);
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void PositionXYZ_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionXYZ(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
