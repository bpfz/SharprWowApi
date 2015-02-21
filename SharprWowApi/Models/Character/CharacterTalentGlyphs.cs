using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character
{
    public class CharacterTalentGlyphs
    {
        public IEnumerable<CharacterTalentGlyph> Major { get; set; }

        public IEnumerable<CharacterTalentGlyph> Minor { get; set; }
    }
}
