using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharprWowApi.Models.Achievement;

namespace SharprWowApi.Models.DataResources
{
    public class DataGuildRewardsRoot
    {
        public IEnumerable<Reward> Rewards { get; set; }
    }

    public class RewardItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Quality { get; set; }

        public int ItemLevel { get; set; }

        public TooltipParams TooltipParams { get; set; }

        public IEnumerable<object> Stats { get; set; }

        public int Armor { get; set; }

        public string Context { get; set; }

        public IEnumerable<object> BonusLists { get; set; }
    }

    public class DataGuildAchievement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public string Reward { get; set; }

        public IEnumerable<RewardItem> RewardItems { get; set; }

        public string Icon { get; set; }

        public IEnumerable<object> Criteria { get; set; }

        public bool AccountWide { get; set; }

        public int FactionId { get; set; }
    }

    /// <summary>
    /// Unused?
    /// </summary>
    public class TooltipParams2
    {
    }

    public class GuildItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Quality { get; set; }

        public int ItemLevel { get; set; }

        public TooltipParams2 TooltipParams { get; set; }

        public IEnumerable<object> Stats { get; set; }

        public int Armor { get; set; }

        public string Context { get; set; }

        public IEnumerable<object> BonusLists { get; set; }
    }

    public class Reward
    {
        public int MinGuildLevel { get; set; }

        public int MinGuildRepLevel { get; set; }

        public DataGuildAchievement Achievement { get; set; }

        public GuildItem Item { get; set; }

        public IEnumerable<int?> Races { get; set; }
    }
}
