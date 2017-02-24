// ReSharper disable once CheckNamespace
namespace System
{
  internal static class StringExtensions
  {
    public static string FirstCharacterToLower(this string str)
    {
      return (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
        ? str : $"{char.ToLowerInvariant(str[0])}{str.Substring(1)}";
    }
  }
}
