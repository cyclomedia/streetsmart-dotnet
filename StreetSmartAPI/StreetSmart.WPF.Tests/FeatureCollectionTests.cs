using System;
using System.Collections.Generic;
using StreetSmart.Common.Data.GeoJson;
using StreetSmart.Common.Interfaces.GeoJson;
using Xunit;
using System.Reflection;
using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;

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
      var feature1 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));
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
      var feature2 = new Feature(new LineString(new List<ICoordinate> { new Coordinate(1, 1), new Coordinate(2, 2) }));

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
      var feature1 = new Feature(new LineString(new List<ICoordinate>
    {
        new Coordinate(1, 1),
        new Coordinate(2, 2)
    }));

      var feature2 = new Feature(new LineString(new List<ICoordinate>
    {
        new Coordinate(2, 2),
        new Coordinate(1, 1)
    }));

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
      var lineString = new Feature(new LineString(new List<ICoordinate>{new Coordinate(1, 1),new Coordinate(2, 2)}));
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
      Assert.IsType<Properties>(feature.Properties);
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

      var properties = new Properties(propertiesData);

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

      var properties1 = new Properties(propertiesData);
      var properties2 = new Properties(propertiesData);

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

      var properties1 = new Properties(propertiesData1);
      var properties2 = new Properties(propertiesData2);

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
      var data1 = new DerivedDataLineString(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataLineString(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPoint_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedDataPoint(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPoint(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPoint_WhenObjectsAreNotEquals_ReturnsFalse()
    {
      var data1 = new DerivedDataPoint(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPoint(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "ft" },
            { "precision", 2 }
        });

      Assert.False(data1.Equals(data2));
    }
    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreEquals_ReturnsTrue()
    {
      var data1 = new DerivedDataPolygon(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPolygon(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      Assert.True(data1.Equals(data2));
    }

    [Fact]
    public void DerivedDataPolygon_WhenObjectsAreNotEquals_ReturnsFalse()
    {
      var data1 = new DerivedDataPolygon(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "m" },
            { "precision", 2 }
        });

      var data2 = new DerivedDataPolygon(new System.Collections.Generic.Dictionary<string, object>
        {
            { "unit", "ft" },
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
    public void DetailsForwardIntersection_Equality_Null()
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
    public void DetailsSmartClick_Equals_SameInstance()
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
    public void DetailsSmartClick_Equals_EqualObjects()
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
    public void DetailsSmartClick_Equals_NullObject()
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
    public void DetailsSmartClick_Equals_DifferentObjects()
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
  }
}


