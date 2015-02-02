using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Profile
{
    public class ProfileRoot
    {
        public string BattleTag { get; set; }
        public int ParagonLevel { get; set; }
        public int ParagonLevelHardcore { get; set; }
        public int ParagonLevelSeason { get; set; }
        public int ParagonLevelSeasonHardcore { get; set; }
        public List<Hero> Heroes { get; set; }
        public int LastHeroPlayed { get; set; }
        public int LastUpdated { get; set; }
        public Kills Kills { get; set; }
        public int HighestHardcoreLevel { get; set; }
        public TimePlayed TimePlayed { get; set; }
        public Progression Progression { get; set; }
        public List<object> FallenHeroes { get; set; }
        public Blacksmith Blacksmith { get; set; }
        public Jeweler Jeweler { get; set; }
        public Mystic Mystic { get; set; }
        public BlacksmithHardcore BlacksmithHardcore { get; set; }
        public JewelerHardcore JewelerHardcore { get; set; }
        public MysticHardcore MysticHardcore { get; set; }
        public BlacksmithSeason BlacksmithSeason { get; set; }
        public JewelerSeason JewelerSeason { get; set; }
        public MysticSeason MysticSeason { get; set; }
        public BlacksmithSeasonHardcore BlacksmithSeasonHardcore { get; set; }
        public JewelerSeasonHardcore JewelerSeasonHardcore { get; set; }
        public MysticSeasonHardcore MysticSeasonHardcore { get; set; }
        public SeasonalProfiles SeasonalProfiles { get; set; }
    }

    public class Hero
    {
        public int ParagonLevel { get; set; }
        public bool Seasonal { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Level { get; set; }
        public bool Hardcore { get; set; }
        public int Gender { get; set; }
        public bool Dead { get; set; }
        public string @Class { get; set; }
        public int LastUpdated { get; set; }
    }

    public class Kills
    {
        public int Monsters { get; set; }
        public int Elites { get; set; }
        public int HardcoreMonsters { get; set; }
    }

    public class TimePlayed
    {
        public double barbarian { get; set; }
        public double crusader { get; set; }
        public double DemonHunter { get; set; }
        public double monk { get; set; }
        public double WitchDoctor { get; set; }
        public double wizard { get; set; }
    }

    public class Progression
    {
        public bool act1 { get; set; }
        public bool act2 { get; set; }
        public bool act3 { get; set; }
        public bool act4 { get; set; }
        public bool act5 { get; set; }
    }

    public class Blacksmith
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class Jeweler
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class Mystic
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class BlacksmithHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class JewelerHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class MysticHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class BlacksmithSeason
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class JewelerSeason
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class MysticSeason
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class BlacksmithSeasonHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class JewelerSeasonHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class MysticSeasonHardcore
    {
        public string slug { get; set; }
        public int level { get; set; }
        public int stepCurrent { get; set; }
        public int stepMax { get; set; }
    }

    public class Progression2
    {
        public bool act1 { get; set; }
        public bool act2 { get; set; }
        public bool act3 { get; set; }
        public bool act4 { get; set; }
        public bool act5 { get; set; }
    }

    public class Season
    {
        public int seasonId { get; set; }
        public int paragonLevel { get; set; }
        public int paragonLevelHardcore { get; set; }
        public Kills kills { get; set; }
        public TimePlayed timePlayed { get; set; }
        public int highestHardcoreLevel { get; set; }
        public Progression progression { get; set; }
    }

    public class SeasonalProfiles
    {
        public Season season0 { get; set; }
        public Season season1 { get; set; }
    }
}
