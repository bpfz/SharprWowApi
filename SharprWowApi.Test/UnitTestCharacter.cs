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
        private static ApiClient client;


        [TestMethod]
        public void Test_CharacterRoot_EU()
        {
            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.EU_en_GB_Realm, "Hjortronsmak", CharacterOptions.None);

            Assert.IsNotNull(character.Name);

        }

        [TestMethod]
        public void Test_CharacterRoot_EU2()
        {
            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.EU_en_GB_Realm, TestConstants.ApiKey);

            var character = client.GetCharacter("Hjortronsmak", CharacterOptions.None);

            Assert.IsNotNull(character.Name);

        }
        [TestMethod]
        public void Test_CharacterRoot_US()
        {
            client = new ApiClient(Region.US, Locale.en_US, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.US_en_US_Realm, "Smexxin", CharacterOptions.None);

            Assert.IsNotNull(character.Name);
        }

        [TestMethod]
        public void Test_CharacterRoot_Achievement_EU()
        {
            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.EU_en_GB_Realm, "Hjortronsmak", CharacterOptions.GetAchievements);

            Console.WriteLine(character.Name);
            Assert.IsNotNull(character.Achievements.AchievementsCompleted[1]);
            Assert.IsNotNull(character.Achievements.Criteria[1]);
            Assert.IsNotNull(character.Achievements.Criteria);

        }

        [TestMethod]
        public void Test_CharacterRoot_PVP_EU()
        {

            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.EU_en_GB_Realm, "xzy", CharacterOptions.GetPvP);

            Console.WriteLine(character.Pvp.Brackets.ArenaBracket2v2.Rating);
            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket2v2.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket3v3.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket5v5.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracketRBG.Rating);

        }
        [TestMethod]
        public void Test_CharacterRoot_Items_EU()
        {
            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);
            var character = client.GetCharacter(TestConstants.EU_en_GB_Realm, "xzy", CharacterOptions.GetItems);

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

            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.EU_en_GB_Realm, "hjortronsmak", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket2v2.Rating);
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

            Assert.AreEqual(CharacterRace.Pandaren_Alliance, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }

        [TestMethod]
        public async Task Test_CharacterRoot_Everything_EU_async()
        {

            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var character = await client.GetCharacterAsync(TestConstants.EU_en_GB_Realm, "hjortronsmak", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket2v2.Rating);
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

            Assert.AreEqual(CharacterRace.Pandaren_Alliance, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }

        [TestMethod]
        public void Test_CharacterRoot_Everything_US()
        {

            client = new ApiClient(Region.US, Locale.en_US, TestConstants.ApiKey);

            var character = client.GetCharacter(TestConstants.US_en_US_Realm, "smexxin", CharacterOptions.GetEverything);

            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket2v2.Rating);
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
