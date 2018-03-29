using System.Collections.Generic;
using System.Threading.Tasks;
using SharprWowApi.Models.Achievement;
using SharprWowApi.Models.Auction;
using SharprWowApi.Models.BattlePet;
using SharprWowApi.Models.ChallengeMode;
using SharprWowApi.Models.Character;
using SharprWowApi.Models.DataResources;
using SharprWowApi.Models.Guild;
using SharprWowApi.Models.Item;
using SharprWowApi.Models.PVP;
using SharprWowApi.Models.Quest;
using SharprWowApi.Models.RealmStatus;
using SharprWowApi.Models.Recipe;
using SharprWowApi.Models.Spells;

namespace SharprWowApi
{
    public interface IGetDataAsync
    {
        Task<AchievementRoot> GetAchievementAsync(int achievementId);
        Task<DataAchievementRoot> GetAchievementsDataAsync();
        Task<AuctionFilesRoot> GetAuctionFileAsync();
        Task<AuctionFilesRoot> GetAuctionFileAsync(string realm);
        Task<AuctionsRoot> GetAuctionsAsync();
        Task<AuctionsRoot> GetAuctionsAsync(string realm);
        Task<AuctionsRoot> GetAuctionsAsync(string realm, string auctionUrl);
        Task<DataBattleGroupRoot> GetBattlegroupDataAsync();
        Task<BattlePetAbilitiesRoot> GetBattlePetAbilitiesAsync(int abilityId);
        Task<BattlePetSpeciesRoot> GetBattlePetSpeciesAsync(int speciesId);
        Task<BattlePetStatsRoot> GetBattlePetStatsAsync(int speciesId);
        Task<ChallengeRoot> GetChallengeModeLeaderboardAsync();
        Task<ChallengeRoot> GetChallengeModeLeaderboardAsync(string realm);
        Task<ChallengeRoot> GetChallengeModeLeaderboardForRegionAsync();
        Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions);
        Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions, string realm);
        Task<List<CharacterRoot>> GetCharactersInGuildAsync(IEnumerable<GuildMember> guildMembers, CharacterOptions characterOptions, int levelThreshold, int membersToTake);
        Task<HashSet<CharacterRoot>> GetCharactersInGuildAsync(string[] guildMembers, CharacterOptions characterOptions);
        Task<DataCharacterClassesRoot> GetClassDataAsync();
        Task<DataGuildAchivementRoot> GetGuildAchievementDataAsync();
        Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions);
        Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions, string realm);
        Task<DataGuildPerksRoot> GetGuildPerkDataAsync();
        Task<DataGuildRewardsRoot> GetGuildRewardDataAsync();
        Task<ItemRoot> GetItemAsync(string itemId);
        Task<DataItemClassRoot> GetItemClassDataAsync();
        Task<ItemSetRoot> GetItemSet(string itemSetId);
        Task<LeaderboardRoot> GetLeaderboardAsync(LeaderboardOptions leaderboardOptions);
        Task<DataPetTypesRoot> GetPetTypeDataAsync();
        Task<QuestRoot> GetQuestAsync(int questId);
        Task<DataRacesRoot> GetRaceDataAsync();
        Task<RealmRoot> GetRealmStatusAsync();
        Task<RecipeRoot> GetRecipeAsync(int recipeId);
        Task<SpellRoot> GetSpellAsync(int spellId);
    }
}