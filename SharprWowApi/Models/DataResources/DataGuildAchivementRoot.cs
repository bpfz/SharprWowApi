using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{

    /// <summary>
    /// The guild achievements data API provides a list of all of the achievements that guilds can earn as well as the category structure and hierarchy.
    /// </summary>
    public class DataGuildAchivementRoot
    {
        /// <summary>
        /// The guild achievements data API provides a list of all of the achievements that guilds can earn as well as the category structure and hierarchy.
        /// </summary>
        public List<Achievement> achievements { get; set; }
    }
}
