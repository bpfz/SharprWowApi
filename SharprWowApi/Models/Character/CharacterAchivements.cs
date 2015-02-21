using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterAchievements
    {
        public IEnumerable<int> AchievementsCompleted { get; set; }

        public IEnumerable<string> AchievementsCompletedTimestamp { get; set; }

        public IEnumerable<string> Criteria { get; set; }

        public IEnumerable<string> CriteriaQuantity { get; set; }

        public IEnumerable<string> CriteriaTimestamp { get; set; }

        public IEnumerable<string> CriteriaCreated { get; set; }
    }
}
