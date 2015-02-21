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
        internal Region _Region { get; set; }

        internal Locale _Locale { get; set; }

        internal string _APIKey { get; set; }

        internal string _Host { get; set; }

        internal string _Realm { get; set; }

        internal string UrlStringBuilder(string param, string name, CharacterOptions characterOptions, string realm)
        {
            this._Realm = realm;

            var uriBuilder = new UriBuilder();
            uriBuilder.Host = this._Host;
            uriBuilder.Path = string.Format(
                @"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                this._Host,
                realm,
                name,
                this._Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                this._APIKey);

            uriBuilder.Scheme = "Https";

            return uriBuilder.ToString();
        }
    }
}
