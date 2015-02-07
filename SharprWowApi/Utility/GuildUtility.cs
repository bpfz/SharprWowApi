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

            switch (realmOptions)
            {
                case GuildOptions.GetMembers:
                    query += "members";
                    break;
                case GuildOptions.GetAchievements:
                    query += "achievements";
                    break;
                case GuildOptions.GetNews:
                    query += "news";
                    break;
                case GuildOptions.GetChallenge:
                    query += "challenge";
                    break;
                case GuildOptions.GetEverything:
                    query += AllOptions;
                    break;
                default:
                    return string.Empty;
            }

            return query;
        }
    }
}
