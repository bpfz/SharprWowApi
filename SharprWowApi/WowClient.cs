using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi
{
    /// <summary>
    /// Client to use to get data from the api.
    /// </summary>
    public class WowClient : GetDataAsync
    {
        /// <summary>
        /// Initializes a new instance of the ApiClientAsync class.
        /// Set region, locale, your API key and optional Realm
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public WowClient(Region region, Locale locale, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                this.Region = region;
                this.Locale = locale;
                this.APIKey = apiKey;

                this.SetHost(this.Region);
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
        public WowClient(Region region, Locale locale, string apiKey, string realm)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                this.Region = region;
                this.Locale = locale;
                this.APIKey = apiKey;
                this.Realm = realm;

                this.SetHost(this.Region);
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
                    this.Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    this.Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    this.Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    this.Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    this.Host = "https://us.api.battle.net";
                    break;
            }
        }
    }
}
