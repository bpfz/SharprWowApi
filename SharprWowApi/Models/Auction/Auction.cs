﻿
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

        /// <summary>
        /// Returns time left of the item (blizzard formatting is 'VERY_LONG', 'SHORT' etc.). 
        /// Use TimeLeftFormatted if you want title cased strings. 
        /// </summary>
        public string TimeLeft { get; set; }

        public int Rand { get; set; }
        public string Seed { get; set; }
        public int Context { get; set; }
        public IEnumerable<BonusList> BonusLists { get; set; }
        public IEnumerable<Modifier> Modifiers { get; set; }
        public int? PetSpeciesId { get; set; }
        public int? PetBreedId { get; set; }
        public int? PetLevel { get; set; }
        public int? PetQualityId { get; set; }

        #region mine
        /// <summary>
        /// Gets only gold
        /// </summary>
        public string BidGold { get { if (Buyout.Length > 4)  return Bid.RemoveTail(4); else return "NA"; } }

        /// <summary>
        /// Gets only silver
        /// </summary>
        public string BidSilver { get { return Bid.Tail(4).RemoveTail(2); } }
        /// <summary>
        /// Gets only coppper
        /// </summary>
        public string BidCopper { get { return Bid.Tail(2); } }

        /// <summary>
        /// Gets only gold
        /// </summary>
        public string BuyoutGold { get { if (Buyout.Length > 4) return Buyout.RemoveTail(4); else return "NA"; } }
        /// <summary>
        /// Gets only silver
        /// </summary>
        public string BuyoutSilver { get { return Buyout.Tail(4).RemoveTail(2); } }

        /// <summary>
        /// Gets only coppper
        /// </summary>
        public string BuyoutCopper { get { return Buyout.Tail(2); } }

        /// <summary>
        /// Get time left that's formatted to title case with underscores removed.
        /// </summary>
        public string TimeLeftFormatted { get { return TimeLeft.ToTitleCase().Replace("_", " "); } }
        #endregion
    }
}
