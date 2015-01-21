
namespace SharprWowApi.Models.Auction
{
    public class Auction
    {
        public int Auc { get; set; }
        public long Item { get; set; }
        public string Owner { get; set; }
        public string OwnerRealm { get; set; }
        public long Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public string TimeLeft { get; set; }
        public long Rand { get; set; }
        public long Seed { get; set; }
        public long Context { get; set; }
    }
}
