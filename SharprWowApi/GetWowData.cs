using SharprWowApi.WowModels.Achievement;
using SharprWowApi.WowModels.Auction;
using SharprWowApi.WowModels.BattlePet;
using SharprWowApi.WowModels.ChallengeMode;
using SharprWowApi.WowModels.Character;
using SharprWowApi.WowModels.DataResources;
using SharprWowApi.WowModels.Guild;
using SharprWowApi.WowModels.PVP;
using SharprWowApi.WowModels.Quest;
using SharprWowApi.WowModels.RealmStatus;
using SharprWowApi.WowModels.Recipe;
using SharprWowApi.WowModels.Spells;
using SharprWowApi.Utility;
using System;
using System.Threading.Tasks;
using SharprWowApi.Utility;

namespace SharprWowApi
{
    public abstract class GetWowData
    {
        JsonUtility json = new JsonUtility();

        public Region _Region { get; internal set; }
        public Locale _Locale { get; internal set; }
        public string _APIKey { get; internal set; }
        public string _Host { get; internal set; }
        public string _Realm { get; internal set; }

        //done
        #region achievement

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

        public AchievementRoot GetAchievement(int achievementId)
        {
            var achievement = new AchievementRoot();

            var url = string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}",
                _Host,
                achievementId,
                _Locale,
                _APIKey);

            achievement = json.GetDataFromURL<AchievementRoot>(url);
            return achievement;
        }

        #endregion

        //needs testing
        #region Auctions

        /// <summary>
        /// Realm from client
        /// </summary>
        /// <returns>AuctionFilesRoot</returns>
        public AuctionFilesRoot GetAuctionFile()
        {
            return GetAuctionFile(_Realm);
        }

        /// <summary>
        /// Use to get value of "lastmodified".
        /// </summary>
        /// <param name="realm"></param>
        /// <returns></returns>
        public AuctionFilesRoot GetAuctionFile(string realm)
        {
            var auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            var url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            auctionFiles = json.GetDataFromURL<AuctionFilesRoot>(url);
            return auctionFiles;
        }

        /// <summary>
        /// Realm from client
        /// </summary>
        /// <returns>AuctionsRoot</returns>
        public AuctionsRoot GetAuctions()
        {
            return GetAuctions(_Realm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="realm"></param>
        /// <returns>AuctionsRoot</returns>
        public AuctionsRoot GetAuctions(string realm)
        {
            var auctionFiles = GetAuctionFile(realm); ;

            if (auctionFiles != null)
            {
                var auctions = new AuctionsRoot();
                var auctionUrl = "";

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                auctions = json.GetDataFromURL<AuctionsRoot>(auctionUrl);

                return auctions;
            }

            return null;
        }

        /// <summary>
        /// Gets Realm from client
        /// </summary>
        /// <returns>Task<AuctionsRoot></returns>
        public async Task<AuctionsRoot> GetAuctionsAsync()
        {
            return await GetAuctionsAsync(_Realm);
        }

        /// <summary>
        /// Does not block main thread.
        /// </summary>
        /// <param name="realm"></param>
        /// <returns>Task<AuctionsRoot></returns>
        public async Task<AuctionsRoot> GetAuctionsAsync(string realm)
        {
            var auctionFiles = GetAuctionFile(realm);

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

        //Needs testing
        #region BattlePet

        /// <summary>
        /// This provides data about a individual battle pet ability ID.
        /// </summary>
        /// <param name="achievementId">ID of the ability you want to retrieve</param>
        /// <returns></returns>
        public BattlePetAbilitiesRoot GetBattlePetAbilities(int abilityId)
        {
            var battlePetAbility = new BattlePetAbilitiesRoot();

            var url = string.Format(@"{0}/wow/battlepet/ability/{1}?locale={2}&apikey={3}",
                _Host,
                abilityId,
                _Locale,
                _APIKey);

            battlePetAbility = json.GetDataFromURL<BattlePetAbilitiesRoot>(url);
            return battlePetAbility;
        }

        /// <summary>
        /// Get pet species from ID.
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns></returns>
        public BattlePetSpeciesRoot GetBattlePetSpecies(int speciesId)
        {
            var battlePetSpecies = new BattlePetSpeciesRoot();

            var url = string.Format(@"{0}/wow/battlepet/species/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetSpecies = json.GetDataFromURL<BattlePetSpeciesRoot>(url);
            return battlePetSpecies;
        }

        /// <summary>
        /// Get stats from species
        /// </summary>
        /// <param name="speciesId">Species ID</param>
        /// <returns></returns>
        public BattlePetStatsRoot GetBattlePetStats(int speciesId)
        {
            var battlePetStats = new BattlePetStatsRoot();

            var url = string.Format(@"{0}/wow/battlepet/FollowerStats/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetStats = json.GetDataFromURL<BattlePetStatsRoot>(url);
            return battlePetStats;
        }


        #endregion

        //Needs testing
        #region Challenge Mode

        /// <summary>
        /// Uses realm from client.
        /// </summary>
        /// <returns></returns>
        public ChallengeRoot GetChallengeModeLeaderboard()
        {
            return GetChallengeModeLeaderboard(_Realm);
        }

        /// <summary>
        /// Leaderboard for challenge mode on "realm"
        /// </summary>
        /// <param name="realm">realm to get CM leaderboard from</param>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboard(string realm)
        {
            var challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = json.GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Uses realm from client.
        /// </summary>
        /// <returns></returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync()
        {
            return await GetChallengeModeLeaderboardAsync(_Realm);
        }

        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync(string realm)
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = await json.GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboardForRegion()
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = json.GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardForRegionAsync()
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = await json.GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }

        #endregion

        //done (could use more testing)
        #region Character

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="characterOptions"></param>
        /// <returns></returns>
        public CharacterRoot GetCharacter(string name, CharacterOptions characterOptions)
        {
            return GetCharacter(_Realm, name, characterOptions);
        }

        public CharacterRoot GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            var character = new CharacterRoot();

            var url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = json.GetDataFromURL<CharacterRoot>(url);

            return character;
        }

        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions)
        {
            return await GetCharacterAsync(_Realm, name, characterOptions);
        }

        public async Task<CharacterRoot> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions)
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

        //Needs testing
        #region Guild

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="guildOptions"></param>
        /// <returns></returns>
        public GuildRoot GetGuild(string name, GuildOptions guildOptions)
        {
            return GetGuild(_Realm, name, guildOptions);
        }

        public GuildRoot GetGuild(string realm, string name, GuildOptions guildOptions)
        {
            var guild = new GuildRoot();
            var url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(guildOptions),
                _APIKey);

            guild = json.GetDataFromURL<GuildRoot>(url);

            return guild;
        }

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="guildOptions"></param>
        /// <returns></returns>
        public async Task<GuildRoot> GetGuildAsync(string name, GuildOptions guildOptions)
        {
            return await GetGuildAsync(_Realm, name, guildOptions);
        }

        public async Task<GuildRoot> GetGuildAsync(string realm, string name, GuildOptions guildOptions)
        {
            var guild = new GuildRoot();
            var url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(guildOptions),
                _APIKey);

            guild = await json.GetDataFromURLAsync<GuildRoot>(url);

            return guild;
        }

        #endregion

        //Needs testing
        #region PVP

        /// <summary>
        /// Leaderboard for 2v2, 3v3, 5v5 or RBG
        /// </summary>
        /// <param name="leaderboardOptions">choose between 2v2, 3v3, 5v5 or RBG leaderboard</param>
        /// <returns>LeaderboardRoot object</returns>
        public LeaderboardRoot GetLeaderboard(LeaderboardOptions leaderboardOptions)
        {
            var leaderboard = new LeaderboardRoot();

            var url = string.Format(@"{0}/wow/leaderboard/{1}?locale={2}&apikey={3}",
                _Host,
               LeaderboardUtility.buildOptionalQuery(leaderboardOptions),
               _Locale,
               _APIKey);

            leaderboard = json.GetDataFromURL<LeaderboardRoot>(url);

            return leaderboard;
        }

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

        //Needs testing
        #region Quest

        /// <summary>
        /// Get quest from achievementId
        /// </summary>
        /// <param name="achievementId">Quest ID</param>
        /// <returns>QuestRoot object</returns>
        public QuestRoot getAchievement(int questId)
        {
            var quest = new QuestRoot();

            var url = string.Format(@"{0}/wow/quest/{1}?locale={2}&apikey={3}",
                _Host,
                questId,
                _Locale,
                _APIKey);

            quest = json.GetDataFromURL<QuestRoot>(url);
            return quest;
        }

        #endregion

        //Needs testing
        #region _Realm Status

        /// <summary>
        /// Gets status for realms in your _Locale
        /// </summary>
        /// <returns>RealmRoot object</returns>
        public RealmRoot GetRealmStatus()
        {
            var realm = new RealmRoot();

            var url = string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            realm = json.GetDataFromURL<RealmRoot>(url);
            return realm;
        }

        #endregion

        //Needs testing
        #region Recipe

        public RecipeRoot GetRecipe(int recipeId)
        {
            var recipe = new RecipeRoot();

            var url = string.Format(@"{0}/wow/Recipe/{1}?locale={2}&apikey={3}",
                _Host,
                recipeId,
                _Locale,
                _APIKey);

            recipe = json.GetDataFromURL<RecipeRoot>(url);
            return recipe;
        }

        #endregion

        //Needs testing
        #region Spells
        public SpellRoot GetSpell(int spellId)
        {
            var spell = new SpellRoot();

            var url = string.Format(@"{0}/wow/spell/{1}?locale={2}&apikey={3}",
                _Host,
                spellId,
                _Locale,
                _APIKey);

            spell = json.GetDataFromURL<SpellRoot>(url);
            return spell;
        }

        #endregion

        //needs testing
        #region Data Resources

        //needs testing
        #region Achievements

        /// <summary>
        /// Achievements attainable by individual characters (or accounts)
        /// </summary>
        /// <returns>DataAchievementRoot object</returns>
        public DataAchievementRoot GetAchievementsData()
        {
            var achievementsData = new DataAchievementRoot();

            var url = string.Format(@"{0}/wow/data/Character/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementsData = json.GetDataFromURL<DataAchievementRoot>(url);
            return achievementsData;
        }

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

        ///needs testing
        #region Battlegroup

        ///<summary>
        ///The battlegroups data API provides the list of battlegroups for this region
        /// </summary>
        /// <returns>DataBattleGroupRoot object</returns>
        public DataBattleGroupRoot GetBattlegroupData()
        {
            var battlegroupData = new DataBattleGroupRoot();

            var url = string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            battlegroupData = json.GetDataFromURL<DataBattleGroupRoot>(url);
            return battlegroupData;
        }
        #endregion

        //needs testing
        #region Character classes
        /// <summary>
        /// The character classes data API provides a list of character classes.
        /// </summary>
        /// <returns>DataCharacterClassesRoot object</returns>
        public DataCharacterClassesRoot GetClassData()
        {
            var classData = new DataCharacterClassesRoot();

            var url = string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            classData = json.GetDataFromURL<DataCharacterClassesRoot>(url);
            return classData;
        }
        #endregion

        //needs testing
        #region Guild Achivements
        /// <summary>
        /// The guild achievements data API provides a list of all of the achievements 
        /// that guilds can earn as well as the category structure and hierarchy.
        /// </summary>
        /// <returns>DataGuildAchivementRoot object</returns>
        public DataGuildAchivementRoot GetGuildAchievementData()
        {
            var achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = json.GetDataFromURL<DataGuildAchivementRoot>(url);
            return achievementData;
        }

        public async Task<DataGuildAchivementRoot> GetGuildAchievementDataAsync()
        {
            var achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = await json.GetDataFromURLAsync<DataGuildAchivementRoot>(url);
            return achievementData;
        }
        #endregion

        //needs testing
        #region Guild Perks

        /// <summary>
        ///The guild perks data API provides a list of all guild perks.
        /// </summary>
        /// <returns>DataGuildPerksRoot object</returns>
        public DataGuildPerksRoot GetGuildPerkData()
        {
            var guildPerksData = new DataGuildPerksRoot();

            var url = string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildPerksData = json.GetDataFromURL<DataGuildPerksRoot>(url);
            return guildPerksData;
        }
        #endregion

        //needs testing
        #region Guild Rewards

        /// <summary>
        ///The guild rewards data API provides a list of all guild rewards.
        /// </summary>
        /// <returns>DataGuildRewardsRoot object</returns>
        public DataGuildRewardsRoot GetGuildRewardData()
        {
            var guildRewardsData = new DataGuildRewardsRoot();

            var url = string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildRewardsData = json.GetDataFromURL<DataGuildRewardsRoot>(url);
            return guildRewardsData;
        }

        #endregion

        //needs testing
        #region Item classes

        /// <summary>
        ///The item classes data API provides a list of item classes 
        /// </summary>
        /// <returns>DataItemClassRoot object</returns>
        public DataItemClassRoot GetItemClassData()
        {
            var itemData = new DataItemClassRoot();

            var url = string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            itemData = json.GetDataFromURL<DataItemClassRoot>(url);
            return itemData;
        }
        #endregion

        //needs testing
        #region Pet Types

        /// <summary>
        ///The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns>DataPetTypesRoot object</returns>
        public DataPetTypesRoot GetPetTypeData()
        {
            var petData = new DataPetTypesRoot();

            var url = string.Format(@"{0}/wow/data/pet/types?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            petData = json.GetDataFromURL<DataPetTypesRoot>(url);
            return petData;
        }
        #endregion

        //needs testing
        #region Races
        /// <summary>
        /// The character races data API provides a list of each race and their associated faction, name, unique ID, and skin.
        /// </summary>
        /// <returns>DataRacesRoot object</returns>
        public DataRacesRoot GetRaceData()
        {
            var raceData = new DataRacesRoot();

            var url = string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            raceData = json.GetDataFromURL<DataRacesRoot>(url);
            return raceData;
        }

        #endregion

        #endregion


    }
}
