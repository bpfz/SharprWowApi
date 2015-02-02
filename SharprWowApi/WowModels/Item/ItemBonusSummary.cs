using System.Collections.Generic;

namespace SharprWowApi.WowModels.Item
{
    public class ItemBonusSummary
    {
        public List<object> DefaultBonusLists { get; set; }
        public List<object> ChanceBonusLists { get; set; }
        public List<object> BonusChances { get; set; }
    }
}
