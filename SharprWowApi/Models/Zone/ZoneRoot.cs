using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.Zone
{
    public class ZoneRoot
    {
        public IEnumerable<Zone> Zones { get; set; }
    }
}
