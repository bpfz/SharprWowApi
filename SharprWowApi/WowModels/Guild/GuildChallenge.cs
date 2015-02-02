using SharprWowApi.WowModels.ChallengeMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.Guild
{
    public class GuildChallenge
    {
        public ChallengeRealm realm { get; set; }
        public ChallengeMap map { get; set; }
        public List<GuildChallengeGroup> groups { get; set; }
    }
}
