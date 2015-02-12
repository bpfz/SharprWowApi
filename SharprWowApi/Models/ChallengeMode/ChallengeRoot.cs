using System.Collections.Generic;

namespace SharprWowApi.Models.ChallengeMode
{
    /// <summary>
    /// The data in this request has data for all 9 Challenge mode maps (currently).
    /// The map field includes the current medal times for each dungeon. Inside each ladder we provide data about each character that was part of each run.
    /// The character data includes the current cached spec of the character while the member field includes the spec of the character during the Challenge mode run.
    /// </summary>
    public class ChallengeRoot
    {
        public List<Challenge> Challenge { get; set; }
    }
}
