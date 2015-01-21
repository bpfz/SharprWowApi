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

/* use this for enum
 {
    "races": [{
        "achievementId": 1,
        "mask": 1,
        "side": "alliance",
        "name": "Human"
    }, {
        "achievementId": 1,
        "mask": 1,
        "side": "alliance",
        "name": "Human"
    }, {
        "achievementId": 2,
        "mask": 2,
        "side": "horde",
        "name": "Orc"
    }, {
        "achievementId": 2,
        "mask": 2,
        "side": "horde",
        "name": "Orc"
    }, {
        "achievementId": 3,
        "mask": 4,
        "side": "alliance",
        "name": "Dwarf"
    }, {
        "achievementId": 3,
        "mask": 4,
        "side": "alliance",
        "name": "Dwarf"
    }, {
        "achievementId": 4,
        "mask": 8,
        "side": "alliance",
        "name": "Night Elf"
    }, {
        "achievementId": 4,
        "mask": 8,
        "side": "alliance",
        "name": "Night Elf"
    }, {
        "achievementId": 5,
        "mask": 16,
        "side": "horde",
        "name": "Undead"
    }, {
        "achievementId": 5,
        "mask": 16,
        "side": "horde",
        "name": "Undead"
    }, {
        "achievementId": 6,
        "mask": 32,
        "side": "horde",
        "name": "Tauren"
    }, {
        "achievementId": 6,
        "mask": 32,
        "side": "horde",
        "name": "Tauren"
    }, {
        "achievementId": 7,
        "mask": 64,
        "side": "alliance",
        "name": "Gnome"
    }, {
        "achievementId": 7,
        "mask": 64,
        "side": "alliance",
        "name": "Gnome"
    }, {
        "achievementId": 8,
        "mask": 128,
        "side": "horde",
        "name": "Troll"
    }, {
        "achievementId": 8,
        "mask": 128,
        "side": "horde",
        "name": "Troll"
    }, {
        "achievementId": 9,
        "mask": 256,
        "side": "horde",
        "name": "Goblin"
    }, {
        "achievementId": 10,
        "mask": 512,
        "side": "horde",
        "name": "Blood Elf"
    }, {
        "achievementId": 11,
        "mask": 1024,
        "side": "alliance",
        "name": "Draenei"
    }, {
        "achievementId": 11,
        "mask": 1024,
        "side": "alliance",
        "name": "Draenei"
    }, {
        "achievementId": 22,
        "mask": 2097152,
        "side": "alliance",
        "name": "Worgen"
    }, {
        "achievementId": 24,
        "mask": 8388608,
        "side": "neutral",
        "name": "Pandaren"
    }, {
        "achievementId": 25,
        "mask": 16777216,
        "side": "alliance",
        "name": "Pandaren"
    }, {
        "achievementId": 26,
        "mask": 33554432,
        "side": "horde",
        "name": "Pandaren"
    }]
}*/