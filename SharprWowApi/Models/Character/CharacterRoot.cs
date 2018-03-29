using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SharprWowApi.Models.Character.AuditModel;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// The Character Profile API is the primary way to access character information.
    /// </summary>
    public class CharacterRoot
    {
        /// <summary>
        /// Gets or setsTimestamp that shows when the character API was last updated.
        /// </summary>
        public string LastModified { get; set; }

        public string Name { get; set; }

        public string Realm { get; set; }

        public string Battlegroup { get; set; }

        public int Level { get; set; }

        /// <summary>
        /// Gets the total amount of achievement points on this character.
        /// </summary>
        public int AchievementPoints { get; set; }

        public string Thumbnail { get; set; }

        public string CalcClass { get; set; }

        /// <summary>
        /// Gets or sets a character guild
        /// </summary>
        public CharacterGuild Guild { get; set; }

        /// <summary>
        /// Gets or sets the activity feed of the character. Achievements and items.
        /// </summary>
        public IEnumerable<CharacterFeed> Feed { get; set; }

        /// <summary>
        /// Gets or sets a list of items equipped by the character. 
        /// Use of this field will also include the average item level and average item level equipped for the character.
        /// </summary>
        public CharacterItems Items { get; set; }

        /// <summary>
        /// Gets or sets a map of character attributes and stats.
        /// </summary>
        public CharacterStats Stats { get; set; }

        /// <summary>
        /// Gets or sets a map containing list for both secondary and primary professions on this character.
        /// </summary>
        public CharacterProfessions Professions { get; set; }

        /// <summary>
        /// Gets or sets a list of the factions that the character has an associated reputation with.
        /// </summary>
        public IEnumerable<CharacterReputation> Reputation { get; set; }

        /// <summary>
        /// Gets or sets a list of the titles acquired by the character.
        /// </summary>
        public IEnumerable<CharacterTitles> Titles { get; set; }

        /// <summary>
        /// Gets or sets a map of achievement data including completion timestamps and criteria information.
        /// </summary>
        public CharacterAchievements Achievements { get; set; }

        /// <summary>
        /// Gets or sets a list of talent structures.
        /// </summary>
        public List<CharacterTalent> Talents { get; set; }

        /// <summary>
        /// Gets or sets a map of character appearance
        /// </summary>
        public CharacterAppearance Appearance { get; set; }

        /// <summary>
        /// Gets or sets a list of all of the mounts obtained by the character.
        /// </summary>
        public CharacterMounts Mounts { get; set; }

        /// <summary>
        /// Gets or sets a list of the battle pets obtained by the character.
        /// </summary>
        public CharacterPets Pets { get; set; }

        /// <summary>
        /// Gets or sets data about the current battle pet slots on this characters account.
        /// </summary>
        public IEnumerable<CharacterPetSlot> PetSlots { get; set; }

        /// <summary>
        /// Gets or sets a list of raids and bosses indicating raid progression and completeness.
        /// </summary>
        public CharacterProgression Progression { get; set; }

        /// <summary>
        /// Gets or sets a map of player versus player information including arena team membership and rated battlegrounds information.
        /// </summary>
        public CharacterPvp Pvp { get; set; }

        /// <summary>
        /// Gets or sets a list of all of the combat pets obtained by the character.
        /// </summary>
        public IEnumerable<CharacterHunterPet> HunterPets { get; set; }

        /// <summary>
        /// Gets or sets a  list of quests completed by the character.
        /// </summary>
        public IEnumerable<int> Quests { get; set; }

        /// <summary>
        /// Gets or sets audit (Not 100% done, kinda broken on blizzards end as well)
        /// </summary>
        public Audit Audit { get; set; }

        /// <summary>
        /// Gets or sets total amount of honorable kills by the character.
        /// </summary>
        public int TotalHonorableKills { get; set; }

        /// <summary>
        /// Gets class of this character (warrior, priest etc.)
        /// </summary>
        public CharacterClass Class
        {
            get
            {
                return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), this.ClassNumber));
            }
        }

        /// <summary>
        /// Gets race of this character (Human, Undead, Orc etc.)
        /// </summary>
        public CharacterRace Race
        {
            get
            {
                return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), this.RaceNumber));
            }
        }

        /// <summary>
        /// Gets gender of this character (Male or female)
        /// </summary>
        public CharacterGender Gender
        {
            get
            {
                return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), this.GenderNumber));
            }
        }

        /// <summary>
        /// Gets or sets integer value of the characters class. Use Class for class string.
        /// </summary>
        [JsonProperty("class")]
        public int ClassNumber { get; set; }

        /// <summary>
        /// Gets or sets integer value of the characters race. Use Race for race string.
        /// </summary>
        [JsonProperty("race")]
        public int RaceNumber { get; set; }

        /// <summary>
        /// Gets or sets integer value of gender the characters gender. Use Gender for gender string. 
        /// </summary>
        [JsonProperty("gender")]
        public int GenderNumber { get; set; }
    }
}
