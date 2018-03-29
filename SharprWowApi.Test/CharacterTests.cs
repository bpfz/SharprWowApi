using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharprWowApi.Models.Character;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class CharacterTests : TestBase
    {
        private static WowClient client;


        [TestMethod]
        [TestCategory("Character")]

        public async Task Test_CharacterRoot()
        {
            var character = await EuClient.GetCharacterAsync(
                "Hjortronsmak",
                CharacterOptions.None,
                TestConstants.EU_en_GB_Realm);

            Assert.IsNotNull(character.Name);

            var usCharacter = await UsClient.GetCharacterAsync(
                "Smexxin",
                CharacterOptions.None,
                TestConstants.US_en_US_Realm);

            Assert.IsNotNull(usCharacter.Name);
        }

        [TestMethod]
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_Guild()
        {
            var character = await EuClient.GetCharacterAsync(
                "Hjortronsmak",
                CharacterOptions.Guild,
                TestConstants.EU_en_GB_Realm);

            var str = Enum.GetName(typeof(CharacterOptions), CharacterOptions.Guild);

            Console.WriteLine(str);
            Assert.IsNotNull(character.Name);
            Assert.IsNotNull(character.Guild);

        }


        [TestMethod]
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_Achievement()
        {
            var options = CharacterOptions.Achievements | CharacterOptions.Guild | CharacterOptions.Items;

            var character = await EuClient.GetCharacterAsync(
                "Hjortronsmak",
                options,
                TestConstants.EU_en_GB_Realm);

            Console.WriteLine(character.Name);
            Assert.IsNotNull(character.Achievements.AchievementsCompleted.ElementAt(1));
            Assert.IsNotNull(character.Achievements.Criteria.ElementAt(1));
            Assert.IsNotNull(character.Achievements.Criteria);

        }

        [TestMethod]
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_PVP()
        {

            var character = await EuClient.GetCharacterAsync(
                "xzy",
                CharacterOptions.PvP,
                TestConstants.EU_en_GB_Realm);

            Console.WriteLine(character.Pvp.Brackets.ArenaBracket2v2.Rating);
            Assert.IsTrue(character.TotalHonorableKills > 0);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket2v2.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracket3v3.Rating);
            Assert.IsNotNull(character.Pvp.Brackets.ArenaBracketRBG.Rating);

        }
        [TestMethod]
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_Items()
        {
            var character = await EuClient.GetCharacterAsync(
                "xzy",
                CharacterOptions.Items,
                TestConstants.EU_en_GB_Realm);

            foreach (var stat in character.Items.Finger1.Stats)
            {
                Assert.IsNotNull(stat.Stat);
            }

            Assert.IsNotNull(character.Items.AverageItemLevel);
            Assert.IsNotNull(character.Items.Finger2.Id);
            Assert.IsNotNull(character.Items.AverageItemLevel);
        }

        [TestMethod]
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_Everything()
        {
            var character = await EuClient.GetCharacterAsync(
                "hjortronsmak",
                CharacterOptions.AllOptions,
                TestConstants.EU_en_GB_Realm);

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
        [TestCategory("Character")]
        public async Task Test_CharacterRoot_Everything_US()
        {
            var character = await UsClient.GetCharacterAsync(
                "smexxin",
                CharacterOptions.AllOptions,
                TestConstants.US_en_US_Realm);

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

            Assert.AreEqual(CharacterRace.Orc, character.Race);

            Console.WriteLine("Class: " + character.Class);
            Console.WriteLine("Race: " + character.Race);
            Console.WriteLine("Gender: " + character.Gender);
        }
    }
}
