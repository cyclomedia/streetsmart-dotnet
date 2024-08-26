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
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result); 
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_DifferentColorFullTransparency_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(0, 128, 64, 32);
    double? opacity = null;
    string expectedColorValue = "#804020";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }
  [Fact]
  public void GetFillObject_DifferentColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 128, 64, 32);
    double? opacity = null;
    string expectedColorValue = "#804020";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_AllZeroColorExceptTransparency_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 0, 0);
    double? opacity = null;
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_AllZeroColorExceptTransparencyWhichIsOn10_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(10, 0, 0, 0);
    double? opacity = null;
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_DifferentColorHighTransparency_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(10, 128, 64, 32);
    double? opacity = null;
    string expectedColorValue = "#804020";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  

  [Fact]
  public void GetStrokeObject_AllZeroColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(0, 0, 0, 0); 
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }
  [Fact]
  public void GetStrokeObject_DifferentColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(0, 128, 64, 32);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#804020";
    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_AllZeroColorExceptTransparencyIs10_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(10, 0, 0, 0);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }
  [Fact]
  public void GetStrokeObject_DifferentColorExceptTransparencyIs10_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(10, 128, 64, 32);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#804020";
    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_AllZeroColorExceptTransparencyIs255_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 0, 0);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#000000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }
  [Fact]
  public void GetStrokeObject_DifferentColorExceptTransparencyIs255_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 128, 64, 32);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#804020";
    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_OnlyRedColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 255, 0, 0);
    double? opacity = null;
    string expectedColorValue = "#FF0000";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_OnlyGreenColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 255, 0);
    double? opacity = null;
    string expectedColorValue = "#00FF00";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_OnlyBlueColor_NullOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 0, 255);
    double? opacity = null;
    string expectedColorValue = "#0000FF";

    // Act
    var result = SvgParameterCollection<FillType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(FillType.Fill, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_OnlyRedColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 255, 0, 0);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#FF0000";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_OnlyGreenColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 255, 0);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#00FF00";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_OnlyBlueColor_NullWidthAndOpacity_ReturnsExpectedResult()
  {
    // Arrange
    Color color = Color.FromArgb(255, 0, 0, 255);
    double? width = null;
    double? opacity = null;
    string expectedColorValue = "#0000FF";

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equal(StrokeType.Stroke, result.SvgParameter[0].Name);
    Assert.Equal(expectedColorValue, result.SvgParameter[0].Value);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }


  public static (int Red, int Green, int Blue) HexToRgb(string hex)
  {
    hex = hex.TrimStart('#');

    int argb = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);

    int red = (argb >> 16) & 0xFF;
    int green = (argb >> 8) & 0xFF;
    int blue = argb & 0xFF;

    return (red, green, blue);
  }
}
