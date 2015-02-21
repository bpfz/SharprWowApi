using System;
using System.Collections.Generic;

namespace SharprWowApi.Models.Guild
{
    [Flags]
    public enum WoWFaction
    {
        Alliance = 0,
        Horde = 1
    }

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

        public IEnumerable<GuildMember> Members { get; set; }

        public GuildEmblem Emblem { get; set; }

        public IEnumerable<GuildNews> News { get; set; }

        public IEnumerable<GuildChallenge> Challenge { get; set; }

        public WoWFaction Faction
        {
            get
            {
                return (WoWFaction)Enum.Parse(typeof(WoWFaction), Enum.GetName(typeof(WoWFaction), this.Side));
            }
        }
    }
}
