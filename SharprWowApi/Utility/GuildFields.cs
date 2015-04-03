using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class GuildFields
    {
        //http://stackoverflow.com/questions/1285986/flags-enum-bitwise-operations-vs-string-of-bits
        //http://www.codeproject.com/Articles/396851/Ending-the-Great-Debate-on-Enum-Flags
        public static string BuildOptionalFields(GuildOptions guildOptions)
        {
            string fields = "fields=";
            var fieldList = new List<string>();

            if ((guildOptions & GuildOptions.Members) == GuildOptions.Members)
            {
                fieldList.Add("members");
            }

            if ((guildOptions & GuildOptions.Achievements) == GuildOptions.Achievements)
            {
                fieldList.Add("achivements");
            }

            if ((guildOptions & GuildOptions.News) == GuildOptions.News)
            {
                fieldList.Add("news");
            }

            if ((guildOptions & GuildOptions.Challenge) == GuildOptions.Challenge)
            {
                fieldList.Add("challenge");
            }

            if (fieldList.Count == 0)
            {
                return string.Empty;
            }

            fields += string.Join(",", fieldList);
            return fields;
        }
    }
}
