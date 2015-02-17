using System;

namespace SharprWowApi
{

    public class ApiClient : GetData
    {
        /// <summary>
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public ApiClient(Region region, Locale locale, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                _Region = region;
                _Locale = locale;
                _APIKey = apiKey;

                Host(region);
            }
            else
            {
                throw new Exception("Api key missing");
            }
        }

        /// <summary>
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
                _Region = region;
                _Locale = locale;
                _APIKey = apiKey;
                _Realm = realm;

                Host(region);
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
                    _Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    _Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    _Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    _Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    _Host = "https://us.api.battle.net";
                    break;
            }
        }
    }
}
