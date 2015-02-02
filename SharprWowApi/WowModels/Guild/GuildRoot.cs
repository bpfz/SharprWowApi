using System.Collections.Generic;

namespace SharprWowApi.WowModels.Guild
{
    public class GuildRoot
    {
        public long LastModified { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }
        public int Level { get; set; }
        public int Side { get; set; }
        public int AchievementPoints { get; set; }
        public GuildAchievements Achievements { get; set; }
        public List<GuildMember> Members { get; set; }
        public GuildEmblem Emblem { get; set; }
        public List<GuildNews> News { get; set; }
        public List<GuildChallenge> Challenge { get; set; }
    }
}

