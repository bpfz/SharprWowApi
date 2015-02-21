using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class AuditSpell
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public string CastTime { get; set; }
    }
}
