using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharprWowApi.Models.Character.AuditModel
{
    /// <summary>
    /// This  is currently unavailable
    /// </summary>
    public class Audit
    {
        public int NumberOfIssues { get; set; }

        public Slots Slots { get; set; }

        public int EmptyGlyphSlots { get; set; }

        public int UnspentTalentPoints { get; set; }

        public bool NoSpec { get; set; }

        public UnenchantedItems UnenchantedItems { get; set; }

        public int EmptySockets { get; set; }

        public ItemsWithEmptySockets ItemsWithEmptySockets { get; set; }

        public int AppropriateArmorType { get; set; }

        public InappropriateArmorType InappropriateArmorType { get; set; }

        public LowLevelItems LowLevelItems { get; set; }

        public int LowLevelThreshold { get; set; }

        public MissingExtraSockets MissingExtraSockets { get; set; }

        public RecommendedBeltBuckle RecommendedBeltBuckle { get; set; }

        public MissingBlacksmithSockets MissingBlacksmithSockets { get; set; }

        public MissingEnchanterEnchants MissingEnchanterEnchants { get; set; }

        public MissingEngineerEnchants MissingEngineerEnchants { get; set; }

        public MissingScribeEnchants MissingScribeEnchants { get; set; }

        [JsonProperty("nMissingJewelcrafterGems")]
        public int MissingJewelcrafingGems { get; set; }

        public MissingLeatherworkerEnchants MissingLeatherworkerEnchants { get; set; }
    }
}
