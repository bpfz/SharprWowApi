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
        /// IE from the word 'Hello' with tailLength set to 2 it would return 'lo'.
        /// </summary>
        /// <param name="source">string to modify</param>
        /// <param name="tailLength">length to take</param>
        /// <returns>Substring of string</returns>
        public static string Tail(this string source, int tailLength)
        {
            if (tailLength >= source.Length)
            {
                return source;
            }

            return source.Substring(source.Length - tailLength);
        }

        /// <summary>
        /// Removes set amount from the tail of the string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tailLength">Length to remove</param>
        /// <returns>String with removed tail.</returns>
        public static string RemoveTail(this string source, int tailLength)
        {
            if (tailLength >= source.Length)
            {
                return source;
            }

            return source.Remove(source.Length - tailLength);
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
        /// From long gets unix time and returns date time.
        /// Divides by 1000 (blizzard added some zeros).
        /// </summary>
        /// <param name="unixTimeStamp">time stamp in unix format</param>
        /// <returns>time in DateTime</returns>
        public static DateTime UnixTimestampToDateTime(this long unixTimeStamp)
        {
            unixTimeStamp = unixTimeStamp / 1000;
            System.DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
