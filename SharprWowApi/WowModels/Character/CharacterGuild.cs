using SharprWowApi.WowModels.Guild;

namespace SharprWowApi.WowModels
{
    public class CharacterGuild
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }
        public int Members { get; set; }
        public int AchievementPoints { get; set; }
        public GuildEmblem Emblem { get; set; }
    }
}
