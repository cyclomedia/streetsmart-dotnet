using System.Drawing;
using Xunit;
using StreetSmart.Common.Data.SLD;
using StreetSmart.Common.Interfaces.SLD;

namespace StreetSmart.WPF.Tests;

public class SvgParameterCollectionTests
{
  [Fact]
  public void GetFillObject_AllZeroColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(0, 0, 0, 0);
    double? opacity = null;

    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
  }
  [Fact]
  public void GetFillObject_DifferentColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 128, 64, 32); // Different color
    double? opacity = null;

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
  }

  [Fact]
  public void GetStrokeObject_AllZeroColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(0, 0, 0, 0); // All zeros
    double? width = null;
    double? opacity = null;

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
  }
  [Fact]
  public void GetStrokeObject_DifferentColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 128, 64, 32);
    double? width = null;
    double? opacity = null;

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
  }
}
