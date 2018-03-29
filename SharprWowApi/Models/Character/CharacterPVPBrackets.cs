using Newtonsoft.Json;

namespace SharprWowApi.Models.Character
{
    public class CharacterPvpBrackets
    {
        [JsonProperty("Arena_Bracket_2v2")]
        public ArenaBracket ArenaBracket2v2 { get; set; }

        [JsonProperty("Arena_Bracket_3v3")]
        public ArenaBracket ArenaBracket3v3 { get; set; }
   
        [JsonProperty("Arena_Bracket_RBG")]
        public ArenaBracket ArenaBracketRBG { get; set; }
    }
}
