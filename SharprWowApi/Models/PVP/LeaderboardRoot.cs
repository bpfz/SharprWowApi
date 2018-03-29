namespace SharprWowApi.Models.Pvp
{
    public class LeaderboardRoot
    {
        public long LastModified { get; set; }

        public string Name { get; set; }

        public string Realm { get; set; }

        public string Battlegroup { get; set; }

        public int Class { get; set; }

        public int Race { get; set; }

        public int Gender { get; set; }

        public int Level { get; set; }

        public int AchievementPoints { get; set; }

        public string Thumbnail { get; set; }

        public string CalcClass { get; set; }

        public int TotalHonorableKills { get; set; }
    }
}
