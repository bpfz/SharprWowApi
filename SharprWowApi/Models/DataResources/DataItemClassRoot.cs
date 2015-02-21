using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharprWowApi.Models.DataResources
{
    public class DataItemClassRoot
    {
        public IEnumerable<ItemClass> Classes { get; set; }
    }

    public class ItemSubclass
    {
        public int Subclass { get; set; }

        public string Name { get; set; }
    }

    public class ItemClass
    {
        [JsonProperty("itemClass")]
        public int ClassOfItem { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemSubclass> Subclasses { get; set; }
    }
}
