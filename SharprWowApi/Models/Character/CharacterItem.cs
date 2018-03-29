using SharprWowApi.Models.Item;
using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Quality { get; set; }

        public int ItemLevel { get; set; }

        public int Armor { get; set; }

        public string Context { get; set; }

        public CharacterItemTooltipParams TooltipParams { get; set; }

        public IEnumerable<CharacterItemStat> Stats { get; set; }

        public ItemWeaponInfo WeaponInfo { get; set; }

        public int ArtifactInfoId { get; set; }

        public int DisplayInfoId { get; set; }

        public int ArtifactAppearanceId { get; set; }

        public IEnumerable<ArtifactTrait> ArtifactTraits { get; set; }

        public IEnumerable<Relic> Relics { get; set; }

        public CharacterItemAppearance Appearance { get; set; }

        public IEnumerable<int> BonusLists { get; set; }
    }
}
