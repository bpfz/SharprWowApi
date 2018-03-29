using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharprWowApi.Models.Achievement;
using SharprWowApi.Models.Auction;
using SharprWowApi.Models.BattlePet;
using SharprWowApi.Models.ChallengeMode;
using SharprWowApi.Models.Character;
using SharprWowApi.Models.DataResources;
using SharprWowApi.Models.Guild;
using SharprWowApi.Models.Item;
using SharprWowApi.Models.Pvp;
using SharprWowApi.Models.Quest;
using SharprWowApi.Models.RealmStatus;
using SharprWowApi.Models.Recipe;
using SharprWowApi.Models.Spells;
using SharprWowApi.Utility;
using SharprWowApi.Models.Zone;
using SharprWowApi.Models.Mount;

namespace SharprWowApi
{
    public abstract class GetDataAsync : GetDataBase
    {
        private JsonUtility _jsonUtility;

        public GetDataAsync()
        {
            _jsonUtility = new JsonUtility();
        }

        #region Achievement
        public async Task<AchievementRoot> GetAchievementAsync(int achievementId)
        {
            var url = $"{Host}/wow/achievement/{achievementId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<AchievementRoot>(url);
        }
        #endregion

        #region auctions
        public async Task<AuctionFilesRoot> GetAuctionFileAsync()
        {
            return await this.GetAuctionFileAsync(this.Realm);
        }

        /// <summary>
        /// Gets the the url to othe auction datablob
        /// </summary>
        /// <param name="realm">The realm which you want to retrieve the  data from. Method replaces an space ' ' with '-'.
        ///  <example>"Grim Batol" becomes "Grim-Batol"</example>
        /// </param>
        /// <returns>AuctionFile root containing a list containing URLs to the auction datablob (usually there's only one)</returns>
        public async Task<AuctionFilesRoot> GetAuctionFileAsync(string realm)
        {
            realm.ToLower().Replace(' ', '-');

            var url = $"{Host}/wow/auction/data/{realm}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<AuctionFilesRoot>(url);
        }

        /// <summary>
        /// Gets Realm from client
        /// </summary>
        /// <remarks>
        /// sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0. (First run only)
        /// </remarks>
        /// <returns>AuctionsRoot object</returns>
        public async Task<AuctionsRoot> GetAuctionsAsync()
        {
            return await this.GetAuctionsAsync(this.Realm);
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// Sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0.
        /// </remarks>
        /// <param name="realm"></param>
        /// <returns>AuctionsRoot object</returns>
        public async Task<AuctionsRoot> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await this.GetAuctionFileAsync(realm);

            var auctionUrl = auctionFiles.Files.FirstOrDefault(file => !string.IsNullOrEmpty(file.Url)).Url;
            if (auctionUrl == null)
            {
                throw new System.NullReferenceException($"Could not find an url to the auctions. Make sure this is correctly a spelled realm: {realm}");
            }
            return await this._jsonUtility.GetDataFromURLAsync<AuctionsRoot>(auctionUrl);
        }

        public async Task<AuctionsRoot> GetAuctionsAsync(string realm, string auctionUrl)
        {
            return await this._jsonUtility.GetDataFromURLAsync<AuctionsRoot>(auctionUrl);
        }
        #endregion

        #region battlePet

        /// <summary>
        /// This provides data about a individual battle pet ability ID.
        /// </summary>
        /// <param name="abilityId">ID of the ability you want to retrieve</param>
        /// <returns>BattlePetAbilitiesRoot object</returns>
        public async Task<BattlePetAbilitiesRoot> GetBattlePetAbilitiesAsync(int abilityId)
        {
            var url = $"{Host}/wow/battlepet/ability/{abilityId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<BattlePetAbilitiesRoot>(url);
        }

        /// <summary>
        /// Get pet species from ID.
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns>BattlePetSpeciesRoot object</returns>
        public async Task<BattlePetSpeciesRoot> GetBattlePetSpeciesAsync(int speciesId)
        {
            var url = $"{Host}/wow/battlepet/species/{speciesId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<BattlePetSpeciesRoot>(url);
        }

        /// <summary>
        /// Get stats from species
        /// </summary>
        /// <param name="speciesId">Species ID</param>
        /// <returns>BattlePetStatsRoot object</returns>
        public async Task<BattlePetStatsRoot> GetBattlePetStatsAsync(int speciesId)
        {
            var url = $"{Host}/wow/battlepet/FollowerStats/{speciesId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<BattlePetStatsRoot>(url);
        }

        #endregion

        #region challenge

        /// <summary>
        /// Uses realm from ApiClient.
        /// </summary>
        /// <returns></returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync()
        {
            return await this.GetChallengeModeLeaderboardAsync(this.Realm);
        }

        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync(string realm)
        {
            var url = $"{Host}/wow/Challenge/{realm}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<ChallengeRoot>(url);
        }

        /// <summary>
        /// Leaderboard for Challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardForRegionAsync()
        {
            var url = $"{Host}/wow/Challenge/region?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<ChallengeRoot>(url);
        }
        #endregion

        #region character

        /// <summary>
        /// Gets data about a character. Use this if you have set the realm in ApiClient.
        /// </summary>
        /// <param name="name">The Characters name</param>
        /// <param name="characterOptions">What characteroptions should be set (enum)</param>
        /// <returns>CharacterRoot object</returns>
        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions)
        {
            return await this.GetCharacterAsync(name, characterOptions, this.Realm);
        }

        /// <summary>
        /// Gets data about a character.
        /// </summary>
        /// <param name="name">The Characters name.</param>
        /// <param name="characterOptions">What characteroptions should be set (enum).</param>
        /// <param name="realm">The realm this character exists on.</param>
        /// <returns>CharacterRoot object</returns>
        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions, string realm)
        {
            var url = $"{Host}/wow/character/{realm}/{name}?locale={Locale}{CharacterFields.BuildOptionalFields(characterOptions)}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<CharacterRoot>(url);
        }

        #endregion

        #region GetGuildCharactersAsync

        /// <summary>
        /// Creates a list with CharacterRoot for every member in given guild.
        /// To avoid calling the wow api more than 100 times per second, this method limits the list of guild members (integer) to take.
        /// </summary>
        /// <param name="guildMembers">List with guildmembers</param>
        /// <param name="characterOptions">Options for CharacterRoot</param>
        /// <param name="levelThreshold">Take only members above or equal to this integer</param>
        /// <param name="membersToTake">How many members should be returned (mind the 100 calls per second cap)</param>
        /// <returns>List filled with characterRoot</returns>
        public async Task<List<CharacterRoot>> GetCharactersInGuildAsync(
            IEnumerable<GuildMember> guildMembers,
            CharacterOptions characterOptions,
            int levelThreshold,
            int membersToTake)
        {
            ////var guild = GetGuild(guildName, GuildOptions.Members, _Realm);
            var characterList = new List<CharacterRoot>();

            var order = from guildMemberLevel in guildMembers
                        orderby guildMemberLevel.Character.Level descending
                        select guildMemberLevel;

            var downloadTasksQuery = from member in order.Take(membersToTake)
                                     where member.Character.Level >= levelThreshold
                                     select this.GetCharacterAsync(
                                     member.Character.Name,
                                     characterOptions,
                                     Realm);

            var downloadTasks = downloadTasksQuery.ToList();

            while (downloadTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                var character = await finishedTask;
                characterList.Add(character);
            }

            return characterList;
        }

        /// <summary>
        /// Creates a list with CharacterRoot for every member in given guild using an array with the names of those members.
        /// </summary>
        /// <param name="guildMembers">string array with guildmembers</param>
        /// <param name="characterOptions"></param>
        /// <returns>HashSet filled with characterRoot objects</returns>
        public async Task<HashSet<CharacterRoot>> GetCharactersInGuildAsync(
            string[] guildMembers,
         CharacterOptions characterOptions)
        {
            var memberHashSet = new HashSet<string>(guildMembers);
            var characterHashSet = new HashSet<CharacterRoot>();

            var downloadTasks = new HashSet<Task<CharacterRoot>>();

            for (int i = 0; i < memberHashSet.Count; i++)
            {
                downloadTasks.Add(this.GetCharacterAsync(memberHashSet.ElementAt(i), characterOptions, this.Realm));
            }

            while (downloadTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                var finished = await finishedTask;
                characterHashSet.Add(finished);
            }

            return characterHashSet;
        }

        #endregion

        #region guild

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="guildOptions"></param>
        /// <returns></returns>
        public async Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions)
        {
            return await this.GetGuildAsync(name, guildOptions, this.Realm);
        }

        //realm in getGuildAsync does not work (404 not found), why? setting realm in apiclient constructor works.
        public async Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions, string realm)
        {
            var url = $"{Host}/wow/guild/{realm}/{name}?{GuildFields.BuildOptionalFields(guildOptions)}&locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<GuildRoot>(url);
        }

        /// <summary>
        /// Gets all members in a guild above a set level threshold (>=) and adds them to a string that can be inserted into an array (manually).
        /// Used for testing. Dont try to use this in anything other than testing.  Best to leave it closed.
        /// </summary>
        /// <example>returns: {"name", "name2", "name3"};</example>
        /// <param name="guildmembers">The guild you want to get members from.</param>
        /// <param name="lvlThreshold">Gets all characters above or at this level.</param>
        /// <returns>returns string[] with the names of all guildmembers over lvlThreshold (>=).</returns>
        internal string GetGuildMembers(GuildRoot guildmembers, int lvlThreshold)
        {
            var guildMembers = from members in guildmembers.Members
                               where members.Character.Level >= lvlThreshold
                               orderby members.Character.Level descending
                               select members.Character.Name;

            var memberArray = guildMembers.ToArray();
            var format = string.Format("{0}, {1}", (char)34, (char)34);
            string memberString = "{" + (char)34 + string.Join(format, memberArray) + (char)34 + "};";

            return memberString;
        }

        #endregion

        #region items

        /// <summary>
        /// The item API provides detailed item information.
        /// This includes item set information if this item is part of a set.
        /// </summary>
        /// <param name="itemId">the id of the item</param>
        /// <returns>ItemRoot object</returns>
        public async Task<ItemRoot> GetItemAsync(string itemId)
        {
            var url = $"{Host}/wow/item/{itemId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<ItemRoot>(url);
        }

        /// <summary>
        /// This data can also be found using GetItem if the item is part of a set. 
        /// </summary>
        /// <example>
        /// You can use this if you already know the set ID, ie 1060. 
        /// Can be a good choice if you don't need all stats for each item that you would get from the GetItem method.
        /// </example>
        /// <param name="itemSetId"></param>
        /// <returns></returns>
        public async Task<ItemSetRoot> GetItemSet(string itemSetId)
        {
            var url = $"{Host}/wow/item/{itemSetId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<ItemSetRoot>(url);
        }

        #endregion

        #region pvp
        /// <summary>
        /// Leaderboard for 2v2, 3v3, 5v5 or RBG
        /// </summary>
        /// <param name="leaderboardOptions">choose between 2v2, 3v3, 5v5 or RBG leaderboard</param>
        /// <returns>LeaderboardRoot object</returns>
        public async Task<LeaderboardRoot> GetLeaderboardAsync(LeaderboardOptions leaderboardOptions)
        {
            var url = $"{Host}/wow/leaderboard/{LeaderboardFields.BuildOptionalQuery(leaderboardOptions)}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<LeaderboardRoot>(url);
        }

        #endregion

        #region quest

        /// <summary>
        /// Get quest from quest ID
        /// </summary>
        /// <param name="questId">Quest ID</param>
        /// <returns>QuestRoot object</returns>
        public async Task<QuestRoot> GetQuestAsync(int questId)
        {
            var url = $"{Host}/wow/quest/{questId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<QuestRoot>(url);
        }

        #endregion

        #region Recipe

        public async Task<RecipeRoot> GetRecipeAsync(int recipeId)
        {
            var url = $"{Host}/wow/recipe/{recipeId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<RecipeRoot>(url);
        }

        #endregion

        #region RealmStatus

        /// <summary>
        /// Gets status for realms in your _Locale (EU, US etc.)
        /// </summary>
        /// <returns>RealmRoot object</returns>
        public async Task<RealmRoot> GetRealmStatusAsync()
        {
            var url = $"{Host}/wow/realm/status?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<RealmRoot>(url);
        }

        #endregion

        #region Spells
        public async Task<SpellRoot> GetSpellAsync(int spellId)
        {
            var url = $"{Host}/wow/spell/{spellId}?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<SpellRoot>(url);
        }

        #endregion

        #region dataresources

        #region achievements
        /// <summary>
        /// Achievements attainable by individual characters (or accounts)
        /// </summary>
        /// <returns>DataAchievementRoot object</returns>
        public async Task<DataAchievementRoot> GetAchievementsDataAsync()
        {
            var url = $"{Host}/wow/data/Character/Achievements?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataAchievementRoot>(url);
        }
        #endregion

        #region Battlegroup

        /// <summary>
        /// The battlegroups data API provides the list of battlegroups for this region
        /// </summary>
        /// <returns>DataBattleGroupRoot object</returns>
        public async Task<DataBattleGroupRoot> GetBattlegroupDataAsync()
        {
            var url = $"{Host}/wow/data/battlegroups/?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataBattleGroupRoot>(url);
        }

        #endregion

        #region Character classes
        /// <summary>
        /// The character classes data API provides a list of character classes.
        /// </summary>
        /// <returns>DataCharacterClassesRoot object</returns>
        public async Task<DataCharacterClassesRoot> GetClassDataAsync()
        {
            var url = $"{Host}/wow/data/character/classes?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataCharacterClassesRoot>(url);
        }
        #endregion

        #region Guild Achievements

        public async Task<DataGuildAchivementRoot> GetGuildAchievementDataAsync()
        {
            var url = $"{Host}/wow/data/guild/Achievements?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataGuildAchivementRoot>(url);
        }

        #endregion

        #region Guild Perks

        /// <summary>
        /// The guild perks data API provides a list of all guild perks.
        /// </summary>
        /// <returns>DataGuildPerksRoot object</returns>
        public async Task<DataGuildPerksRoot> GetGuildPerkDataAsync()
        {
            var url = $"{Host}/wow/data/guild/perks?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataGuildPerksRoot>(url);
        }
        #endregion

        #region Guild Rewards

        /// <summary>
        /// The guild rewards data API provides a list of all guild rewards.
        /// </summary>
        /// <returns>DataGuildRewardsRoot object</returns>
        public async Task<DataGuildRewardsRoot> GetGuildRewardDataAsync()
        {
            var url = $"{Host}/wow/data/guild/rewards?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataGuildRewardsRoot>(url);
        }

        #endregion

        #region Item classes

        /// <summary>
        /// The item classes data API provides a list of item classes 
        /// </summary>
        /// <returns>DataItemClassRoot object</returns>
        public async Task<DataItemClassRoot> GetItemClassDataAsync()
        {
            var url = $"{Host}/wow/data/item/classes?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataItemClassRoot>(url);
        }
        #endregion

        #region Pet Types

        /// <summary>
        /// The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns>DataPetTypesRoot object</returns>
        public async Task<DataPetTypesRoot> GetPetTypeDataAsync()
        {
            var url = $"{Host}/wow/data/pet/types?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataPetTypesRoot>(url);
        }
        #endregion

        #region Races
        /// <summary>
        /// The character races data API provides a list of each race and their associated faction, name, unique ID, and skin.
        /// </summary>
        /// <returns>DataRacesRoot object</returns>
        public async Task<DataRacesRoot> GetRaceDataAsync()
        {
            var url = $"{Host}/wow/data/character/races?locale={Locale}&apikey={APIKey}";
            return await this._jsonUtility.GetDataFromURLAsync<DataRacesRoot>(url);
        }

        #endregion

        #endregion

        #region Zone
        public async Task<ZoneRoot> GetZoneMasterListAsync()
        {
            var url = $"{Host}/wow/zone/?locale={Locale}&apikey={APIKey}";
            return await _jsonUtility.GetDataFromURLAsync<ZoneRoot>(url);
        }

        public async Task<Zone> GetZoneById(int id)
        {
            var url = $"{Host}/wow/zone/{id}?locale={Locale}&apikey={APIKey}";
            return await _jsonUtility.GetDataFromURLAsync<Zone>(url);
        }

        #endregion

        #region Mounts

        public async Task<MountRoot> GetMountMasterList()
        {
            var url = $"{Host}/wow/mount/?locale={Locale}&apikey={APIKey}";
            return await _jsonUtility.GetDataFromURLAsync<MountRoot>(url);
        }

        #endregion
    }
}
