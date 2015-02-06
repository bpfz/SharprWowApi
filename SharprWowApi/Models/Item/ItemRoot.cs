using System.Collections.Generic;

namespace SharprWowApi.Models.Item
{
    public class ItemRoot
    {
        public int Id { get; set; }
        public int DisenchantingSkillRank { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Stackable { get; set; }
        public int ItemBind { get; set; }
        public List<ItemBonusStat> BonusStats { get; set; }
        public List<ItemSpell> ItemSpells { get; set; }
        public int BuyPrice { get; set; }
        public int ItemClass { get; set; }
        public int ItemSubClass { get; set; }
        public int ContainerSlots { get; set; }
        public ItemWeaponInfo WeaponInfo { get; set; }
        public int InventoryType { get; set; }
        public bool Equippable { get; set; }
        public int ItemLevel { get; set; }
        public int MaxCount { get; set; }
        public int MaxDurability { get; set; }
        public int MinFactionId { get; set; }
        public int MinReputation { get; set; }
        public int Quality { get; set; }
        public int SellPrice { get; set; }
        public int RequiredSkill { get; set; }
        public int RequiredLevel { get; set; }
        public int RequiredSkillRank { get; set; }
        public ItemSource ItemSource { get; set; }
        public int BaseArmor { get; set; }
        public bool HasSockets { get; set; }
        public bool IsAuctionable { get; set; }
        public int Armor { get; set; }
        public int DisplayInfoId { get; set; }
        public string NameDescription { get; set; }
        public string NameDescriptionColor { get; set; }
        public bool Upgradable { get; set; }
        public bool HeroicTooltip { get; set; }
        public string Context { get; set; }
        public List<object> BonusLists { get; set; }
        public List<string> AvailableContexts { get; set; }
        public ItemBonusSummary BonusSummary { get; set; }
        public ItemSetRoot ItemSet { get; set; }

    }
}
