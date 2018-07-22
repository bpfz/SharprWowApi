using System;

namespace SharprWowApi
{

    public enum Region
    {
        US,     ////us.api.battle.net/
        EU,     ////eu.api.battle.net/
        KR,     ////kr.api.battle.net/
        TW,     ////tw.api.battle.net/
        CN,     ////https://battlenet.com.cn/api/
        SEA     ////sea.api.battle.net/
    }

    public enum Locale
    {
        None,
        en_US,
        es_MX,
        pt_BR,
        en_GB,
        de_DE,
        es_ES,
        fr_FR,
        it_IT,
        pl_PL,
        pt_PT,
        ru_RU,
        ko_KR,
        zh_TW,
        zh_CN
    }

    [Flags]
    public enum CharacterClass
    {
        Warrior = 1,
        Paladin = 2,
        Hunter = 3,
        Rogue = 4,
        Priest = 5,
        Death_Knight = 6,
        Shaman = 7,
        Mage = 8,
        Warlock = 9,
        Monk = 10,
        Druid = 11,
        Demon_Hunter = 12
    }

    public enum CharacterGender
    {
        Male = 0,
        Female = 1,
    }

    public enum CharacterOptions
    {
        None = 0,
        Guild = 1,
        Stats = 2,
        Talents = 4,
        Items = 8,
        Reputation = 16,
        Titles = 32,
        Professions = 64,
        Appearance = 128,
        PetSlots = 256,
        Mounts = 512,
        Pets = 1024,
        Achievements = 2048,
        Progression = 4096,
        Feed = 8192,
        PvP = 16384,
        Quests = 32768,
        HunterPets = 65536,
        AllOptions = Guild | Stats | Talents |
                    Items | Reputation | Titles |
                    Professions | Appearance | PetSlots |
                    Mounts | Pets | Achievements | Progression |
                    Feed | PvP | Quests | HunterPets
    }

    public enum CharacterRace
    {
        Human = 1,
        Orc = 2,
        Dwarf = 3,
        Night_Elf = 4,
        Undead = 5,
        Tauren = 6,
        Gnome = 7,
        Troll = 8,
        Goblin = 9,
        Blood_Elf = 10,
        Draenei = 11,
        Worgen = 22,
        Pandaren_Neutral = 24,
        Pandaren_Alliance = 25,
        Pandaren_Horde = 26,
        Nightborne = 27,
        Highmountain_Tauren = 28,
        Void_Elf = 29,
        Lightforged_Draenei = 30,
        Dark_Iron_Dwarf = 34,
        Maghar_Orc = 36
    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        Members = 1,
        Achievements = 2,
        News = 4,
        Challenge = 8,
        AllOptions = Members | Achievements | News | Challenge
    }

    public enum LeaderboardOptions
    {
        TwoVersusTwo,
        ThreeVersusThree,
        FiveVersusFive,
        RBG
    }

    [Flags]
    public enum ItemQuality
    {
        Gray = 0,
        White = 1,
        Green = 2,
        Blue = 3,
        Epic = 4,
        Legendary = 5
    }

    /// <summary>
    /// Both can also mean neutral (for example in pvp zones)
    /// </summary>
    [Flags]
    public enum WoWFaction
    {
        Alliance = 0,
        Horde = 1,
        Both = 2
    }
}
