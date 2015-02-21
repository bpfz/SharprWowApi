using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// A list of all of the mounts obtained by the character.
    /// </summary>
    public class CharacterMounts
    {
        public int NumCollected { get; set; }

        public int NumNotCollected { get; set; }

        public IEnumerable<CharacterMountsCollected> Collected { get; set; }
    }
}