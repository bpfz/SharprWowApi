namespace SharprWowApi.Models.Character
{
    public class CharacterHunterPet
    {
        public string Name { get; set; }

        public int Creature { get; set; }

        public int Slot { get; set; }

        public CharacterHunterPetSpec Spec { get; set; }

        public string CalcSpec { get; set; }

        public int FamilyId { get; set; }

        public string FamilyName { get; set; }

        public bool? Selected { get; set; }
    }
}
