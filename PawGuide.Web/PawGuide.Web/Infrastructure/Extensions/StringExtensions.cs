namespace PawGuide.Web.Infrastructure.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
            => Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();

        public static string ToImageName(this string text, int id, string businessType, string businessName)
            => text
                .Substring(text.LastIndexOf('.'))
                .Insert(0, $"{id}-{businessType}-{businessName}")
                .ToLower();
    }
}
