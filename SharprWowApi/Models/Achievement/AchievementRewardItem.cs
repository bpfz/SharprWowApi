using System.Collections.Generic;

namespace SharprWowApi.Models.Achievement
{
    public class AchievementRewardItem
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
}
