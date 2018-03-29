using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SharprWowApi.Models.Character;
using System.Linq;
using System.Threading;
namespace SharprWowApi.Test
{
    [TestClass]
    public class GuildTests : TestBase
    {
        //get all members, get character based on member.character.name save to csv file?
        [TestMethod]
        [TestCategory("Guild")]
        public async Task Test_Guild_Root()
        {
            var options = GuildOptions.Members | GuildOptions.Challenge;
            Console.WriteLine(options);
            var guild = await EuClient.GetGuildAsync("Dress code purple", options, TestConstants.EU_en_GB_Realm);

            foreach (var member in guild.Members)
            {
                Assert.IsNotNull(member.Character.Name);
                Console.WriteLine(member.Character.Name);
            }

            Assert.IsNotNull(guild.LastModified);
            Assert.IsNotNull(guild.Challenge);

            var guild2 = await EuClient.GetGuildAsync("Dress code purple", GuildOptions.None, TestConstants.EU_en_GB_Realm);
            Assert.IsNotNull(guild.AchievementPoints);


        }

        [TestMethod]
        [TestCategory("Guild")]
        public async Task Test_Guild_Everything()
        {
            var options = GuildOptions.AllOptions;
            Console.WriteLine(options);

            var guild = await EuClient.GetGuildAsync("Dress code purple", options, TestConstants.EU_en_GB_Realm);

            foreach (var member in guild.Members)
            {
                Assert.IsNotNull(member.Character.Name);
                Console.WriteLine(member.Character.Name);
            }

            Assert.IsNotNull(guild.Challenge);
            Assert.IsNotNull(guild.News);

            Assert.IsNotNull(guild.LastModified);
            Assert.IsNotNull(guild.Challenge);

            var guild2 = await EuClient.GetGuildAsync("Dress code purple", GuildOptions.None, TestConstants.EU_en_GB_Realm);
            Assert.IsNotNull(guild.AchievementPoints);


        }

        //requires new guild to test against [TestMethod]
        public async Task Test_GetCharacter_FromGuildMembers()
        {
            var client = new WowClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);
            //realm in getGuildAsync does not work (404 not found), why? setting realm in apiclient constructor works.
            var guild = await client.GetGuildAsync("method", GuildOptions.Members, "Twisting Nether");

            Assert.IsNotNull(guild);

            Stopwatch s1 = new Stopwatch();

            s1.Start();
            int iteration = 0;
            var charc = await
                client.GetCharactersInGuildAsync(guild.Members, CharacterOptions.AllOptions, 100, 60);

            foreach (var c in charc)
            {
                iteration++;

                Console.WriteLine("Iteration Nr: " + iteration + " ------------------------------");
                Console.WriteLine("Name: " + c.Name
                    + "\nAchivement points: " + c.AchievementPoints
                    + "\nLevel: " + c.Level);
                Console.WriteLine("----------------------------------------------");

            }

            Console.WriteLine("Asynchronous time: " + s1.Elapsed.TotalSeconds + " sec");
            s1.Stop();
        }

        //needs new guild, this is  moved/inactive or something [TestMethod]
        public async Task Test_GetCharacters_FromGuildMembersHashSet()
        {
            var client = new WowClient(Region.EU, Locale.en_GB, TestConstants.ApiKey, "Twisting Nether");
            //var guild = await client.GetGuildAsync("dress code purple", GuildOptions.Members);

            //var client = new ApiClientAsync(_Region.EU, _Locale.en_GB, TestConstants.ApiKey, "grim batol");
            //var guild = await client.GetGuildAsync("dress code purple", GuildOptions.Members);


            string[] dcp = { "Miizumi", "Athènâ", "Basiun", "Xploz", "Snoogypoo", "Mizlol",
                                 "Duridpls", "Pórtello", "Hjortronsmak", "Hjortronsylt", "Lingonberry",
                                 "Nekja", "Schweinhynd", "Restaurante", "ßäcon", "Lindelof", "Meekz",
                                 "Fantasmak", "Tyiriel", "Cermonia", "Aarturius", "Cazsi", "Risrina",
                                 "Swegirl", "Kikhosta", "Drunco", "Kradashian", "Smiskamig", "Jensnn",
                                 "Góranpersson", "Bluebearý", "Lilgitler", "Galavien", "Dakniel", "Tacoslam",
                                 "Burritoheal", "Forrko", "Xzy", "Tinuvíel", "Amida", "Saltmustasch", "Catchlife",
                                 "Skeyro", "Creak", "Vulkyra", "Quirk", "Funkalistic", "Kappabobqt", "Pinglan",
                                 "Turbotomte", "Ourqt", "Elementpimp", "Ostpajen", "Skalta", "Bearmister", "Tturbotomte",
                                 "Spaceshipman", "Turbotanten", "Siljaline", "Littlewing", "Siljaa", "Höken",
                                 "Tturbotanten", "Missgutt", "Zeachi", "Hartis",  };



            string[] method = {"Aris", "Maleficarium", "Isheriia", "Rogeritsa", "Rogerakos", "Saabok",
            "Faerko", "Justtwo", "Justnita", "Justpaladin", "Kuzfour", "Zammy",
            "Nxe", "Noxe", "Monstermunch", "Magulina", "Pactjesaurus", "Blattardos",
            "Blattard", "Masouka", "Gaiã", "Lambroukos", "Warcried", "Justsham",
            "Blattos", "Isheria", "Bellise", "Razielakooze", "Fragmage", "Smootiekin",
            "Fluffyroger", "Oliviawilde", "Noxo", "Finalpandasy", "Tryhardlund", "Isherya",
            "Zaabok", "Tbagin", "Finshmstr", "Fragdekay", "Treckye", "Lørglock", "Noxbustion",
            "Blattchi", "Kreps", "Åladya", "Sparkgg"};


            /*var methodNames = client.GetGuildMembers(guild, 90);
            Console.WriteLine(methodNames);
            Console.WriteLine(methodNames.Length);
            */
            Console.WriteLine("Parsing: " + method.Length + "objects ");

            Stopwatch s1 = new Stopwatch();
            s1.Start();
            var mA2 = await client.GetCharactersInGuildAsync(method, CharacterOptions.None);
            s1.Stop();
            Console.WriteLine("mA2: " + s1.ElapsedMilliseconds + " ms");

            Thread.Sleep(2000);


            /*
            foreach (var c in mA2)
            {
                iteration++;

                Console.WriteLine("Iteration Nr: " + iteration + " ------------------------------");
                Console.WriteLine("Name: " + c.Name
                    + "\nAchivement points: " + c.AchievementPoints
                    + "\nLevel: " + c.Level);
                Console.WriteLine("----------------------------------------------");

            }*/
        }
    }
}

