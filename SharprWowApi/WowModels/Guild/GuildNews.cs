
namespace SharprWowApi.WowModels.Guild
{
    public class GuildNews
    {
        public string Type { get; set; }
        public string Character { get; set; }
        public long Timestamp { get; set; }
        public int ItemId { get; set; }
        public GuildAchievement Achievement { get; set; }
    }
}
