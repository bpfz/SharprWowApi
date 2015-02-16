using Newtonsoft.Json;
using SharprWowApi.Utility;
using System.Collections.Generic;

namespace SharprWowApi.Models.Auction
{
    public class AuctionsList
    {
        [JsonProperty("auctions")]
        public IEnumerable<Auction> Auction { get; set; }
    }
}
