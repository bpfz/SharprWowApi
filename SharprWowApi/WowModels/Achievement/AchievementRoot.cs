﻿using System.Collections.Generic;

namespace SharprWowApi.WowModels.Achievement
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
        public List<AchievementRewardItem> RewardItems { get; set; }
        public string Icon { get; set; }
        public List<AchiviementCriteria> Criteria { get; set; }
        public bool AccountWide { get; set; }
        public int FactionId { get; set; }
    }

    /// <summary>
    /// Unused?
    /// </summary>
    public class TooltipParams
    {
    }
}