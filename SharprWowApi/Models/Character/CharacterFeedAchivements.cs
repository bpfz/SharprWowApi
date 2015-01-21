﻿using System.Collections.Generic;

namespace SharprWowApi.Models
{
    public class CharacterFeedAchivements
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public List<object> RewardItems { get; set; }
        public string Icon { get; set; }
        public List<object> Criteria { get; set; }
        public bool AccountWide { get; set; }
        public int FactionId { get; set; }
        public string Reward { get; set; }
    }
}