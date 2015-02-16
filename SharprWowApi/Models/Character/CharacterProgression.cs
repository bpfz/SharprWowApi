using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProgression
    {
        public IEnumerable<CharacterProgressionRaid> Raids { get; set; }
    }
}
