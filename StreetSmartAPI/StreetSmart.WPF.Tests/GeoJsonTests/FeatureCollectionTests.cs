using StreetSmart.Common.Data;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
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
  }
}
