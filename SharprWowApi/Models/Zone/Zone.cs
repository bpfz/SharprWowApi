using Newtonsoft.Json;
using System.Collections.Generic;

namespace SharprWowApi.Models.Zone
{
    [JsonObject]
    public class Zone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }

        public int ExpansionId { get; set; }

        public string Patch { get; set; }

        public string NumPlayers { get; set; }

        public bool IsDungeon { get; set; }

        public bool IsRaid { get; set; }

        public int AdvisedMinLevel { get; set; }

        public int AdvisedMaxLevel { get; set; }

        public int AdvisedHeroicMinLevel { get; set; }

        public int AdvisedHeroicMaxLevel { get; set; }

        public IEnumerable<string> AvailableModes { get; set; }

        public int LfgNormalMinGearLevel { get; set; }

        public int LfgHeroicMinGearLevel { get; set; }

        public int Floors { get; set; }

        public IEnumerable<Boss> Bosses { get; set; }
    }
}
