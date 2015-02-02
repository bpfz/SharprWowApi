using SharprWowApi.WowModels.ChallengeMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.Guild
{
    public class GuildChallengeGroup
    {
        public int ranking { get; set; }
        public ChallengeTime time { get; set; }
        public string date { get; set; }
        public string medal { get; set; }
        public string faction { get; set; }
        public bool isRecurring { get; set; }
        public List<GroupMember> members { get; set; }
        public ChallengeGuild guild { get; set; }
    }
}
