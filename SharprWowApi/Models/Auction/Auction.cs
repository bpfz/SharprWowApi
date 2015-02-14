
using System.Collections.Generic;
namespace SharprWowApi.Models.Auction
{
    public class Auction
    {
        public int Auc { get; set; }
        public int Item { get; set; }
        public string Owner { get; set; }
        public string OwnerRealm { get; set; }
        public string Bid { get; set; }
        public string Buyout { get; set; }
        public int Quantity { get; set; }
        public string TimeLeft { get; set; }
        public int Rand { get; set; }
        public object Seed { get; set; }
        public int Context { get; set; }
        public List<BonusList> BonusLists { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public int? PetSpeciesId { get; set; }
        public int? PetBreedId { get; set; }
        public int? PetLevel { get; set; }
        public int? PetQualityId { get; set; }
    }
}
