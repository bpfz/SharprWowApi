using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class CharacterUtility
    {

        private const string AllOptions =
        "guild,stats,talents,items,reputation,titles,professions,appearance,petSlots,mounts,pets,achievements,progression,feed,pvp,quests,hunterPets";

        public static string BuildOptionalFields(CharacterOptions characterOptions)
        {
            var query = "&fields=";
            List<string> fields = new List<string>();

            switch (characterOptions)
            {
                case CharacterOptions.GetGuild:
                    fields.Add("guild");
                    break;
                case CharacterOptions.GetStats:
                    fields.Add("stats");
                    break;
                case CharacterOptions.GetTalents:
                    fields.Add("talents");
                    break;
                case CharacterOptions.GetItems:
                    fields.Add("items");
                    break;
                case CharacterOptions.GetReputation:
                    fields.Add("reputation");
                    break;
                case CharacterOptions.GetTitles:
                    fields.Add("titles");
                    break;
                case CharacterOptions.GetProfessions:
                    fields.Add("professions");
                    break;
                case CharacterOptions.GetAppearance:
                    fields.Add("appearance");
                    break;
                case CharacterOptions.GetPetSlots:
                    fields.Add("petSlots");
                    break;
                case CharacterOptions.GetMounts:
                    fields.Add("mounts");
                    break;
                case CharacterOptions.GetPets:
                    fields.Add("pets");
                    break;
                case CharacterOptions.GetAchievements:
                    fields.Add("achievements");
                    break;
                case CharacterOptions.GetProgression:
                    fields.Add("progression");
                    break;
                case CharacterOptions.GetFeed:
                    fields.Add("feed");
                    break;
                case CharacterOptions.GetPvP:
                    fields.Add("pvp");
                    break;
                case CharacterOptions.GetQuests:
                    fields.Add("quests");
                    break;
                case CharacterOptions.GetHunterPets:
                    fields.Add("hunterPets");
                    break;
                case CharacterOptions.GetEverything:
                    fields.Add(AllOptions);
                    break;
                default:
                    break;
            };

            if (fields.Count == 0) return string.Empty;

            query += fields[0].ToString();
            return query;
        }
    }
}
