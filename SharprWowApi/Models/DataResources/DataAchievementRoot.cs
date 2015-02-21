using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataAchievementRoot
    {
        public IEnumerable<Achievement> Achievements { get; set; }
    }

    public class Achievement
    {
        public int Id { get; set; }

        public IEnumerable<SubAchievement> Achievements { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }

    public class SubAchievement
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

        public string Reward { get; set; }
    }

    public class SubSubAchievement
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

        public string Reward { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public IEnumerable<SubSubAchievement> Achievements { get; set; }

        public string Name { get; set; }
    }
}
