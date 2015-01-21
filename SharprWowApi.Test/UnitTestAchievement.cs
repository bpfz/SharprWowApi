using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestAchievement
    {
        private static ApiClient client;

        [TestMethod]
        public void Test_EU_Achivement_By_Id()
        {
            client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var achievement = client.GetAchievement(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Title);

        }

        [TestMethod]
        public void Test_US_Achivement_By_Id()
        {
            client = new ApiClient(Region.US, Locale.en_US, TestConstants.ApiKey);

            var achievement = client.GetAchievement(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Id);

        }
    }
}
