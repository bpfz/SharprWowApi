using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.DataResources
{
    public class DataAchievementRoot
    {
        public List<Achievement> achievements { get; set; }
    }

    public class Achievement
    {
        public int id { get; set; }
        public List<SubAchievement> achievements { get; set; }
        public string name { get; set; }
        public List<Category> categories { get; set; }
    }

    public class SubAchievement
    {
        public int id { get; set; }
        public string title { get; set; }
        public int points { get; set; }
        public string description { get; set; }
        public List<object> rewardItems { get; set; }
        public string icon { get; set; }
        public List<object> criteria { get; set; }
        public bool accountWide { get; set; }
        public int factionId { get; set; }
        public string reward { get; set; }
    }

    public class SubSubAchievement
    {
        public int id { get; set; }
        public string title { get; set; }
        public int points { get; set; }
        public string description { get; set; }
        public List<object> rewardItems { get; set; }
        public string icon { get; set; }
        public List<object> criteria { get; set; }
        public bool accountWide { get; set; }
        public int factionId { get; set; }
        public string reward { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public List<SubSubAchievement> achievements { get; set; }
        public string name { get; set; }
    }




}
