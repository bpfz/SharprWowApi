using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character
{
    public class CharacterTalentGlyphs
    {
        public List<CharacterTalentGlyph> Major { get; set; }
        public List<CharacterTalentGlyph> Minor { get; set; }
    }
}
