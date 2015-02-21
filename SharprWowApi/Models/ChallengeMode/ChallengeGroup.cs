using System.Collections.Generic;

namespace SharprWowApi.Models.ChallengeMode
{
    public class ChallengeGroup
    {
        public int Ranking { get; set; }

        public ChallengeTime Time { get; set; }

        public string Date { get; set; }

        public string Medal { get; set; }

        public string Faction { get; set; }

        public bool IsRecurring { get; set; }

        public List<ChallengeGroupMember> Members { get; set; }
    }
}
