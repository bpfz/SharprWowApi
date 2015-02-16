using SharprWowApi.Models.ChallengeMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Guild
{
    public class GuildChallenge
    {
        public ChallengeRealm realm { get; set; }
        public ChallengeMap map { get; set; }
        public IEnumerable<GuildChallengeGroup> groups { get; set; }
    }
}
