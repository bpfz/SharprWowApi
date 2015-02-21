using System.Collections.Generic;

namespace SharprWowApi.Models.Auction
{
    /// <summary>
    /// Auction APIs currently provide rolling batches of data about current auctions. 
    /// Fetching auction dumps is a two step process that involves checking a per-realm index file to determine 
    /// if a recent dump has been generated and then fetching the most recently generated dump file if necessary.
    /// This API resource provides a per-realm list of recently generated auction house data dumps.
    /// </summary>
    public class AuctionFilesRoot
    {
        public IEnumerable<AuctionFile> Files { get; set; }
    }
}
