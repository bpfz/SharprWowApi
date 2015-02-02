using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.WowModels.Character.AuditModel
{
    public class BonusSummary
    {
        public List<object> defaultBonusLists { get; set; }
        public List<object> chanceBonusLists { get; set; }
        public List<object> bonusChances { get; set; }
    }
}
