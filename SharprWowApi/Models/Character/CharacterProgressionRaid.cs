using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProgressionRaid
    {
        public string Name { get; set; }

        public int Lfr { get; set; }

        public int Normal { get; set; }

        public int Heroic { get; set; }

        public int Mythic { get; set; }

        public int Id { get; set; }

        public IEnumerable<CharacterProgressionBoss> Bosses { get; set; }
    }
}
