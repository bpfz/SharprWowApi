
using Newtonsoft.Json;
namespace SharprWowApi.Models.Character
{

    public class CharacterPVPBrackets
    {
        [JsonProperty("Arena_Bracket_2v2")]
        public ArenaBracket ArenaBracket2v2 { get; set; }

        [JsonProperty("Arena_Bracket_3v3")]
        public ArenaBracket ArenaBracket3v3 { get; set; }

        [JsonProperty("Arena_Bracket_5v5")]
        public ArenaBracket ArenaBracket5v5 { get; set; }

        [JsonProperty("Arena_Bracket_RBG")]
        public ArenaBracket ArenaBracketRBG { get; set; }
    }
}
