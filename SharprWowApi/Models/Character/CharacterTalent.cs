using System.Collections.Generic;

namespace SharprWowApi.Models.Character
{
    public class CharacterTalent
    {
        public IEnumerable<CharacterTalentSelectedTalent> Talents { get; set; }

        public CharacterTalentGlyphs Glyphs { get; set; }

        public CharacterTalentSpec Spec { get; set; }

        public string CalcTalent { get; set; }

        public string CalcSpec { get; set; }

        public string CalcGlyph { get; set; }

        public bool? Selected { get; set; }
    }
}
