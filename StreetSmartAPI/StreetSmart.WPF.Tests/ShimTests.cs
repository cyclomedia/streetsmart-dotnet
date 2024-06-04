using Pose;
using System;
using Xunit;

namespace StreetSmart.WPF.Tests;

public sealed class ShimTests
{
#if NETCOREAPP
  [Fact]
  public void Test_ReplaceConsole()
  {
    string? written = null;
    var consoleShim = Shim.Replace(() => Console.WriteLine(Is.A<string>())).With(delegate (string s) { written = string.Format("Hijacked: {0}", s); });
    PoseContext.Isolate(() =>
    {
      Console.WriteLine("Hello World!");
    }, consoleShim);

    Assert.Equal("Hijacked: Hello World!", written);
  }

  [Fact]
  public void Test_ReplaceInsideMethod()
  {
    static string myTestMethod()
    {
      return DateTime.Now.ToString("g");
    }

    Shim shim = Shim.Replace(() => DateTime.Now).With(() => new DateTime(2004, 4, 4, 1, 1, 0, DateTimeKind.Utc));
    string result = string.Empty;
    PoseContext.Isolate(() =>
    {
      result = myTestMethod();
    }, shim);

    Assert.Equal(result, new DateTime(2004, 4, 4, 1, 1, 0, DateTimeKind.Utc).ToString("g"));
  }
#endif
}
