using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class Progression
    {
        public Act Act1 { get; set; }
        public Act Act2 { get; set; }
        public Act Act3 { get; set; }
        public Act Act4 { get; set; }
        public Act Act5 { get; set; }
    }
    public class Act
    {
        public bool completed { get; set; }
        public List<CompletedQuest> completedQuests { get; set; }
    }
    public class CompletedQuest
    {
        public string slug { get; set; }
        public string name { get; set; }
    }
}
