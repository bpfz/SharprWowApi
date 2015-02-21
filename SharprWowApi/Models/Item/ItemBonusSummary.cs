using System.Collections.Generic;

namespace SharprWowApi.Models.Item
{
    public class ItemBonusSummary
    {
        public IEnumerable<object> DefaultBonusLists { get; set; }

        public IEnumerable<object> ChanceBonusLists { get; set; }

        public IEnumerable<object> BonusChances { get; set; }
    }
}
