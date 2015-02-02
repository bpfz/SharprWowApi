using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.DataResources
{
    public class DataItemClassRoot
    {
        public List<ItemClass> classes { get; set; }
    }
    public class ItemSubclass
    {
        public int subclass { get; set; }
        public string name { get; set; }
    }

    public class ItemClass
    {
        public int itemClass { get; set; }
        public string name { get; set; }
        public List<ItemSubclass> subclasses { get; set; }
    }
}
