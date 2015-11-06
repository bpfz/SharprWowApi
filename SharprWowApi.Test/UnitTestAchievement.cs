using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestAchievement
    {
        private static ApiClient client;
        private static ApiClientAsync client2;

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
        [TestMethod]
        public async Task Test_EU_Recipe_By_Id()
        {
            client2 = new ApiClientAsync(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var recipe = await client2.GetRecipeAsync(33994);
            var item = await client2.GetItemAsync("115542");
            Assert.IsNotNull(recipe.Id);
            Assert.IsNotNull(item.Id);

        }
    }
}
