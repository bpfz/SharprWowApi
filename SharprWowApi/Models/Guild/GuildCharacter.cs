using SharprWowApi;
using SharprWowApi.Models.Character;
using System;

namespace SharprWowApi.Models.Guild
{
    public class GuildCharacter
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }

        public int Level { get; set; }
        public int AchievementPoints { get; set; }
        public string Thumbnail { get; set; }
        public CharacterTalentSpec Spec { get; set; }
        public string Guild { get; set; }
        public string GuildRealm { get; set; }

        /// <summary>
        /// Class of this character (warrior, priest etc.) (string)
        /// </summary>
        public CharacterClass Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), @class)); } }
        /// <summary>
        /// Race of this character (Human, Undead, Orc etc.) (string)
        /// </summary>
        public CharacterRace Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), race)); } }
        /// <summary>
        /// Gender of this character (Male or female) (string)
        /// </summary>
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), gender)); } }
    }
}
