using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProfessions
    {
        public List<CharacterProfession> primary { get; set; }
        public List<CharacterProfession> secondary { get; set; }
    }
}
