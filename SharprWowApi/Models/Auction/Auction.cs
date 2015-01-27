
using System.Collections.Generic;
namespace SharprWowApi.Models.Auction
{
    public class Auction
    {
        public int auc { get; set; }
        public int item { get; set; }
        public string owner { get; set; }
        public string ownerRealm { get; set; }
        public object bid { get; set; }
        public object buyout { get; set; }
        public int quantity { get; set; }
        public string timeLeft { get; set; }
        public int rand { get; set; }
        public object seed { get; set; }
        public int context { get; set; }
        public List<BonusList> bonusLists { get; set; }
        public List<Modifier> modifiers { get; set; }
        public int? petSpeciesId { get; set; }
        public int? petBreedId { get; set; }
        public int? petLevel { get; set; }
        public int? petQualityId { get; set; }
    }
}
