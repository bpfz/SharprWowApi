using SharprWowApi.Models.Achievement;
using SharprWowApi.Models.Auction;
using SharprWowApi.Models.BattlePet;
using SharprWowApi.Models.ChallengeMode;
using SharprWowApi.Models.Character;
using SharprWowApi.Models.DataResources;
using SharprWowApi.Models.Guild;
using SharprWowApi.Models.PVP;
using SharprWowApi.Models.Quest;
using SharprWowApi.Models.RealmStatus;
using SharprWowApi.Models.Recipe;
using SharprWowApi.Models.Spells;
using SharprWowApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi
{

    public class ApiClient : IApiClient
    {
        public Region _Region { get; set; }
        public Locale _Locale { get; set; }
        public string _APIKey { get; set; }
        public string _Host { get; set; }
        public string _Realm { get; set; }

        /// <summary>
        /// Explorer method for API init.
        /// </summary>
        /// <param name="region">The region, EU, KR, TW, CN or US. Use "_Region property".</param>
        /// <param name="locale">_Locale, en_gb, en_us etc. Use "_Locale" Property"</param>
        /// <param name="apiKey">Your API key (get one at dev.battle.net)</param>
        public ApiClient(Region region, Locale locale, string apiKey)
        {
            _Region = region;
            _Locale = locale;
            _APIKey = apiKey;

            switch (_Region)
            {
                case Region.EU:
                    _Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    _Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    _Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    _Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    _Host = "https://us.api.battle.net";
                    break;
            }
        }

        public ApiClient(Region region, Locale locale, string realm, string apiKey)
        {
            _Region = region;
            _Locale = locale;
            _APIKey = apiKey;
            _Realm = realm;

            switch (_Region)
            {
                case Region.EU:
                    _Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    _Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    _Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    _Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                    _Host = "https://us.api.battle.net";
                    break;
            }
        }

        //done
        #region achievement

        public async Task<AchievementRoot> GetAchievementAsync(int achievementId)
        {
            AchievementRoot achievement = new AchievementRoot();

            var url = string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}",
                _Host,
                achievementId,
                _Locale,
                _APIKey);

            achievement = await GetDataFromURLAsync<AchievementRoot>(url);

            return achievement;
        }

        public AchievementRoot GetAchievement(int achievementId)
        {
            AchievementRoot achievement = new AchievementRoot();

            var url = string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}",
                _Host,
                achievementId,
                _Locale,
                _APIKey);

            achievement = GetDataFromURL<AchievementRoot>(url);
            return achievement;
        }

        #endregion

        //needs testing
        #region Auctions

        public AuctionFilesRoot GetAuctionFile()
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            _Realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                _Realm,
                _Locale,
                _APIKey);

            auctionFiles = GetDataFromURL<AuctionFilesRoot>(url);
            return auctionFiles;
        }

        /// <summary>
        /// Use to get value of "lastmodified".
        /// </summary>
        /// <param name="realm"></param>
        /// <returns></returns>
        public AuctionFilesRoot GetAuctionFile(string realm)
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            auctionFiles = GetDataFromURL<AuctionFilesRoot>(url);
            return auctionFiles;
        }

        public AuctionsRoot GetAuctions()
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            _Realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                _Realm,
                _Locale,
                _APIKey);

            auctionFiles = GetDataFromURL<AuctionFilesRoot>(url);

            if (auctionFiles != null)
            {
                string auctionUrl = "";

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                AuctionsRoot auctions = new AuctionsRoot();

                auctions = GetDataFromURL<AuctionsRoot>(auctionUrl);

                return auctions;
            }

            return null;
        }

        public AuctionsRoot GetAuctions(string realm)
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            auctionFiles = GetDataFromURL<AuctionFilesRoot>(url);

            if (auctionFiles != null)
            {
                string auctionUrl = "";

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                AuctionsRoot auctions = new AuctionsRoot();

                auctions = GetDataFromURL<AuctionsRoot>(auctionUrl);

                return auctions;
            }

            return null;
        }

        /// <summary>
        /// Does not block main thread.
        /// </summary>
        /// <param name="realm"></param>
        /// <returns></returns>
        public async Task<AuctionsRoot> GetAuctionsAsync(string realm)
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            auctionFiles = await GetDataFromURLAsync<AuctionFilesRoot>(url);

            if (auctionFiles != null)
            {
                string auctionUrl = "";

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                AuctionsRoot auctions = new AuctionsRoot();

                auctions = await GetDataFromURLAsync<AuctionsRoot>(auctionUrl);

                return auctions;
            }
            return null;
        }

        /// <summary>
        /// Gets Realm from client, if that's used.
        /// </summary>
        /// <returns></returns>
        public async Task<AuctionsRoot> GetAuctionsAsync()
        {
            AuctionFilesRoot auctionFiles = new AuctionFilesRoot();
            _Realm.ToLower().Replace(' ', '-');

            string url = string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
                _Host,
                _Realm,
                _Locale,
                _APIKey);

            auctionFiles = await GetDataFromURLAsync<AuctionFilesRoot>(url);

            if (auctionFiles != null)
            {
                string auctionUrl = "";

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                AuctionsRoot auctions = new AuctionsRoot();

                auctions = await GetDataFromURLAsync<AuctionsRoot>(auctionUrl);

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
            BattlePetAbilitiesRoot battlePetAbility = new BattlePetAbilitiesRoot();

            var url = string.Format(@"{0}/wow/battlepet/ability/{1}?locale={2}&apikey={3}",
                _Host,
                abilityId,
                _Locale,
                _APIKey);

            battlePetAbility = GetDataFromURL<BattlePetAbilitiesRoot>(url);
            return battlePetAbility;
        }

        /// <summary>
        /// Get pet species from ID.
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns></returns>
        public BattlePetSpeciesRoot GetBattlePetSpecies(int speciesId)
        {
            BattlePetSpeciesRoot battlePetSpecies = new BattlePetSpeciesRoot();

            var url = string.Format(@"{0}/wow/battlepet/species/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetSpecies = GetDataFromURL<BattlePetSpeciesRoot>(url);
            return battlePetSpecies;
        }

        /// <summary>
        /// Get stats from species
        /// </summary>
        /// <param name="speciesId">Species ID</param>
        /// <returns></returns>
        public BattlePetStatsRoot GetBattlePetStats(int speciesId)
        {
            BattlePetStatsRoot battlePetStats = new BattlePetStatsRoot();

            var url = string.Format(@"{0}/wow/battlepet/Stats/{1}?locale={2}&apikey={3}",
                _Host,
                speciesId,
                _Locale,
                _APIKey);

            battlePetStats = GetDataFromURL<BattlePetStatsRoot>(url);
            return battlePetStats;
        }


        #endregion

        //Needs testing
        #region Challenge Mode

        /// <summary>
        /// Leaderboard for challenge mode on "realm"
        /// </summary>
        /// <param name="realm">realm to get CM leaderboard from</param>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboard(string realm)
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Uses realm from client.
        /// </summary>
        /// <returns></returns>
        public ChallengeRoot GetChallengeModeLeaderboard()
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                _Realm,
                _Locale,
                _APIKey);

            challenge = GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync(string realm)
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = await GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Uses realm from client.
        /// </summary>
        /// <returns></returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardAsync()
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}",
                _Host,
                _Realm,
                _Locale,
                _APIKey);

            challenge = await GetDataFromURLAsync<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboardForRegion()
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public async Task<ChallengeRoot> GetChallengeModeLeaderboardForRegionAsync()
        {
            ChallengeRoot challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = await GetDataFromURLAsync<ChallengeRoot>(url);

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
            CharacterRoot character = new CharacterRoot();

            string url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                _Realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = GetDataFromURL<CharacterRoot>(url);

            return character;
        }

        /// <summary>
        /// gets Character with CharacterOptions.None (plain character)
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public CharacterRoot GetCharacter(string realm, string name)
        {
            return GetCharacter(realm, name, CharacterOptions.None);
        }

        public CharacterRoot GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            CharacterRoot character = new CharacterRoot();

            string url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = GetDataFromURL<CharacterRoot>(url);

            return character;
        }

        public async Task<CharacterRoot> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions)
        {
            CharacterRoot character = new CharacterRoot();

            string url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = await GetDataFromURLAsync<CharacterRoot>(url);

            return character;
        }

        public async Task<CharacterRoot> GetCharacterAsync(string name, CharacterOptions characterOptions)
        {
            CharacterRoot character = new CharacterRoot();

            string url = string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                _Realm,
                name,
                _Locale,
                CharacterUtility.BuildOptionalFields(characterOptions),
                _APIKey);

            character = await GetDataFromURLAsync<CharacterRoot>(url);

            return character;
        }

        #endregion

        //Needs testing
        #region Guild

        /// <summary>
        /// Guild with Guildoptions.None
        /// </summary>
        /// <param name="realm"></param>
        /// <param name="name"></param>
        /// <returns>returns guildRoot</returns>
        public GuildRoot GetGuild(string realm, string name)
        {

            return GetGuild(realm, name, GuildOptions.None);
        }

        public GuildRoot GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            GuildRoot guild = new GuildRoot();
            string url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(realmOptions),
                _APIKey);

            guild = GetDataFromURL<GuildRoot>(url);

            return guild;
        }

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="realmOptions"></param>
        /// <returns></returns>
        public GuildRoot GetGuild(string name, GuildOptions realmOptions)
        {
            GuildRoot guild = new GuildRoot();
            string url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                _Realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(realmOptions),
                _APIKey);

            guild = GetDataFromURL<GuildRoot>(url);

            return guild;
        }

        public async Task<GuildRoot> GetGuildAsync(string realm, string name, GuildOptions realmOptions)
        {
            GuildRoot guild = new GuildRoot();
            string url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(realmOptions),
                _APIKey);

            guild = await GetDataFromURLAsync<GuildRoot>(url);

            return guild;
        }

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="realmOptions"></param>
        /// <returns></returns>
        public async Task<GuildRoot> GetGuildAsync(string name, GuildOptions realmOptions)
        {
            GuildRoot guild = new GuildRoot();
            string url = string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}",
                _Host,
                _Realm,
                name,
                _Locale,
                GuildUtility.BuildOptionalFields(realmOptions),
                _APIKey);

            guild = await GetDataFromURLAsync<GuildRoot>(url);

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
            LeaderboardRoot leaderboard = new LeaderboardRoot();

            string url = string.Format(@"{0}/wow/leaderboard/{1}?locale={2}&apikey={3}",
                _Host,
               LeaderboardUtility.buildOptionalQuery(leaderboardOptions),
               _Locale,
               _APIKey);

            leaderboard = GetDataFromURL<LeaderboardRoot>(url);

            return leaderboard;
        }

        public async Task<LeaderboardRoot> GetLeaderboardAsync(LeaderboardOptions leaderboardOptions)
        {
            LeaderboardRoot leaderboard = new LeaderboardRoot();

            string url = string.Format(@"{0}/wow/leaderboard/{1}?locale={2}&apikey={3}",
                _Host,
               LeaderboardUtility.buildOptionalQuery(leaderboardOptions),
               _Locale,
               _APIKey);

            leaderboard = await GetDataFromURLAsync<LeaderboardRoot>(url);

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
            QuestRoot quest = new QuestRoot();

            var url = string.Format(@"{0}/wow/quest/{1}?locale={2}&apikey={3}",
                _Host,
                questId,
                _Locale,
                _APIKey);

            quest = GetDataFromURL<QuestRoot>(url);
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
            RealmRoot realm = new RealmRoot();

            var url = string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            realm = GetDataFromURL<RealmRoot>(url);
            return realm;
        }

        #endregion

        //Needs testing
        #region Recipe

        public RecipeRoot GetRecipe(int recipeId)
        {
            RecipeRoot recipe = new RecipeRoot();

            var url = string.Format(@"{0}/wow/Recipe/{1}?locale={2}&apikey={3}",
                _Host,
                recipeId,
                _Locale,
                _APIKey);

            recipe = GetDataFromURL<RecipeRoot>(url);
            return recipe;
        }
        #endregion

        //Needs testing
        #region Spells
        public SpellRoot GetSpell(int spellId)
        {
            SpellRoot spell = new SpellRoot();

            var url = string.Format(@"{0}/wow/spell/{1}?locale={2}&apikey={3}",
                _Host,
                spellId,
                _Locale,
                _APIKey);

            spell = GetDataFromURL<SpellRoot>(url);
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
            DataAchievementRoot achievementsData = new DataAchievementRoot();

            var url = string.Format(@"{0}/wow/data/Character/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementsData = GetDataFromURL<DataAchievementRoot>(url);
            return achievementsData;
        }

        public async Task<DataAchievementRoot> GetAchievementsDataAsync()
        {
            DataAchievementRoot achievementsData = new DataAchievementRoot();

            var url = string.Format(@"{0}/wow/data/Character/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementsData = await GetDataFromURLAsync<DataAchievementRoot>(url);
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
            DataBattleGroupRoot battlegroupData = new DataBattleGroupRoot();

            var url = string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            battlegroupData = GetDataFromURL<DataBattleGroupRoot>(url);
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
            DataCharacterClassesRoot classData = new DataCharacterClassesRoot();

            var url = string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            classData = GetDataFromURL<DataCharacterClassesRoot>(url);
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
            DataGuildAchivementRoot achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = GetDataFromURL<DataGuildAchivementRoot>(url);
            return achievementData;
        }

        public async Task<DataGuildAchivementRoot> GetGuildAchievementDataAsync()
        {
            DataGuildAchivementRoot achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = await GetDataFromURLAsync<DataGuildAchivementRoot>(url);
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
            DataGuildPerksRoot guildPerksData = new DataGuildPerksRoot();

            var url = string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildPerksData = GetDataFromURL<DataGuildPerksRoot>(url);
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
            DataGuildRewardsRoot guildRewardsData = new DataGuildRewardsRoot();

            var url = string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            guildRewardsData = GetDataFromURL<DataGuildRewardsRoot>(url);
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
            DataItemClassRoot itemData = new DataItemClassRoot();

            var url = string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            itemData = GetDataFromURL<DataItemClassRoot>(url);
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
            DataPetTypesRoot petData = new DataPetTypesRoot();

            var url = string.Format(@"{0}/wow/data/pet/types?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            petData = GetDataFromURL<DataPetTypesRoot>(url);
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
            DataRacesRoot raceData = new DataRacesRoot();

            var url = string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            raceData = GetDataFromURL<DataRacesRoot>(url);
            return raceData;
        }

        #endregion

        #endregion


        private T GetDataFromURL<T>(string url) where T : class
        {
            var json = new JsonUtility();

            try
            {
                return json.JsonDeserialize<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURL");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<T> GetDataFromURLAsync<T>(string url) where T : class
        {
            var json = new JsonUtility();
            try
            {
                return await json.JsonDeserializeAsync<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURLAsync");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
