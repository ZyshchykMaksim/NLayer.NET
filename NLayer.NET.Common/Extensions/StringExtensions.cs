using System;
using System.Text.RegularExpressions;

namespace NLayer.Common.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get the first characters.
        /// </summary>
        /// <param name="str">The line.</param>
        /// <param name="maxLength">The length.</param>
        /// <returns></returns>
        public static string ToTruncateLongString(this string str, int maxLength)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Length <= maxLength)
                {
                    return str;
                }

                return $"{str.Substring(0, Math.Min(str.Length, maxLength))} ...";
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns true/false if there is a matching pattern
        /// </summary>
        /// <param name="value">The line.</param>
        /// <param name="pattern">The found pattern.</param>
        /// <returns></returns>
        public static bool IsMatch(this string value, string pattern)
        {
            pattern = Regex.Escape(pattern);

            return Regex.IsMatch(value, pattern);
        }
    }
}
