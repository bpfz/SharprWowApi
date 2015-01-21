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
        List<string> tmp = new List<string>();

          if ((leaderboardOptions & LeaderboardOptions.TwoVersusTwo).Equals(LeaderboardOptions.TwoVersusTwo))
                tmp.Add("2v2");

            if ((leaderboardOptions & LeaderboardOptions.ThreeVersusThree).Equals(LeaderboardOptions.ThreeVersusThree))
                tmp.Add("3v3");

            if ((leaderboardOptions & LeaderboardOptions.FiveVersusFive).Equals(LeaderboardOptions.FiveVersusFive))
                tmp.Add("5v5");

             if ((leaderboardOptions & LeaderboardOptions.RBG).Equals(LeaderboardOptions.RBG))
                tmp.Add("5v5");

            if (tmp.Count == 0) return "3v3";

            query += string.Join(",", tmp.ToArray());

            return query;

    }
    }
}
