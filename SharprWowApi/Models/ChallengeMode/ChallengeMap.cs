namespace SharprWowApi.Models.ChallengeMode
{
    public class ChallengeMap
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public bool HasChallengeMode { get; set; }

        public ChallengeCriteria BronzeCriteria { get; set; }

        public ChallengeCriteria SilverCriteria { get; set; }

        public ChallengeCriteria GoldCriteria { get; set; }
    }
}
