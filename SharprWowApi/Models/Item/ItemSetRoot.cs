using System.Collections.Generic;

namespace SharprWowApi.Models.Item
{
    public class ItemSetRoot
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemSetBonus> SetBonuses { get; set; }

        public IEnumerable<int> Items { get; set; }
    }
}
