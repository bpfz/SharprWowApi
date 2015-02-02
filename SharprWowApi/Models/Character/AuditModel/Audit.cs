using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Character.AuditModel
{
    public class Audit
    {
        public int numberOfIssues { get; set; }
        public Slots slots { get; set; }
        public int emptyGlyphSlots { get; set; }
        public int unspentTalentPoints { get; set; }
        public bool noSpec { get; set; }
        public UnenchantedItems unenchantedItems { get; set; }
        public int emptySockets { get; set; }
        public ItemsWithEmptySockets itemsWithEmptySockets { get; set; }
        public int appropriateArmorType { get; set; }
        public InappropriateArmorType inappropriateArmorType { get; set; }
        public LowLevelItems lowLevelItems { get; set; }
        public int lowLevelThreshold { get; set; }
        public MissingExtraSockets missingExtraSockets { get; set; }
        public RecommendedBeltBuckle recommendedBeltBuckle { get; set; }
        public MissingBlacksmithSockets missingBlacksmithSockets { get; set; }
        public MissingEnchanterEnchants missingEnchanterEnchants { get; set; }
        public MissingEngineerEnchants missingEngineerEnchants { get; set; }
        public MissingScribeEnchants missingScribeEnchants { get; set; }
        public int nMissingJewelcrafterGems { get; set; }
        public MissingLeatherworkerEnchants missingLeatherworkerEnchants { get; set; }
    }
}
