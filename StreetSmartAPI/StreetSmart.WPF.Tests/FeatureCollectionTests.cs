using StreetSmart.Common.Data;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;
using System;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests
{
  public class FeatureCollectionTests
  {
    [Fact]
    public void FeatureCollection_Equals_SameReference_ReturnsTrue()
    {
      var featureCollection = new FeatureCollection(new Dictionary<string, object>(), true);
      Assert.True(featureCollection.Equals(featureCollection));
    }

    [Fact]
    public void FeatureCollection_Equals_Null_ReturnsFalse()
    {
      var featureCollection = new FeatureCollection(new Dictionary<string, object>(), true);
      Assert.False(featureCollection.Equals(null));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentTypes_ReturnsFalse()
    {
      var featureCollection = new FeatureCollection(new Dictionary<string, object>(), true);
      Assert.False(featureCollection.Equals(new object()));
    }

    [Fact]
    public void FeatureCollection_Equals_NullFeature_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(new Feature(new Point(0, 0)));

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(null);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_FeatureCollectionsWithDifferentFeatureCounts_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(new Feature(new Point(0, 0)));

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentFeatureProperties_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Point(0, 0));
      feature2.Properties.Add("prop2", "value2");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentFeaturePropertiesSameKey_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Point(0, 0));
      feature2.Properties.Add("prop1", "value2");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SamePropertiesDifferentGeometry_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Point(1, 1));
      feature2.Properties.Add("prop1", "value1");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SamePropertiesSameGeometry_ReturnsTrue()
    {
      var feature1 = new Feature(new Point(0, 0));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Point(0, 0));
      feature2.Properties.Add("prop1", "value1");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentType_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Unknown
      };

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameType_ReturnsTrue()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature
      };

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentCRS_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(456)
      };

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameCRS_ReturnsTrue()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(123)
      };

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameType_SameCRS_ReturnsTrue()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(123)
      };

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameType_DifferentCRS_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(456)
      };

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameType_NullValueOfSecondCRS_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = null
      };

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentType_SameCRS_ReturnsFalse()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature,
        CRS = new CRS(123)
      };
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Unknown,
        CRS = new CRS(123)
      };

      Assert.False(featureCollection1.Equals(featureCollection2));
    }
    [Fact]
    public void Rotation_Equals_ReturnsFalse_WhenOtherIsNull()
    {
      var rotationValues = new Dictionary<string, object>
        {
            { "m", new Dictionary<string, object>
                {
                    { "shape", new[] { 3, 3 } },
                    { "data", new[] { 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 } }
                }
            }
        };

      var rotation1 = new Rotation(rotationValues);

      Assert.False(rotation1.Equals(null));
    }

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

    [Fact]
    public void FeatureCollection_Equals_SamePropertiesDifferentCRS_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Point(0, 0));
      feature2.Properties.Add("prop1", "value1");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(123)
      };
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(456)
      };
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SamePropertiesSameCRSDifferentFeatures_ReturnsFalse()
    {
      var feature1 = new Feature(new LineString([new Coordinate(1, 1), new Coordinate(2, 2)]));
      feature1.Properties.Add("prop1", "value1");

      var feature2 = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0), new Coordinate(0.0, 0.0, 0.0) } }));
      feature2.Properties.Add("prop1", "value1");

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(456)
      };
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        CRS = new CRS(456)
      };
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameType_DifferentTypes_ReturnsFalse()
    {
      var featureCollection = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature
      };
      Assert.False(featureCollection.Equals(new object()));
    }

    [Fact]
    public void FeatureCollection_Equals_SameFeatures_DifferentType_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Feature
      };
      featureCollection1.Features.Add(feature1);
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true)
      {
        Type = FeatureType.Unknown
      };
      featureCollection2.Features.Add(feature1);
      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentFeatures_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      var feature2 = new Feature(new LineString([new Coordinate(1, 1), new Coordinate(2, 2)]));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameFeatures_ReturnsTrue()
    {
      var feature1 = new Feature(new Point(0, 0));
      var feature2 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);
      featureCollection1.Features.Add(feature2);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature1);
      featureCollection2.Features.Add(feature2);

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentCoordinateOrderWithinFeature_ReturnsFalse()
    {
      var feature1 = new Feature(new LineString([new Coordinate(1, 1), new Coordinate(2, 2)]));

      var feature2 = new Feature(new LineString([new Coordinate(2, 2), new Coordinate(1, 1)]));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_EmptyFeatureCollections_ReturnsTrue()
    {
      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void Polygon_WhenACountHasDifferentValue_ReturnFalse()
    {
      var element1 = new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0), new Coordinate(0.0, 0.0, 0.0) };
      var element2 = new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0), new Coordinate(0.0, 0.0, 0.0) };
      var polygon1 = new Polygon(new List<IList<ICoordinate>> { element1, element2 });
      var polygon2 = new Polygon(new List<IList<ICoordinate>> { element1 });

      Assert.False(polygon1.Equals(polygon2));
    }

    [Fact]
    public void Properties_WhenACountHasDifferentValue_ReturnFalse()
    {
      var element1 = new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" },
                    { "measureDetails", new List<object>() },
                    { "fontsize", 12 },
                    { "dimension", 2 }
                };
      var element2 = new Dictionary<string, object>
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
                    { "pointsWithErrors", new List<int> { 1, 2, 3 } },
                    { "validGeometry", true },
                    { "observationLines", new Dictionary<string, object>() },
                    { "wgsGeometry", new Dictionary<string, object>
                        {
                            { "type", "Point" },
                            { "coordinates", new List<double> { 3.0, 4.0 } }
                        }
                    }
                };
      var properties1 = new Common.Data.GeoJson.Properties(element1);
      var properties2 = new Common.Data.GeoJson.Properties(element2);

      Assert.False(properties1.Equals(properties2));
    }

    [Fact]
    public void RecordingInfo_WhenSecondObjectIsNull_ReturnFalse()
    {
      var recordinginfo = new RecordingInfo(new Dictionary<string, object> {
                    { "id", "1" }
      });

      Assert.False(recordinginfo.Equals(null));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentPolygonFeatures_ReturnsFalse()
    {
      var polygon1 = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0), new Coordinate(0.0, 0.0, 0.0) } }));
      var polygon2 = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(1.0, 1.0, 0.0), new Coordinate(1.0, 2.0, 0.0), new Coordinate(2.0, 2.0, 0.0), new Coordinate(1.0, 1.0, 0.0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(polygon1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(polygon2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentPolygonFeaturesSizeSameStartCoordinates_ReturnsFalse()
    {
      var polygon1 = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0), new Coordinate(0.0, 0.0, 0.0) } }));
      var polygon2 = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0.0, 0.0, 0.0), new Coordinate(0.0, 1.0, 0.0), new Coordinate(1.0, 1.0, 0.0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(polygon1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(polygon2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SamePolygonFeatures_ReturnsTrue()
    {
      var polygon = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(0, 0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(polygon);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(polygon);

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_MixedFeatures_ReturnsFalse()
    {
      var point = new Feature(new Point(0, 0));
      var lineString = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));
      var polygon = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(0, 0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(point);
      featureCollection1.Features.Add(lineString);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(polygon);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameMixedFeatures_ReturnsTrue()
    {
      var point = new Feature(new Point(0, 0));
      var lineString = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));
      var polygon = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(0, 0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(point);
      featureCollection1.Features.Add(lineString);
      featureCollection1.Features.Add(polygon);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(point);
      featureCollection2.Features.Add(lineString);
      featureCollection2.Features.Add(polygon);

      Assert.True(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameFeaturesButDifferentOrder_ReturnsFalse()
    {
      var point = new Feature(new Point(0, 0));
      var lineString = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));
      var polygon = new Feature(new Polygon(new List<IList<ICoordinate>> { new List<ICoordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(0, 0) } }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(point);
      featureCollection1.Features.Add(polygon);
      featureCollection1.Features.Add(lineString);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(point);
      featureCollection2.Features.Add(lineString);
      featureCollection2.Features.Add(polygon);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentNumbersOfFeatures_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      var feature2 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature1);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_SameFeaturesDifferentOrder_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(0, 0));
      var feature2 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);
      featureCollection1.Features.Add(feature2);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);
      featureCollection2.Features.Add(feature1);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentFeaturesDifferentCoordinateDimension_ReturnsFalse()
    {
      var feature1 = new Feature(new Point(new Coordinate(0, 0)));
      var feature2 = new Feature(new Point(new Coordinate(0, 0, 0)));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_Equals_DifferentFeaturesDifferentNumberOfCoordinatesLineString_ReturnsFalse()
    {
      var feature1 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2), new Coordinate(2, 2) }));
      var feature2 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));

      var featureCollection1 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection1.Features.Add(feature1);

      var featureCollection2 = new FeatureCollection(new Dictionary<string, object>(), true);
      featureCollection2.Features.Add(feature2);

      Assert.False(featureCollection1.Equals(featureCollection2));
    }

    [Fact]
    public void FeatureCollection_WithMeasurementProperties_ShouldInitializeCorrectly()
    {
      var featureData = new Dictionary<string, object>
        {
            { "type", "Feature" },
            { "geometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 1.0, 2.0 } }
                }
            },
            { "properties", new Dictionary<string, object>
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
                    { "pointsWithErrors", new List<int> { 1, 2, 3 } },
                    { "validGeometry", true },
                    { "observationLines", new Dictionary<string, object>() },
                    { "wgsGeometry", new Dictionary<string, object>
                        {
                            { "type", "Point" },
                            { "coordinates", new List<double> { 3.0, 4.0 } }
                        }
                    }
                }
            }
        };

      var feature = new Feature(featureData, true);

      Assert.Equal(FeatureType.Feature, feature.Type);
      Assert.IsType<Point>(feature.Geometry);
      Assert.IsType<MeasurementProperties>(feature.Properties);
    }

    [Fact]
    public void FeatureCollection_WithoutMeasurementProperties_ShouldInitializeCorrectly()
    {
      var featureData = new Dictionary<string, object>
        {
            { "type", "Feature" },
            { "geometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 1.0, 2.0 } }
                }
            },
            { "properties", new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" }
                }
            }
        };

      var feature = new Feature(featureData, false);

      Assert.Equal(FeatureType.Feature, feature.Type);
      Assert.IsType<Point>(feature.Geometry);
      Assert.IsType<Common.Data.GeoJson.Properties>(feature.Properties);
    }

    [Fact]
    public void FeatureCollection_EqualsMethod_ShouldReturnTrueForEqualFeatures()
    {
      var featureData = new Dictionary<string, object>
        {
            { "type", "Feature" },
            { "geometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 1.0, 2.0 } }
                }
            },
            { "properties", new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" }
                }
            }
        };

      var feature1 = new Feature(featureData, false);
      var feature2 = new Feature(featureData, false);

      var areEqual = feature1.Equals(feature2);

      Assert.True(areEqual);
    }

    [Fact]
    public void FeatureCollection_EqualsMethod_ShouldReturnFalseForDifferentFeatures()
    {
      var featureData1 = new Dictionary<string, object>
        {
            { "type", "Feature" },
            { "geometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 1.0, 2.0 } }
                }
            },
            { "properties", new Dictionary<string, object>
                {
                    { "id", "1" },
                    { "name", "Test Feature" },
                    { "group", "Test Group" }
                }
            }
        };

      var featureData2 = new Dictionary<string, object>
        {
            { "type", "Feature" },
            { "geometry", new Dictionary<string, object>
                {
                    { "type", "Point" },
                    { "coordinates", new List<double> { 3.0, 4.0 } }
                }
            },
            { "properties", new Dictionary<string, object>
                {
                    { "id", "2" },
                    { "name", "Test Feature 2" },
                    { "group", "Test Group 2" }
                }
            }
        };

      var feature1 = new Feature(featureData1, false);
      var feature2 = new Feature(featureData2, false);

      var areEqual = feature1.Equals(feature2);

      Assert.False(areEqual);
    }

    [Fact]
    public void Properties_ShouldInitializeCorrectly()
    {
      var propertiesData = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var properties = new Common.Data.GeoJson.Properties(propertiesData);

      Assert.Equal("1", properties["id"]);
      Assert.Equal("Test Feature", properties["name"]);
      Assert.Equal("Test Group", properties["group"]);
    }

    [Fact]
    public void Properties_EqualsMethod_ShouldReturnTrueForEqualProperties()
    {
      var propertiesData = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var properties1 = new Common.Data.GeoJson.Properties(propertiesData);
      var properties2 = new Common.Data.GeoJson.Properties(propertiesData);

      var areEqual = properties1.Equals(properties2);

      Assert.True(areEqual);
    }

    [Fact]
    public void Properties_EqualsMethod_ShouldReturnFalseForDifferentProperties()
    {
      var propertiesData1 = new Dictionary<string, object>
        {
            { "id", "1" },
            { "name", "Test Feature" },
            { "group", "Test Group" }
        };

      var propertiesData2 = new Dictionary<string, object>
        {
            { "id", "2" },
            { "name", "Test Feature 2" },
            { "group", "Test Group 2" }
        };

      var properties1 = new Common.Data.GeoJson.Properties(propertiesData1);
      var properties2 = new Common.Data.GeoJson.Properties(propertiesData2);

      var areEqual = properties1.Equals(properties2);

      Assert.False(areEqual);
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
    public void DerivedData_EqualObjects_ReturnsTrue()
    {
      var data1 = new DerivedData(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedData(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
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
    public void DerivedData_NotEqualObjects_ReturnsFalse()
    {
      var data1 = new DerivedData(new Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedData(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataLineString_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedData(new Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      var data2 = new DerivedData(new Dictionary<string, object>
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
    public void PositionStdev_ConstructWithCoordinatesAndStdev_ShouldSetPropertiesCorrectly()
    {
      double x = 1.0, y = 2.0, z = 3.0;
      double stdX = 0.1, stdY = 0.2, stdZ = 0.3;

      var positionStdev = new PositionStdev(x, y, z, stdX, stdY, stdZ);

      Assert.Equal(x, positionStdev.X);
      Assert.Equal(y, positionStdev.Y);
      Assert.Equal(z, positionStdev.Z);
      Assert.Equal(stdX, positionStdev.StdDev.X);
      Assert.Equal(stdY, positionStdev.StdDev.Y);
      Assert.Equal(stdZ, positionStdev.StdDev.Z);
    }

    [Fact]
    public void PositionStdev_Equals_ShouldReturnTrueForEqualObjects()
    {
      var position1 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);
      var position2 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);

      var isEqual = position1.Equals(position2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionStdev_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var position1 = new PositionStdev(1.0, 2.0, 3.0, 0.1, 0.2, 0.3);
      var position2 = new PositionStdev(1.0, 2.0, 3.0, 0.4, 0.5, 0.6);

      var isEqual = position1.Equals(position2);

      Assert.False(isEqual);
    }

    [Fact]
    public void PositionXY_ConstructWithValueAndStdev_ShouldSetPropertiesCorrectly()
    {
      var value = new List<object> { 1.0, 2.0 };
      double stdev = 0.1;

      var positionXY = new PositionXY(value, stdev);

      Assert.Equal(value[0], positionXY.X);
      Assert.Equal(value[1], positionXY.Y);
      Assert.Equal(stdev, positionXY.Stdev);
    }

    [Fact]
    public void PositionXY_Equals_ShouldReturnTrueForEqualObjects()
    {
      var value1 = new List<object> { 1.0, 2.0 };
      var value2 = new List<object> { 1.0, 2.0 };

      var positionXY1 = new PositionXY(value1, 0.1);
      var positionXY2 = new PositionXY(value2, 0.1);
      var isEqual = positionXY1.Equals(positionXY2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionXY_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var value1 = new List<object> { 1.0, 2.0 };
      var value2 = new List<object> { 2.0, 3.0 };

      var positionXY1 = new PositionXY(value1, 0.1);
      var positionXY2 = new PositionXY(value2, 0.1);
      var isEqual = positionXY1.Equals(positionXY2);

      Assert.False(isEqual);
    }

    [Fact]
    public void PositionXYZ_ConstructWithCoordinates_ShouldSetPropertiesCorrectly()
    {
      var positionDict = new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            };

      var positionXYZ = new PositionXYZ(positionDict);

      Assert.True(positionXYZ.XYZ.X.Equals((Double)positionDict["x"]));
      Assert.True(positionXYZ.XYZ.Y.Equals((Double)positionDict["y"]));
      Assert.True(positionXYZ.XYZ.Z.Equals((Double)positionDict["z"]));
    }

    [Fact]
    public void PositionXYZ_Equals_ShouldReturnTrueForEqualObjects()
    {
      var position1 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var position2 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var isEqual = position1.Equals(position2);

      Assert.True(isEqual);
    }

    [Fact]
    public void PositionXYZ_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var position1 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 1.0 },
                { "y", 2.0 },
                { "z", 3.0 }
            });

      var position2 = new PositionXYZ(new Dictionary<string, object>
            {
                { "x", 4.0 },
                { "y", 5.0 },
                { "z", 6.0 }
            });

      var isEqual = position1.Equals(position2);

      Assert.False(isEqual);
    }

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
    public void Geometry_ConstructWithDictionary_ShouldSetTypeCorrectly()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };

      var geometry = new Geometry(geometryDict);

      Assert.True(geometryDict["type"].Equals(geometry.Type));
    }

    [Fact]
    public void Geometry_ConstructWithUnknownType_ShouldSetTypeToUnknown()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", "InvalidType" }
            };

      var geometry = new Geometry(geometryDict);

      Assert.Equal(GeometryType.Unknown, geometry.Type);
    }
    [Fact]
    public void Geometry_CheckingIfTwoSameGeometryAreTrue()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };

      var geometry = new Geometry(geometryDict);
      var geometry2 = new Geometry(geometryDict);

      Assert.True(geometry.Equals(geometry2));
    }

    [Fact]
    public void Geometry_CheckingIfTwoSameGeometryAreFalse()
    {
      var geometryDict = new Dictionary<string, object>
            {
                { "type", GeometryType.Point }
            };
      var geometryDict2 = new Dictionary<string, object>
            {
                { "type", GeometryType.LineString }
            };
      var geometry = new Geometry(geometryDict);
      var geometry2 = new Geometry(geometryDict2);

      Assert.False(geometry.Equals(geometry2));
    }

    [Fact]
    public void Point_Equals_ShouldReturnTrueForEqualObjects()
    {
      var point1 = new Point(new Dictionary<string, object>
            {
                { "coordinates", new List<object> { 1.0, 2.0 } },
                { "type", GeometryType.Point }
            });

      var point2 = new Point(new Dictionary<string, object>
            {
                { "coordinates", new List<object> { 1.0, 2.0 } },
                { "type", GeometryType.Point }
            });

      Assert.True(point1.Equals(point2));
    }

    [Fact]
    public void Point_Equals_ShouldReturnFalseForDifferentObjects()
    {
      var point1 = new Point(new Dictionary<string, object>
        {
            { "coordinates", new List<object> { 1.0, 2.0 } },
            { "type", GeometryType.Point }
        });

      var point2 = new Point(new Dictionary<string, object>
        {
            { "coordinates", new List<object> { 3.0, 4.0 } },
            { "type", GeometryType.Point }
        });

      Assert.False(point1.Equals(point2));
    }

    [Fact]
    public void Coordinate_InitializationWithDictionary_ShouldSetCorrectValues()
    {
      var coordinateDict = new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            };

      var coordinate = new Coordinate(coordinateDict);

      Assert.True(coordinate.X.Equals(1.0));
      Assert.True(coordinate.Y.Equals(2.0));
      Assert.True(coordinate.Z.Equals(3.0));
    }

    [Fact]
    public void Coordinate_InitializationWithList_ShouldSetCorrectValues()
    {
      var coordinateList = new List<object> { 4.0, 5.0, 6.0 };

      var coordinate = new Coordinate(coordinateList);

      Assert.True(coordinate.X.Equals(4.0));
      Assert.True(coordinate.Y.Equals(5.0));
      Assert.True(coordinate.Z.Equals(6.0));
    }

    [Fact]
    public void Coordinate_Equals_ShouldReturnFalseForDifferentCoordinates()
    {
      var coordinate1 = new Coordinate(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            });

      var coordinate2 = new Coordinate(new Dictionary<string, object>
            {
                { "0", 4.0 },
                { "1", 5.0 },
                { "2", 6.0 }
            });

      Assert.False(coordinate1.Equals(coordinate2));
    }
    [Fact]
    public void Coordinate_Equals_ShouldReturnTrueForSameCoordinates()
    {
      var coordinate = new Coordinate(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 }
            });

      Assert.True(coordinate.Equals(coordinate));
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
    public void Direction_WhenSecondIsNull_ReturnFalse()
    {
      var direction1 = new Direction(1.0, 2.0, 3.0);

      Assert.False(direction1.Equals(null));
    }

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
    public void Resolution_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Resolution(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Property_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Property(1, 1);
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Properties_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Common.Data.GeoJson.Properties(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Coordinate_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Coordinate(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void CRS_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new CRS(123);
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void DerivedData_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new DerivedData(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

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
    public void Geometry_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Geometry(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void ObservationLines_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new ObservationLines(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Point_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Point(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void Polygon_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new Polygon(new Dictionary<string, object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void PositionStdev_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionStdev(new Dictionary<string, object>(), new List<object>());
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void PositionXY_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionXY(new List<object>(), 1);
      var result = obj1.Equals(null);

      Assert.False(result);
    }

    [Fact]
    public void PositionXYZ_Equals_ReturnsFalseForSecondObjectNull()
    {
      var obj1 = new PositionXYZ(new Dictionary<string, object>());
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

    [Fact]
    public void Matrix_Equals_ReturnsTrueForEqualMatrices()
    {
      var matrix1 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 },
            }, 3, 1);

      var matrix2 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 },
            }, 3, 1);

      bool result = matrix1.Equals(matrix2);

      Assert.True(result);
    }

    [Fact]
    public void Matrix_Equals_ReturnsFalseForUnequalMatrices()
    {
      var matrix1 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 },
            }, 3, 1);

      var matrix2 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 4.0 },
            }, 3, 1);

      bool result = matrix1.Equals(matrix2);

      Assert.False(result);
    }
    [Fact]
    public void Matrix_Equals_ReturnsFalseForUnequalSizeOfMatrices()
    {
      var matrix1 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 },
            }, 3, 1);

      var matrix2 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 }
            }, 2, 1);

      bool result = matrix1.Equals(matrix2);

      Assert.False(result);
    }

    [Fact]
    public void Matrix_Equals_ReturnsFalseForNullValurOfSecondObject()
    {
      var matrix1 = new Matrix(new Dictionary<string, object>
            {
                { "0", 1.0 },
                { "1", 2.0 },
                { "2", 3.0 },
            }, 3, 1);
      ;

      bool result = matrix1.Equals(null);

      Assert.False(result);
    }
  }
}



