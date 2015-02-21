using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharprWowApi.Models.ChallengeMode;

namespace SharprWowApi.Models.Guild
{
    public class GuildChallengeGroup
    {
        public int Ranking { get; set; }

        public ChallengeTime Time { get; set; }

        public string Date { get; set; }

        public string Medal { get; set; }

        public string Faction { get; set; }

        public bool IsRecurring { get; set; }

        public IEnumerable<GroupMember> Members { get; set; }

        public ChallengeGuild Guild { get; set; }
    }
}
