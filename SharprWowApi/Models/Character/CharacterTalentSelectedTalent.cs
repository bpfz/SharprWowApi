using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character
{
    public class CharacterTalentSelectedTalent
    {
        public int Tier { get; set; }

        public int Column { get; set; }

        public CharacterTalentSpell Spell { get; set; }
    }
}
