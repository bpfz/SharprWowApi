using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SharprWowApi.Models.Character.AuditModel;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// The Character Profile API is the primary way to access character information.
    /// </summary>
    public class CharacterRoot
    {
        /// <summary>
        /// Timestamp that shows when the character API was last updated.
        /// </summary>
        public long LastModified { get; set; }

        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        /// <summary>
        /// int value of the characters class. Use Class for class string.
        /// </summary>
        public int @class { get; set; }

        /// <summary>
        /// int value of the characters race. Use Race for race string.
        /// </summary>
        public int race { get; set; }

        /// <summary>
        /// int value of gender the characters gender. Use Gender for gender string. 
        /// </summary>
        public int gender { get; set; }

        public int Level { get; set; }

        /// <summary>
        /// Gets the total amount of achievement points on this character.
        /// </summary>
        public int AchievementPoints { get; set; }

        public string Thumbnail { get; set; }

        public string CalcClass { get; set; }

        /// <summary>
        /// A summary of the guild that the character belongs to. To get guild rank use the Guild API.
        /// </summary>
        public CharacterGuild Guild { get; set; }

        /// <summary>
        /// The activity feed of the character. Achievements and items.
        /// </summary>
        public List<CharacterFeed> Feed { get; set; }

        /// <summary>
        /// A list of items equipped by the character. 
        /// Use of this field will also include the average item level and average item level equipped for the character.
        /// </summary>
        public CharacterItems Items { get; set; }

        /// <summary>
        /// A map of character attributes and stats.
        /// </summary>
        public CharacterStats Stats { get; set; }

        /// <summary>
        /// A map containing list for both secondary and primary professions on this character.
        /// </summary>
        public CharacterProfessions Professions { get; set; }

        /// <summary>
        /// A list of the factions that the character has an associated reputation with.
        /// </summary>
        public List<CharacterReputation> Reputation { get; set; }

        /// <summary>
        /// A list of the titles aquired by the character.
        /// </summary>
        public List<CharacterTitles> Titles { get; set; }

        /// <summary>
        /// A map of achievement data including completion timestamps and criteria information.
        /// </summary>
        public CharacterAchievements Achievements { get; set; }

        /// <summary>
        /// A list of talent structures.
        /// </summary>
        public List<CharacterTalent> Talents { get; set; }

        /// <summary>
        /// A map of character appearance
        /// </summary>
        public CharacterAppearance Appearance { get; set; }

        /// <summary>
        /// A list of all of the mounts obtained by the character.
        /// </summary>
        public CharacterMounts Mounts { get; set; }

        /// <summary>
        /// A list of the battle pets obtained by the character.
        /// </summary>
        public CharacterPets Pets { get; set; }

        /// <summary>
        /// Data about the current battle pet slots on this characters account.
        /// </summary>
        public List<CharacterPetSlot> PetSlots { get; set; }

        /// <summary>
        /// A list of raids and bosses indicating raid progression and completeness.
        /// </summary>
        public CharacterProgression Progression { get; set; }

        /// <summary>
        /// A map of pvp information including arena team membership and rated battlegrounds information.
        /// </summary>
        public CharacterPVP Pvp { get; set; }

        /// <summary>
        /// A list of all of the combat pets obtained by the character.
        /// </summary>
        public List<CharacterHunterPet> HunterPets { get; set; }

        /// <summary>
        /// A list of quests completed by the character.
        /// </summary>
        public List<int> Quests { get; set; }

        /// <summary>
        /// Not 100% done
        /// </summary>
        public Audit Audit { get; set; }

        /// <summary>
        /// Total amount of honorable kills by the character.
        /// </summary>
        public int TotalHonorableKills { get; set; }

        /// <summary>
        /// Class of this character (warrior, priest etc.) (string)
        /// </summary>
        public CharacterClass Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), @class).Replace(' ', '_')); } }

        /// <summary>
        /// Race of this character (Human, Undead, Orc etc.) (string)
        /// </summary>
        public CharacterRace Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), race).Replace(' ', '_')); } }

        /// <summary>
        /// Gender of this character (Male or female) (string)
        /// </summary>
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), gender).Replace(' ', '_')); } }
    }
}
