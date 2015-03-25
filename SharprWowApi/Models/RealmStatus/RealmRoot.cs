using System.Collections.Generic;

namespace SharprWowApi.Models.RealmStatus
{
    public class RealmRoot
    {
        public IEnumerable<Realm> Realms { get; set; }
    }
}
