using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharprWowApi.Models.Character;
using SharprWowApi.Models.ChallengeMode;

namespace SharprWowApi.Models.Guild
{
    public class GroupMember
    {
        public ChallengeGroupMemberCharacter character { get; set; }
        public ChallengeIndividualSpec spec { get; set; }
    }
}
