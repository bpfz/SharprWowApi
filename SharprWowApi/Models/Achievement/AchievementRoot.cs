using System;
using System.Collections.Generic;

namespace SharprWowApi.Models.Achievement
{
    /// <summary>
    /// This provides data about an individual achievement.
    /// </summary>
    public class AchievementRoot
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public string Reward { get; set; }

        public IEnumerable<AchievementRewardItem> RewardItems { get; set; }

        public string Icon { get; set; }

        public IEnumerable<AchiviementCriteria> Criteria { get; set; }

        public bool AccountWide { get; set; }

        public int FactionId { get; set; }

        public WoWFaction Faction
        {
            get
            {
                return (WoWFaction)Enum.Parse(typeof(WoWFaction), Enum.GetName(typeof(WoWFaction), this.FactionId));
            }
        }
    }

    /// <summary>
    /// Unused?
    /// </summary>
    public class TooltipParams
    {
    }
}
