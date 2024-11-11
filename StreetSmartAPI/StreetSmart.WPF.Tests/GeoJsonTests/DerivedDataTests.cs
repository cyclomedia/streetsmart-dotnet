using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json;
using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class DerivedDataTests
  {
    [Fact]
    public void DerivedDataPoint_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "unit", "m" },
        { "precision", 2 }
      };
      var derivedDataPoint = new DerivedDataPoint(data);

      // act
      var result = derivedDataPoint.ToString();

      // assert
      var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

      Assert.Equivalent(data, obj, true);
    }

    [Fact]
    public void DerivedDataPoint_Full_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "positionXY", new Dictionary<string, object> { { "x", 1.1 }, { "y", 2.3 }, {"stdev", 3.4 } } },
        { "positionZ", new Dictionary<string, object> { { "stdev", 4.234 }, {"value", 5.3456 } } },
        { "position", new Dictionary<string, object>  { { "value", new List<object?> { 1.6, 1.2, 33.45987 } } } },
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 1.1 }, { "1", 2.3 }, {"2", 3.4 } } } },
        { "unit", "m" },
        { "precision", 2 }
      };
      var expectedData = new Dictionary<string, object>
      {
        { "positionZ", new Dictionary<string, object> { { "stdev", 4.234 }, {"value", 5.3456 } } },
        { "position", new Dictionary<string, object>  { { "value", new List<object?> { 1.6, 1.2, 33.45987 } }, { "stdev", new List<object?> { 1.1, 2.3, 3.4 } } } } ,
        { "unit", "m" },
        { "precision", 2 }
      };
      var expected = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(expectedData));

      // act
      var ddp = new DerivedDataPoint(data);
      var result = ddp.ToString();

      // assert
      JsonConvert.DeserializeObject(result).Should().BeEquivalentTo(expected);
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

    [Fact]
    public void DerivedDataPolygon_Area_ToString_Equals()
    {
      // arrange
      var data = new Dictionary<string, object>
      {
        { "triangles", new List<object> { new List<object> {1, 2, 3 } } },
        { "area", new { stdev= 1.234, value = 3456 } },
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

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenOtherIsNull()
    {
      var derivedData = new DerivedDataLineString(new Dictionary<string, object>());
      Assert.False(derivedData.Equals(null));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenCoordinateStdevIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 } , { "1", 0.03 } } } }

      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 }, { "1", 0.03 }, { "2", 0.03 } } } }

      });

      Assert.False(derivedData1.Equals(derivedData2));
    }


    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenCoordinateCountSegmentsSlopePercentageIsNotEqual()
    {
      var slopeValues = new List<object> { 5.5, 10.2, 15.3 };
      var slopeStdevs = new List<object> { 0.5, 1.0, 1.5 };

      var slopeValues2 = new List<object> { 5.6, 10.3, 15.3 };
      var slopeStdevs2 = new List<object> { 0.5, 1.5, 1.5 };

      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object>
        {
            { "value", slopeValues },
            { "stdev", slopeStdevs }
        }

      } });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object>
        {
            { "value", slopeValues2 },
            { "stdev", slopeStdevs2 }
        }

      } });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenCoordinateCountStdevIsNotEqual()
    {
      var position1 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);
      var position2 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);

      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", position1 } , { "1", position2 } } } }

      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object?>
      {
        { "coordinateStdevs", null }

      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentLengthsIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0, 20.0 } }, { "stdev", new List<object> { 0.1, 0.2 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0, 20.0 } }, { "stdev", new List<object> { 0.1, 0.3 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsDeltaXYIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.2 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.3 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsDeltaZIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.2 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.3 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void ResultDirectionOblique_OtherObjectNull_ReturnsFalse()
    {
      var data1 = new ResultDirectionOblique(new Dictionary<string, object>());

      Assert.False(data1.Equals(null));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenCoordinateStdevIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 }, { "1", 0.03 }, { "2", 0.02 } } } }

      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 }, { "1", 0.03 }, { "2", 0.03 } } } }

      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentLengthsIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0, 20.0 } }, { "stdev", new List<object> { 0.1, 0.2 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0 } }, { "stdev", new List<object> { 0.1, 0.3 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsDeltaXYIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.3 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsDeltaZIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.1 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.3 } }, { "stdev", new List<object> { 0.01, 0.02 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }
    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsSlopePercentageIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0 } }, { "stdev", new List<object> { 0.5, 1.0 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0, 11.0 } }, { "stdev", new List<object> { 0.5, 1.0 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsSlopeAngleIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
       { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0, 30.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0, 31.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenUnitIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
       { "unit", "m" }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "unit", "ft" }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenPrecisionIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
       { "precision", 2 }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "precision", 3 }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenTotalLengthIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
       { "totalLength", new Dictionary<string, object> { { "value", 100.0 }, { "stdev", 1.0 } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "totalLength", new Dictionary<string, object> { { "value", 104.0 }, { "stdev", 1.0 } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenDeltaXYIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "deltaXY", new Dictionary<string, object> { { "value", 0.5 }, { "stdev", 0.05 } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "deltaXY", new Dictionary<string, object> { { "value", 0.6 }, { "stdev", 0.05 } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenDeltaZIsNotEqual()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "deltaZ", new Dictionary<string, object> { { "value", 0.5 }, { "stdev", 0.05 } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "deltaZ", new Dictionary<string, object> { { "value", 0.6 }, { "stdev", 0.05 } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsSlopePercentageIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0 } }, { "stdev", new List<object> { 1.0 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0, 11.0 } }, { "stdev", new List<object> { 0.5, 1.0 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalse_WhenSegmentsSlopeAngleIsNotEqualCount()
    {
      var derivedData1 = new DerivedDataLineString(new Dictionary<string, object>
      {
       { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0, 30.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } }
      });
      var derivedData2 = new DerivedDataLineString(new Dictionary<string, object>
      {
        { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } }
      });

      Assert.False(derivedData1.Equals(derivedData2));
    }

    [Fact]
    public void DerivedDataLineString_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedDataLineString(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataLineString(new Dictionary<string, object>
      {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataLineString_WhenObjectsAreNotEquals_ReturnsFalse()
    {
      var data1 = new DerivedDataLineString(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataLineString(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsTrue_WhenAllPropertiesAreEqual()
    {
      var data1 = new DerivedDataLineString(new Dictionary<string, object>
    {
        { "unit", "m" },
        { "precision", 2 },
        { "totalLength", new Dictionary<string, object> { { "value", 100.0 }, { "stdev", 1.0 } } },
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0, 20.0 } }, { "stdev", new List<object> { 0.1, 0.2 } } } },
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.2 } }, { "stdev", new List<object> { 0.01, 0.02 } } } },
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.3, 0.4 } }, { "stdev", new List<object> { 0.03, 0.04 } } } },
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0, 10.0 } }, { "stdev", new List<object> { 0.5, 1.0 } } } },
        { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0, 30.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } },
        { "deltaXY", new Dictionary<string, object> { { "value", 0.5 }, { "stdev", 0.05 } } },
        { "deltaZ", new Dictionary<string, object> { { "value", 0.1 }, { "stdev", 0.01 } } },
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 }, { "1", 0.02 }, { "2", 0.03 } } } }
    });

      var data2 = new DerivedDataLineString(new Dictionary<string, object>
    {
        { "unit", "m" },
        { "precision", 2 },
        { "totalLength", new Dictionary<string, object> { { "value", 100.0 }, { "stdev", 1.0 } } },
        { "segmentLengths", new Dictionary<string, object> { { "value", new List<object> { 10.0, 20.0 } }, { "stdev", new List<object> { 0.1, 0.2 } } } },
        { "segmentsDeltaXY", new Dictionary<string, object> { { "value", new List<object> { 0.1, 0.2 } }, { "stdev", new List<object> { 0.01, 0.02 } } } },
        { "segmentsDeltaZ", new Dictionary<string, object> { { "value", new List<object> { 0.3, 0.4 } }, { "stdev", new List<object> { 0.03, 0.04 } } } },
        { "segmentsSlopePercentage", new Dictionary<string, object> { { "value", new List<object> { 5.0, 10.0 } }, { "stdev", new List<object> { 0.5, 1.0 } } } },
        { "segmentsSlopeAngle", new Dictionary<string, object> { { "value", new List<object> { 15.0, 30.0 } }, { "stdev", new List<object> { 1.5, 3.0 } } } },
        { "deltaXY", new Dictionary<string, object> { { "value", 0.5 }, { "stdev", 0.05 } } },
        { "deltaZ", new Dictionary<string, object> { { "value", 0.1 }, { "stdev", 0.01 } } },
        { "coordinateStdevs", new List<object> { new Dictionary<string, object> { { "0", 0.01 }, { "1", 0.02 }, { "2", 0.03 } } } }
    });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPoint_WhenSecondObjectNull_ReturnsFalse()
    {
      var data1 = new DerivedDataPoint(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(null));
    }

    [Fact]
    public void DerivedDataPoint_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedDataPoint(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPoint(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPoint_WhenObjectsAreNotEquals_ReturnsFalse()
    {
      var data1 = new DerivedDataPoint(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPoint(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }
    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreNotEquals_ReturnsFalse()
    {
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenSecondObjectHasDifferentTriangleCount_ReturnsFalse()
    {
      var triangle1 = new { Vertex1 = "A", Vertex2 = "B", Vertex3 = "C" };
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "triangles", new List<object>
              {
                  triangle1
              }
            }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object?>
        {
            { "unit", "m" },
            { "triangles", null }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenSecondObjectHasNoTriangles_ReturnsFalse()
    {
      var triangle1 = new { Vertex1 = "A", Vertex2 = "B", Vertex3 = "C" };
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "triangles", new List<object>
              {
                  triangle1
              }
            }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenSecondObjectNull_ReturnsFalse()
    {
      var triangle1 = new { Vertex1 = "A", Vertex2 = "B", Vertex3 = "C" };
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "triangles", new List<object>
              {
                  triangle1
              }
            }
        });
      Assert.False(data1.Equals(null));
    }
    [Fact]
    public void DerivedDataPolygon_WhenSecondObjectHasDifferentTriangleValue_ReturnsFalse()
    {
      var triangle1 = new { Vertex1 = "A", Vertex2 = "B", Vertex3 = "C" };
      var triangle2 = new { Vertex1 = "D", Vertex2 = "E", Vertex3 = "F" };

      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "triangles", new List<object>
              {
                  triangle1
              }
            }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "triangles", new List<object>
                {
                    triangle2
                }
            }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreNotEqualsBasedOnArea_ReturnsFalse()
    {
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 },
            { "area", new Dictionary<string, object>
              {
                { "value", 2.2 },
                { "stdev", 3.3 }
              }
            }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 },
            { "area", new Dictionary<string, object>
              {
                { "value", 2.3 },
                { "stdev", 3.4 }
              }
            }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreNotEqualsBasedOnAreaSecondDontHaveIt_ReturnsFalse()
    {
      var data1 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 },
            { "area", new Dictionary<string, object>
              {
                { "value", 2.2 },
                { "stdev", 3.3 }
              }
            }
        });

      var data2 = new DerivedDataPolygon(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPoint_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DerivedDataPoint(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DerivedDataLineString_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DerivedDataLineString(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DerivedDataPolygon_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DerivedDataPolygon(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
