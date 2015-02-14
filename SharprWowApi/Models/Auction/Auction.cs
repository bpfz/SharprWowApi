
using System;
using System.Collections.Generic;
using SharprWowApi.Utility.ExtensionMethods;
namespace SharprWowApi.Models.Auction
{
    public class Auction
    {
        public int Auc { get; set; }
        public int Item { get; set; }
        public string Owner { get; set; }
        public string OwnerRealm { get; set; }

        /// <summary>
        /// gets bid gets buyout (gold+silver+bronze) as one number
        /// </summary>
        public string Bid { get; set; }

        /// <summary>
        /// gets buyout (gold+silver+bronze) as one number
        /// </summary>
        public string Buyout { get; set; }

        public int Quantity { get; set; }
        public string TimeLeft { get; set; }
        public int Rand { get; set; }
        public string Seed { get; set; }
        public int Context { get; set; }
        public List<BonusList> BonusLists { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public int? PetSpeciesId { get; set; }
        public int? PetBreedId { get; set; }
        public int? PetLevel { get; set; }
        public int? PetQualityId { get; set; }

        public string BidGold { get { return Bid.RemoveTail(4); } }
        public string BidSilver { get { return Bid.Tail(4).RemoveTail(2); } }
        public string BidCopper { get { return Bid.Tail(2); } }

        public string BuyoutGold { get { return Buyout.RemoveTail(4); } }
        public string BuyoutSilver { get { return Buyout.Tail(4).RemoveTail(2); } }
        public string BuyoutCopper { get { return Buyout.Tail(2); } }
    }
}
