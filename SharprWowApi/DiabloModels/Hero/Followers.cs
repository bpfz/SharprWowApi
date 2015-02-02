using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class FollowerStats
    {
        public int goldFind { get; set; }
        public int magicFind { get; set; }
        public int experienceBonus { get; set; }
    }

    public class Templar
    {
        public string slug { get; set; }
        public int level { get; set; }
        public Items items { get; set; }
        public FollowerStats stats { get; set; }
        public List<Skills> skills { get; set; }
    }

    public class Scoundrel
    {
        public string slug { get; set; }
        public int level { get; set; }
        public Items items { get; set; }
        public FollowerStats stats { get; set; }
        public List<Skills> skills { get; set; }
    }

    public class Enchantress
    {
        public string slug { get; set; }
        public int level { get; set; }
        public Items items { get; set; }
        public FollowerStats stats { get; set; }
        public List<Skills> skills { get; set; }
    }

    public class Followers
    {
        public Templar templar { get; set; }
        public Scoundrel scoundrel { get; set; }
        public Enchantress enchantress { get; set; }
    }
}
