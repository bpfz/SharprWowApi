using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class BonusSummary
    {
        public List<object> DefaultBonusLists { get; set; }
        public List<object> ChanceBonusLists { get; set; }
        public List<object> BonusChances { get; set; }
    }
}
