using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class ObservationLinesTests
  {
    [Fact]
    public void ObservationLines_ConstructWithDictionary_ShouldSetPropertiesCorrectly()
    {
      var observationDict = new Dictionary<string, object>
            {
                { "activeObservation", 1 },
                { "recordingId", "123456" },
                { "color", new List<object> { 255, 0, 0, 0.5 } },
                { "selectedMeasureMethod", MeasureMethod.DepthMap }
            };

      var observationLines = new ObservationLines(observationDict);

      Assert.Equal(observationDict["activeObservation"], observationLines.ActiveObservation);
      Assert.Equal(observationDict["recordingId"], observationLines.RecordingId);
      Assert.Equal(observationDict["selectedMeasureMethod"], observationLines.SelectedMeasureMethod);
    }

    [Fact]
    public void ObservationLines_Equals_ShouldReturnTrueForEqualObjects()
    {
      var observation1 = new ObservationLines(new Dictionary<string, object>
            {
                { "activeObservation", 1 },
                { "recordingId", "123456" },
                { "color", new List<object> { 255, 0, 0, 0.5 } },
                { "selectedMeasureMethod", MeasureMethod.DepthMap }
            });

      var observation2 = new ObservationLines(new Dictionary<string, object>
            {
                { "activeObservation", 1 },
                { "recordingId", "123456" },
                { "color", new List<object> { 255, 0, 0, 0.5 } },
                { "selectedMeasureMethod", MeasureMethod.DepthMap }
            });

      var isEqual = observation1.Equals(observation2);

      Assert.True(isEqual);
    }

    [Fact]
    public void ObservationLines_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var observation1 = new ObservationLines(new Dictionary<string, object>
            {
                { "activeObservation", 1 },
                { "recordingId", "123456" },
                { "color", new List<object> { 255, 0, 0, 0.5 } },
                { "selectedMeasureMethod", MeasureMethod.DepthMap }
            });

      var observation2 = new ObservationLines(new Dictionary<string, object>
            {
                { "activeObservation", 2 },
                { "recordingId", "654321" },
                { "color", new List<object> { 255, 255, 255, 1.0 } },
                { "selectedMeasureMethod", MeasureMethod.DepthMap }
            });

      var isEqual = observation1.Equals(observation2);

      Assert.False(isEqual);
    }

    [Fact]
    public void ObservationLines_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new ObservationLines(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }
  }
}
