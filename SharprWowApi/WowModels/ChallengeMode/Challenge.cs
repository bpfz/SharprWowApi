using System.Collections.Generic;

namespace SharprWowApi.WowModels.ChallengeMode
{
    public class Challenge
    {
        public ChallengeRealm Realm { get; set; }
        public ChallengeMap Map { get; set; }
        public List<ChallengeGroup> Groups { get; set; }
    }
}
