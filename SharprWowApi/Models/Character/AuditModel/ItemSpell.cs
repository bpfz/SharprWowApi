using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class ItemSpell
    {
        public int SpellId { get; set; }

        public AuditSpell Spell { get; set; }

        [JsonProperty("nCharges")]
        public int Charges { get; set; }

        public bool Consumable { get; set; }

        public int CategoryId { get; set; }

        public string Trigger { get; set; }
    }
}
