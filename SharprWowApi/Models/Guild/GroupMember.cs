using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharprWowApi.Models.ChallengeMode;
using SharprWowApi.Models.Character;

namespace SharprWowApi.Models.Guild
{
    public class GroupMember
    {
        public ChallengeGroupMemberCharacter Character { get; set; }

        public ChallengeIndividualSpec Spec { get; set; }
    }
}
