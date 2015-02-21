using System.Collections.Generic;

namespace SharprWowApi.Models.RealmStatus
{
    public class Realm
    {
        public string Type { get; set; }

        public string Population { get; set; }

        public bool Queue { get; set; }

        public bool Status { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Battlegroup { get; set; }

        public string Locale { get; set; }

        public string Timezone { get; set; }

        public IEnumerable<string> ConnectedRealms { get; set; }

        public PvpZone Wintergrasp { get; set; }

        public PvpZone TolBarad { get; set; }
    }
}
