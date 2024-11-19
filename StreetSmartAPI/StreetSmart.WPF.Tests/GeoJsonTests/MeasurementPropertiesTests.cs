using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class MeasurementPropertiesTests
  {
    [Fact]
    public void MeasurementProperties_Equals_ShouldReturnFalseForMeasureDetailsCountDifferent()
    {
      var measureDetail1 = new { Length = 10.5, Width = 5.2, Height = 3.8 };
      var measureDetail2 = new { Length = 7.1, Width = 4.5, Height = 2.3 };

      var propertiesDict = new Dictionary<string, object>
            {
                { "id", "test-id" },
                { "name", "test-name" },
                { "group", "test-group" },
                { "fontsize", 12 },
                { "dimension", 3 },
                { "measureReliability", "RELIABLE" },
                { "measurementTool", "MAP" },
                { "validGeometry", true },
                { "pointsWithErrors", new List<object> { 1, 2, 3 } },
                { "observationLines", new Dictionary<string, object>() },
                { "derivedData", new Dictionary<string, object>() },
                {  "measureDetails", new List<object>
                  {
                      measureDetail1,
                      measureDetail2
                  }},
                { "wgsGeometry", new Dictionary<string, object>() }
            };

      var propertiesDict2 = new Dictionary<string, object?>
            {
                { "id", "test-id" },
                { "name", "test-name" },
                { "group", "test-group" },
                { "fontsize", 12 },
                { "dimension", 3 },
                { "measureReliability", "RELIABLE" },
                { "measurementTool", "MAP" },
                { "validGeometry", true },
                { "pointsWithErrors", new List<object> { 1, 2, 3 } },
                { "observationLines", new Dictionary<string, object>() },
                { "derivedData", new Dictionary<string, object>() },
                {  "measureDetails", null },
                { "wgsGeometry", new Dictionary<string, object>() }
            };

      var measurementProperties1 = new MeasurementProperties(propertiesDict, GeometryType.Point);
      var measurementProperties2 = new MeasurementProperties(propertiesDict2, GeometryType.Point);

      Assert.False(measurementProperties1.Equals(measurementProperties2));
    }

    [Fact]
    public void MeasurementProperties_Equals_ShouldReturnTrueForEqualObjects()
    {
      var propertiesDict = new Dictionary<string, object>
            {
                { "id", "test-id" },
                { "name", "test-name" },
                { "group", "test-group" },
                { "fontsize", 12 },
                { "dimension", 3 },
                { "measureReliability", "RELIABLE" },
                { "measurementTool", "MAP" },
                { "validGeometry", true },
                { "pointsWithErrors", new List<object> { 1, 2, 3 } },
                { "observationLines", new Dictionary<string, object>() },
                { "derivedData", new Dictionary<string, object>() },
                { "measureDetails", new List<object>{ 1, 2, 3 } },
                { "wgsGeometry", new Dictionary<string, object>() }
            };

      var measurementProperties1 = new MeasurementProperties(propertiesDict, GeometryType.Point);
      var measurementProperties2 = new MeasurementProperties(propertiesDict, GeometryType.Point);

      Assert.Equal(measurementProperties1, measurementProperties2);
    }

    [Fact]
    public void MeasurementProperties_Equals_ShouldReturnFalseForSecondObjectNullValue()
    {
      var propertiesDict = new Dictionary<string, object>
            {
                { "id", "test-id" },
                { "name", "test-name" },
                { "group", "test-group" },
                { "fontsize", 12 },
                { "dimension", 3 },
                { "measureReliability", "RELIABLE" },
                { "measurementTool", "MAP" },
                { "validGeometry", true },
                { "pointsWithErrors", new List<object> { 1, 2, 3 } },
                { "observationLines", new Dictionary<string, object>() },
                { "derivedData", new Dictionary<string, object>() },
                { "measureDetails", new List<object>{ 1, 2, 3 } },
                { "wgsGeometry", new Dictionary<string, object>() }
            };

      var measurementProperties1 = new MeasurementProperties(propertiesDict, GeometryType.Point);

      Assert.False(measurementProperties1.Equals(null));
    }

    [Fact]
    public void MeasurementProperties_ShouldInitializeCorrectly()
    {
      var propertiesData = new Dictionary<string, object>
            {
                { "id", "1" },
                { "name", "Test Feature" },
                { "group", "Test Group" },
                { "measureDetails", new List<object>
                    {
                        new Dictionary<string, object>
                        {
                            { "measureMethod", "DepthMap" },
                            { "details", new Dictionary<string, object>() },
                            { "pointProblems", new List<object>() },
                            { "pointReliability", "RELIABLE" }
                        }
                    }
                },
                { "fontsize", 12 },
                { "dimension", 2 },
                { "derivedData", new Dictionary<string, object>
                    {
                        { "unit", "m" },
                        { "precision", 2 }
                    }
                },
                { "measureReliability", "RELIABLE" },
                { "measurementTool", "MAP" },
                { "pointsWithErrors", new List<object> { 1, 2, 3 } },
                { "validGeometry", true },
                { "observationLines", new Dictionary<string, object>
                    {
                        { "activeObservation", 1 },
                        { "recordingId", "rec123" },
                        { "color", new Dictionary<string, object> { { "r", 255 }, { "g", 0 }, { "b", 0 } } },
                        { "selectedMeasureMethod", "DepthMap" }
                    }
                },
                { "wgsGeometry", new Dictionary<string, object>
                    {
                        { "type", "Point" },
                        { "coordinates", new List<double> { 3.0, 4.0 } }
                    }
                }
            };

      var measurementProperties = new MeasurementProperties(propertiesData, GeometryType.Point);

      Assert.Equal("1", measurementProperties.Id);
      Assert.Equal("Test Feature", measurementProperties.Name);
      Assert.Equal("Test Group", measurementProperties.Group);
      Assert.Equal(12, measurementProperties.FontSize);
      Assert.Equal(2, measurementProperties.Dimension);
      Assert.Equal(Reliability.Reliable, measurementProperties.MeasureReliability);
      Assert.Equal(MeasurementTools.Map, measurementProperties.MeasurementTool);
      Assert.Equal(3, measurementProperties.PointsWithErrors.Count);
      Assert.True(measurementProperties.ValidGeometry);
      Assert.IsType<Point>(measurementProperties.WgsGeometry);

      Assert.Equal(1, measurementProperties.ObservationLines.ActiveObservation);
      Assert.Equal("rec123", measurementProperties.ObservationLines.RecordingId);
      Assert.Equal(MeasureMethod.DepthMap, measurementProperties.ObservationLines.SelectedMeasureMethod);

      Assert.Equal(CustomGeometryType.NotDefined, measurementProperties.CustomGeometryType);

      Assert.Equal(Unit.Meters, measurementProperties.DerivedData.Unit);
      Assert.Equal(2, measurementProperties.DerivedData.Precision);

      Assert.Single(measurementProperties.MeasureDetails);
      var measureDetail = measurementProperties.MeasureDetails[0];
      Assert.True(measurementProperties.MeasureDetails.Equals(measurementProperties.MeasureDetails));
      Assert.True(measureDetail.Equals(measureDetail));
      Assert.Equal(MeasureMethod.DepthMap, measureDetail.MeasureMethod);
      Assert.Equal(Reliability.Reliable, measureDetail.PointReliability);
    }

    [Fact]
    public void MeasurementProperties_EqualsMethod_ShouldReturnFalseForDifferentPointsWithErrorsCount()
    {
      var propertiesData1 = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" },
            { "measureDetails", new List<object>() },
            { "fontsize", 12 },
            { "dimension", 2 },
            { "derivedData", new Dictionary<string, object>() },
            { "measureReliability", "RELIABLE" },
            { "measurementTool", "MAP" },
            { "pointsWithErrors", new List<object> { 1, 2, 3 } },
            { "validGeometry", true },
            { "observationLines", new Dictionary<string, object>() },
            { "wgsGeometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 3.0, 4.0 } }
                }
            }
        };

      var propertiesData2 = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" },
            { "measureDetails", new List<object>() },
            { "fontsize", 12 },
            { "dimension", 2 },
            { "derivedData", new Dictionary<string, object>() },
            { "measureReliability", "RELIABLE" },
            { "measurementTool", "MAP" },
            { "pointsWithErrors", new List<object> { 1, 2 } },
            { "validGeometry", true },
            { "observationLines", new Dictionary<string, object>() },
            { "wgsGeometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 3.0, 4.0 } }
                }
            }
        };

      var properties1 = new MeasurementProperties(propertiesData1, GeometryType.Point);
      var properties2 = new MeasurementProperties(propertiesData2, GeometryType.Point);

      var areEqual = properties1.Equals(properties2);

      Assert.False(areEqual);
    }

    [Fact]
    public void MeasurementProperties_EqualsMethod_ShouldReturnFalseForDifferentObjects()
    {
      var propertiesData1 = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" },
            { "measureDetails", new List<object>() },
            { "fontsize", 12 },
            { "dimension", 2 },
            { "derivedData", new Dictionary<string, object>() },
            { "measureReliability", "RELIABLE" },
            { "measurementTool", "MAP" },
            { "pointsWithErrors", new List<object> { 1, 2, 3 } },
            { "validGeometry", true },
            { "observationLines", new Dictionary<string, object>() },
            { "wgsGeometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 3.0, 4.0 } }
                }
            }
        };

      var propertiesData2 = new Dictionary<string, object>
        {
            { "id", "2" },
            { "name", "Test Feature 2" },
            { "group", "Test Group 2" },
            { "measureDetails", new List<object>() },
            { "fontsize", 14 },
            { "dimension", 3 },
            { "derivedData", new Dictionary<string, object>() },
            { "measureReliability", "UNRELIABLE" },
            { "measurementTool", "PANORAMA" },
            { "pointsWithErrors", new List<object> { 4, 5, 6 } },
            { "validGeometry", false },
            { "observationLines", new Dictionary<string, object>() },
            { "wgsGeometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 5.0, 6.0 } }
                }
            }
        };

      var properties1 = new MeasurementProperties(propertiesData1, GeometryType.Point);
      var properties2 = new MeasurementProperties(propertiesData2, GeometryType.Point);

      var areEqual = properties1.Equals(properties2);

      Assert.False(areEqual);
    }

    [Fact]
    public void MeasurementProperties_EqualsMethod_ShouldReturnTrueForEqualObjects()
    {
      var propertiesData = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" },
            { "measureDetails", new List<object>() },
            { "fontsize", 12 },
            { "dimension", 2 },
            { "derivedData", new Dictionary<string, object>() },
            { "measureReliability", "RELIABLE" },
            { "measurementTool", "MAP" },
            { "pointsWithErrors", new List<object> { 1, 2, 3 } },
            { "validGeometry", true },
            { "observationLines", new Dictionary<string, object>() },
            { "wgsGeometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 3.0, 4.0 } }
                }
            }
        };

      var properties1 = new MeasurementProperties(propertiesData, GeometryType.Point);
      var properties2 = new MeasurementProperties(propertiesData, GeometryType.Point);

      var areEqual = properties1.Equals(properties2);

      Assert.True(areEqual);
    }
  }
}
