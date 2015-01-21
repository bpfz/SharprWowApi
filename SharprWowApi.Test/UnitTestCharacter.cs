using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharprWowApi.Models.Character;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestCharacter
    {
        private static ApiClient explorer;


        [TestMethod]
        public void Test_CharacterRoot_EU()
        {
            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var character = explorer.GetCharacter("Grim Batol", "Hjortronsmak", CharacterOptions.None);

            Assert.IsNotNull(character.Name);

        }
        [TestMethod]
        public void Test_CharacterRoot_US()
        {
            explorer = new ApiClient(Region.US, Locale.en_US, ApiKey.Value);

            var character = explorer.GetCharacter("Tichondrius", "Smexxin", CharacterOptions.None);

            Assert.IsNotNull(character.Name);
        }

        [TestMethod]
        public void Test_CharacterRoot_Achievement_EU()
        {
            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var character = explorer.GetCharacter("Grim Batol", "Hjortronsmak", CharacterOptions.GetAchievements);

            Assert.IsNotNull(character.Achievements.AchievementsCompleted[1]);
            Assert.IsNotNull(character.Achievements.Criteria[1]);
            Assert.IsNotNull(character.Achievements.Criteria);

        }

        [TestMethod]
        public void Test_CharacterRoot_PVP_EU()
        {

            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var character = explorer.GetCharacter("Grim Batol", "xzy", CharacterOptions.GetPvP);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_3v3.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_5v5.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_RBG.Rating);

        }
        [TestMethod]
        public void Test_CharacterRoot_Items_EU()
        {
            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);
            var character = explorer.GetCharacter("Grim Batol", "xzy", CharacterOptions.GetItems);

            foreach (var stat in character.Items.Finger1.Stats)
            {
                Assert.IsNotNull(stat.stat);
            }
            Assert.IsNotNull(character.Items.AverageItemLevel);
            Assert.IsNotNull(character.Items.Finger2.Id);
            Assert.IsNotNull(character.Items.AverageItemLevel);
        }

        [TestMethod]
        public void Test_CharacterRoot_Everything_EU()
        {

            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var character = explorer.GetCharacter("Grim Batol", "hjortronsmak", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
            Assert.IsNotNull(character.AchievementPoints);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Appearance);
            Assert.IsNotNull(character.Battlegroup);
            Assert.IsNotNull(character.CalcClass);
            Assert.IsNotNull(character.Feed);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Level);

            foreach (var raid in character.Progression.Raids)
            {
                var boss = from b in raid.Bosses
                           select b.Id;

                Assert.IsNotNull(boss);

            }
            Assert.AreEqual(CharacterClass.Priest, character.Class);

            //character.Race should be "Pandaren_Alliance", ' ' replaced by '_'
            Assert.AreEqual(CharacterRace.Pandaren_Alliance, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }

        [TestMethod]
        public async Task Test_CharacterRoot_Everything_EU_async()
        {

            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var character = await explorer.GetCharacterAsync("Grim Batol", "hjortronsmak", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
            Assert.IsNotNull(character.AchievementPoints);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Appearance);
            Assert.IsNotNull(character.Battlegroup);
            Assert.IsNotNull(character.CalcClass);
            Assert.IsNotNull(character.Feed);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Level);

            foreach (var raid in character.Progression.Raids)
            {
                var boss = from b in raid.Bosses
                           select b.Id;

                Assert.IsNotNull(boss);
            }

            Assert.AreEqual(CharacterClass.Priest, character.Class);

            //character.Race should be "Pandaren_Alliance", ' ' replaced by '_'
            Assert.AreEqual(CharacterRace.Pandaren_Alliance, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }

        [TestMethod]
        public void Test_CharacterRoot_Everything_US()
        {

            explorer = new ApiClient(Region.US, Locale.en_US, ApiKey.Value);

            var character = explorer.GetCharacter("Tichondrius", "smexxin", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
            Assert.IsNotNull(character.AchievementPoints);
            Assert.IsNotNull(character.Achievements);
            Assert.IsNotNull(character.Appearance);
            Assert.IsNotNull(character.Battlegroup);
            Assert.IsNotNull(character.CalcClass);
            Assert.IsNotNull(character.Feed);
            Assert.IsNotNull(character.Guild);
            Assert.IsNotNull(character.Level);

            foreach (var raid in character.Progression.Raids)
            {
                var boss = from b in raid.Bosses
                           select b.Id;

                Assert.IsNotNull(boss);

            }
            Assert.AreEqual(CharacterClass.Warrior, character.Class);

            Assert.AreEqual(CharacterRace.Human, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }

    }
}
