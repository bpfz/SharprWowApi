using SharprWowApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi
{
    public abstract class GetDataBase
    {
        internal Region _Region { get; set; }
        internal Locale _Locale { get; set; }
        internal string _APIKey { get; set; }
        internal string _Host { get; set; }
        internal string _Realm { get; set; }
    }
}
