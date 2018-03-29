using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class AchievementTests  : TestBase
    {

        [TestMethod]
        [TestCategory("Achievement")]
        public async Task Achievment_By_Id()
        {
            var achievement = await EuClient.GetAchievementAsync(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Title);

        }

        [TestMethod]
        [TestCategory("Achievement")]
        public async Task Achivement_By_Id()
        {
            var achievement = await EuClient.GetAchievementAsync(2144);

            Assert.IsNotNull(achievement.Id);
            Assert.IsNotNull(achievement.Points);
            Assert.IsNotNull(achievement.Reward);
            Console.WriteLine(achievement.Id);
        }

        [TestMethod]
        [TestCategory("Recipe")]
        public async Task Recipe_By_Id()
        {
            var recipe = await EuClient.GetRecipeAsync(33994);
            var item = await EuClient.GetItemAsync("115542");
            Assert.IsNotNull(recipe.Id);
            Assert.IsNotNull(item.Id);

        }
    }
}
