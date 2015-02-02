using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi
{

    public enum Region
    {
        US,     //us.api.battle.net/
        EU,     //eu.api.battle.net/
        KR,     //kr.api.battle.net/
        TW,     //tw.api.battle.net/
        CN,     //https://battlenet.com.cn/api/
        SEA     //sea.api.battle.net/
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

    public enum CharacterOptions
    {
        None,
        GetGuild,
        GetStats,
        GetTalents,
        GetItems,
        GetReputation,
        GetTitles,
        GetProfessions,
        GetAppearance,
        GetPetSlots,
        GetMounts,
        GetPets,
        GetAchievements,
        GetProgression,
        GetFeed,
        GetPvP,
        GetQuests,
        GetHunterPets,
        GetEverything = GetGuild | GetStats | GetTalents | GetItems | GetReputation | GetTitles
        | GetProfessions | GetAppearance | GetPetSlots | GetMounts | GetPets
        | GetAchievements | GetProgression | GetFeed | GetPvP | GetQuests | GetHunterPets

    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetNews = 4,
        GetChallenge = 8,
        GetEverything = GetMembers | GetAchievements | GetNews | GetChallenge
    }

    public enum LeaderboardOptions
    {
        TwoVersusTwo,
        ThreeVersusThree,
        FiveVersusFive,
        RBG
    }

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
        Druid = 11
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
        Pandaren_Horde = 26
    }

    public enum CharacterGender
    {
        Male = 0,
        Female = 1,
    }
}
