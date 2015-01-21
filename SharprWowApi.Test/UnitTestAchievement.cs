using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestAchievement
    {
        private static ApiClient explorer;

        [TestMethod]
        public void Test_EU_Achivement_By_Id()
        {
            explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

            var achievement = explorer.GetAchievement(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Id);

        }

        [TestMethod]
        public void Test_US_Achivement_By_Id()
        {
            explorer = new ApiClient(Region.US, Locale.en_US, ApiKey.Value);

            var achievement = explorer.GetAchievement(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Id);

        }
    }
}
