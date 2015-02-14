using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility.ExtensionMethods
{
    public static class StringExtension
    {
        public static string Tail(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        public static string RemoveTail(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Remove(source.Length - tail_length);
        }
    }
}
