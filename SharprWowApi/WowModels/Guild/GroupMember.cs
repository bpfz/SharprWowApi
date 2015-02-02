using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharprWowApi.WowModels.Character;
using SharprWowApi.WowModels.ChallengeMode;

namespace SharprWowApi.WowModels.Guild
{
    public class GroupMember
    {
        public ChallengeGroupMemberCharacter character { get; set; }
        public ChallengeIndividualSpec spec { get; set; }
    }
}
