using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class GuildUtility
    {
        public static string BuildOptionalFields(GuildOptions realmOptions)
        {
            string query = "&fields=";
            List<string> fields = new List<string>();

            if ((realmOptions & GuildOptions.GetMembers).Equals(GuildOptions.GetMembers))
                fields.Add("members");

            if ((realmOptions & GuildOptions.GetAchievements).Equals(GuildOptions.GetAchievements))
                fields.Add("achievements");

            if ((realmOptions & GuildOptions.GetNews).Equals(GuildOptions.GetNews))
                fields.Add("news");

            if ((realmOptions & GuildOptions.GetChallenge).Equals(GuildOptions.GetChallenge))
                fields.Add("news");

            if (fields.Count == 0) return string.Empty;

            query += string.Join(",", fields.ToArray());

            return query;
        }
    }
}
