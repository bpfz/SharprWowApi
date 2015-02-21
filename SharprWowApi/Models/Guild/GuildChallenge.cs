using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharprWowApi.Models.ChallengeMode;

namespace SharprWowApi.Models.Guild
{
    public class GuildChallenge
    {
        public ChallengeRealm Realm { get; set; }

        public ChallengeMap Map { get; set; }

        public IEnumerable<GuildChallengeGroup> Groups { get; set; }
    }
}
