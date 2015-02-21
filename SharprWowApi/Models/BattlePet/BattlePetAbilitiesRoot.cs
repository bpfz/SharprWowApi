namespace SharprWowApi.Models.BattlePet
{
    /// <summary>
    /// This provides data about a individual battle pet ability ID. 
    /// We do not provide the tooltip for the ability yet. We are working on a better way to provide this since it depends on your pet's species, level and quality rolls.
    /// </summary>
    public class BattlePetAbilitiesRoot
    {
        public int Slot { get; set; }

        public int Order { get; set; }

        public int RequiredLevel { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Cooldown { get; set; }

        public int Rounds { get; set; }

        public int PetTypeId { get; set; }

        public bool IsPassive { get; set; }

        public bool HideHints { get; set; }
    }
}
