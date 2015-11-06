using System.Collections.Generic;

namespace SharprWowApi.Models.Auction
{
    public class AuctionsRoot
    {
        public IEnumerable<AuctionRealm> Realms { get; set; }

        public IEnumerable<Auction> Auctions { get; set; }
    }
}
