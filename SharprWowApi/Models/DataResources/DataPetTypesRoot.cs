using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Models.DataResources
{
    public class DataPetTypesRoot
    {
        public IEnumerable<PetType> PetTypes { get; set; }
    }

    public class PetType
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public int TypeAbilityId { get; set; }

        public int StrongAgainstId { get; set; }

        public int WeakAgainstId { get; set; }
    }
}
