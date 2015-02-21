using System.Collections.Generic;

namespace SharprWowApi.Models.Guild
{
    public class GuildAchievement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public IEnumerable<object> RewardItems { get; set; }

        public string Icon { get; set; }

        public IEnumerable<object> Criteria { get; set; }

        public bool AccountWide { get; set; }

        public int FactionId { get; set; }
    }
}
