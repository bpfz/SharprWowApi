using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility.ExtensionMethods
{
    public static class StringExtension
    {
        /// <summary>
        /// Substrings set amount from the Tail. 
        /// IE from the word 'Hello' with tail_length set to 2 it would return 'lo'.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tail_length"></param>
        /// <returns></returns>
        public static string Tail(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        /// <summary>
        /// Removes set amount from the tail of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tail_length"></param>
        /// <returns></returns>
        public static string RemoveTail(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Remove(source.Length - tail_length);
        }

        /// <summary>
        /// Returns title cased string (First letter capital, rest small)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="current_string"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string source)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());
        }
    }
}
