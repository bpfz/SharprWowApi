using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Guild
{
    public class ChallengeGuild
    {
        public string Name { get; set; }

        public string Realm { get; set; }

        public string Battlegroup { get; set; }

        public int Members { get; set; }

        public int AchievementPoints { get; set; }

        public GuildEmblem Emblem { get; set; }
    }
}
