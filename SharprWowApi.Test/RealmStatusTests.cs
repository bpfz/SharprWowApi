using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class RealmStatusTests : TestBase
    {
        [TestMethod]
        [TestCategory("Realm")]
        public async Task Test_GetRealms()
        {
            var realms = await EuClient.GetRealmStatusAsync();

            Console.WriteLine("var listItems = new List<ListItem>{");
            foreach (var realm in realms.Realms)
            {
                if (realm.Locale.Equals("en_GB"))
                {
                    Console.WriteLine("new ListItem { Text =" + (char)34 + realm.Name + (char)34 + ", " + "Value=" + (char)34 + realm.Name + (char)34 + "},");
                }
            }
            Console.WriteLine("};");
        }
    }
}
