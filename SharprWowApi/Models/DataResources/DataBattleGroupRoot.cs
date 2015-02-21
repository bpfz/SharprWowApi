using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataBattleGroupRoot
    {
        public IEnumerable<Battlegroup> Battlegroups { get; set; }
    }

    public class Battlegroup
    {
        public string Name { get; set; }

        public string Slug { get; set; }
    }
}
