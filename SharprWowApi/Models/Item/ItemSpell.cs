using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharprWowApi.Models.Item
{
    class ItemSpell
    {
        public int SpellId { get; set; }
        public ItemSpellDesc Spell { get; set; }
        public int NCharges { get; set; }
        public bool Consumable { get; set; }
        public int CategoryId { get; set; }
        public string Trigger { get; set; }

    }
}
