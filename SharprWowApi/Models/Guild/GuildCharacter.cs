using System;
using Newtonsoft.Json;
using SharprWowApi;
using SharprWowApi.Models.Character;

namespace SharprWowApi.Models.Guild
{
    public class GuildCharacter
    {
        public string Name { get; set; }

        public string Realm { get; set; }

        public string Battlegroup { get; set; }

        public int Level { get; set; }

        public int AchievementPoints { get; set; }

        public string Thumbnail { get; set; }

        public CharacterTalentSpec Spec { get; set; }

        public string Guild { get; set; }

        public string GuildRealm { get; set; }

        /// <summary>
        /// Gets class of this character (warrior, priest etc.) (string)
        /// </summary>
        public CharacterClass Class
        {
            get
            {
                return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), this.ClassNumber));
            }
        }

        /// <summary>
        /// Gets race of this character (Human, Undead, Orc etc.) (string)
        /// </summary>
        public CharacterRace Race
        {
            get
            {
                return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), this.RaceNumber));
            }
        }

        /// <summary>
        /// Gets gender of this character (Male or female) (string)
        /// </summary>
        public CharacterGender Gender
        {
            get
            {
                return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), this.GenderNumber));
            }
        }

        [JsonProperty("class")]
        internal int ClassNumber { get; set; }

        [JsonProperty("race")]
        internal int RaceNumber { get; set; }

        [JsonProperty("gender")]
        internal int GenderNumber { get; set; }
    }
}
