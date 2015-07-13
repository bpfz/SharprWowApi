using System;
namespace SharprWowApi.Models.RealmStatus
{
    public class PvpZone
    {
        /// <summary>
        /// Internal achievementId of the zone
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// 0: Alliance, 1: Horde, 2: Neutral
        /// </summary>
        public int ControllingFaction { get; set; }

        /// <summary>
        /// -1:Unknown, 0:Idle, 1:Populating, 2: Active, 3:Concluded
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// timestamp of when next battle starts
        /// </summary>
        public object Next { get; set; }

        /// <summary>
        /// Gets the name of the faction for the controlling faction (Alliance, Horde)
        /// </summary>
        public WoWFaction ControllingFactionString
        {
            get
            {
                return (WoWFaction)Enum.Parse(typeof(WoWFaction), Enum.GetName(typeof(WoWFaction), this.ControllingFaction));
            }
        }
    }
}
