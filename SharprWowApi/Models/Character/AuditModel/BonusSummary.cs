using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class BonusSummary
    {
        public IEnumerable<object> DefaultBonusLists { get; set; }

        public IEnumerable<object> ChanceBonusLists { get; set; }

        public IEnumerable<object> BonusChances { get; set; }
    }
}
