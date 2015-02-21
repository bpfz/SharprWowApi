using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// Data about the current battle pet slots on this characters account.
    /// </summary>
    public class CharacterPetSlot
    {
        public int Slot { get; set; }

        public bool IsEmpty { get; set; }

        public bool IsLocked { get; set; }

        public IEnumerable<int> Abilities { get; set; }
    }
}
