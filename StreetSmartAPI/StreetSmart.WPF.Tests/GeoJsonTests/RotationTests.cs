using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class RotationTests
  {
    [Fact]
    public void Rotation_Equals_ReturnsTrue_WhenRotationsAreEqual()
    {
      var rotationValues1 = new Dictionary<string, object>
        {
            { "m", new Dictionary<string, object>
                {
                    { "shape", new[] { 3, 3 } },
                    { "data", new[] { 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 } }
                }
            }
        };

      var rotationValues2 = new Dictionary<string, object>
        {
            { "m", new Dictionary<string, object>
                {
                    { "shape", new[] { 3, 3 } },
                    { "data", new[] { 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 } }
                }
            }
        };

      var rotation1 = new Rotation(rotationValues1);
      var rotation2 = new Rotation(rotationValues2);

      Assert.True(rotation1.Equals(rotation2));
    }
  }
}
