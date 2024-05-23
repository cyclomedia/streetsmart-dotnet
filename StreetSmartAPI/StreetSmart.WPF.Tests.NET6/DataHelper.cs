using StreetSmart.Common.Data;
using StreetSmart.Common.Interfaces.Data;
using System;
using System.Collections.Generic;

namespace StreetSmart.WPF.Tests.NET6
{
  internal static class DataHelper
  {
    public static IRecording Recording => new Recording(_recording);

    private static readonly Dictionary<string, object> _recording = new()
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

    public static IOrientation Orientation => new Orientation(2d, 3d, 50.2211112d);

    public static IDepthInfo DepthInfo => new DepthInfo(new Dictionary<string, object> { { "depth", 2d }, { "depthInMeters", 3d }, { "xyz", new { } }, { "srs", "mySrs" } });

    public static ITimeTravelInfo TimeTravelInfo => new TimeTravelInfo(new Dictionary<string, object> { { "date", DateTime.UtcNow } });

    public static IFeatureInfo FeatureInfo => new FeatureInfo(new Dictionary<string, object> { { "layerName", "myLayer" }, { "layerId", "layer2" }, { "featureProperties", new { } } });
  }
}
