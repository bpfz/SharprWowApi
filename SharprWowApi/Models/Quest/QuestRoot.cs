namespace SharprWowApi.Models.Quest
{
    public class QuestRoot
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReqLevel { get; set; }

        public int SuggestedPartyMembers { get; set; }

        public string Category { get; set; }

        public int Level { get; set; }
    }
}
