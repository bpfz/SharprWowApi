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
using SharprWowApi.Utility;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SharprWowApi
{
    public abstract class GetDataAsync : GetDataBase
    {
        private JsonUtility json = new JsonUtility();

        #region Achievement
        public async Task<AchievementRoot> GetAchievementAsync(int achievementId)
        {
            var achievement = new AchievementRoot();

            var url = string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}",
                _Host,
                achievementId,
                _Locale,
                _APIKey);

            achievement = await json.GetDataFromURLAsync<AchievementRoot>(url);

            return achievement;
        }
        #endregion

        #region auctions
        public async Task<AuctionFilesRoot> GetAuctionFileAsync()
        {
            return await GetAuctionFileAsync(_Realm);
        }

        public async Task<AuctionFilesRoot> GetAuctionFileAsync(string realm)
        {
            var auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            var url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            auctionFiles = await json.GetDataFromURLAsync<AuctionFilesRoot>(url);
            return auctionFiles;
        }
        /// <summary>
        /// Does not block main thread.
        /// Gets Realm from client
        /// </summary>
        ///<remarks>
        ///sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0.
        ///</remarks>
        /// <returns>AuctionsRoot</returns>
        public async Task<AuctionsRoot> GetAuctionsAsync()
        {
            return await GetAuctionsAsync(_Realm);
        }

        /// <summary>
        /// Does not block main thread.
        /// </summary>
        ///<remarks>
        ///sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0.
        ///</remarks>
        /// <param name="realm"></param>
        /// <returns>AuctionsRoot</returns>
        public async Task<AuctionsRoot> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await GetAuctionFileAsync(realm);

            if (auctionFiles != null)
            {
                var auctionUrl = "";
                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                var auctions = new AuctionsRoot();
                auctions = await json.GetDataFromURLAsync<AuctionsRoot>(auctionUrl);

                return auctions;
            }
            return null;
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
            var battlePetAbility = new BattlePetAbilitiesRoot();

            var url = string.Format(@"{0}/wow/battlepet/ability/{1}?locale={2}&apikey={3}",
                _Host,
                abilityId,
                _Locale,
                _APIKey);

            battlePetAbility = await json.GetDataFromURLAsync<BattlePetAbilitiesRoot>(url);
            return battlePetAbility;
        }

        /// <summary>
        /// Get pet species from ID.
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns>BattlePetSpeciesRoot object</returns>
        public async Task<BattlePetSpeciesRoot> GetBattlePetSpeciesAsync(int speciesId)
        {
            var battlePetSpecies = new BattlePetSpeciesRoot();

            var url = string.Format(@"{0}/wow/battlepet/species/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetSpecies = await json.GetDataFromURLAsync<BattlePetSpeciesRoot>(url);
            return battlePetSpecies;
        }

        /// <summary>
        /// Get stats from species
        /// </summary>
        /// <param name="speciesId">Species ID</param>
        /// <returns>BattlePetStatsRoot object</returns>
        public async Task<BattlePetStatsRoot> GetBattlePetStatsAsync(int speciesId)
        {
            var battlePetStats = new BattlePetStatsRoot();

            var url = string.Format(@"{0}/wow/battlepet/FollowerStats/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetStats = await json.GetDataFromURLAsync<BattlePetStatsRoot>(url);
            return battlePetStats;
        }

        #endregion

        #region challenge

        /// <summary>
        /// Uses realm from apiclient.
        /// </summary>
        /// <returns></returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync()
        {
            return await GetChallengeModeLeaderboardAsync(_Realm);
        }

        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync(string realm)
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/Challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = await json.GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for Challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardForRegionAsync()
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/Challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = await json.GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }
        #endregion

        #region character
        /// <summary>
        /// Get character. Use this if you have set the realm in ApiClient.
        /// </summary>
        /// <param name="name">The Characters name</param>
        /// <param name="characterOptions">What characteroptions should be set (enum)</param>
        /// <returns>CharacterRoot object</returns>
        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions)
        {
            return await GetCharacterAsync(name, characterOptions, _Realm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The Characters name</param>
        /// <param name="characterOptions">What characteroptions should be set (enum)</param>
        /// <param name="realm"></param>
        /// <returns>CharacterRoot object</returns>
        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions, string realm)
        {
            var character = new CharacterRoot();

            var url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = await json.GetDataFromURLAsync<CharacterRoot>(url);

            return character;
        }

        #endregion

        #region GetGuildCharactersAsync
        /// <summary>
        /// Creates a list with CharacterRoot for every member in given guild.
        /// To avoid calling the wow api more than 100 times per second, this method limits the list of guildmembers to int take.
        /// Adds delay on the task if members are over 95, and 280 (0.5s each).
        /// </summary>
        /// <param name="guildMembers">List with guildmembers</param>
        /// <param name="characterOptions">Options for CharacterRoot</param>
        /// <param name="levelThreshold">Take only members above or equal to this integer</param>
        /// <param name="membersToTake">How many members should be returned (mind the 100 calls per second cap)</param>
        /// <returns>List filled with characterRoot</returns>
        public async Task<List<CharacterRoot>> GetAllCharactersInGuildAsync(IEnumerable<GuildMember> guildMembers,
            CharacterOptions characterOptions,
            int levelThreshold, int membersToTake)
        {
            //var guild = GetGuild(guildName, GuildOptions.Members, _Realm);
            var characterList = new List<CharacterRoot>();

            var order = from guildMemberLevel in guildMembers
                        orderby guildMemberLevel.Character.Level descending
                        select guildMemberLevel;

            var downloadTasksQuery = from member in order.Take(membersToTake)
                                     where member.Character.Level >= levelThreshold
                                     select GetCharacterAsync(member.Character.Name,
                                     characterOptions,
                                     _Realm);

            var downloadTasks = downloadTasksQuery.ToList();

            while (downloadTasks.Count > 0)
            {
                if (downloadTasks.Count.Equals(95))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                if (downloadTasks.Count.Equals(280))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                var finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                var character = await finishedTask;
                characterList.Add(character);
            }

            return characterList;
        }

        public async Task<HashSet<CharacterRoot>> GetAllCharactersInGuildAsync(string[] guildMembers,
         CharacterOptions characterOptions)
        {
            var memberHash = new HashSet<string>(guildMembers);
            var characterHash = new HashSet<CharacterRoot>();
            //Task<CharacterRoot> character;

            var downloadTasks = new HashSet<Task<CharacterRoot>>();


            for (int i = 0; i < memberHash.Count; i++)
            {
                if (i.Equals(95))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                if (i.Equals(180))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                if (i.Equals(275))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                if (i.Equals(370))
                    await Task.Delay(System.TimeSpan.FromMilliseconds(500));

                downloadTasks.Add(GetCharacterAsync(memberHash.ElementAt(i), characterOptions, _Realm));

            }

            while (downloadTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                var finished = await finishedTask;
                characterHash.Add(finished);
            }
            return characterHash;
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
            return await GetGuildAsync(name, guildOptions, _Realm);
        }

        public async Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions, string realm)
        {
            var guild = new GuildRoot();
            var url = string.Format(@"{0}/wow/guild/{1}/{2}?{3}&locale={4}&apikey={5}",
                _Host,
                realm,
                name,
                GuildUtility.BuildOptionalFields(guildOptions),
                _Locale,
                _APIKey);

            guild = await json.GetDataFromURLAsync<GuildRoot>(url);

            return guild;
        }

        /// <summary>
        /// Gets all members in a guild above a set level threshold (>=) and adds them to a string that can be inserted into an array (manually).
        /// Useful for doing fast (big) queries with GetAllCharactersInGuildAsync.
        /// </summary>
        /// <example>returns: {"name", "name2", "name3"};</example>
        /// <param name="guildmembers">The guild you want to get members from.</param>
        /// <param name="lvlThreshold">Gets all characters above or at this level.</param>
        /// <returns>returns string[] with the names of all guildmembers over lvlThreshold (>=).</returns>
        public string GetGuildMembers(GuildRoot guildmembers, int lvlThreshold)
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
        /// <param name="itemID">the id of the item</param>
        /// <returns>ItemRoot</returns>
        public async Task<ItemRoot> GetItemAsync(string itemID)
        {
            var item = new ItemRoot();

            var url = string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}",
                _Host,
                itemID,
                _Locale,
                _APIKey);

            item = await json.GetDataFromURLAsync<ItemRoot>(url);
            return item;
        }

        /// <summary>
        /// This data can also be found using GetItem if the item is part of a set. 
        /// </summary>
        /// <example>
        /// You can use this if you already know the set ID, ie 1060. 
        /// Can be a good choice if you don't need all stats for each item that you would get from the GetItem method.
        /// </example>
        /// <param name="itemSetID"></param>
        /// <returns></returns>
        public async Task<ItemSetRoot> GetItemSet(string itemSetID)
        {
            var item = new ItemSetRoot();

            var url = string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}",
                _Host,
                itemSetID,
                _Locale,
                _APIKey);

            item = await json.GetDataFromURLAsync<ItemSetRoot>(url);
            return item;
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
            var leaderboard = new LeaderboardRoot();

            var url = string.Format(@"{0}/wow/leaderboard/{1}?locale={2}&apikey={3}",
                _Host,
               LeaderboardUtility.buildOptionalQuery(leaderboardOptions),
               _Locale,
               _APIKey);

            leaderboard = await json.GetDataFromURLAsync<LeaderboardRoot>(url);

            return leaderboard;
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
            var quest = new QuestRoot();

            var url = string.Format(@"{0}/wow/quest/{1}?locale={2}&apikey={3}",
                _Host,
                questId,
                _Locale,
                _APIKey);

            quest = await json.GetDataFromURLAsync<QuestRoot>(url);
            return quest;
        }

        #endregion

        #region Recipe

        public async Task<RecipeRoot> GetRecipeAsync(int recipeId)
        {
            var recipe = new RecipeRoot();

            var url = string.Format(@"{0}/wow/Recipe/{1}?locale={2}&apikey={3}",
                _Host,
                recipeId,
                _Locale,
                _APIKey);

            recipe = await json.GetDataFromURLAsync<RecipeRoot>(url);
            return recipe;
        }

        #endregion

        #region _Realm Status

        /// <summary>
        /// Gets status for realms in your _Locale (EU, US etc.)
        /// </summary>
        /// <returns>RealmRoot object</returns>
        public async Task<RealmRoot> GetRealmStatusAsync()
        {
            var realm = new RealmRoot();

            var url = string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            realm = await json.GetDataFromURLAsync<RealmRoot>(url);
            return realm;
        }

        #endregion

        #region Spells
        public async Task<SpellRoot> GetSpellAsync(int spellId)
        {
            var spell = new SpellRoot();

            var url = string.Format(@"{0}/wow/spell/{1}?locale={2}&apikey={3}",
                _Host,
                spellId,
                _Locale,
                _APIKey);

            spell = await json.GetDataFromURLAsync<SpellRoot>(url);
            return spell;
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
            var achievementsData = new DataAchievementRoot();

            var url = string.Format(@"{0}/wow/data/Character/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementsData = await json.GetDataFromURLAsync<DataAchievementRoot>(url);
            return achievementsData;
        }
        #endregion

        #region Battlegroup

        ///<summary>
        ///The battlegroups data API provides the list of battlegroups for this region
        /// </summary>
        /// <returns>DataBattleGroupRoot object</returns>
        public async Task<DataBattleGroupRoot> GetBattlegroupDataAsync()
        {
            var battlegroupData = new DataBattleGroupRoot();

            var url = string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            battlegroupData = await json.GetDataFromURLAsync<DataBattleGroupRoot>(url);
            return battlegroupData;
        }

        #endregion

        #region Character classes
        /// <summary>
        /// The character classes data API provides a list of character classes.
        /// </summary>
        /// <returns>DataCharacterClassesRoot object</returns>
        public async Task<DataCharacterClassesRoot> GetClassDataAsync()
        {
            var classData = new DataCharacterClassesRoot();

            var url = string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            classData = await json.GetDataFromURLAsync<DataCharacterClassesRoot>(url);
            return classData;
        }
        #endregion

        #region Guild Achievements

        public async Task<DataGuildAchivementRoot> GetGuildAchievementDataAsync()
        {
            var achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = await json.GetDataFromURLAsync<DataGuildAchivementRoot>(url);
            return achievementData;
        }

        #endregion

        #region Guild Perks

        /// <summary>
        ///The guild perks data API provides a list of all guild perks.
        /// </summary>
        /// <returns>DataGuildPerksRoot object</returns>
        public async Task<DataGuildPerksRoot> GetGuildPerkDataAsync()
        {
            var guildPerksData = new DataGuildPerksRoot();

            var url = string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildPerksData = await json.GetDataFromURLAsync<DataGuildPerksRoot>(url);
            return guildPerksData;
        }
        #endregion

        #region Guild Rewards

        /// <summary>
        ///The guild rewards data API provides a list of all guild rewards.
        /// </summary>
        /// <returns>DataGuildRewardsRoot object</returns>
        public async Task<DataGuildRewardsRoot> GetGuildRewardDataAsync()
        {
            var guildRewardsData = new DataGuildRewardsRoot();

            var url = string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildRewardsData = await json.GetDataFromURLAsync<DataGuildRewardsRoot>(url);
            return guildRewardsData;
        }

        #endregion

        #region Item classes

        /// <summary>
        ///The item classes data API provides a list of item classes 
        /// </summary>
        /// <returns>DataItemClassRoot object</returns>
        public async Task<DataItemClassRoot> GetItemClassDataAsync()
        {
            var itemData = new DataItemClassRoot();

            var url = string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            itemData = await json.GetDataFromURLAsync<DataItemClassRoot>(url);
            return itemData;
        }
        #endregion

        #region Pet Types

        /// <summary>
        ///The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns>DataPetTypesRoot object</returns>
        public async Task<DataPetTypesRoot> GetPetTypeDataAsync()
        {
            var petData = new DataPetTypesRoot();

            var url = string.Format(@"{0}/wow/data/pet/types?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            petData = await json.GetDataFromURLAsync<DataPetTypesRoot>(url);
            return petData;
        }
        #endregion

        #region Races
        /// <summary>
        /// The character races data API provides a list of each race and their associated faction, name, unique ID, and skin.
        /// </summary>
        /// <returns>DataRacesRoot object</returns>
        public async Task<DataRacesRoot> GetRaceDataAsync()
        {
            var raceData = new DataRacesRoot();

            var url = string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            raceData = await json.GetDataFromURLAsync<DataRacesRoot>(url);
            return raceData;
        }

        #endregion

        #endregion
    }
}
