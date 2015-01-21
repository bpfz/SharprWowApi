using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class ItemSpell
    {
        public int spellId { get; set; }
        public AuditSpell spell { get; set; }
        public int nCharges { get; set; }
        public bool consumable { get; set; }
        public int categoryId { get; set; }
        public string trigger { get; set; }
    }
}
