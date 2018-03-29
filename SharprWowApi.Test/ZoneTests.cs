using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class ZoneTests
    {
        private WowClient _client;
        public ZoneTests()
        {
            _client = new WowClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);
        }

        [TestMethod]
        [TestCategory("Zone")]
        public async Task Get_Zone_Master_List()
        {
            var root = await _client.GetZoneMasterListAsync();

            foreach (var zone in root.Zones)
            {
                Assert.IsNotNull(zone);
                Assert.IsFalse(string.IsNullOrEmpty(zone.Name));
            }
        }

        [TestMethod]
        [TestCategory("Zone")]
        public async Task Get_Zone_By_Id()
        {
            var zone = await _client.GetZoneById(4131);
            Assert.IsNotNull(zone);
            Assert.IsFalse(string.IsNullOrEmpty(zone.Name));
        }
    }
}
