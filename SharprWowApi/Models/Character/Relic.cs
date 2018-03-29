using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class Relic
    {
        public int Socket { get; set; }

        public int ItemId { get; set; }

        public int Context { get; set; }

        public List<int> BonusLists { get; set; }
    }
}
