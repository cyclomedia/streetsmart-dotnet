using System.Drawing;
using Xunit;
using StreetSmart.Common.Data.SLD;
using StreetSmart.Common.Interfaces.SLD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetSmart.WPF.Tests;

public class SvgParameterCollectionTests
{
  private static readonly Random _random = new Random();

  [Theory]
  [InlineData(0, 0, 0, 0, null, null, "#000000")]
  [InlineData(10, 0, 0, 0, null, null, "#000000")]
  [InlineData(255, 0, 0, 0, null, null, "#000000")]
  [InlineData(0, 128, 64, 32, null, null, "#804020")]
  [InlineData(10, 128, 64, 32, null, null, "#804020")]
  [InlineData(255, 128, 64, 32, null, null, "#804020")]
  [InlineData(0, 255, 0, 0, null, null, "#FF0000")]
  [InlineData(0, 0, 255, 0, null, null, "#00FF00")]
  [InlineData(0, 0, 0, 255, null, null, "#0000FF")]
  [InlineData(255, 255, 0, 0, null, null, "#FF0000")]
  [InlineData(255, 0, 255, 0, null, null, "#00FF00")]
  [InlineData(255, 0, 0, 255, null, null, "#0000FF")]
  [InlineData(0, 0, 0, 0, 5.0, "5", "#000000")]
  [InlineData(10, 0, 0, 0, 5.0, "5", "#000000")]
  [InlineData(255, 0, 0, 0, 5.0, "5", "#000000")]
  [InlineData(0, 128, 64, 32, 5.0, "5", "#804020")]
  [InlineData(10, 128, 64, 32, 5.0, "5", "#804020")]
  [InlineData(255, 128, 64, 32, 5.0, "5", "#804020")]
  [InlineData(0, 255, 0, 0, 5.0, "5", "#FF0000")]
  [InlineData(0, 0, 255, 0, 5.0, "5", "#00FF00")]
  [InlineData(0, 0, 0, 255, 5.0, "5", "#0000FF")]
  [InlineData(255, 255, 0, 0, 5.0, "5", "#FF0000")]
  [InlineData(255, 0, 255, 0, 5.0, "5", "#00FF00")]
  [InlineData(255, 0, 0, 255, 5.0, "5", "#0000FF")]
  public void GetFillObject_ReturnsExpectedResult(int a, int r, int g, int b, double? opacity, string expectedOpacityValue, string expectedColorValue)
  {
    Color color = Color.FromArgb(a, r, g, b);
    List<object> expectedResult = [new { Name = FillType.Fill, Value = expectedColorValue }];
    if (expectedOpacityValue != null)
    {
      expectedResult.Add(new { Name = FillType.FillOpacity, Value = expectedOpacityValue });
    }
    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Equivalent(expectedResult, result.SvgParameter);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Theory]
  [InlineData(0, 0, 0, 0, null, null, null, null, "#000000")]
  [InlineData(10, 0, 0, 0, null, null, null, null, "#000000")]
  [InlineData(255, 0, 0, 0, null, null, null, null, "#000000")]
  [InlineData(0, 128, 64, 32, null, null, null, null, "#804020")]
  [InlineData(10, 128, 64, 32, null, null, null, null, "#804020")]
  [InlineData(255, 128, 64, 32, null, null, null, null, "#804020")]
  [InlineData(0, 255, 0, 0, null, null, null, null, "#FF0000")]
  [InlineData(0, 0, 255, 0, null, null, null, null, "#00FF00")]
  [InlineData(0, 0, 0, 255, null, null, null, null, "#0000FF")]
  [InlineData(255, 255, 0, 0, null, null, null, null, "#FF0000")]
  [InlineData(255, 0, 255, 0, null, null, null, null, "#00FF00")]
  [InlineData(255, 0, 0, 255, null, null, null, null, "#0000FF")]
  [InlineData(0, 0, 0, 0, 5.0, "5", 5.0, "5", "#000000")]
  [InlineData(10, 0, 0, 0, 5.0, "5", 5.0, "5", "#000000")]
  [InlineData(255, 0, 0, 0, 5.0, "5", 5.0, "5", "#000000")]
  [InlineData(0, 128, 64, 32, 5.0, "5", 5.0, "5", "#804020")]
  [InlineData(10, 128, 64, 32, 5.0, "5", 5.0, "5", "#804020")]
  [InlineData(255, 128, 64, 32, 5.0, "5", 5.0, "5", "#804020")]
  [InlineData(0, 255, 0, 0, 5.0, "5", 5.0, "5", "#FF0000")]
  [InlineData(0, 0, 255, 0, 5.0, "5", 5.0, "5", "#00FF00")]
  [InlineData(0, 0, 0, 255, 5.0, "5", 5.0, "5", "#0000FF")]
  [InlineData(255, 255, 0, 0, 5.0, "5", 5.0, "5", "#FF0000")]
  [InlineData(255, 0, 255, 0, 5.0, "5", 5.0, "5", "#00FF00")]
  [InlineData(255, 0, 0, 255, 5.0, "5", 5.0, "5", "#0000FF")]
  [InlineData(0, 0, 0, 0, 5.0, "5", null, null, "#000000")]
  [InlineData(10, 0, 0, 0, 5.0, "5", null, null, "#000000")]
  [InlineData(255, 0, 0, 0, 5.0, "5", null, null, "#000000")]
  [InlineData(0, 128, 64, 32, 5.0, "5", null, null, "#804020")]
  [InlineData(10, 128, 64, 32, 5.0, "5", null, null, "#804020")]
  [InlineData(255, 128, 64, 32, 5.0, "5", null, null, "#804020")]
  [InlineData(0, 255, 0, 0, 5.0, "5", null, null, "#FF0000")]
  [InlineData(0, 0, 255, 0, 5.0, "5", null, null, "#00FF00")]
  [InlineData(0, 0, 0, 255, 5.0, "5", null, null, "#0000FF")]
  [InlineData(255, 255, 0, 0, 5.0, "5", null, null, "#FF0000")]
  [InlineData(255, 0, 255, 0, 5.0, "5", null, null, "#00FF00")]
  [InlineData(255, 0, 0, 255, 5.0, "5", null, null, "#0000FF")]
  [InlineData(0, 0, 0, 0, null, null, 5.0, "5", "#000000")]
  [InlineData(10, 0, 0, 0, null, null, 5.0, "5", "#000000")]
  [InlineData(255, 0, 0, 0, null, null, 5.0, "5", "#000000")]
  [InlineData(0, 128, 64, 32, null, null, 5.0, "5", "#804020")]
  [InlineData(10, 128, 64, 32, null, null, 5.0, "5", "#804020")]
  [InlineData(255, 128, 64, 32, null, null, 5.0, "5", "#804020")]
  [InlineData(0, 255, 0, 0, null, null, 5.0, "5", "#FF0000")]
  [InlineData(0, 0, 255, 0, null, null, 5.0, "5", "#00FF00")]
  [InlineData(0, 0, 0, 255, null, null, 5.0, "5", "#0000FF")]
  [InlineData(255, 255, 0, 0, null, null, 5.0, "5", "#FF0000")]
  [InlineData(255, 0, 255, 0, null, null, 5.0, "5", "#00FF00")]
  [InlineData(255, 0, 0, 255, null, null, 5.0, "5", "#0000FF")]
  public void GetStrokeObject_ReturnsExpectedResult(int a, int r, int g, int b, double? width, string expectedWidth, double? opacity, string expectedOpacity, string expectedColorValue)
  {
    Color color = Color.FromArgb(a, r, g, b);
    List<object> expectedResult = [new { Name = StrokeType.Stroke, Value = expectedColorValue }];
    if (expectedWidth != null)
    {
      expectedResult.Add(new { Name = StrokeType.StrokeWidth, Value = expectedWidth });
    }
    if (expectedOpacity != null)
    {
      expectedResult.Add(new { Name = StrokeType.StrokeOpacity, Value = expectedOpacity });
    }
    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Equivalent(expectedResult, result.SvgParameter);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetFillObject_RandomColor_ReturnsExpectedResult()
  {
    // Arrange
    Color color = GenerateRandomColor();
    double? opacity = null;
    string expectedColorValue = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    List<object> expectedResult = [new { Name = FillType.Fill, Value = expectedColorValue }];

    // Act
    var result = SvgParameterCollection<StrokeType>.GetFillObject(color, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equivalent(expectedResult, result.SvgParameter);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  [Fact]
  public void GetStrokeObject_RandomColor_ReturnsExpectedResult()
  {
    // Arrange
    Color color = GenerateRandomColor();
    double? width = null;
    double? opacity = null;
    string expectedColorValue = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    List<object> expectedResult = [new { Name = StrokeType.Stroke, Value = expectedColorValue }];

    // Act
    var result = SvgParameterCollection<StrokeType>.GetStrokeObject(color, width, opacity);
    var (resultRed, resultGreen, resultBlue) = HexToRgb(result.SvgParameter[0].Value);

    // Assert
    Assert.NotNull(result);
    Assert.Single(result.SvgParameter);
    Assert.Equivalent(expectedResult, result.SvgParameter);
    Assert.Equal(color.R, resultRed);
    Assert.Equal(color.G, resultGreen);
    Assert.Equal(color.B, resultBlue);
  }

  public static (int Red, int Green, int Blue) HexToRgb(string hex)
  {
    var color = ColorTranslator.FromHtml(hex);
    return (color.R, color.G, color.B);
  }

  public Color GenerateRandomColor()
  {
    int a = _random.Next(0, 256);
    int r = _random.Next(0, 256);
    int g = _random.Next(0, 256);
    int b = _random.Next(0, 256);
    return Color.FromArgb(a, r, g, b);
  }

}
