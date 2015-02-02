using System.Collections.Generic;

namespace SharprWowApi.WowModels.Item
{
    public class ItemSetRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemSetBonus> SetBonuses { get; set; }
        public List<int> Items { get; set; }
    }
}
