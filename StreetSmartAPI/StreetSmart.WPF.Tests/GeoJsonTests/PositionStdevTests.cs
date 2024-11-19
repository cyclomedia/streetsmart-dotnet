using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class PositionStdevTests
  {
    [Fact]
    public void PositionStdev_ConstructWithCoordinatesAndStdev_ShouldSetPropertiesCorrectly()
    {
      double x = 1.0, y = 2.0, z = 3.0;
      double stdX = 0.1, stdY = 0.2, stdZ = 0.3;

      var positionStdev = new PositionStdev(x, y, z, stdX, stdY, stdZ);

      Assert.Equal(x, positionStdev.X);
      Assert.Equal(y, positionStdev.Y);
      Assert.Equal(z, positionStdev.Z);
      Assert.Equal(stdX, positionStdev.StdDev.X);
      Assert.Equal(stdY, positionStdev.StdDev.Y);
      Assert.Equal(stdZ, positionStdev.StdDev.Z);
    }

    [Fact]
    public void PositionStdev_Equals_ShouldReturnTrueForEqualObjects()
    {
      var position1 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);
      var position2 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);

      var isEqual = position1.Equals(position2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionStdev_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var position1 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);
      var position2 = new PositionStdev(1.0, 2.0, 3.0, 0.4, 0.5, 0.6);

      var isEqual = position1.Equals(position2);

      Assert.False(isEqual);
    }

    [Fact]
    public void PositionStdev_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionStdev(new Dictionary<string, object>(), new List<object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
