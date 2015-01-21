using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataRacesRoot
    {
        public List<Race> races { get; set; }
    }
    public class Race
    {
        public int id { get; set; }
        public int mask { get; set; }
        public string side { get; set; }
        public string name { get; set; }
    }
}