using StreetSmart.Common.Data.GeoJson;
using System.Collections.Generic;
using Xunit;

namespace StreetSmart.WPF.Tests.GeoJsonTests
{
  public class MatrixTests
  {
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
