using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.DataResources
{
    class ItemData
    {
    }
    public class Type
{
    public bool twoHanded { get; set; }
    public string id { get; set; }
}

public class Armor
{
    public double min { get; set; }
    public double max { get; set; }
}

public class Primary
{
    public string text { get; set; }
    public string color { get; set; }
    public string affixType { get; set; }
}

public class Secondary
{
    public string text { get; set; }
    public string color { get; set; }
    public string affixType { get; set; }
}

public class Attributes
{
    public List<Primary> primary { get; set; }
    public List<Secondary> secondary { get; set; }
    public List<object> passive { get; set; }
}

public class DurabilityCur
{
    public double min { get; set; }
    public double max { get; set; }
}

public class ArmorBonusItem
{
    public double min { get; set; }
    public double max { get; set; }
}

public class DurabilityMax
{
    public double min { get; set; }
    public double max { get; set; }
}

public class MovementScalar
{
    public double min { get; set; }
    public double max { get; set; }
}

public class DamagePercentReductionFromMelee
{
    public double min { get; set; }
    public double max { get; set; }
}

public class ResistanceAll
{
    public double min { get; set; }
    public double max { get; set; }
}

public class ArmorItem
{
    public double min { get; set; }
    public double max { get; set; }
}

public class AttributesRaw
{
    public DurabilityCur Durability_Cur { get; set; }
    public ArmorBonusItem Armor_Bonus_Item { get; set; }
    public DurabilityMax Durability_Max { get; set; }
    public MovementScalar Movement_Scalar { get; set; }
    public DamagePercentReductionFromMelee Damage_Percent_Reduction_From_Melee { get; set; }
    public ResistanceAll Resistance_All { get; set; }
    public ArmorItem Armor_Item { get; set; }
}

public class Primary2
{
    public string text { get; set; }
    public string color { get; set; }
    public string affixType { get; set; }
}

public class Attributes2
{
    public List<Primary2> primary { get; set; }
    public List<object> secondary { get; set; }
    public List<object> passive { get; set; }
}

public class DexterityItem
{
    public double min { get; set; }
    public double max { get; set; }
}

public class StrengthItem
{
    public double min { get; set; }
    public double max { get; set; }
}

public class IntelligenceItem
{
    public double min { get; set; }
    public double max { get; set; }
}

public class AttributesRaw2
{
    public DexterityItem Dexterity_Item { get; set; }
    public StrengthItem Strength_Item { get; set; }
    public IntelligenceItem Intelligence_Item { get; set; }
}

public class OneOf
{
    public Attributes2 attributes { get; set; }
    public AttributesRaw2 attributesRaw { get; set; }
}

public class RandomAffix
{
    public List<OneOf> oneOf { get; set; }
}

public class Item
{
    public string id { get; set; }
    public string name { get; set; }
    public string icon { get; set; }
    public string displayColor { get; set; }
    public string tooltipParams { get; set; }
}

public class Attributes3
{
    public List<object> primary { get; set; }
    public List<object> secondary { get; set; }
    public List<object> passive { get; set; }
}

public class CritPercentBonusCapped
{
    public double min { get; set; }
    public double max { get; set; }
}

public class DexterityItem2
{
    public double min { get; set; }
    public double max { get; set; }
}

public class ResourceMaxBonusDiscipline
{
    public double min { get; set; }
    public double max { get; set; }
}

public class AttributesRaw3
{
    public CritPercentBonusCapped Crit_Percent_Bonus_Capped { get; set; }
    public DexterityItem2 Dexterity_Item { get; set; }
    public ResourceMaxBonusDiscipline __invalid_name__Resource_Max_Bonus#Discipline { get; set; }
}

public class Rank
{
    public int required { get; set; }
    public Attributes3 attributes { get; set; }
    public AttributesRaw3 attributesRaw { get; set; }
}

public class Set
{
    public string name { get; set; }
    public List<Item> items { get; set; }
    public string slug { get; set; }
    public List<Rank> ranks { get; set; }
}

public class RootObject
{
    public string id { get; set; }
    public string name { get; set; }
    public string icon { get; set; }
    public string displayColor { get; set; }
    public string tooltipParams { get; set; }
    public int requiredLevel { get; set; }
    public int itemLevel { get; set; }
    public int bonusAffixes { get; set; }
    public int bonusAffixesMax { get; set; }
    public bool accountBound { get; set; }
    public string flavorText { get; set; }
    public string typeName { get; set; }
    public Type type { get; set; }
    public Armor armor { get; set; }
    public List<string> slots { get; set; }
    public Attributes attributes { get; set; }
    public AttributesRaw attributesRaw { get; set; }
    public List<RandomAffix> randomAffixes { get; set; }
    public List<object> gems { get; set; }
    public List<object> socketEffects { get; set; }
    public Set set { get; set; }
    public List<object> craftedBy { get; set; }
    public int seasonRequiredToDrop { get; set; }
    public bool isSeasonRequiredToDrop { get; set; }
}
}
