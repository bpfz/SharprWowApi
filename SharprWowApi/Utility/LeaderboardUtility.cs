using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class LeaderboardUtility
    {

        public static string buildOptionalQuery(LeaderboardOptions leaderboardOptions)
        {
            string query = "&fields=";
            List<string> fields = new List<string>();

            switch (leaderboardOptions)
            {
                case LeaderboardOptions.TwoVersusTwo:
                    fields.Add("2v2");
                    break;
                case LeaderboardOptions.ThreeVersusThree:
                    fields.Add("3v3");
                    break;
                case LeaderboardOptions.FiveVersusFive:
                    fields.Add("5v5");
                    break;
                case LeaderboardOptions.RBG:
                    fields.Add("RBG");
                    break;
            }

            query += fields[0];
            return query;
        }
    }
}
