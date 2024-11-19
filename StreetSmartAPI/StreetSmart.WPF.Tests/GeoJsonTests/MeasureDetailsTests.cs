using FluentAssertions;
using Newtonsoft.Json;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using StreetSmart.WPF.Tests.TestData;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class MeasureDetailsTests
  {
    [Theory]
    [MemberData(nameof(MeasureDetailsData))]
    public void MeasureDetails_ToString_Equals(IDictionary<string, object> measureDetails, MeasurementTools measurementTool)
    {
      // arrange

      // act
      var md = new MeasureDetails(measureDetails, measurementTool);
      var result = md.ToString();

      // assert
      new MeasureDetails(md, measurementTool).ToString().Should().BeEquivalentTo(result);
    }

    [Theory]
    [MemberData(nameof(MeasureDetailsData))]
    public void MeasureDetails_ToString_ValidJson(IDictionary<string, object> measureDetails, MeasurementTools measurementTool)
    {
      // arrange

      // act
      var md = new MeasureDetails(measureDetails, measurementTool);
      var result = md.ToString();

      // assert
      Assert.NotNull(JsonConvert.DeserializeObject(result));
    }

    public static IEnumerable<object[]> MeasureDetailsData() =>
    [
      [
        new Dictionary<string, object> {
          { "measureMethod", MeasureMethod.DepthMap },
          { "details", GeoJsonTestData.GetRandomDetailsDepth() },
          { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
           { "pointReliability", "RELIABLE" }
        },
        MeasurementTools.Oblique
      ],
      [
        new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        },
        MeasurementTools.Map
      ]
    ];

    [Fact]
    public void MeasureDetails_Constructor_SetsPointProblems_Correctly()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      Assert.Contains(PointProblems.OneObservation, measureDetailsObj.PointProblems);
      Assert.Contains(PointProblems.InvalidAngle, measureDetailsObj.PointProblems);
      Assert.DoesNotContain(PointProblems.TooFewRecordings, measureDetailsObj.PointProblems);
    }

    [Fact]
    public void MeasureDetails_Constructor_SetsPointProblemsWhenSecondObjectIsNull_ReturnFalse()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      var measureDetails2 = new Dictionary<string, object?>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", null},
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj2 = new MeasureDetails(measureDetails2, MeasurementTools.NotDefined);

      Assert.False(measureDetailsObj.Equals(measureDetailsObj2));
    }

    [Fact]
    public void MeasureDetails_Constructor_SetsPointProblemsWithDifferentCount_ReturnFalse()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      var measureDetails2 = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION"} },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj2 = new MeasureDetails(measureDetails2, MeasurementTools.NotDefined);

      Assert.False(measureDetailsObj.Equals(measureDetailsObj2));
    }

    [Fact]
    public void MeasureDetails_Constructor_SetsPointProblemsWithOneHaveAndOneDont_ReturnFalse()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      var measureDetails2 = new Dictionary<string, object?>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", null },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj2 = new MeasureDetails(measureDetails2, MeasurementTools.NotDefined);

      Assert.False(measureDetailsObj.Equals(measureDetailsObj2));
    }

    [Fact]
    public void MeasureDetails_Constructor_SetsPointProblemsWithDifferentValue_ReturnFalse()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      var measureDetails2 = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "POINT_TOO_FAR" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj2 = new MeasureDetails(measureDetails2, MeasurementTools.NotDefined);

      Assert.False(measureDetailsObj.Equals(measureDetailsObj2));
    }

    [Fact]
    public void MeasureDetails_Constructor_SetsPointReliability_Correctly()
    {
      var measureDetails = new Dictionary<string, object>
      {
          { "details", new Dictionary<string, object>() },
          { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
          { "measureMethod", "SmartClick" },
          { "pointReliability", "RELIABLE" }
      };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      Assert.True(measureDetailsObj.PointReliability.Equals(Reliability.Reliable));
    }

    [Fact]
    public void MeasureDetails_Equals_ReturnsFalse_WhenOtherIsNull()
    {
      var measureDetails = new Dictionary<string, object>
        {
            { "details", new Dictionary<string, object>() },
            { "pointProblems", new List<object> { "ONE_OBSERVATION", "INVALID_ANGLE" } },
            { "measureMethod", "SmartClick" },
            { "pointReliability", "RELIABLE" }
        };

      var measureDetailsObj = new MeasureDetails(measureDetails, MeasurementTools.NotDefined);

      Assert.False(measureDetailsObj.Equals(null));
    }
  }
}
