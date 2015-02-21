using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataCharacterClassesRoot
    {
        public IEnumerable<DataCharacterClass> Classes { get; set; }
    }
}