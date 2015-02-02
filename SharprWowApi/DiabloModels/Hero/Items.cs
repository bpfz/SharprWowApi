using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string displayColor { get; set; }
        public string tooltipParams { get; set; }
        public List<object> craftedBy { get; set; }
    }

    public class Items
    {
        public Item Torso { get; set; }
        public Item Feet { get; set; }
        public Item Shoulders { get; set; }
        public Item Bracers { get; set; }
        public Item MainHand { get; set; }
        public Item OffHand { get; set; }
        public Item Waist { get; set; }
        public Item RightFinger { get; set; }
        public Item LeftFinger { get; set; }
        public Item Neck { get; set; }
    }
}
