using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProfessions
    {
        public IEnumerable<CharacterProfession> Primary { get; set; }

        public IEnumerable<CharacterProfession> Secondary { get; set; }
    }
}
