using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class Stats
    {
        public int life { get; set; }
        public double damage { get; set; }
        public double toughness { get; set; }
        public double healing { get; set; }
        public double attackSpeed { get; set; }
        public int armor { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int vitality { get; set; }
        public int intelligence { get; set; }
        public int physicalResist { get; set; }
        public int fireResist { get; set; }
        public int coldResist { get; set; }
        public int lightningResist { get; set; }
        public int poisonResist { get; set; }
        public int arcaneResist { get; set; }
        public double critDamage { get; set; }
        public double blockChance { get; set; }
        public int blockAmountMin { get; set; }
        public int blockAmountMax { get; set; }
        public double damageIncrease { get; set; }
        public double critChance { get; set; }
        public double damageReduction { get; set; }
        public double thorns { get; set; }
        public double lifeSteal { get; set; }
        public double lifePerKill { get; set; }
        public double goldFind { get; set; }
        public double magicFind { get; set; }
        public double lifeOnHit { get; set; }
        public int primaryResource { get; set; }
        public int secondaryResource { get; set; }
    }
}
