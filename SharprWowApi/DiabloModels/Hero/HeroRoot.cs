using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class HeroRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string @Class { get; set; }
        public int Gender { get; set; }
        public int Level { get; set; }
        public int ParagonLevel { get; set; }
        public bool Hardcore { get; set; }
        public bool Seasonal { get; set; }
        public int SeasonCreated { get; set; }
        public Skills Skills { get; set; }
        public Items Items { get; set; }
        public Followers Followers { get; set; }
        public Stats Stats { get; set; }
        public Kills Kills { get; set; }
        public Progression Progression { get; set; }
        public bool Dead { get; set; }

        [JsonProperty("last-updated")]
        public int LastUpdated { get; set; }
    }

    public class Kills
    {
        public int elites { get; set; }
    }

}
