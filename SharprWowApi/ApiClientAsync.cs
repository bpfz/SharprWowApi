using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi
{
    public class ApiClientAsync : GetDataAsync
    {
        /// <summary>
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public ApiClientAsync(Region region, Locale locale, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                _Region = region;
                _Locale = locale;
                _APIKey = apiKey;

                switch (_Region)
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
        public ApiClientAsync(Region region, Locale locale, string apiKey, string realm)
        {

            if (!string.IsNullOrEmpty(apiKey))
            {
                _Region = region;
                _Locale = locale;
                _APIKey = apiKey;
                _Realm = realm;

                switch (_Region)
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
            else
            {
                throw new Exception("Api key missing");
            }
        }
    }
}
