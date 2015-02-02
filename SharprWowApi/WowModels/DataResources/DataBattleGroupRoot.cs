using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.DataResources
{
    public class DataBattleGroupRoot
    {
        public List<Battlegroup> battlegroups { get; set; }
    }
    public class Battlegroup
    {
        public string name { get; set; }
        public string slug { get; set; }
    }
}
