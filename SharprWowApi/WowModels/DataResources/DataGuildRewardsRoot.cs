using SharprWowApi.Models.Achievement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataGuildRewardsRoot
    {
        public List<Reward> rewards { get; set; }
    }
    public class RewardItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams tooltipParams { get; set; }
        public List<object> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
    }

    public class DataGuildAchievement
    {
        public int id { get; set; }
        public string title { get; set; }
        public int points { get; set; }
        public string description { get; set; }
        public string reward { get; set; }
        public List<RewardItem> rewardItems { get; set; }
        public string icon { get; set; }
        public List<object> criteria { get; set; }
        public bool accountWide { get; set; }
        public int factionId { get; set; }
    }

    /// <summary>
    /// Unused?
    /// </summary>
    public class TooltipParams2
    {
    }

    public class GuildItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams2 tooltipParams { get; set; }
        public List<object> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
    }

    public class Reward
    {
        public int minGuildLevel { get; set; }
        public int minGuildRepLevel { get; set; }
        public DataGuildAchievement achievement { get; set; }
        public GuildItem item { get; set; }
        public List<int?> races { get; set; }
    }

}
