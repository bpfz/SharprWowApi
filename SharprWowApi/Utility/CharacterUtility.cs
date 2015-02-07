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

            switch (characterOptions)
            {
                case CharacterOptions.GetGuild:
                    query += "guild";
                    break;
                case CharacterOptions.GetStats:
                    query += "stats";
                    break;
                case CharacterOptions.GetTalents:
                    query += "talents";
                    break;
                case CharacterOptions.GetItems:
                    query += "items";
                    break;
                case CharacterOptions.GetReputation:
                    query += "reputation";
                    break;
                case CharacterOptions.GetTitles:
                    query += "titles";
                    break;
                case CharacterOptions.GetProfessions:
                    query += "professions";
                    break;
                case CharacterOptions.GetAppearance:
                    query += "appearance";
                    break;
                case CharacterOptions.GetPetSlots:
                    query += "petSlots";
                    break;
                case CharacterOptions.GetMounts:
                    query += "mounts";
                    break;
                case CharacterOptions.GetPets:
                    query += "pets";
                    break;
                case CharacterOptions.GetAchievements:
                    query += "achievements";
                    break;
                case CharacterOptions.GetProgression:
                    query += "progression";
                    break;
                case CharacterOptions.GetFeed:
                    query += "feed";
                    break;
                case CharacterOptions.GetPvP:
                    query += "pvp";
                    break;
                case CharacterOptions.GetQuests:
                    query += "quests";
                    break;
                case CharacterOptions.GetHunterPets:
                    query += "hunterPets";
                    break;
                case CharacterOptions.GetEverything:
                    query += AllOptions;

                    break;
                default:
                    return string.Empty;
            };

            return query;
        }
    }
}
