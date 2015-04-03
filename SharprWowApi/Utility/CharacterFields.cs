using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class CharacterFields
    {
        //http://stackoverflow.com/questions/1285986/flags-enum-bitwise-operations-vs-string-of-bits
        //http://www.codeproject.com/Articles/396851/Ending-the-Great-Debate-on-Enum-Flags
        public static string BuildOptionalFields(CharacterOptions characterOptions)
        {
            var fields = "&fields=";
            var fieldList = new List<object>();

            if ((characterOptions & CharacterOptions.Guild) == CharacterOptions.Guild)
            {
                fieldList.Add("guild");
            }

            if ((characterOptions & CharacterOptions.Stats) == CharacterOptions.Stats)
            {
                fieldList.Add("stats");
            }

            if ((characterOptions & CharacterOptions.Talents) == CharacterOptions.Talents)
            {
                fieldList.Add("talents");
            }

            if ((characterOptions & CharacterOptions.Items) == CharacterOptions.Items)
            {
                fieldList.Add("items");
            }

            if ((characterOptions & CharacterOptions.Reputation) == CharacterOptions.Reputation)
            {
                fieldList.Add("reputation");
            }

            if ((characterOptions & CharacterOptions.Titles) == CharacterOptions.Titles)
            {
                fieldList.Add("titles");
            }

            if ((characterOptions & CharacterOptions.Professions) == CharacterOptions.Professions)
            {
                fieldList.Add("professions");
            }

            if ((characterOptions & CharacterOptions.Appearance) == CharacterOptions.Appearance)
            {
                fieldList.Add("appearance");
            }

            if ((characterOptions & CharacterOptions.PetSlots) == CharacterOptions.PetSlots)
            {
                fieldList.Add("petSlots");
            }

            if ((characterOptions & CharacterOptions.Mounts) == CharacterOptions.Mounts)
            {
                fieldList.Add("mounts");
            }

            if ((characterOptions & CharacterOptions.Pets) == CharacterOptions.Pets)
            {
                fieldList.Add("pets");
            }

            if ((characterOptions & CharacterOptions.Achievements) == CharacterOptions.Achievements)
            {
                fieldList.Add("achievements");
            }

            if ((characterOptions & CharacterOptions.Progression) == CharacterOptions.Progression)
            {
                fieldList.Add("progression");
            }

            if ((characterOptions & CharacterOptions.Feed) == CharacterOptions.Feed)
            {
                fieldList.Add("feed");
            }

            if ((characterOptions & CharacterOptions.PvP) == CharacterOptions.PvP)
            {
                fieldList.Add("pvp");
            }

            if ((characterOptions & CharacterOptions.Quests) == CharacterOptions.Quests)
            {
                fieldList.Add("quests");
            }

            if ((characterOptions & CharacterOptions.HunterPets) == CharacterOptions.HunterPets)
            {
                fieldList.Add("hunterPets");
            }

            if (fieldList.Count == 0)
            {
                return string.Empty;
            }

            fields += string.Join(",", fieldList);
            return fields;

            /*  private const string AllOptions =
       "guild,stats,talents,items,reputation,titles,professions,appearance,petSlots,mounts,pets,Achievements,progression,feed,pvp,quests,hunterPets";
                       switch (characterOptions)
                       {
                           case CharacterOptions.Guild:
                               fields += "guild";
                               break;
                           case CharacterOptions.Stats:
                               fields += "stats";
                               break;
                           case CharacterOptions.Talents:
                               fields += "talents";
                               break;
                           case CharacterOptions.Items:
                               fields += "items";
                               break;
                           case CharacterOptions.Reputation:
                               fields += "reputation";
                               break;
                           case CharacterOptions.Titles:
                               fields += "titles";
                               break;
                           case CharacterOptions.Professions:
                               fields += "professions";
                               break;
                           case CharacterOptions.Appearance:
                               fields += "appearance";
                               break;
                           case CharacterOptions.PetSlots:
                               fields += "petSlots";
                               break;
                           case CharacterOptions.Mounts:
                               fields += "mounts";
                               break;
                           case CharacterOptions.Pets:
                               fields += "pets";
                               break;
                           case CharacterOptions.Achievements:
                               fields += "Achievements";
                               break;
                           case CharacterOptions.Progression:
                               fields += "progression";
                               break;
                           case CharacterOptions.Feed:
                               fields += "feed";
                               break;
                           case CharacterOptions.PvP:
                               fields += "pvp";
                               break;
                           case CharacterOptions.Quests:
                               fields += "quests";
                               break;
                           case CharacterOptions.HunterPets:
                               fields += "hunterPets";
                               break;
                           case CharacterOptions.AllOptions:
                               fields += AllOptions;
                               break;
                           default:
                               return string.Empty;
                       };*/
        }
    }
}
