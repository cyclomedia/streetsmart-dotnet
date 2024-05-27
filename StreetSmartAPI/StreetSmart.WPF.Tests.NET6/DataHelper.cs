using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;

namespace StreetSmart.WPF.Tests.NET6
{
  internal static class DataHelper
  {
    public static readonly Dictionary<string, object> Recording = 
      new()
      {
        { "xyz", new { } },
        { "groundLevelOffset", 5d },
        { "recorderDirection", 6d },
        { "orientation", 32d },
        { "recordedAt", DateTime.Now },
        { "id", "1" },
        { "srs", "2" },
        { "orientationPrecision", 7d },
        { "tileSchema", TileSchema.Dcr9Tiling },
        { "longitudePrecision", 8d },
        { "latitudePrecision", 9d },
        { "heightPrecision", 10d },
        { "productType", ProductType.Cyclorama },
        { "heightSystem", 11d },
        { "expiredAt", DateTime.Now.AddDays(1) },
        { "year", 2023 }
      };

    public static readonly Dictionary<string, object> Orientation = 
      new()
      { 
        {"yaw", 2d},
        {"pitch", 3d },
        {"hFov", 50.2211112d }
      };

    public static readonly Dictionary<string, object> ObliqueOrientation =
      new()
      {
        {"center", new List<object> {1.45678, 23456.6543 } },
        {"extent", new List<object> {2.345678, 3.1245, 4.32567, 57567.76543 } },
        {"resolution", 4 },
        {"rotation", 50.2211112d },
        {"srs", "mySrs" },
      };

    public static readonly Dictionary<string, object> DepthInfo =
      new()
      { 
        { "depth", 2d }, 
        { "depthInMeters", 3d },
        { "xyz", new { } },
        { "srs", "mySrs" }
      };

    public static readonly Dictionary<string, object> TimeTravelInfo =
      new()
      {
        { "date", DateTime.UtcNow } 
      };

    public static readonly Dictionary<string, object> FeatureInfo =
      new()
      {
        { "layerName", "myLayer" },
        { "layerId", "layer2" },
        { "featureProperties", new { } } 
      };

    public static readonly Dictionary<string, object> ObliqueImageInfo =
      new()
      { 
        { "footprint", new List<object> { new List<object> { new List<object> { 1, 2, 3 } } } },
        { "footprintCentre", new List<object> { 4, 5 } },
        { "rotation", 6d },
        { "srs", "mySrs" }
      };

    public static readonly Dictionary<string, object> DirectionInfo =
      new()
      {
        { "direction", 4 }
      };

    public static readonly WFSOverlay wFSOverlay = new("myName", new Uri("http://any.com"), "typeName", "anyVersion", "mySld", false, null);
  }
}
