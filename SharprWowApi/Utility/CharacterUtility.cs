using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class CharacterUtility
    {
        public static string BuildOptionalFields(CharacterOptions characterOptions)
        {
            string query = "&fields=";
            List<string> fields = new List<string>();

            if ((characterOptions & CharacterOptions.GetGuild).Equals(CharacterOptions.GetGuild))
                fields.Add("guild");

            if ((characterOptions & CharacterOptions.GetStats).Equals(CharacterOptions.GetStats))
                fields.Add("stats");

            if ((characterOptions & CharacterOptions.GetTalents).Equals(CharacterOptions.GetTalents))
                fields.Add("talents");

            if ((characterOptions & CharacterOptions.GetItems).Equals(CharacterOptions.GetItems))
                fields.Add("items");

            if ((characterOptions & CharacterOptions.GetReputation).Equals(CharacterOptions.GetReputation))
                fields.Add("reputation");

            if ((characterOptions & CharacterOptions.GetTitles).Equals(CharacterOptions.GetTitles))
                fields.Add("titles");

            if ((characterOptions & CharacterOptions.GetProfessions).Equals(CharacterOptions.GetProfessions))
                fields.Add("professions");

            if ((characterOptions & CharacterOptions.GetAppearance).Equals(CharacterOptions.GetAppearance))
                fields.Add("appearance");

            if ((characterOptions & CharacterOptions.GetPetSlots).Equals(CharacterOptions.GetPetSlots))
                fields.Add("petSlots");

            if ((characterOptions & CharacterOptions.GetMounts).Equals(CharacterOptions.GetMounts))
                fields.Add("mounts");

            if ((characterOptions & CharacterOptions.GetPets).Equals(CharacterOptions.GetPets))
                fields.Add("pets");

            if ((characterOptions & CharacterOptions.GetAchievements).Equals(CharacterOptions.GetAchievements))
                fields.Add("achievements");

            if ((characterOptions & CharacterOptions.GetProgression).Equals(CharacterOptions.GetProgression))
                fields.Add("progression");

            if ((characterOptions & CharacterOptions.GetFeed).Equals(CharacterOptions.GetFeed))
                fields.Add("feed");

            if ((characterOptions & CharacterOptions.GetPvP).Equals(CharacterOptions.GetPvP))
                fields.Add("pvp");

            if ((characterOptions & CharacterOptions.GetQuests).Equals(CharacterOptions.GetQuests))
                fields.Add("quests");

            if ((characterOptions & CharacterOptions.GetHunterPets).Equals(CharacterOptions.GetHunterPets))
                fields.Add("hunterPets");


            if (fields.Count == 0) return string.Empty;

            query += string.Join(",", fields.ToArray());

            return query;
        }
    }
}
