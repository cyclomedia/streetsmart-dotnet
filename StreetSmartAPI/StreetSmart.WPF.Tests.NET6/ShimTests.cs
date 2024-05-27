using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;
using System;

namespace StreetSmart.WPF.Tests.NET6
{
  [TestClass]
  public class ShimTests
  {
    [TestMethod]
    public void Test_ReplaceConsole()
    {
      string? written = null;
      var consoleShim = Shim.Replace(() => Console.WriteLine(Is.A<string>())).With(delegate (string s) { written = string.Format("Hijacked: {0}", s); });
      PoseContext.Isolate(() =>
      {
        Console.WriteLine("Hello World!");
      }, consoleShim);

      Assert.AreEqual("Hijacked: Hello World!", written);
    }

    [TestMethod]
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

      Assert.AreEqual(result, new DateTime(2004, 4, 4, 1, 1, 0, DateTimeKind.Utc).ToString("g"));
    }
  }
}
