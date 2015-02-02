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
        public CharacterItemTooltipParams TooltipParams { get; set; }
        public List<CharacterItemStat> Stats { get; set; }
        public int Armor { get; set; }
        public string Context { get; set; }
        public List<int> BonusLists { get; set; }
    }
}
