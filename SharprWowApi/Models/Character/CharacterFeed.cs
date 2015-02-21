using System;
using SharprWowApi.Utility.ExtensionMethods;

namespace SharprWowApi.Models.Character
{
    public class CharacterFeed
    {
        /// <summary>
        /// Gets or sets type (looted, purchased, crafted etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets timestamp (Long number)
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets ID of the item
        /// </summary>
        public int ItemId { get; set; }

        public CharacterFeedAchievements Achievement { get; set; }

        /// <summary>
        /// Gets or Sets if it was a feat of strength
        /// </summary>
        public bool? FeatOfStrength { get; set; }

        public CharacterFeedAchievementCriteria Criteria { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gets Timestamp in date time format. 
        /// </summary>
        public DateTime DateTimestamp
        {
            get
            {
                return this.Timestamp.UnixTimestampToDateTime();
            }
        }
    }
}
