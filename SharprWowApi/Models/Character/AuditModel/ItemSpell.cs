using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class ItemSpell
    {
        public int SpellId { get; set; }
        public AuditSpell Spell { get; set; }
        public int nCharges { get; set; }
        public bool Consumable { get; set; }
        public int CategoryId { get; set; }
        public string Trigger { get; set; }
    }
}
