using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// A list of the battle pets obtained by the character.
    /// </summary>
    public class CharacterPets
    {
        public int NumCollected { get; set; }

        public int NumNotCollected { get; set; }

        public IEnumerable<CharacterPetsCollected> Collected { get; set; }
    }
}
