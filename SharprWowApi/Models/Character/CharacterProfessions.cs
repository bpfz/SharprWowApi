using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProfessions
    {
        public IEnumerable<CharacterProfession> primary { get; set; }
        public IEnumerable<CharacterProfession> secondary { get; set; }
    }
}
