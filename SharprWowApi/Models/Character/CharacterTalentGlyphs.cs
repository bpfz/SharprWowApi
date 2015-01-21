using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character
{
    public class CharacterTalentGlyphs
    {
        public List<Major> Major { get; set; }
        public List<Minor> Minor { get; set; }
    }
    public class Major
    {
        public int Glyph { get; set; }
        public int Item { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class Minor
    {
        public int Glyph { get; set; }
        public int Item { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
