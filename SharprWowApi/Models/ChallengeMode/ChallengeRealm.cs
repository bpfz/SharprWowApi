using System.Collections.Generic;

namespace SharprWowApi.Models.ChallengeMode
{
    public class ChallengeRealm
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Battlegroup { get; set; }

        public string Locale { get; set; }

        public string Timezone { get; set; }

        public List<string> ConnectedRealms { get; set; }
    }
}
