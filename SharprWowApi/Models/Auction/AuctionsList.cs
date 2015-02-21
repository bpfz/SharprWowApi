using System.Collections.Generic;
using Newtonsoft.Json;
using SharprWowApi.Utility;

namespace SharprWowApi.Models.Auction
{
    public class AuctionsList
    {
        [JsonProperty("auctions")]
        public IEnumerable<Auction> Auction { get; set; }
    }
}
