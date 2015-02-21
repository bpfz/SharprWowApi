using System;
using SharprWowApi.Utility.ExtensionMethods;

namespace SharprWowApi.Models.Guild
{
    public class GuildNews
    {
        public string Type { get; set; }

        public string Character { get; set; }

        /// <summary>
        /// Gets or Sets Unix timestamp (long number)
        /// </summary>
        public long Timestamp { get; set; }

        public int ItemId { get; set; }

        public GuildAchievement Achievement { get; set; }

        /// <summary>
        /// gets Timestamp in date time format. 
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
