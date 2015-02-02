using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.DataResources
{
    class ArtisanData
    {
    }
    public class Level
    {
        public int tier { get; set; }
        public int tierLevel { get; set; }
        public int percent { get; set; }
        public List<object> trainedRecipes { get; set; }
        public List<object> taughtRecipes { get; set; }
        public int upgradeCost { get; set; }
        public List<object> upgradeItems { get; set; }
    }

    public class Tier
    {
        public int tier { get; set; }
        public List<Level> levels { get; set; }
    }

    public class Training
    {
        public List<Tier> tiers { get; set; }
    }

    public class RootObject
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string portrait { get; set; }
        public Training training { get; set; }
    }
}
