using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class ResultDirectionTests
  {
    [Fact]
    public void ResultDirectionPanorama_Equals_ReturnsTrueForEqualObjects()
    {
      var orientation1 = new Property(45.0, 5.0);
      var resolution1 = new Resolution(new Dictionary<string, object>());
      var obj1 = new ResultDirectionPanorama(new Dictionary<string, object>
            {
                { "DirectionX", 1.0 },
                { "DirectionY", 2.0 },
                { "DirectionZ", 3.0 },
                { "GroundLevelOffset", 5.0 },
                { "Orientation", orientation1 },
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 30.0 },
                { "StdX", 1.0 },
                { "StdY", 2.0 },
                { "StdZ", 3.0 },
                { "calculationMethod", CalculatedMethod.NotDefined.Description() },
                { "Resolution", resolution1 }
            });

      var obj2 = new ResultDirectionPanorama(new Dictionary<string, object>
            {
                { "DirectionX", 1.0 },
                { "DirectionY", 2.0 },
                { "DirectionZ", 3.0 },
                { "GroundLevelOffset", 5.0 },
                { "Orientation", orientation1 },
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 30.0 },
                { "StdX", 1.0 },
                { "StdY", 2.0 },
                { "StdZ", 3.0 },
                { "calculationMethod", CalculatedMethod.NotDefined.Description() },
                { "Resolution", resolution1 }
            });

      var result = obj1.Equals(obj2);

      Assert.True(result);
    }

    [Fact]
    public void ResultDirectionPanorama_Equals_ReturnsFalseForDifferentObjects()
    {
      var obj1 = new ResultDirectionPanorama(new Dictionary<string, object>
            {
                { "DirectionX", 1.0 },
                { "DirectionY", 2.0 },
                { "DirectionZ", 3.0 }
            });

      var obj2 = new ResultDirectionPanorama(new Dictionary<string, object>
            {
                { "DirectionX", 1.0 },
                { "DirectionY", 2.0 },
                { "DirectionZ", 4.0 }
            });

      var result = obj1.Equals(obj2);

      Assert.False(result);
    }

    [Fact]
    public void ResultDirectionOblique_Equals_ReturnsTrueForEqualObjects()
    {
      var angle1 = new Rotation(new Dictionary<string, object>());
      var obj1 = new ResultDirectionOblique(new Dictionary<string, object>
            {
                { "camX", 1.0 },
                { "camY", 2.0 },
                { "camZ", 3.0 },
                { "angle", angle1 }
            });

      var obj2 = new ResultDirectionOblique(new Dictionary<string, object>
            {
                { "camX", 1.0 },
                { "camY", 2.0 },
                { "camZ", 3.0 },
                { "angle", angle1 }
            });

      var result = obj1.Equals(obj2);

      Assert.True(result);
    }

    [Fact]
    public void ResultDirectionOblique_Equals_ReturnsFalseForDifferentObjects()
    {
      var obj1 = new ResultDirectionOblique(new Dictionary<string, object>
            {
                { "camX", 1.0 },
                { "camY", 2.0 },
                { "camZ", 3.0 }
            });

      var obj2 = new ResultDirectionOblique(new Dictionary<string, object>
            {
                { "camX", 1.0 },
                { "camY", 2.0 },
                { "camZ", 4.0 }
            });

      Assert.False(obj1.Equals(obj2));
    }


    [Fact]
    public void ResultDirection_Equals_ReturnsTrueForEqualObjects()
    {
      var obj1 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" }
            });

      var obj2 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" }
            });

      var result = obj1.Equals(obj2);

      Assert.True(result);
    }

    [Fact]
    public void ResultDirection_Equals_ReturnsFalseForEqualObjectsDifferentImage()
    {
      var obj1 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" },
                { "MatchImage", "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wcAAgABAAV5u6kAAAAASUVORK5CYII="}
            });

      var obj2 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" },
                { "MatchImage", "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAYAAABytg0kAAAAFUlEQVR42mJk+A8EBwADcQH/BlgAAiUDJQQHX0YAAAAASUVORK5CYII="}
            });

      var result = obj1.Equals(obj2);

      Assert.False(result);
    }

    [Fact]
    public void ResultDirection_Equals_ReturnsFalseForEqualObjectsSecondImageNullValue()
    {
      var obj1 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" },
                { "MatchImage", "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wcAAgABAAV5u6kAAAAASUVORK5CYII="}
            });

      var obj2 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" }
            });

      var result = obj1.Equals(obj2);

      Assert.False(result);
    }

    [Fact]
    public void ResultDirection_Equals_ReturnsFalseForDifferentObjects()
    {
      var obj1 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" }
            });

      var obj2 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "456" }
            });

      var result = obj1.Equals(obj2);

      Assert.False(result);
    }

    [Fact]
    public void ResultDirection_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new ResultDirection(new Dictionary<string, object>
            {
                { "Id", "123" }
            });

      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void ResultDirectionPanorama_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new ResultDirectionPanorama(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
