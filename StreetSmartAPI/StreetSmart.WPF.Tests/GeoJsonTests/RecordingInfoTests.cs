using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class RecordingInfoTests
  {
    [Fact]
    public void RecordingInfo_WhenSecondObjectIsNull_ReturnFalse()
    {
      var recordinginfo = new RecordingInfo(new Dictionary<string, object> {
                    { "id", "1" }
      });

      Assert.False(recordinginfo.Equals(null));
    }
  }
}
