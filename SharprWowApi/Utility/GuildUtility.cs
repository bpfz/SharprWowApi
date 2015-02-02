using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class GuildUtility
    {
        private const string AllOptions = "members,achievements,news,challenge";

        public static string BuildOptionalFields(GuildOptions realmOptions)
        {
            string query = "&fields=";
            List<string> fields = new List<string>();

            switch (realmOptions)
            {
                case GuildOptions.GetMembers:
                    fields.Add("members");
                    break;
                case GuildOptions.GetAchievements:
                    fields.Add("achievements");
                    break;
                case GuildOptions.GetNews:
                    fields.Add("news");
                    break;
                case GuildOptions.GetChallenge:
                    fields.Add("challenge");
                    break;
                case GuildOptions.GetEverything:
                    fields.Add(AllOptions);
                    break;
                default:
                    return string.Empty;
            }

            query += fields[0];
            return query;
        }
    }
}
