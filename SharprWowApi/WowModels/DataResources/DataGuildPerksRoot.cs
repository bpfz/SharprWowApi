using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataGuildPerksRoot
    {
        public List<Perk> perks { get; set; }
    }
    public class Spell
    {
        public int id { get; set; }
        public string name { get; set; }
        public string subtext { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string castTime { get; set; }
        public string range { get; set; }
        public string cooldown { get; set; }
    }

    public class Perk
    {
        public int guildLevel { get; set; }
        public Spell spell { get; set; }
    }
}
