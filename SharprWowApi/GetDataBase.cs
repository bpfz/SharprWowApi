using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharprWowApi.Utility;

namespace SharprWowApi
{
    public abstract class GetDataBase
    {
        internal Region Region { get; set; }

        internal Locale Locale { get; set; }

        internal string APIKey { get; set; }

        internal string Host { get; set; }

        internal string Realm { get; set; }

    }
}
