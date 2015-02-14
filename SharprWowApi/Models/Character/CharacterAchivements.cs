﻿using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterAchievements
    {
        public List<int> AchievementsCompleted { get; set; }
        public List<object> AchievementsCompletedTimestamp { get; set; }
        public List<int> Criteria { get; set; }
        public List<object> CriteriaQuantity { get; set; }
        public List<object> CriteriaTimestamp { get; set; }
        public List<object> CriteriaCreated { get; set; }
    }
}
