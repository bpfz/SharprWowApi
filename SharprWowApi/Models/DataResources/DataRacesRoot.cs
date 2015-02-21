using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataRacesRoot
    {
        public IEnumerable<Race> Races { get; set; }
    }

    public class Race
    {
        public int Id { get; set; }

        public int Mask { get; set; }

        public string Side { get; set; }

        public string Name { get; set; }
    }
}