using System.Collections.Generic;

namespace SharprWowApi.WowModels.Character
{
    public class CharacterProfessions
    {
        public List<CharacterProfession> primary { get; set; }
        public List<CharacterProfession> secondary { get; set; }
    }
}
