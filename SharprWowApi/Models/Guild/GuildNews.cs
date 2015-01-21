
namespace SharprWowApi.Models.Guild
{
    public class GuildNews
    {
        public string Type { get; set; }
        public string Character { get; set; }
        public object Timestamp { get; set; }
        public int ItemId { get; set; }
        public GuildAchievement Achievement { get; set; }
    }
}
