using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterProfession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Rank { get; set; }

        public int Max { get; set; }

        public IEnumerable<int> Recipes { get; set; }
    }
}
