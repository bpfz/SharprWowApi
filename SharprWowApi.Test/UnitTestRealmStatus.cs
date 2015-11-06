using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestRealmStatus
    {
        [TestMethod]
        public void Test_GetRealms()
        {
            var client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);
            var realms = client.GetRealmStatus();

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
