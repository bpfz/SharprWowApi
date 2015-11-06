using System;

namespace SharprWowApi
{
    public class ApiClient : GetData
    {
        /// <summary>
        /// Initializes a new instance of the ApiClient class.
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public ApiClient(Region region, Locale locale, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                Region = region;
                Locale = locale;
                APIKey = apiKey;

                this.SetHost(region);
            }
            else
            {
                throw new Exception("Api key missing");
            }
        }

        /// <summary>
        /// Initializes a new instance of the ApiClient class.
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        /// <param name="realm"></param>
        public ApiClient(Region region, Locale locale, string apiKey, string realm)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                Region = region;
                Locale = locale;
                APIKey = apiKey;
                Realm = realm;

                this.SetHost(region);
            }
            else
            {
                throw new Exception("Api key missing");
            }
        }

        private void SetHost(Region region)
        {
            switch (region)
            {
                case Region.EU:
                    base.Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    base.Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    base.Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    base.Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    base.Host = "https://us.api.battle.net";
                    break;
            }
        }
    }
}
