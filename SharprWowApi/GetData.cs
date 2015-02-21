namespace SharprWowApi
{
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

    public abstract class GetData : GetDataBase
    {
        private JsonUtility json = new JsonUtility();

        //done
        #region achievement

        public AchievementRoot GetAchievement(int achievementId)
        {
            var achievement = new AchievementRoot();

            var url =
                string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}",
                _Host,
                achievementId,
                _Locale,
                _APIKey);

            achievement = json.GetDataFromURL<AchievementRoot>(url);
            return achievement;
        }

        #endregion

        //needs testing
        //Bug: Sometimes Unexpected character encountered while parsing value: <. Path '', line 0, position 0. 
        #region Auctions

        /// <summary>
        /// Realm from client
        /// </summary>
        /// <returns>AuctionFilesRoot object</returns>
        public AuctionFilesRoot GetAuctionFile()
        {
            return this.GetAuctionFile(_Realm);
        }

        /// <summary>
        /// Use to get value of last modified.
        /// </summary>
        /// <param name="realm">Realm of the auction house</param>
        /// <returns>AuctionFilesRoot object</returns>
        public AuctionFilesRoot GetAuctionFile(string realm)
        {
            var auctionFiles = new AuctionFilesRoot();
            realm.ToLower().Replace(' ', '-');

            var url = 
                string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}",
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
        ///<remarks>
        ///sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0.
        ///</remarks>
        /// <returns>AuctionsRoot object</returns>
        public AuctionsRoot GetAuctions()
        {
            return this.GetAuctions(_Realm);
        }

        /// <summary>
        /// 
        /// </summary>
        ///<remarks>
        /// sometimes Unexpected character encountered while parsing value: . Path '', line 0, position 0.
        /// </remarks>
        /// <param name="realm"></param>
        /// <returns>AuctionsRoot object</returns>
        public AuctionsRoot GetAuctions(string realm)
        {
            var auctionFiles = this.GetAuctionFile(realm); ;

            if (auctionFiles != null)
            {
                var auctions = new AuctionsRoot();
                var auctionUrl = string.Empty;

                foreach (var auctionFile in auctionFiles.Files)
                {
                    auctionUrl = auctionFile.Url;
                }

                auctions = json.GetDataFromURL<AuctionsRoot>(auctionUrl);

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
        /// <param name="abilityId">ID of the ability you want to retrieve</param>
        /// <returns>BattlePetAbilitiesRoot object</returns>
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
        /// <returns>BattlePetSpeciesRoot object</returns>
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
        /// <returns>BattlePetStatsRoot object</returns>
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
        /// Uses realm from ApiClient.
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboard()
        {
            return this.GetChallengeModeLeaderboard(_Realm);
        }

        /// <summary>
        /// Leaderboard for Challenge mode on "realm"
        /// </summary>
        /// <param name="realm">realm to get CM leaderboard from</param>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboard(string realm)
        {
            var challenge = new ChallengeRoot();

            string url = string.Format(@"{0}/wow/Challenge/{1}?locale={2}&apikey={3}",
                _Host,
                realm,
                _Locale,
                _APIKey);

            challenge = json.GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        /// <summary>
        /// Leaderboard for Challenge mode for region (_Locale)
        /// </summary>
        /// <returns>ChallengeRoot object</returns>
        public ChallengeRoot GetChallengeModeLeaderboardForRegion()
        {
            var challenge = new ChallengeRoot();

            var url = string.Format(@"{0}/wow/Challenge/region?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            challenge = json.GetDataFromURL<ChallengeRoot>(url);

            return challenge;
        }

        #endregion

        //done (could use more testing)
        #region Character

        /// <summary>
        /// Get character. Use this if you have set the realm in ApiClient.
        /// </summary>
        /// <param name="name">The Characters name</param>
        /// <param name="characterOptions">What characteroptions should be set (enum)</param>
        /// <returns>CharacterRoot object</returns>
        public CharacterRoot GetCharacter(string name, CharacterOptions characterOptions)
        {
            return this.GetCharacter(name, characterOptions, _Realm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The Characters name</param>
        /// <param name="characterOptions">What characteroptions should be set (enum)</param>
        /// <param name="realm"></param>
        /// <returns>CharacterRoot object</returns>
        public CharacterRoot GetCharacter(string name, CharacterOptions characterOptions, string realm)
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

        #endregion

        //Needs testing
        #region Guild

        /// <summary>
        /// Gets realm from client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="guildOptions"></param>
        /// <returns>GuildRoot object</returns>
        public GuildRoot GetGuild(string name, GuildOptions guildOptions)
        {
            return this.GetGuild(name, guildOptions, _Realm);
        }

        public GuildRoot GetGuild(string name, GuildOptions guildOptions, string realm)
        {
            var guild = new GuildRoot();
            var url = string.Format(@"{0}/wow/guild/{1}/{2}?{3}&locale={4}&apikey={5}",
                _Host,
                realm,
                name,
                GuildUtility.BuildOptionalFields(guildOptions),
                _Locale,
                _APIKey);

            guild = json.GetDataFromURL<GuildRoot>(url);

            return guild;
        }

        #endregion

        //Needs testing
        #region Items

        /// <summary>
        /// The item API provides detailed item information.
        /// This includes item set information if this item is part of a set.
        /// </summary>
        /// <param name="itemID">the id of the item</param>
        /// <returns>ItemRoot</returns>
        public ItemRoot GetItem(string itemID)
        {
            var item = new ItemRoot();

            var url = string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}",
                _Host,
                itemID,
                _Locale,
                _APIKey);

            item = json.GetDataFromURL<ItemRoot>(url);
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
        /// <returns>ItemSetRoot object</returns>
        public ItemSetRoot GetItemSet(string itemSetID)
        {
            var item = new ItemSetRoot();

            var url = string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}",
                _Host,
                itemSetID,
                _Locale,
                _APIKey);

            item = json.GetDataFromURL<ItemSetRoot>(url);
            return item;
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
               LeaderboardUtility.BuildOptionalQuery(leaderboardOptions),
               _Locale,
               _APIKey);

            leaderboard = json.GetDataFromURL<LeaderboardRoot>(url);

            return leaderboard;
        }

        #endregion

        //Needs testing
        #region Quest

        /// <summary>
        /// Get quest from questID
        /// </summary>
        /// <param name="questId">Quest ID</param>
        /// <returns>QuestRoot object</returns>
        public QuestRoot GetQuest(int questId)
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

        /// <summary>
        /// Gets recipe from recipeID
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>RecipeRoot object</returns>
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
        /// <summary>
        /// Gets spell from spellID
        /// </summary>
        /// <param name="spellId">The ID of the spell</param>
        /// <returns>SpellRoot object</returns>
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

        #endregion

        //needs testing
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
        #region Guild Achievements
        /// <summary>
        /// The guild Achievements data API provides a list of all of the Achievements 
        /// that guilds can earn as well as the category structure and hierarchy.
        /// </summary>
        /// <returns>DataGuildAchivementRoot object</returns>
        public DataGuildAchivementRoot GetGuildAchievementData()
        {
            var achievementData = new DataGuildAchivementRoot();

            var url = string.Format(@"{0}/wow/data/guild/Achievements?locale={1}&apikey={2}",
                _Host,
                _Locale,
                _APIKey);

            achievementData = json.GetDataFromURL<DataGuildAchivementRoot>(url);
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
        ///Gets the different battle pet types (including what they are strong and weak against)
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
        /// Gets The character races data, a list of each race and their associated faction, name, unique ID, and skin.
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
