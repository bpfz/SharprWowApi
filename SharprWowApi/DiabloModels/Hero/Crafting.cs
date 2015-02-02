using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class ItemProduced
    {
        public string id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string displayColor { get; set; }
        public string tooltipParams { get; set; }
    }

    public class CraftedBy
    {
        public string id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public List<Reagent> reagents { get; set; }
        public ItemProduced itemProduced { get; set; }
    }

    public class Reagent
    {
        public int quantity { get; set; }
        public Item item { get; set; }
    }
}
