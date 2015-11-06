using System.Collections.Generic;
using Newtonsoft.Json;
using SharprWowApi.Utility;
using System;

namespace SharprWowApi.Models.Auction
{
    [Obsolete("Auctionslist has been replaced with Auction")]
    public class AuctionsList
    {
        [Obsolete("Now use AuctionRoot.Auctions")]
        [JsonProperty("auctions")]
        public IEnumerable<Auction> Auction { get; set; }
    }
}
