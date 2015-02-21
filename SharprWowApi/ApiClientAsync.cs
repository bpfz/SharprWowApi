namespace SharprWowApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Client to use to get data from the api.
    /// </summary>
    public class ApiClientAsync : GetDataAsync
    {
        /// <summary>
        /// Initializes a new instance of the ApiClientAsync class.
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public ApiClientAsync(Region region, Locale locale, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                this._Region = region;
                this._Locale = locale;
                this._APIKey = apiKey;

                this.Host(this._Region);
            }
            else
            {
                throw new Exception("Api key missing");
            }
        }

        /// <summary>
        /// Initializes a new instance of the ApiClientAsync class.
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        /// <param name="realm"></param>
        public ApiClientAsync(Region region, Locale locale, string apiKey, string realm)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                this._Region = region;
                this._Locale = locale;
                this._APIKey = apiKey;
                this._Realm = realm;

                this.Host(this._Region);
            }
            else
            {
                throw new Exception("Api key missing");
            }
        }

        private void Host(Region region)
        {
            switch (region)
            {
                case Region.EU:
                    this._Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    this._Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    this._Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    this._Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    this._Host = "https://us.api.battle.net";
                    break;
            }
        }
    }
}
