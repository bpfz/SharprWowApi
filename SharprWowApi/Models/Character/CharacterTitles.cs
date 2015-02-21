namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// A list of the titles obtained by the character including the currently selected title.
    /// </summary>
    public class CharacterTitles
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? Selected { get; set; }
    }
}
