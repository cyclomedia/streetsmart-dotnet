using System;
using System.Collections.Generic;

namespace StreetSmart.WPF.Tests.TestData
{
  internal class GeoJsonTestData
  {
    public static Dictionary<string, object> GetRandomPositionXYZ() => new()
    {
      { "x", 1.2}, { "y", 2.3}, { "z", 3.4 }
    };

    public static Dictionary<string, object> GetRandomDirection() => new()
    {
      { "0", 1.21 }, { "1", 2.345 }, {"2", 12456.65 }
    };

    public static List<object> GetRandomXYZStdev() => [1, 233.2, 2345.2234];

    public static Dictionary<string, object> GetRandomRecordingInfo() => new()
    {
      { "id", "hjio21234a" },
      { "xyz", GetRandomPositionXYZ() },
      { "yaw", 123.1 },
      { "srs", "EPSG:1111" },
      { "xyzStdev", GetRandomXYZStdev() },
      { "yawStdev", 0.00002123 },
      { "depthStdev", 0.0000111 },
      { "recordedAt", DateTime.Now.ToString("o") }
    };

    public static Dictionary<string, object> GetRandomDetailsDepth() => new()
    {
      { "position", GetRandomPositionXYZ() },
      { "direction", GetRandomDirection() },
      { "depthInMeters", 213245.897 },
      { "depth", 123.2345 },
      { "recordingInfo", GetRandomRecordingInfo() },
    };

    public static Dictionary<string, object> GetRandomDetailsSmartClick()
    {
      var dict = GetRandomDetailsForwardIntersection();
      dict.Add("Confidence", 5);
      dict.Add("Depth", 12.234555);
      return dict;
    }

    public static Dictionary<string, object> GetRandomDetailsForwardIntersection() => new()
    {
      { "PositionX", 126.9948 },
      { "PositionY", 9879.65489 },
      { "PositionZ", 5656988.7789 },
      { "ResultDirections", new Dictionary<string, object>
        {
          { "ResultDirection", new List<object> { new Dictionary<string, object> { 
            // TODO Add something here
                                                                                  
      } } } } }
    };
  }
}
