using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility.ExtensionMethods
{
    public static class ExtensionMethods
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

        /// <summary>
        /// From long gets unix time and returns datetime.
        /// Divides by 1000 (blizzard added some zeros).
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this long unixTimeStamp)
        {
            unixTimeStamp = unixTimeStamp / 1000;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
