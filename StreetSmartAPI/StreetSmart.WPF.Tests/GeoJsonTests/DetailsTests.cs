using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class DetailsTests
  {
    [Fact]
    public void DetailsDepth_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DetailsDepth(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DetailsForwardIntersection_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DetailsForwardIntersection(new Dictionary<string, object>(), MeasurementTools.Map);
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DetailsDepth_ConstructWithDictionary_ShouldSetProperties()
    {
      var detailsDict = new Dictionary<string, object>
            {
                { "position", new Dictionary<string, object> { { "x", 1.0 }, { "y", 2.0 }, { "z", 3.0 } } },
                { "depthInMeters", 10.0 },
                { "depth", 5.0 },
                { "recordingInfo", new Dictionary<string, object>() }
            };

      var detailsDepth = new DetailsDepth(detailsDict);

      Assert.Equal(1.0, detailsDepth.Position.XYZ.X);
      Assert.Equal(2.0, detailsDepth.Position.XYZ.Y);
      Assert.Equal(3.0, detailsDepth.Position.XYZ.Z);
      Assert.Equal(10.0, detailsDepth.DepthInMeters);
      Assert.Equal(5.0, detailsDepth.Depth);
      Assert.NotNull(detailsDepth.RecordingInfo);
    }

    [Fact]
    public void DetailsDepth_Equals_ShouldReturnTrueForEqualObjects()
    {
      var details1 = new DetailsDepth(new Dictionary<string, object>
            {
                { "position", new Dictionary<string, object> { { "x", 1.0 }, { "y", 2.0 }, { "z", 3.0 } } },
                { "depthInMeters", 10.0 },
                { "depth", 5.0 },
                { "recordingInfo", new Dictionary<string, object>() }
            });

      var details2 = new DetailsDepth(new Dictionary<string, object>
            {
                { "position", new Dictionary<string, object> { { "x", 1.0 }, { "y", 2.0 }, { "z", 3.0 } } },
                { "depthInMeters", 10.0 },
                { "depth", 5.0 },
                { "recordingInfo", new Dictionary<string, object>() }
            });

      Assert.True(details1.Equals(details2));
    }

    [Fact]
    public void DetailsDepth_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var details1 = new DetailsDepth(new Dictionary<string, object>
            {
                { "position", new Dictionary<string, object> { { "x", 1.0 }, { "y", 2.0 }, { "z", 3.0 } } },
                { "depthInMeters", 10.0 },
                { "depth", 5.0 },
                { "recordingInfo", new Dictionary<string, object>() }
            });

      var details2 = new DetailsDepth(new Dictionary<string, object>
            {
                { "position", new Dictionary<string, object> { { "x", 4.0 }, { "y", 5.0 }, { "z", 6.0 } } },
                { "depthInMeters", 15.0 },
                { "depth", 8.0 },
                { "recordingInfo", new Dictionary<string, object>() }
            });

      Assert.False(details1.Equals(details2));
    }

    [Fact]
    public void DetailsForwardIntersection_Equality_SameObject()
    {
      var details = new Dictionary<string, object>
            {
                { "PositionX", 1.0 },
                { "PositionY", 2.0 },
                { "PositionZ", 3.0 },
            };

      var detailsObject = new DetailsForwardIntersection(details, MeasurementTools.Oblique);

      Assert.True(detailsObject.Equals(detailsObject));
    }

    [Fact]
    public void DetailsForwardIntersection_Equality_NullValueOfSecondObject()
    {
      var details = new Dictionary<string, object>
            {
                { "PositionX", 1.0 },
                { "PositionY", 2.0 },
                { "PositionZ", 3.0 },
            };

      var detailsObject = new DetailsForwardIntersection(details, MeasurementTools.Oblique);

      Assert.False(detailsObject.Equals(null));
    }

    [Fact]
    public void DetailsSmartClick_EqualsMethod_SameInstance()
    {
      var details = new Dictionary<string, object>
            {
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 5.0 },
                { "Confidence", 80 },
                { "Depth", 15.0 }
            };

      var smartClick1 = new DetailsSmartClick(details);

      bool result = smartClick1.Equals(smartClick1);

      Assert.True(result);
    }

    [Fact]
    public void DetailsSmartClick_EqualsMethod_EqualObjects()
    {
      var details1 = new Dictionary<string, object>
            {
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 5.0 },
                { "Confidence", 80 },
                { "Depth", 15.0 }
            };

      var details2 = new Dictionary<string, object>
            {
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 5.0 },
                { "Confidence", 80 },
                { "Depth", 15.0 }
            };

      var smartClick1 = new DetailsSmartClick(details1);
      var smartClick2 = new DetailsSmartClick(details2);

      bool result = smartClick1.Equals(smartClick2);

      Assert.True(result);
    }

    [Fact]
    public void DetailsSmartClick_EqualsMethod_NullValueOfSecondObject()
    {
      var details = new Dictionary<string, object>
            {
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 5.0 },
                { "Confidence", 80 },
                { "Depth", 15.0 }
            };

      var smartClick1 = new DetailsSmartClick(details);

      bool result = smartClick1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DetailsSmartClick_EqualsMethod_DifferentObjects()
    {
      var details1 = new Dictionary<string, object>
            {
                { "PositionX", 10.0 },
                { "PositionY", 20.0 },
                { "PositionZ", 5.0 },
                { "Confidence", 80 },
                { "Depth", 15.0 }
            };

      var details2 = new Dictionary<string, object>
            {
                { "PositionX", 5.0 },
                { "PositionY", 10.0 },
                { "PositionZ", 2.5 },
                { "Confidence", 90 },
                { "Depth", 12.0 }
            };

      var smartClick1 = new DetailsSmartClick(details1);
      var smartClick2 = new DetailsSmartClick(details2);

      bool result = smartClick1.Equals(smartClick2);

      Assert.False(result);
    }
  }
}
