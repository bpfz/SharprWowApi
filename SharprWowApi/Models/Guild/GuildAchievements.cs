using System.Collections.Generic;

namespace SharprWowApi.Models.Guild
{
    public class GuildAchievements
    {
        public IEnumerable<int> AchievementsCompleted { get; set; }

        public IEnumerable<object> AchievementsCompletedTimestamp { get; set; }

        public IEnumerable<int> Criteria { get; set; }

        public IEnumerable<object> CriteriaQuantity { get; set; }

        public IEnumerable<object> CriteriaTimestamp { get; set; }

        public IEnumerable<object> CriteriaCreated { get; set; }
    }
}
