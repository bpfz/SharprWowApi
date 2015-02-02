using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.Hero
{
    public class Skills
    {
        public List<Active> Active { get; set; }
        public List<Passive> Passive { get; set; }
    }

    public class Active
    {
        public ActiveSkill Skill { get; set; }
        public Rune Rune { get; set; }
    }

    public class Passive
    {
        public PassiveSkill Skill { get; set; }
    }

    public class ActiveSkill
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
        public string CategorySlug { get; set; }
        public string TooltipUrl { get; set; }
        public string Description { get; set; }
        public string SimpleDescription { get; set; }
        public string SkillCalcId { get; set; }
    }

    public class Rune
    {
        public string Slug { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string SimpleDescription { get; set; }
        public string TooltipParams { get; set; }
        public string SkillCalcId { get; set; }
        public int Order { get; set; }
    }

    public class PassiveSkill
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int level { get; set; }
        public string tooltipUrl { get; set; }
        public string description { get; set; }
        public string flavor { get; set; }
        public string skillCalcId { get; set; }
    }


}
