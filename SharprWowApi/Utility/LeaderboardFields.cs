using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class LeaderboardFields
    {
        public static string BuildOptionalQuery(LeaderboardOptions leaderboardOptions)
        {
            string query = "&fields=";

            switch (leaderboardOptions)
            {
                case LeaderboardOptions.TwoVersusTwo:
                    query += "2v2";
                    break;
                case LeaderboardOptions.ThreeVersusThree:
                    query += "3v3";
                    break;
                case LeaderboardOptions.FiveVersusFive:
                    query += "5v5";
                    break;
                case LeaderboardOptions.RBG:
                    query += "RBG";
                    break;
            }

            return query;
        }
    }
}
